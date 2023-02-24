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
    public partial class Ordermodeule : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-945LDU2\SQLEXPRESS;Initial Catalog=userDBD;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public Ordermodeule()
        {
            InitializeComponent();
            Loadcustomer();
            Loadproduct();
        }

        private void pictureBoxcross_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void Loadcustomer()
        {
            int i = 0;
            datagridcustomer.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM customertable WHERE CONCAT(cid,cname) LIKE '%"+csbox.Text+"%'", conn);
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
        public void Loadproduct()
        {
            int i = 0;
            datagridpro.Rows.Clear();

            cm = new SqlCommand("SELECT * FROM protable WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE '%"+psbox.Text+"%'", conn);
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
        private void csbox_TextChanged(object sender, EventArgs e)
        {
            Loadcustomer();
        }

      



        private void datagridcustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          textcid.Text = datagridcustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            textcname.Text = datagridcustomer.Rows[e.RowIndex].Cells[2].Value.ToString();

        }
        private void psbox_TextChanged(object sender, EventArgs e)
        {
            Loadproduct();
        }
        int qty = 0;
        private void datagridpro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textpid.Text = datagridpro.Rows[e.RowIndex].Cells[1].Value.ToString();
            textpname.Text = datagridpro.Rows[e.RowIndex].Cells[2].Value.ToString();
            textprice.Text = datagridpro.Rows[e.RowIndex].Cells[4].Value.ToString();
            qty = Convert.ToInt16(datagridpro.Rows[e.RowIndex].Cells[3].Value.ToString());
            Loadproduct();
        }

        private void textqty_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(textqty.Value) > qty)
            {
                MessageBox.Show("Stock Quantity is Not Enough", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textqty.Value--;
                return;
            }
            if (Convert.ToInt16(textqty.Value) > 0)
            {

                int total = Convert.ToInt32(textprice.Text) * Convert.ToInt16(textqty.Value);
                texttotal.Text = total.ToString();

            
            }
        }
     



        private void btninsert_Click(object sender, EventArgs e)
        {
            try
            {

                if (textcid.Text == "")
                {
                   MessageBox.Show("Please select Customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textpid.Text == "")
                {
                 MessageBox.Show("Please select Product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

          
                if (MessageBox.Show("Are you sure to insert this order?", "Saving Record",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO orderTable (orderdate,pid,cid,qty,price,total,pname,cname)" +
                   "VALUES(@orderdate,@pid,@cid,@qty,@price,@total,@pname,@cname)", conn);

                    cm.Parameters.AddWithValue("@orderdate", orderdate.Value);
                    // cm.Parameters.AddWithValue("@pid", Convert.ToInt16(textpid.Text));
                    // cm.Parameters.AddWithValue("@cid", Convert.ToInt16(textcid.Text));
                    cm.Parameters.AddWithValue("@pid", textpid.Text);
                    cm.Parameters.AddWithValue("@cid", textcid.Text);
                    cm.Parameters.AddWithValue("@qty", textqty.Text);
                    //  cm.Parameters.AddWithValue("@qty", Convert.ToInt16(textqty.Value));
                    cm.Parameters.AddWithValue("@price", textprice.Text);
                    // cm.Parameters.AddWithValue("@price", Convert.ToInt32(textprice.Text));
                    cm.Parameters.AddWithValue("@total", Convert.ToInt32(texttotal.Text));
                    cm.Parameters.AddWithValue("@pname", textpname.Text);
                    cm.Parameters.AddWithValue("@cname", textcname.Text);

                    conn.Open();
                    cm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Order has been successfully inserted");

                    cm = new SqlCommand("UPDATE protable SET pqty=(pqty-@pqty) WHERE pid LIKE '" + textpid.Text + "'", conn);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(textqty.Value));

                    conn.Open();
                    cm.ExecuteNonQuery();
                    conn.Close();
                    clear();
                

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void clear()
        {
            textcid.Clear();
            textcname.Clear();

            textpid.Clear();
            textpname.Clear();

            textprice.Clear();
            textqty.Value = 1;
            texttotal.Clear();
        
            orderdate.Value = DateTime.Now;
                
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
            btninsert.Enabled = true;
            btnudate.Enabled = false;
           
            
        }

    }
}
