using EPS.Common.Models;
using System;
using System.Data.SqlClient;

namespace EPS.Common.Writes
{
    public static class OrderWrites
    {
        /// <summary>
        /// Guardar ordenes por paciente
        /// </summary>
        /// <param name="consecutive"></param>
        /// <param name="history"></param>
        /// <param name="Origin"></param>
        /// <param name="OrderDate"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public static RequestResponse<int> SaveOrderByPatient(int consecutive, int history, string Origin, DateTime OrderDate, string state, string userCode, string provider, string connectionString)
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
                    SqlCommand commandInsert = new SqlCommand(ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.POST_ORDERPATIENT), connection);

                    commandInsert.Parameters.AddWithValue("@oppcon", consecutive);
                    commandInsert.Parameters.AddWithValue("@opphis", history);
                    commandInsert.Parameters.AddWithValue("@oppori", Origin);
                    commandInsert.Parameters.AddWithValue("@oppfec", OrderDate);
                    commandInsert.Parameters.AddWithValue("@oppest", state);
                    commandInsert.Parameters.AddWithValue("@oppusu", userCode);

                    var index = commandInsert.ExecuteNonQuery();

                    SqlCommand commandSerial = new SqlCommand(ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.GET_TABLE_SERIAL), connection);
                    commandSerial.Parameters.AddWithValue("@tabname", "epsopp");
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
