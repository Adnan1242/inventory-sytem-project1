using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_sytem_project1
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }
        // to show subform in main form
        private Form activeform = null;
        private void openchildform(Form childform)
        {
            if(activeform!=null)
                activeform.Close();
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle= FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            paneluser.Controls.Add(childform);
            paneluser.Tag= childform;
            childform.BringToFront();
            childform.Show();
        }
        private void btnusers_Click(object sender, EventArgs e)
        {
            openchildform(new userform());
        }

        private void btncustomer_Click(object sender, EventArgs e)
        {
            openchildform(new Customerform());
        }

        private void btcatogory_Click(object sender, EventArgs e)
        {
            openchildform(new categoryform());
        }

        private void btnproduct_Click(object sender, EventArgs e)
        {
            openchildform(new productform());
        }

        private void btnorders_Click(object sender, EventArgs e)
        {
            openchildform(new orderform());
        }

       
    }
}
