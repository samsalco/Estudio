using EPS.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WEPS.Common.Reads;

namespace EPS.Common.Reads
{
    public static class ProtocolHandler
    {
        public static RequestResponse<IProtocol> GetProtocol(int sequence, string provider, string ConnectionString)
        {
            RequestResponse<IProtocol> response = new RequestResponse<IProtocol>();
            Protocol protocol = new Protocol();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = ResourceHelper.GetQuery(Resources.ReadResources.Queries, provider, ReadsConstants.GET_PATIENT_PROTOCOLOS);

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@proide", sequence);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        response.Successful = true;
                        while (reader.Read())
                        {
                            if (protocol.Orders == null) protocol.Orders = new List<IOrder>();

                            protocol.Sequence = Convert.ToInt32(reader["proide"].ToString());

                            switch (reader["proori"].ToString())
                            {
                                case "MATE":
                                    var material = MaterialHandler.GetMaterial(Convert.ToInt32(reader["procon"].ToString()), provider, ConnectionString);
                                    protocol.Orders.Add(material.Result as Material);
                                    break;
                                case "LABO":
                                    var laboratory = LaboratoryHandler.GetLaboratory(Convert.ToInt32(reader["procon"].ToString()), provider, ConnectionString);
                                    protocol.Orders.Add(laboratory.Result as Laboratory);
                                    break;
                                case "MEDI":
                                    var medicine = MedicineHandler.GetMedicine(Convert.ToInt32(reader["procon"].ToString()), provider, ConnectionString);
                                    protocol.Orders.Add(medicine.Result as Medicine);
                                    break;
                                default:
                                    break;
                            }
                        }
                        response.Result = protocol;
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
