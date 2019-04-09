using EPS.Common.Models;
using System;
using System.Data.SqlClient;
using WEPS.Common.Reads;

namespace EPS.Common.Reads
{
    /// <summary>
    /// Consultas genericas
    /// </summary>
    public static class EPSHandler
    {
        /// <summary>
        /// Obtener informacion del paciente
        /// </summary>
        /// <param name="history"></param>
        /// <param name="provider"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static RequestResponse<Patient> GetPatient(string history, string provider, string connectionString)
        {
            RequestResponse<Patient> response = new RequestResponse<Patient>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.GET_PATIENT), connection);
                    command.Parameters.AddWithValue("@pachis", history);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        response.Successful = true;
                        while (reader.Read())
                        {
                            response.Result = new Patient()
                            {
                                History = Convert.ToInt32(reader["pachis"].ToString()),
                                Identification = reader["pacide"].ToString(),
                                IdentificationType = reader["pactid"].ToString(),
                                FirstName = reader["pacnom"].ToString(),
                                SecondName = reader["pacno2"].ToString(),
                                FirstLastName = reader["pacap1"].ToString(),
                                SecondLastName = reader["pacap2"].ToString(),
                                Genre = reader["pacsex"].ToString(),
                                BirthDate = Convert.ToDateTime(reader["pacnac"].ToString())
                            };
                        }
                    }
                    else
                    {
                        response.Successful = false;
                        response.Message = "No Hay información de paciente";
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
