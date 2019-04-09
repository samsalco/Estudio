using EPS.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EPS.Common.Writes
{
    /// <summary>
    /// Escrituras protocolo
    /// </summary>
    public static class ProtocolWrites
    {
        /// <summary>
        /// Adicionar protocolo
        /// </summary>
        /// <param name="request"></param>
        /// <param name="provider"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static RequestResponse<int> AddProtocol(ProtocolRequest request, string provider, string connectionString)
        {
            try
            {
                List<Tuple<int, string>> orderSavedList = new List<Tuple<int, string>>();
                RequestResponse<int> saveResponse = new RequestResponse<int>();

                IOrder order = null;

                ///1, Guardar las actividades relacionadas al protocolo
                foreach (var item in request.Protocols)
                {
                    saveResponse = new RequestResponse<int>();
                    switch (item.ActivityType)
                    {
                        case "MEDI":
                            order = JsonConvert.DeserializeObject<Medicine>(item.ActivityJson);
                            saveResponse = MedicineWrites.AddMedicine((Medicine)order, provider, connectionString);
                            break;
                        case "MATE":
                            order = JsonConvert.DeserializeObject<Material>(item.ActivityJson);
                            saveResponse = MaterialWrites.AddMaterial((Material)order, provider, connectionString);
                            break;
                        case "LABO":
                            order = JsonConvert.DeserializeObject<Laboratory>(item.ActivityJson);
                            saveResponse = LaboratoryWrites.AddLaboratory((Laboratory)order, provider, connectionString);
                            break;
                        default:
                            break;
                    }
                    if (saveResponse.Successful)
                        orderSavedList.Add(new Tuple<int, string>(saveResponse.Result, item.ActivityType));
                }

                ///2. Guardar el protocolo
                var secuence = GetNextProtocolSequence(provider, connectionString);

                if (orderSavedList.Count > 0)
                {
                    saveResponse = SaveProtocol(orderSavedList, secuence, provider, connectionString);
                    return OrderWrites.SaveOrderByPatient(secuence, request.History, "PROT", DateTime.Now, "A", request.UserCode,  provider, connectionString);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
        /// <summary>
        /// Guardar el protocolo
        /// </summary>
        /// <param name="protocols"></param>
        /// <param name="sequence"></param>
        /// <param name="provider"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static RequestResponse<int> SaveProtocol(List<Tuple<int, string>> protocols, int sequence, string provider, string connectionString)
        {
            RequestResponse<int> response = new RequestResponse<int>();
            int nextSequence = 1;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    ///Abrir la conexion
                    connection.Open();


                    foreach (var item in protocols)
                    {
                        ///Insertar el protocolo
                        SqlCommand commandInsert = new SqlCommand(ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.POST_PROTOCOL), connection);

                        commandInsert.Parameters.AddWithValue("@proide", sequence);
                        commandInsert.Parameters.AddWithValue("@procon", item.Item1);
                        commandInsert.Parameters.AddWithValue("@proori", item.Item2);
                        
                        var index = commandInsert.ExecuteNonQuery();
                    }

                    response.Successful = true;
                    response.Result = nextSequence;
                }
            }
            catch (Exception ex)
            {
                response.Successful = false;
                response.Message = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Obtener sigiente serial disponible de protocolo
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static int GetNextProtocolSequence(string provider, string connectionString)
        {
            int nextSequence = 1;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    ///Abrir la conexion
                    connection.Open();

                    SqlCommand commandSerial = new SqlCommand(ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.GET_NEX_SECUENCE_LABORATORY), connection);
                    var nextSerial = commandSerial.ExecuteScalar();

                    if (nextSerial != null && !string.IsNullOrWhiteSpace(nextSerial.ToString()))
                        nextSequence = Convert.ToInt32(nextSerial);
                }
            }
            catch (Exception)
            {
                return -1;
            }
            return nextSequence;
        }
    }
}
