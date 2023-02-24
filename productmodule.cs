using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_sytem_project1
{
    public partial class productmodule : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-945LDU2\SQLEXPRESS;Initial Catalog=userDBD;Integrated Security=True");

        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public productmodule()
        {
            InitializeComponent();
            loadcategory();
        }
        public void loadcategory()
        {
            comboBoxprocat.Items.Clear();
            cm = new SqlCommand("SELECT  catname FROM cattable", conn);
            conn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboBoxprocat.Items.Add(dr[0].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void pictureBoxcross_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonprosave_Click(object sender, EventArgs e)
        {

            try
            {

                if (MessageBox.Show("Are you sure to save this product", "Saving Record",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO protable (pname,pqty,pprice,pdescription,pcategory)" +
                        "VALUES(@pname,@pqty,@pprice,@pdescription,@pcategory)", conn);
                    cm.Parameters.AddWithValue("@pname", textBoxproname.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(textBoxproqty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt32(textBoxproprice.Text));
                    cm.Parameters.AddWithValue("@pdescription", textBoxprodisc.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboBoxprocat.Text);
                    conn.Open();
                    cm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Product has been successfully saved");
                    Clear();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void Clear()
        {
            textBoxproname.Clear();
            textBoxproqty.Clear();
            textBoxproprice.Clear();
            textBoxprodisc.Clear();
        }

        private void buttonproupdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure you want to update this product?", "update product Record",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
   {
  cm = new SqlCommand("UPDATE protable SET pname = @pname, pqty = @pqty, pprice = @pprice, pdescription = @pdescription, " +
                      "pcategory = @pcategory WHERE pid LIKE '" + labelpid.Text + "'", conn);

                    cm.Parameters.AddWithValue("@pname", textBoxproname.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(textBoxproqty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt32(textBoxproprice.Text));
                    cm.Parameters.AddWithValue("@pdescription", textBoxprodisc.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboBoxprocat.Text);
                    conn.Open();
                    cm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("product has been successfully update");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonproclear_Click(object sender, EventArgs e)
        {
            Clear();
            buttonprosave.Enabled = true;
            buttonproupdate.Enabled = false;
        }
    }
}
