using EPS.Common.Models;
using System;
using System.Data.SqlClient;
using WEPS.Common.Reads;

namespace EPS.Common.Reads
{
    public static class MedicineHandler
    {
        public static RequestResponse<IOrder> GetMedicine(int sequence, string provider, string ConnectionString)
        {
            RequestResponse<IOrder> response = new RequestResponse<IOrder>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.GET_PATIENT_MEDICAMENTS);

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@medide", sequence);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        response.Successful = true;
                        while (reader.Read())
                        {
                            response.Result = new Medicine()
                            {
                                Code = reader["medcod"].ToString(),
                                Dose = Convert.ToDecimal(reader["meddos"].ToString()),
                                Unity = reader["meduni"].ToString(),
                                Frecuency = reader["medfre"].ToString(),
                                Duration = reader["meddur"].ToString(),
                                Posology = reader["medpos"].ToString(),
                                Comments = reader["medobs"].ToString(),
                                Type = "MEDI",
                                Sequence = Convert.ToInt32(reader["medide"].ToString())
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
