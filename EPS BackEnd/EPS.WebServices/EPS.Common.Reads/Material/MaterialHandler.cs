using EPS.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WEPS.Common.Reads;

namespace EPS.Common.Reads
{
    public static class MaterialHandler
    {
        public static RequestResponse<IOrder> GetMaterial(int sequence, string provider, string ConnectionString)
        {
            RequestResponse<IOrder> response = new RequestResponse<IOrder>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.GET_PATIENT_MATERIALS);

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@matide", sequence);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        response.Successful = true;
                        while (reader.Read())
                        {
                            response.Result = new Material()
                            {
                                Code = reader["matcod"].ToString(),
                                Quantity = Convert.ToInt32(reader["matcan"].ToString()),
                                Comments = reader["matobs"].ToString(),
                                Presentation = reader["matpre"].ToString(),
                                Type = "MATE",
                                Sequence = Convert.ToInt32(reader["matide"].ToString())
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
