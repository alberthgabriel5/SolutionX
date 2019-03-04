


using SolutionX.DomainEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SolutionX.DataAccess
{
    public class TicketDataAccess
    {
        List<Ticket> ticketsList = new List<Ticket>();

        public String CreateTicket(Ticket ticket)
        {
            String answer = "DB Conection Failed";

            SqlConnection connectionSupportX = DataAccess.GetSqlConnectionSupportX();

            SqlDataReader reader;
            using (SqlCommand cmd = new SqlCommand("sp_insert_ticket", connectionSupportX))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@description", ticket.description);
                cmd.Parameters.AddWithValue("@idCustomer", ticket.idCustomer);

                connectionSupportX.Open();
                reader = cmd.ExecuteReader();
                //cmd.ExecuteNonQuery();
                
                while (reader.Read())
                {
                    answer=reader["answer"].ToString();
                }

                    connectionSupportX.Close();

                return answer;
            }

        }
        public List<Ticket> ViewTicket()
        {

            SqlConnection connectionSupportX = DataAccess.GetSqlConnectionSupportX();

            SqlDataReader reader;

            using (SqlCommand cmd = new SqlCommand("sp_listar_ticket_1", connectionSupportX))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connectionSupportX.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ticket ticket = new Ticket() {
                    idCode = Convert.ToInt32(reader["idCode"].ToString()),
                    description = reader["description"].ToString(),
                    priority = Convert.ToInt32(reader["idPriority"].ToString()),
                    dateCreate = Convert.ToDateTime(reader["datecreate"].ToString()),
                    idCategory = Convert.ToInt32(reader["idCategory"].ToString()),
                    idCustomer = Convert.ToInt32(reader["idCustomer"].ToString()),
                    idCoordinator = Convert.ToInt32(reader["idCordinator"].ToString()),
                    idEmployee = Convert.ToInt32(reader["idEmployee"].ToString())
                };
                    ticketsList.Add(ticket);
                }
                connectionSupportX.Close();

                return ticketsList;
            }
        }
        public List<Ticket> SearchTicket(Ticket ticket)
        {
            SqlConnection connectionSupportX = DataAccess.GetSqlConnectionSupportX();

            SqlDataReader reader;
            using (SqlCommand cmd = new SqlCommand("sp_listar_ticket_id", connectionSupportX))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCode", ticket.idCode);
                connectionSupportX.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ticket.idCode = Convert.ToInt32(reader["idCode"].ToString());
                    ticket.description = reader["description"].ToString();
                    ticket.priority = Convert.ToInt32(reader["idPriority"].ToString());
                    ticket.dateCreate = Convert.ToDateTime(reader["datecreate"].ToString());
                    ticket.idCategory = Convert.ToInt32(reader["idCategory"].ToString());
                    ticket.idCustomer = Convert.ToInt32(reader["idCustomer"].ToString());
                    ticket.idCoordinator = Convert.ToInt32(reader["idCordinator"].ToString());
                    ticket.idEmployee = Convert.ToInt32(reader["idEmployee"].ToString());

                    ticketsList.Add(ticket);
                }
            }

            return ticketsList;
        }
        public List<Ticket> AssignRequestToManager(Ticket ticket)
        {
            SqlConnection connectionSupportX = DataAccess.GetSqlConnectionSupportX();
            SqlDataReader reader;
            using (SqlCommand cmd = new SqlCommand("sp_cordinator_asigned", connectionSupportX))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCode", ticket.idCode);
                cmd.Parameters.AddWithValue("@idCordinator", ticket.idCoordinator);
                cmd.Parameters.AddWithValue("@idPriority", ticket.priority);
                cmd.Parameters.AddWithValue("@idCategory", ticket.idCategory);
                cmd.Parameters.AddWithValue("@text", ticket.description);


                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ticket.idCode = Convert.ToInt32(reader["idCode"].ToString());
                    ticket.idCoordinator = Convert.ToInt32(reader["idCordinator"].ToString());
                    ticket.priority = Convert.ToInt32(reader["idPriority"].ToString());
                    ticket.idCategory = Convert.ToInt32(reader["idCategory"].ToString());
                    ticket.description = reader["text"].ToString();
                    ticketsList.Add(ticket);
                }

                connectionSupportX.Open();
                cmd.ExecuteNonQuery();
                connectionSupportX.Close();
                return ticketsList;
            }
        }
        public List<Ticket> ViewPendingTicket()
        {

            SqlConnection connectionSupportX = DataAccess.GetSqlConnectionSupportX();

            SqlDataReader reader;

            using (SqlCommand cmd = new SqlCommand("sp_select_ticket_created", connectionSupportX))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connectionSupportX.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Ticket ticket = new Ticket() {
                        idCode = Convert.ToInt32(reader["idCode"].ToString()),
                        description = reader["description"].ToString(),
                        priority = reader["idPriority"] == System.DBNull.Value ? default(int) : Convert.ToInt32(reader["idPriority"].ToString()),
                        idCategory = reader["idCategory"] == System.DBNull.Value ? default(int) : Convert.ToInt32(reader["idCategory"].ToString()),
                        idCustomer = Convert.ToInt32(reader["idCustomer"].ToString()),
                    idCoordinator = reader["idCoordinator"] == System.DBNull.Value ? default(int) : Convert.ToInt32(reader["idCoordinator"].ToString()),
                    idEmployee = reader["idEmployee"] == System.DBNull.Value ? default(int) : Convert.ToInt32(reader["idEmployee"].ToString())
                };
                    ticketsList.Add(ticket);

                }
                connectionSupportX.Close();

                return ticketsList;
            }

        }
        public List<Ticket> UnassignedTicket()
        {

            SqlConnection connectionSupportX = DataAccess.GetSqlConnectionSupportX();

            SqlDataReader reader;

            using (SqlCommand cmd = new SqlCommand("sp_select_ticket_unassigned", connectionSupportX))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connectionSupportX.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ticket ticket = new Ticket() {
                    idCode = Convert.ToInt32(reader["idCode"].ToString()),
                    description = reader["description"].ToString(),
                    idCustomer = Convert.ToInt32(reader["idCustomer"].ToString()),
                    idCoordinator = reader["idCoordinator"] == System.DBNull.Value ? default(int) : Convert.ToInt32(reader["idCoordinator"].ToString()),
                    idEmployee = reader["idEmployee"] == System.DBNull.Value ? default(int) : Convert.ToInt32(reader["idEmployee"].ToString())
                };
                    ticketsList.Add(ticket);

                }
                connectionSupportX.Close();

                return ticketsList;
            }
        }
    }
}