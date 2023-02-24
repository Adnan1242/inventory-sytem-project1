using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace inventory_sytem_project1
{
    public partial class OrderView : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-945LDU2\SQLEXPRESS;Initial Catalog=userDBD;Integrated Security=True");

        SqlCommand cm = new SqlCommand();
       // SqlDataReader dr;
        public OrderView()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void Clear()
        {
          
            oumpqty.Clear();
            oumprice.Clear();
            oumtotal.Clear();
        }
 
    }
    }

