using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_sytem_project1
{
    public partial class welcome_form : Form
    {
        public welcome_form()
        {
            InitializeComponent();
            timer1.Start();
        }
        int startpoint = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 4;
            progressBar1.Value = startpoint;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
             Form1 frml = new Form1();
                this.Hide();
                frml.ShowDialog();
            }
        }

      
    }
}
