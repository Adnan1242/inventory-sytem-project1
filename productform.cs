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
    public partial class productform : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-945LDU2\SQLEXPRESS;Initial Catalog=userDBD;Integrated Security=True");

        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public productform()
        {
            InitializeComponent();
            Loadproduct();
        }
        public void Loadproduct()
        {
            int i = 0;
           datagridpro.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM protable WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE '%"+searchtext.Text+"%'", conn);
            conn.Open();
            dr = cm.ExecuteReader();
           
            while (dr.Read())
            {
                i++;
                datagridpro.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            conn.Close();
        }
        private void btncadd_Click(object sender, EventArgs e)
        {
            productmodule prom = new productmodule();
            prom.buttonprosave.Enabled = true;
            prom.buttonproupdate.Enabled = false;
            prom.ShowDialog();
            Loadproduct();

        }

        private void datagridpro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = datagridpro.Columns[e.ColumnIndex].Name;
            if (colname == "edit")
            {
                productmodule usermd = new productmodule();
                usermd.labelpid.Text = datagridpro.Rows[e.RowIndex].Cells[1].Value.ToString();
                usermd.textBoxproname.Text = datagridpro.Rows[e.RowIndex].Cells[2].Value.ToString();
                usermd.textBoxproqty.Text = datagridpro.Rows[e.RowIndex].Cells[3].Value.ToString();
                usermd.textBoxproprice.Text = datagridpro.Rows[e.RowIndex].Cells[4].Value.ToString();
                usermd.textBoxprodisc.Text = datagridpro.Rows[e.RowIndex].Cells[5].Value.ToString();
                usermd.comboBoxprocat.Text = datagridpro.Rows[e.RowIndex].Cells[6].Value.ToString();
 

                usermd.buttonprosave.Enabled = false;
                usermd.buttonproupdate.Enabled = true;
                usermd.ShowDialog();


            }
            else if (colname == "delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Item?", " delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cm = new SqlCommand(" DELETE FROM protable WHERE pid LIKE'" + datagridpro.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Item has been successfully deleted!");
                    conn.Close();
                }
            }
            Loadproduct();
        }

        private void searchtext_TextChanged(object sender, EventArgs e)
        {
            
                Loadproduct();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure to delete the entire Product table?", "deleting product Record",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cm = new SqlCommand(" DELETE  proTable ", conn);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Records has been successfully deleted!");
                    conn.Close();
                    Loadproduct();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

