using EPS.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WEPS.Common.Reads;

namespace EPS.Common.Reads
{
    /// <summary>
    /// Lecturas protocolo
    /// </summary>
    public static class OrderHandler
    {
        /// <summary>
        /// Obtener ordenes por paciente
        /// </summary>
        /// <param name="history"></param>
        /// <param name="type"></param>
        /// <param name="provider"></param>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        public static RequestResponse<List<IActivity>> GetOrdersPatient(int history, string type, string provider, string ConnectionString)
        {
            RequestResponse<List<IActivity>> response = new RequestResponse<List<IActivity>>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.GET_ORDERBY_PATIENT);
                    query = string.IsNullOrWhiteSpace(type) ? query : $"{query} AND oppori = @oppori";

                    ///1. Mediante historia buscar ordenes por paciente en epsopp
                    ///Insertar el usuario
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@opphis", history);
                    if (!string.IsNullOrWhiteSpace(type))
                        command.Parameters.AddWithValue("@oppori", type);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (response.Result == null) response.Result = new List<IActivity>();

                        response.Successful = true;
                        while (reader.Read())
                        {
                            switch (reader["oppori"].ToString())
                            {
                                case "PROT":
                                    var protocol = ProtocolHandler.GetProtocol(Convert.ToInt32(reader["oppcon"].ToString()), provider, ConnectionString);
                                    response.Result.Add(new Activity<Protocol>(protocol.Result as Protocol) { Type = "PROT" });
                                    break;
                                case "MATE":
                                    var material = MaterialHandler.GetMaterial(Convert.ToInt32(reader["oppcon"].ToString()), provider, ConnectionString);
                                    response.Result.Add(new Activity<Material>(material.Result as Material) { Type = "MATE" });
                                    break;
                                case "MEDI":
                                    var medicine = MedicineHandler.GetMedicine(Convert.ToInt32(reader["oppcon"].ToString()), provider, ConnectionString);
                                    response.Result.Add(new Activity<Medicine>(medicine.Result as Medicine) { Type = "MEDI" });
                                    break;
                                case "LABO":
                                    var laborartory = LaboratoryHandler.GetLaboratory(Convert.ToInt32(reader["oppcon"].ToString()), provider, ConnectionString);
                                    response.Result.Add(new Activity<Laboratory>(laborartory.Result as Laboratory) { Type = "LABO" });
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        response.Successful = false;
                        response.Message = "No Hay información de estudiantes";
                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                response.Successful = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
