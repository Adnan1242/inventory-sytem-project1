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
    public partial class userform : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-945LDU2\SQLEXPRESS;Initial Catalog=userDBD;Integrated Security=True");

        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public userform()
        {
            InitializeComponent();
            LoadUser();
        }
        public void LoadUser()
        {
            int i = 0;
            datagriduser.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM userformtb", conn);
            conn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                datagriduser.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            conn.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            UserModule usermd = new UserModule();
            usermd.buttonsave.Enabled = true; 
            usermd.buttonupdate.Enabled = false;
            usermd.ShowDialog();
            LoadUser();
        }

        private void datagriduser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = datagriduser.Columns[e.ColumnIndex].Name;
            if(colname == "edit")
            {
                UserModule usermd =new UserModule();
                usermd.textBoxusername.Text = datagriduser.Rows[e.RowIndex].Cells[1].Value.ToString();
                usermd.textBoxfullname.Text = datagriduser.Rows[e.RowIndex].Cells[2].Value.ToString();
                usermd.textBoxpassword.Text = datagriduser.Rows[e.RowIndex].Cells[3].Value.ToString();
                usermd.textBoxphone.Text = datagriduser.Rows[e.RowIndex].Cells[4].Value.ToString();
               
                usermd.buttonsave.Enabled = false;
                usermd.buttonupdate.Enabled = true;
                usermd.textBoxusername.Enabled= false;
                usermd.ShowDialog();
              

            }
            else if(colname == "delete")
            {
                if(MessageBox.Show("Are you sure you want delete this user?"," delete record",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cm= new SqlCommand(" DELETE FROM userformtb WHERE username LIKE'"+ datagriduser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'",conn);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Record has been successfully deleted!");
                    conn.Close();
                }
            }
            LoadUser();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
