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
    public partial class ControlButton : PictureBox
    {
        public ControlButton()
        {
            InitializeComponent();
        }
        private Image NormalImage;
        private Image HoverImage;
        public Image ImageNormal 
        {
            get { return NormalImage; }
            set { NormalImage = value; }    

        }
        public Image ImageHover
        {
            get { return HoverImage; }
            set { HoverImage = value; }

        }

        private void ControlButton_MouseHover(object sender, EventArgs e)
        {
            this.Image = HoverImage;
        }

        private void ControlButton_MouseLeave(object sender, EventArgs e)
        {
            this.Image = NormalImage;
        }
    }
}
