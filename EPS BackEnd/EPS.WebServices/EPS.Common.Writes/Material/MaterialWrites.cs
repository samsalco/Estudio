using EPS.Common.Models;
using System;
using System.Data.SqlClient;

namespace EPS.Common.Writes
{
    /// <summary>
    /// Escritura materiales
    /// </summary>
    public static class MaterialWrites
    {
        /// <summary>
        /// Adicionar material
        /// </summary>
        /// <param name="material"></param>
        /// <param name="provider"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static RequestResponse<int> AddMaterial(Material material, string provider, string connectionString)
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
                    SqlCommand commandInsert = new SqlCommand(ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.POST_MATERIAL), connection);

                    commandInsert.Parameters.AddWithValue("@matpre", material.Presentation);
                    commandInsert.Parameters.AddWithValue("@matcan", material.Quantity);
                    commandInsert.Parameters.AddWithValue("@matobs", material.Comments);
                    commandInsert.Parameters.AddWithValue("@matcod", material.Code);

                    var index = commandInsert.ExecuteNonQuery();

                    SqlCommand commandSerial = new SqlCommand(ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.GET_TABLE_SERIAL), connection);
                    commandSerial.Parameters.AddWithValue("@tabname", "epsmat");
                    var nextSerial = commandSerial.ExecuteScalar();
                    
                    if(nextSerial != null && !string.IsNullOrWhiteSpace(nextSerial.ToString()))
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
