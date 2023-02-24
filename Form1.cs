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
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-945LDU2\SQLEXPRESS;Initial Catalog=userDBD;Integrated Security=True");

        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxpass.Checked == false)
            {
                textBoxpass.UseSystemPasswordChar = true;
            }
            else
                textBoxpass.UseSystemPasswordChar = false;
        }


        private void label3_Click(object sender, EventArgs e)
        {
            textBoxname.Clear();
            textBoxpass.Clear();
        }

        private void pictureBoxcross_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("exit apliication","Confirm",MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes){
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
              cm =new SqlCommand("SELECT * FROM userformtb WHERE username=@username AND password = @password",conn);
                cm.Parameters.AddWithValue("username", textBoxname.Text);
                cm.Parameters.AddWithValue("password", textBoxpass.Text);
                conn.Open();
                dr = cm.ExecuteReader();
                dr.Read();
             
              
                if (dr.HasRows)
                {
                    MessageBox.Show("Welcome " + dr["username" ].ToString() + " | ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mainform main = new mainform();
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid username or Password! ","ACCESS DENIED",MessageBoxButtons.OK,MessageBoxIcon.Information);   
                }

                conn.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
