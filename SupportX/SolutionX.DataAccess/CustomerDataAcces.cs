using SolutionX.DomainEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionX.DataAccess
{
   public  class CustomerDataAcces
    {
        public Customer VerifyUser(Customer customer)
        {
            SqlConnection connectionCustomer = DataAccess.GetSqlConnectionCustomer();
            SqlDataReader reader;
            using (SqlCommand cmd = new SqlCommand("sp_user_exists", connectionCustomer))
            {
                customer.id = -5;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@user", customer.nickName);
                cmd.Parameters.AddWithValue("@pass", customer.pass);

                connectionCustomer.Open();
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customer.id = Convert.ToInt32(reader["idEmployee"].ToString());
                    customer.name = reader["nameEmployee"].ToString();
                    customer.lastName = reader["lastName"].ToString();
                }
                return customer;

            }
        }
        public Customer ReturnValueCustomer(Customer customer)
        {
            SqlConnection connectionCustomer = DataAccess.GetSqlConnectionCustomer();
            SqlDataReader reader;
            using (SqlCommand cmd = new SqlCommand("sp_user_exists", connectionCustomer))
            {

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@user", customer.nickName);
                cmd.Parameters.AddWithValue("@pass", customer.pass);

                connectionCustomer.Open();
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    customer.id = Convert.ToInt32(reader["idEmployee"].ToString());
                    customer.name = reader["nameEmployee"].ToString();
                    customer.lastName = reader["lastname"].ToString();
                    customer.nickName = reader["nickname"].ToString();
                    customer.pass= reader["pass"].ToString();


                }
                connectionCustomer.Close();
                return customer;
            }
        }
    }

            
            

            
}
