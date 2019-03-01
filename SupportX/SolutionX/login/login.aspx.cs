using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SolutionX.BussinesLayer;
using SolutionX.DomainEntities;

namespace SolutionX.login
{
  
    public partial class login : System.Web.UI.Page
    {
        EmployeeBussines employeeBussines = new EmployeeBussines();
        CustomerBussines customerBussines = new CustomerBussines();
        LoginUser loginUser = new LoginUser();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButttonCLick(object sender, EventArgs e) {
            string user = username.Value;
            string passw = password.Value;
            // Console.WriteLine(user + "g" + pass);

            Employee employee = new Employee();
            employee.nickName = user;
            employee.pass = passw;
            employee.Role = new Role();

            Customer customer = new Customer();
            customer.nickName = username.Value;
            customer.pass = password.Value;

            string aux = employeeBussines.VerifyUser(employee);
            Session["userName"] = employee;
            Console.WriteLine(aux);
            switch (aux) {
                case "Super Admin":
                    Session["userName"] = employee;
                    Response.Redirect("../viewAdmSuper.aspx");
                    break;
                case "Admin":
                    Session["userName"] = employee;
                    Response.Redirect("../viewAdm.aspx");
                    break;
                case "Manager Desktop":
                    Session["userName"] = employee;
                    Response.Redirect("../viewCoordinatorTable.aspx");
                    break;
                case "Manager":
                    Session["userName"] = employee;
                    Response.Redirect("../viewCoordinator.aspx");
                    break;
                case "Funtionary":
                    Session["userName"] = employee;
                    Response.Redirect("../viewEmployee.aspx");
                    break;
                case "Does not exists this role":
                    
                    string answer = customerBussines.VerifyCustomer(customer);
                    if (answer.Equals("Login Successful"))
                    {
                        //Session["userName"] = username.Value.ToString();
                        //Session["password"] = password.Value.ToString();
                        loginUser.userLogin= username.Value.ToString();
                        loginUser.passwordLogin = password.Value.ToString();

                        Response.Redirect("../viewClient.aspx");

                        
                    }
                    else {
                        Response.Write("Login Failed");
                        Response.Redirect("login.aspx");
                    }
                    break;
                default:
                    //Response.Redirect("./login.aspx");
                    break;
            }
        }
        
    }
}