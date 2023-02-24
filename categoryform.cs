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
    public partial class categoryform : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-945LDU2\SQLEXPRESS;Initial Catalog=userDBD;Integrated Security=True");

        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public categoryform()
        {
            InitializeComponent();
            Loadcat();
        }
        public void Loadcat()
        {
            int i = 0;
        datagridcat.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM cattable", conn);
            conn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
               datagridcat.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void btncadd_Click(object sender, EventArgs e)
        {
            categorymodule categ = new categorymodule();
            categ.btncatsave.Enabled = true;
            categ.btncatupdate.Enabled = false;
            categ.ShowDialog();
            Loadcat();
        }

        private void datagridcat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = datagridcat.Columns[e.ColumnIndex].Name;
            if (colname == "edit")
            {
                categorymodule catmodule = new categorymodule();
                catmodule.labelcatid.Text = datagridcat.Rows[e.RowIndex].Cells[1].Value.ToString();
               catmodule.textBoxcatname.Text = datagridcat.Rows[e.RowIndex].Cells[2].Value.ToString();
              


                 catmodule.btncatsave.Enabled = false;
                 catmodule.btncatupdate.Enabled = true;
                 catmodule.ShowDialog();
            }
            else if (colname == "delete")
            {
                if (MessageBox.Show("Are you sure you want delete this Category?", " delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cm = new SqlCommand(" DELETE FROM cattable WHERE catid LIKE'" + datagridcat.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Record has been successfully deleted!");
                    conn.Close();
                }
            }
            Loadcat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure to delete the entire table?", "deleting Record",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cm = new SqlCommand(" DELETE  cattable " , conn);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Records has been successfully deleted!");
                    conn.Close();
                    Loadcat();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
