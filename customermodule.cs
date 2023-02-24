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
    public partial class customermodule : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-945LDU2\SQLEXPRESS;Initial Catalog=userDBD;Integrated Security=True");

        SqlCommand cm = new SqlCommand();
        public customermodule()
        {
            InitializeComponent();
        }

        private void btncsave_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBoxcustomername.Text == "")
                {
                    MessageBox.Show("Please select Customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (textBoxcustomerphone.Text == "")
                {
                    MessageBox.Show("Please select the Customer cell no!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (MessageBox.Show("Are you sure to save this this Customer?", "Saving Record",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO customertable(cname,cphone)" +
                    "VALUES(@cname,@cphone)", conn);
                    cm.Parameters.AddWithValue("@cname", textBoxcustomername.Text);

                    cm.Parameters.AddWithValue("@cphone", textBoxcustomerphone.Text);
                    conn.Open();
                    cm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("User has been successfully saved");
                    clear();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } public void clear()
        {
            textBoxcustomername.Clear();
            textBoxcustomerphone.Clear();
            btncsave.Enabled = true;
            btncupdate.Enabled = false;
        }

        private void btncclear_Click(object sender, EventArgs e)
        {
            clear();
            btncsave.Enabled = true;
            btncupdate.Enabled = false;
        }

        private void pictureBoxcross_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btncupdate_Click(object sender, EventArgs e)
        {
            try {
                if (MessageBox.Show("Are you sure you want to update this Customer?", "update Record",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE customertable SET cname = @cname, cphone = @cphone WHERE cid LIKE '" + labelcid.Text + "' ", conn);

                    cm.Parameters.AddWithValue("@cname", textBoxcustomername.Text);
                    cm.Parameters.AddWithValue("@cphone", textBoxcustomerphone.Text);

                    conn.Open();
                    cm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Customer has been successfully updated");
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

