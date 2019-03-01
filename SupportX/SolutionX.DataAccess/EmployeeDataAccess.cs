using SolutionX.DomainEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionX.DataAccess
{
    public class EmployeeDataAccess
    {
        List<Employee> employeeList = new List<Employee>();
        List<Ticket> ticketsList = new List<Ticket>();
        public string VerifyUser(Employee employee)
        {

            SqlConnection connectionEmployee = DataAccess.GetSqlConnectionEmployee();
            SqlDataReader reader;
            using (SqlCommand cmd = new SqlCommand("sp_user_exists", connectionEmployee))
            {

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@user", employee.nickName);
                cmd.Parameters.AddWithValue("@pass", employee.pass);

                connectionEmployee.Open();
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employee.id = Convert.ToInt32(reader["idEmployee"].ToString());
                }
                if (employee.id != -5)
                {
                    SqlConnection connectionSupportX = DataAccess.GetSqlConnectionSupportX();
                    SqlDataReader readerSupportX;
                    using (SqlCommand cmdSupportX = new SqlCommand("sp_select_employee_id", connectionSupportX))
                    {

                        cmdSupportX.CommandType = System.Data.CommandType.StoredProcedure;

                        cmdSupportX.Parameters.AddWithValue("@id", employee.id);

                        connectionSupportX.Open();
                        cmdSupportX.ExecuteNonQuery();
                        readerSupportX = cmdSupportX.ExecuteReader();
                        while (readerSupportX.Read())
                        {

                            employee.id = Convert.ToInt32(readerSupportX["idEmployee"].ToString());
                            employee.name = readerSupportX["nameEmployee"].ToString();
                            employee.lastName = readerSupportX["lastName"].ToString();
                            employee.Role.idRole = Convert.ToInt32(readerSupportX["idRole"].ToString());
                            employee.Role.roleName = readerSupportX["roleName"].ToString();

                        }
                        string roleEmployee = employee.Role.roleName;
                        Console.WriteLine("ROL DE EMPLEADO " + roleEmployee);
                        switch (roleEmployee)
                        {
                            case "Super Admin":
                                return "Super Admin";
                                break;
                            case "Admin":
                                return "Admin";
                                break;
                            case "Manager Desktop":
                                return "Manager Desktop";
                                break;
                            case "Manager":
                                return "Manager";
                                break;
                            case "Funtionary":
                                return "Funtionary";
                                break;

                            default:
                                connectionSupportX.Close();
                                return "Does not exists this role";
                                
                        }
                        
                    }
                }
            }
            Console.WriteLine("Resultado de vaaaaaaalorrrrrrrr: " + employee.id);

            connectionEmployee.Close();

            return "Does not exists this role";

        }


        public void AssignRole(Role role, Employee employee)
        {
            SqlConnection connectionSupportX = DataAccess.GetSqlConnectionSupportX();
            using (SqlCommand cmd = new SqlCommand("sp_funtionary_asigned_roll", connectionSupportX))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idRole", role.idRole);
                cmd.Parameters.AddWithValue("@idFuntionary", employee.id);
                connectionSupportX.Open();
                cmd.ExecuteNonQuery();
                connectionSupportX.Close();
            }
        }
        public List<Employee> ListCoordinator()
        {
            SqlConnection connectionSupportX = DataAccess.GetSqlConnectionSupportX();
            SqlDataReader reader;

            using (SqlCommand cmd = new SqlCommand("sp_select_employee_role", connectionSupportX))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rol", 4);
                connectionSupportX.Open();
                cmd.ExecuteNonQuery();

                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.id = Convert.ToInt32(reader["idEmployee"].ToString());
                    employee.name = reader["nameEmployee"].ToString();
                    employee.lastName = reader["lastName"].ToString();

                    employeeList.Add(employee);

                }
                return employeeList;
                connectionSupportX.Close();
            }
        }

        public List<Employee> ListEmployee()
        {
            SqlConnection connectionSupportX = DataAccess.GetSqlConnectionSupportX();
            SqlDataReader reader;

            using (SqlCommand cmd = new SqlCommand("sp_select_employee_all", connectionSupportX))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connectionSupportX.Open();
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.id = Convert.ToInt32(reader["idEmployee"].ToString());
                    employee.name = reader["nameEmployee"].ToString();
                    employee.lastName = reader["lastName"].ToString();
                    employeeList.Add(employee);
                }
                connectionSupportX.Close();
                return employeeList;
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

                    Ticket ticket = new Ticket();
                    ticket.idCode = Convert.ToInt32(reader["idCode"].ToString());
                    ticket.description = reader["description"].ToString();

                    ticket.idCustomer = Convert.ToInt32(reader["idCustomer"].ToString());
                    ticket.idCoordinator = reader["idCoordinator"] == System.DBNull.Value ? default(int) : Convert.ToInt32(reader["idCoordinator"].ToString());
                    ticket.idEmployee = reader["idEmployee"] == System.DBNull.Value ? default(int) : Convert.ToInt32(reader["idEmployee"].ToString());

                    ticketsList.Add(ticket);

                }
                connectionSupportX.Close();

                return ticketsList;
            }
        }



    }
    

}
