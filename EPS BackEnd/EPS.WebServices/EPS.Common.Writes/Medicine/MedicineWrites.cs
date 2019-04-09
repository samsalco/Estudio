using EPS.Common.Models;
using System;
using System.Data.SqlClient;

namespace EPS.Common.Writes
{
    /// <summary>
    /// Escrituras medicina
    /// </summary>
    public static class MedicineWrites
    {
        public static RequestResponse<int> AddMedicine(Medicine medicine, string provider, string connectionString)
        {
            RequestResponse<int> response = new RequestResponse<int>();
            int nextSequence = 1;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    ///Abrir la conexion
                    connection.Open();

                    ///Insertar el usuario
                    SqlCommand commandInsert = new SqlCommand(ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.POST_MEDICINE), connection);

                    commandInsert.Parameters.AddWithValue("@meddos", medicine.Dose);
                    commandInsert.Parameters.AddWithValue("@meduni", medicine.Unity);
                    commandInsert.Parameters.AddWithValue("@medfre", medicine.Frecuency);
                    commandInsert.Parameters.AddWithValue("@meddur", medicine.Duration);
                    commandInsert.Parameters.AddWithValue("@medpos", medicine.Posology);
                    commandInsert.Parameters.AddWithValue("@medobs", medicine.Comments);
                    commandInsert.Parameters.AddWithValue("@medcod", medicine.Code);

                    var index = commandInsert.ExecuteNonQuery();

                    SqlCommand commandSerial = new SqlCommand(ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.GET_TABLE_SERIAL), connection);
                    commandSerial.Parameters.AddWithValue("@tabname", "epsmed");
                    var nextSerial = commandSerial.ExecuteScalar();

                    if (nextSerial != null && !string.IsNullOrWhiteSpace(nextSerial.ToString()))
                        nextSequence = Convert.ToInt32(nextSerial);

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
    }
}
