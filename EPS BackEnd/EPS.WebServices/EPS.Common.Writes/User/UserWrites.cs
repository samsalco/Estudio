using EPS.Common.Models;
using EPS.Common.Reads;
using System;
using System.Data.SqlClient;
using WEPS.Common.Reads;

namespace EPS.Common.Writes
{
    /// <summary>
    /// Escrituras usuario
    /// </summary>
    public static class UserWrites
    {
        /// <summary>
        /// Adicionar usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="provider"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static RequestResponse<int> AddUser(User user, string provider, string connectionString)
        {
            RequestResponse<int> response = new RequestResponse<int>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    ///Abrir la conexion
                    connection.Open();

                    ///Buscar si ya existe
                    if (ExistsUser(user, provider, connectionString))
                    {
                        response.Successful = false;
                        response.Message = $"El usuario {user.Code} ya se encuentra registrado.";
                        return response;
                    }

                    ///Insertar el usuario
                    SqlCommand commandInsert = new SqlCommand(ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.POST_USER), connection);

                    commandInsert.Parameters.AddWithValue("@usucod", user.Code);
                    commandInsert.Parameters.AddWithValue("@usucla", user.Password);
                    commandInsert.Parameters.AddWithValue("@usuact", "S");
                    commandInsert.Parameters.AddWithValue("@usunom", user.Name);

                    
                    var index = commandInsert.ExecuteNonQuery();
                    response.Successful = true;
                    response.Result = index;
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
        /// Validar si existe un usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="provider"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        static bool ExistsUser(User user, string provider, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    ///Abrir la conexion
                    connection.Open();

                    ///Buscar si ya existe
                    SqlCommand commandSearch = new SqlCommand(ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.EXISTS_USER), connection);
                    commandSearch.Parameters.AddWithValue("@usucod", user.Code);
                    commandSearch.Parameters.AddWithValue("@usucla", user.Password);
                    var exists = commandSearch.ExecuteScalar();
                    return (exists != null && !string.IsNullOrWhiteSpace(exists.ToString()))?true:false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
