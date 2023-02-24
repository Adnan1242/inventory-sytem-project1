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
    public partial class UserModule : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-945LDU2\SQLEXPRESS;Initial Catalog=userDBD;Integrated Security=True");
      
        SqlCommand cm = new SqlCommand();
     
       
        public UserModule()
        {
            InitializeComponent();
        }
        
        private void pictureBoxcross_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        private void buttonsave_Click(object sender, EventArgs e)
        {
           
            try
            {
               
                if (textBoxpassword.Text != textBoxrepass.Text)
                {
                    MessageBox.Show("Password did not match","warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
              if (MessageBox.Show("Are you sure to save this this user?", "Saving Record",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO userformtb(username,fullname,password,phone)" +
                        "VALUES(@username,@fullname,@password,@phone)", conn);
                    cm.Parameters.AddWithValue("@username", textBoxusername.Text);
                    cm.Parameters.AddWithValue("@fullname", textBoxfullname.Text);
                    cm.Parameters.AddWithValue("@password", textBoxpassword.Text);
                    cm.Parameters.AddWithValue("@phone", textBoxphone.Text);
                    conn.Open();
                    cm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("User has been successfully saved");
                    Clear();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            Clear();
            buttonsave.Enabled = true;
            buttonupdate.Enabled = false;
        }
        public void Clear()
        { 
            textBoxusername.Clear();
            textBoxfullname.Clear();
            textBoxpassword.Clear();
            textBoxphone.Clear();
        }

        private void buttonupdate_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (textBoxpassword.Text != textBoxrepass.Text)
                {
                    MessageBox.Show("Password did not match", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to update this user?", "update Record",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE userformtb SET username=@username, fullname = @fullname, password = @password, phone=@phone WHERE username LIKE '" +textBoxusername.Text+ "' ",conn);
                    cm.Parameters.AddWithValue("@username", textBoxusername.Text);
                    cm.Parameters.AddWithValue("@fullname", textBoxfullname.Text);
                    cm.Parameters.AddWithValue("@password", textBoxpassword.Text);
                    cm.Parameters.AddWithValue("@phone", textBoxphone.Text);
                    conn.Open();
                    cm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("User has been successfully update");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBoxcross_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}