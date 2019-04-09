using EPS.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EPS.Common.Writes
{
    /// <summary>
    /// Escrituras laboratorio
    /// </summary>
    public static class LaboratoryWrites
    {
        /// <summary>
        /// Adicionar laboratorio
        /// </summary>
        /// <param name="laboratory"></param>
        /// <param name="provider"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static RequestResponse<int> AddLaboratory(Laboratory laboratory, string provider, string connectionString)
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
                    SqlCommand commandInsert = new SqlCommand(ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.POST_LABORATORY), connection);

                    commandInsert.Parameters.AddWithValue("@labcan", laboratory.Quantity);
                    commandInsert.Parameters.AddWithValue("@labfre", laboratory.Frecuency);
                    commandInsert.Parameters.AddWithValue("@labobs", laboratory.Comments);
                    commandInsert.Parameters.AddWithValue("@labcod", laboratory.Code);

                    var index = commandInsert.ExecuteNonQuery();

                    SqlCommand commandSerial = new SqlCommand(ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.GET_TABLE_SERIAL), connection);
                    commandSerial.Parameters.AddWithValue("@tabname", "epslab");
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
