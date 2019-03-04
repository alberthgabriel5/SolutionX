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
    public partial class ViewClient : System.Web.UI.Page
    {
        TicketBussines ticketBussines = new TicketBussines();
        CustomerBussines customerBussines = new CustomerBussines();        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblName.Text = Session["Name"].ToString() + " "+ Session["LastName"].ToString();
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
            Ticket ticket = new Ticket()
            {
                description = txDesc.Value,
                idCustomer = int.Parse(Session["id"].ToString())
            };
            string textInfo = ticketBussines.CreateTicket(ticket);
            if(textInfo== "success")
            {
                lblAnswer.CssClass = "alert alert-success";
                lblAnswer.Text = "Your request was registered";
                txDesc.Value = "";
            }
            else
            {
                lblAnswer.CssClass = "alert alert-danger";
                lblAnswer.Text = textInfo.ToString();
            }
        }
    }
}