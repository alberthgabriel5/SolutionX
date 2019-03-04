using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SolutionX.DomainEntities;
using SolutionX.BussinesLayer;

using System.Data;

namespace SolutionX
{
    public partial class viewCoordinator 
    {
        Category category = new Category();
        Ticket ticket = new Ticket();
        CategoryBussines categoryBussines = new CategoryBussines();
        Priority prioritys = new Priority();
        PriorityBussines priorityBussines = new PriorityBussines();
        TicketBussines TicketBussines = new TicketBussines();
        DropDownList listC = new DropDownList();
        DropDownList listP = new DropDownList();
        Button button = new Button();

        TableRow r = new TableRow();
        TableCell code = new TableCell();
        TableCell dateCreate = new TableCell();
        TableCell description = new TableCell();
        TableCell categoryC = new TableCell();
        TableCell priorityC = new TableCell();
        TableCell buttonC = new TableCell();

        protected void Page_Load(object sender, EventArgs e)
        {

            List<Ticket> listTicket = TicketBussines.UnassignedTicket();
            List<Category> list = categoryBussines.ListCategory();
            List<Priority> listPr = priorityBussines.ListPriority();
            foreach (Category cate in list)
            {
                listC.Items.Add(cate.idCategory + cate.name);
            }

            foreach (Priority prio in listPr)
            {
                listP.Items.Add(prio.idPriority + prio.namePriority);
            }

            code.Controls.Add(new LiteralControl("Code"));

            r.Cells.Add(code);

            dateCreate.Controls.Add(new LiteralControl("Date create"));
            r.Cells.Add(dateCreate);

            description.Controls.Add(new LiteralControl("Description"));
            r.Cells.Add(description);


            categoryC.Controls.Add(new LiteralControl("Category"));
            r.Cells.Add(categoryC);


            priority.Controls.Add(new LiteralControl("Priority"));
            r.Cells.Add(priority);

            buttonC.Controls.Add(new LiteralControl("Save"));
            r.Cells.Add(buttonC);

            customers.Rows.Add(r);

            foreach (Ticket ti in listTicket)
            {
                listC = new DropDownList();
                listP = new DropDownList();
                button = new Button();
                r = new TableRow();
                code = new TableCell();
                dateCreate = new TableCell();
                description = new TableCell();
                categoryC = new TableCell();
                priorityC = new TableCell();
                buttonC = new TableCell();
                listC.Items.Add("--");
                listP.Items.Add("--");
                foreach (Category cate in list)
                {
                    listC.Items.Add(cate.idCategory + "  " + cate.name);
                }

                foreach (Priority prio in listPr)
                {
                    listP.Items.Add(prio.idPriority + "  " + prio.namePriority);
                }
                categoryC.Controls.Add(listC);
                r.Cells.Add(categoryC);
                button.Text = "Save";
                button.Enabled = true;
                button.FindControl("Code");
                button.Click += new System.EventHandler(Save);
                button.ForeColor = System.Drawing.Color.Silver;
                button.Font.Size = 9;
                button.BackColor = System.Drawing.Color.Blue;
                button.Width = 120;
                button.Height = 30;

                priorityC.Controls.Add(listP);
                r.Cells.Add(priorityC);

                buttonC.Controls.Add(button);
                r.Cells.Add(buttonC);

                code.Controls.Add(new LiteralControl(ti.idCode + ""));
                code.ID = ti.idCode.ToString();
                Console.WriteLine("P " + code.ID.ToString());
                r.Cells.Add(code);

                dateCreate.Controls.Add(new LiteralControl(ti.dateCreate + ""));
                r.Cells.Add(dateCreate);


                description.Controls.Add(new LiteralControl(ti.description + ""));
                r.Cells.Add(description);

                categoryC.Controls.Add(listC);
                r.Cells.Add(categoryC);


                priorityC.Controls.Add(listP);
                r.Cells.Add(priorityC);

                buttonC.Controls.Add(button);
                r.Cells.Add(buttonC);

                customers.Rows.Add(r);


            }

            r.FindControl("Code");
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button bt = (Button)sender;

            string s = r.Controls.ToString();

            string cat = listC.SelectedItem.Text;
            string prio = listP.SelectedItem.Text;
            Console.WriteLine(s + cat + customers.NamingContainer);

        }

        protected void Save(object sender, EventArgs e)
        {
            string s = customers.AccessKey.ToString();

            string cat = listC.SelectedItem.Text;
            string prio = listP.SelectedItem.Text;
            Console.WriteLine(s + cat + prio);

        }
    }
}