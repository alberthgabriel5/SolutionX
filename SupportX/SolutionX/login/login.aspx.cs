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

            employee = employeeBussines.VerifyUser(employee);
            if (employee.id != -5)
            {
                Session["id"] = employee.id;                
                Session["Name"] = employee.name;
                Session["LastName"] = employee.lastName;
                Session["userName"] = employee.nickName;
                Session["pass"] = employee.pass;
                Console.WriteLine(employee.Role.roleName);
                switch (employee.Role.idRole) {
                    case 1:
                        Session["userName"] = employee;
                        Response.Redirect("../viewAdmSuper.aspx");
                        break;
                    case 2:
                        Session["userName"] = employee;
                        Response.Redirect("../viewAdm.aspx");
                        break;
                    case 3:
                        Session["userName"] = employee;
                        Response.Redirect("../viewCoordinatorTable.aspx");
                        break;
                    case 4:
                        Session["userName"] = employee;
                        Response.Redirect("../viewCoordinator.aspx");
                        break;
                    case 5:
                        Session["userName"] = employee;
                        Response.Redirect("../viewEmployee.aspx");
                        break;
                    default:
                        Response.Write("Login Failed");
                        Response.Redirect("login.aspx");
                        break;
                }
            } 
            else { 
            customer = customerBussines.VerifyCustomer(customer);
                    if (customer.id != -5)
                    {
                    Session["id"] = customer.id;
                    Session["Name"] = customer.name;
                    Session["LastName"] = customer.lastName;
                    Session["userName"] = customer.nickName;
                    Session["pass"] = customer.pass;
                    //loginUser.userLogin= username.Value.ToString();
                    //    loginUser.passwordLogin = password.Value.ToString();

                    Response.Redirect("../ViewClient.aspx");

                        
                    }
                    else {
                        Response.Write("Login Failed");
                        Response.Redirect("login.aspx");
                    }
            }
        }
        
    }
}