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
    public partial class Customerform : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-945LDU2\SQLEXPRESS;Initial Catalog=userDBD;Integrated Security=True");

        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Customerform()
        {
            InitializeComponent();
            Loadcustomer();
        }
        public void Loadcustomer()
        {
            int i = 0;
            datagridcustomer.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM customertable", conn);
            conn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                datagridcustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            customermodule customer = new customermodule();
            customer.btncsave.Enabled = true;
            customer.btncupdate.Enabled = false;
            customer.ShowDialog();
            Loadcustomer();
        }
       
        private void datagridcustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = datagridcustomer.Columns[e.ColumnIndex].Name;
            if (colname == "edit")
            {
                customermodule ctmr = new customermodule();
                ctmr.labelcid.Text = datagridcustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                ctmr.textBoxcustomername.Text = datagridcustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                ctmr.textBoxcustomerphone.Text = datagridcustomer.Rows[e.RowIndex].Cells[3].Value.ToString();


                ctmr.btncsave.Enabled = false;
                ctmr.btncupdate.Enabled = true;
                ctmr.ShowDialog();
            }
            else if (colname == "delete")
            {
                if (MessageBox.Show("Are you sure you want delete this customer?", " delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cm = new SqlCommand(" DELETE FROM customertable WHERE cid LIKE'" + datagridcustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Record has been successfully deleted!");
                    conn.Close();
                }
            }
            Loadcustomer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure to delete the entire Customer table?", "deleting customer Record",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cm = new SqlCommand(" DELETE  customertable ", conn);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Records has been successfully deleted!");
                    conn.Close();
                    Loadcustomer();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }

 