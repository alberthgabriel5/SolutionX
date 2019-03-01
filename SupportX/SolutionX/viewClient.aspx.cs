using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SolutionX.BussinesLayer;
using SolutionX.DomainEntities;

namespace SolutionX
{
    public partial class viewClient : System.Web.UI.Page
    {
        ticketBussines ticketBussines = new ticketBussines();
        CustomerBussines customerBussines = new CustomerBussines();
        Ticket ticket = new Ticket();
        Customer customer;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void ButtonSaveRequest(object sender, EventArgs e)
        {
            /* string description = txDesc.Value;
             Ticket ticket = new Ticket();
             ticket.description = description;
             if (Session["usuario"].Equals("") {
             }
             ti.CreateTicket(ticket);
             */
        }
        protected void CreateTicket(object sender, EventArgs e)
        {
            



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string user =HttpContext.Current.Session["userName"].ToString();
            //string pas = HttpContext.Current.Session["password"].ToString();
            LoginUser login = new LoginUser();
            
            customer = new Customer();
            customer.nickName = login.userLogin;
            customer.pass = login.passwordLogin;

            customer = customerBussines.returnCustomer(customer);

            ticket.description = txDesc.Value;
            ticket.idCustomer = customer.id;
            ticketBussines.CreateTicket(ticket);
        }
    }
}