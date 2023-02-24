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
    public partial class orderform : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-945LDU2\SQLEXPRESS;Initial Catalog=userDBD;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public orderform()
        {
            InitializeComponent();
            loadorder();
        }
        public void loadorder()
        {
            double total = 0;
            int i = 0;
            datagridorder.Rows.Clear();
            cm = new SqlCommand("SELECT orderid,orderdate,discount,granttotal,O.pid,P.pname,C.cid,C.cname,qty,price,total FROM orderTable AS O JOIN customertable AS C on O.cid=C.cid JOIN protable AS P on O.pid=P.pid  WHERE CONCAT(orderid,orderdate,O.pid,P.pname,C.cid,C.cname,qty,price) LIKE '%"+ordersearchtext.Text+"%'", conn);
            conn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                datagridorder.Rows.Add(i, dr[0].ToString(),Convert.ToDateTime(dr[1].ToString()).ToString("d/MM/yyyy"), dr[6].ToString(), dr[7].ToString(), dr[4].ToString(), dr[5].ToString(),dr[9].ToString(), dr[8].ToString(),dr[10].ToString());

                total += Convert.ToInt32(dr[10].ToString());

                //  datagridorder.Rows.Add(i, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("d/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());


            }
            dr.Close();
            conn.Close();
            lblqty.Text = i.ToString();
            lbltotal.Text= total.ToString();
        }

        private void btncadd_Click(object sender, EventArgs e)
        {
            Ordermodeule frm = new Ordermodeule();
            frm.btninsert.Enabled = true;
            frm.btnudate.Enabled = false;
            frm.ShowDialog();
            loadorder();

        }

        private void pictureBoxcross_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void datagridorder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = datagridorder.Columns[e.ColumnIndex].Name;
            if (colname == "view")
            {
               OrderView usermd = new OrderView();
                usermd.oumoid.Text = datagridorder.Rows[e.RowIndex].Cells[1].Value.ToString();
                usermd.oumcname.Text = datagridorder.Rows[e.RowIndex].Cells[4].Value.ToString();
                usermd.oumpname.Text = datagridorder.Rows[e.RowIndex].Cells[6].Value.ToString();
                usermd.oumprice.Text = datagridorder.Rows[e.RowIndex].Cells[7].Value.ToString();
               usermd.oumpqty.Text = datagridorder.Rows[e.RowIndex].Cells[8].Value.ToString();
                usermd.oumtotal.Text = datagridorder.Rows[e.RowIndex].Cells[9].Value.ToString();
                usermd.oumcid.Text = datagridorder.Rows[e.RowIndex].Cells[3].Value.ToString();
                usermd.datebox.Text = datagridorder.Rows[e.RowIndex].Cells[2].Value.ToString();
                usermd.ShowDialog();

            }

            if (colname == "delete")
            {
                if (MessageBox.Show("Are you sure you want delete this order?", " delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cm = new SqlCommand(" DELETE FROM orderTable WHERE orderid LIKE'" + datagridorder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Order has been successfully deleted!");
                    conn.Close();
                }
            }
            loadorder();

        }

        private void ordersearchtext_TextChanged(object sender, EventArgs e)
        {
            loadorder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure to delete the entire Order table?", "deleting customer Record",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cm = new SqlCommand(" DELETE  orderTable ", conn);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Records has been successfully deleted!");
                    conn.Close();
                    loadorder();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
