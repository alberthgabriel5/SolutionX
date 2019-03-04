using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionX.DataAccess;
using SolutionX.DomainEntities;

namespace SolutionX.DataAccess
{
    public class PriorityDataAccess
    {
        List<Priority> priorityList = new List<Priority>();
        public List<Priority> ListPriority()
        {

            SqlConnection connectionSupportX = DataAccess.GetSqlConnectionSupportX();
            SqlDataReader reader;

            using (SqlCommand cmd = new SqlCommand("sp_select_priority", connectionSupportX))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connectionSupportX.Open();
                cmd.ExecuteNonQuery();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Priority priority = new Priority()
                    {
                        idPriority = Convert.ToInt32(reader["idPriority"].ToString()),
                        namePriority = reader["namePriority"].ToString()
                    };
                    priorityList.Add(priority);
                }
                connectionSupportX.Close();
                return priorityList;

            }

        }
    }
}
