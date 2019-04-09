using EPS.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WEPS.Common.Reads;

namespace EPS.Common.Reads
{
    public static class LaboratoryHandler
    {
        public static RequestResponse<IOrder> GetLaboratory(int sequence, string provider, string ConnectionString)
        {
            RequestResponse<IOrder> response = new RequestResponse<IOrder>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.GET_PATIENT_LABORATORIES);

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@labide", sequence);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        response.Successful = true;
                        while (reader.Read())
                        {
                            response.Result = new Laboratory()
                            {
                                Code = reader["labcod"].ToString(),
                                Quantity = Convert.ToInt32(reader["labcan"].ToString()),
                                Comments = reader["labobs"].ToString(),
                                Frecuency = reader["labfre"].ToString(),
                                Type = "LABO",
                                Sequence= Convert.ToInt32(reader["labide"].ToString())
                            };
                        }
                    }
                    else
                    {
                        response.Successful = true;
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
