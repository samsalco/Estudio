using EPS.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WEPS.Common.Reads;

namespace EPS.Common.Reads
{
    /// <summary>
    /// Handler de Usuario
    /// </summary>
    public static class UserHandler
    {
        /// <summary>
        /// Obtener todos los usuarios
        /// </summary>
        /// <returns></returns>
        public static RequestResponse<List<User>> GetAllUsers(string provider, string ConnectionString)
        {
            RequestResponse<List<User>> response = new RequestResponse<List<User>>();
            try
            {
                response.Successful = true;
                response.Result = new List<User>()
                {
                    { new User(){  Name = "Esperanza", Code = "admon", Password = "123"} },
                    { new User(){  Name = "Sofia", Code = "pruebas", Password = "456"} }
                };
            }
            catch (Exception ex)
            {
                response.Successful = false;
                response.Message = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Obtener usuario
        /// </summary>
        /// <param name="id">codigo</param>
        /// <param name="password">Contraseña</param>
        /// <returns></returns>
        public static RequestResponse<User> GetUser(string id, string password, string provider, string connectionString)
        {
            RequestResponse<User> response = new RequestResponse<User>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.GET_USER), connection);
                    command.Parameters.AddWithValue("@usucod", id);
                    command.Parameters.AddWithValue("@usucla", password);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        response.Successful = true;
                        while (reader.Read())
                        {
                            response.Result = new User()
                            {
                                Code = reader["usucod"].ToString(),
                                Password = reader["usucla"].ToString(),
                                State = "S",
                                Name = reader["usunom"].ToString()
                            };
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
