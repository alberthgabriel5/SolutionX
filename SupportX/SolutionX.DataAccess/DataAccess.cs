using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SolutionX.DataAccess
{
    public class DataAccess
    {
        public static SqlConnection GetSqlConnectionCustomer()
        {
            SqlConnection connectionCustomer= new SqlConnection();
            connectionCustomer.ConnectionString = "Data Source=163.178.107.130;Initial Catalog=EmpresaX_ClientDB;Persist Security Info=True;User ID=laboratorios;Password=Saucr.118";
            
            return connectionCustomer;
        }

        public static SqlConnection GetSqlConnectionEmployee()
        {
            SqlConnection connectionEmployee = new SqlConnection();
            connectionEmployee.ConnectionString = "Data Source=163.178.107.130;Initial Catalog=EmpresaX_HumanResources;Persist Security Info=True;User ID=laboratorios;Password=Saucr.118";
            return connectionEmployee;
        }
        public static SqlConnection GetSqlConnectionSupportX()
        {
            SqlConnection connectionSupportX = new SqlConnection();
            connectionSupportX.ConnectionString = "Data Source=163.178.107.130;Initial Catalog=SupportX_PrimaryDatabase;User ID=laboratorios;Password=Saucr.118";
            
            return connectionSupportX;
        }
    }
}