using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SolutionX.DomainEntities;
using SolutionX.BussinesLayer;

namespace SolutionX
{
    public partial class viewAdm : System.Web.UI.Page
    {
        EmployeeBussines employeeBussines = new EmployeeBussines();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Employee> listEmployee = employeeBussines.ListEmployee();
            TableRow r = new TableRow();
            TableCell c = new TableCell();
            TableCell f = new TableCell();
            TableCell g = new TableCell();
            TableCell m = new TableCell();

            c.Controls.Add(new LiteralControl("Code"));
            r.Cells.Add(c);

            f.Controls.Add(new LiteralControl("Employee name"));
            r.Cells.Add(f);

            g.Controls.Add(new LiteralControl("Last name "));
            r.Cells.Add(g);


            m.Controls.Add(new LiteralControl("Role"));
            r.Cells.Add(m);

            customers.Rows.Add(r);

            foreach (Employee em in listEmployee) {
                r = new TableRow();
                c = new TableCell();
                f = new TableCell();
                g = new TableCell();
                m = new TableCell();
                c.Controls.Add(new LiteralControl(em.id+""));
                r.Cells.Add(c);

                f.Controls.Add(new LiteralControl(em.name));
                r.Cells.Add(f);

                g.Controls.Add(new LiteralControl(em.lastName));
                r.Cells.Add(g);


                customers.Rows.Add(r);
            }


        }
    }
}