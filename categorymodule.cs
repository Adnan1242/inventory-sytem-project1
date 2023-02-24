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
    public partial class categorymodule : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-945LDU2\SQLEXPRESS;Initial Catalog=userDBD;Integrated Security=True");

        SqlCommand cm = new SqlCommand();
        public categorymodule()
        {
            InitializeComponent();
        }

        private void btncatsave_Click(object sender, EventArgs e)
        {

            try
            {

                if (MessageBox.Show("Are you sure to save this this Category?", "Saving Record",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO cattable(catname)" +
                        "VALUES(@catname)", conn);
                    cm.Parameters.AddWithValue("@catname", textBoxcatname.Text);

                 
                    conn.Open();
                    cm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("category has been successfully saved");
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
            textBoxcatname.Clear();
        }

        private void btncatclear_Click(object sender, EventArgs e)
        {
            clear();
            btncatsave.Enabled = true;
            btncatupdate.Enabled = false;
        }

        private void pictureBoxcross_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btncatupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this category?", "update Record",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE cattable SET catname = @catname WHERE catid LIKE '" + labelcatid.Text + "' ", conn);

                    cm.Parameters.AddWithValue("@catname", textBoxcatname.Text);
                 

                    conn.Open();
                    cm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("category has been successfully updated");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
