namespace inventory_sytem_project1
{
    partial class categorymodule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(categorymodule));
            this.btncatclear = new System.Windows.Forms.Button();
            this.btncatupdate = new System.Windows.Forms.Button();
            this.btncatsave = new System.Windows.Forms.Button();
            this.textBoxcatname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxcross = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelcatid = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxcross)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btncatclear
            // 
            this.btncatclear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btncatclear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btncatclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncatclear.ForeColor = System.Drawing.Color.Transparent;
            this.btncatclear.Location = new System.Drawing.Point(385, 139);
            this.btncatclear.Name = "btncatclear";
            this.btncatclear.Size = new System.Drawing.Size(75, 23);
            this.btncatclear.TabIndex = 37;
            this.btncatclear.Text = "Clear";
            this.btncatclear.UseVisualStyleBackColor = false;
            this.btncatclear.Click += new System.EventHandler(this.btncatclear_Click);
            // 
            // btncatupdate
            // 
            this.btncatupdate.BackColor = System.Drawing.Color.Blue;
            this.btncatupdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btncatupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncatupdate.ForeColor = System.Drawing.Color.Transparent;
            this.btncatupdate.Location = new System.Drawing.Point(304, 139);
            this.btncatupdate.Name = "btncatupdate";
            this.btncatupdate.Size = new System.Drawing.Size(75, 23);
            this.btncatupdate.TabIndex = 36;
            this.btncatupdate.Text = "Update";
            this.btncatupdate.UseVisualStyleBackColor = false;
            this.btncatupdate.Click += new System.EventHandler(this.btncatupdate_Click);
            // 
            // btncatsave
            // 
            this.btncatsave.BackColor = System.Drawing.Color.Black;
            this.btncatsave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btncatsave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btncatsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncatsave.ForeColor = System.Drawing.Color.Transparent;
            this.btncatsave.Location = new System.Drawing.Point(223, 139);
            this.btncatsave.Name = "btncatsave";
            this.btncatsave.Size = new System.Drawing.Size(75, 23);
            this.btncatsave.TabIndex = 35;
            this.btncatsave.Text = "Save";
            this.btncatsave.UseVisualStyleBackColor = false;
            this.btncatsave.Click += new System.EventHandler(this.btncatsave_Click);
            // 
            // textBoxcatname
            // 
            this.textBoxcatname.Location = new System.Drawing.Point(179, 98);
            this.textBoxcatname.Name = "textBoxcatname";
            this.textBoxcatname.Size = new System.Drawing.Size(327, 21);
            this.textBoxcatname.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(64, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "Category Name:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 192);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(615, 29);
            this.panel2.TabIndex = 30;
            // 
            // pictureBoxcross
            // 
            this.pictureBoxcross.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxcross.Image")));
            this.pictureBoxcross.Location = new System.Drawing.Point(583, 0);
            this.pictureBoxcross.Name = "pictureBoxcross";
            this.pictureBoxcross.Size = new System.Drawing.Size(32, 27);
            this.pictureBoxcross.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxcross.TabIndex = 11;
            this.pictureBoxcross.TabStop = false;
            this.pictureBoxcross.Click += new System.EventHandler(this.pictureBoxcross_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Category Module";
            // 
            // labelcatid
            // 
            this.labelcatid.AutoSize = true;
            this.labelcatid.Location = new System.Drawing.Point(90, 144);
            this.labelcatid.Name = "labelcatid";
            this.labelcatid.Size = new System.Drawing.Size(72, 16);
            this.labelcatid.TabIndex = 38;
            this.labelcatid.Text = "Category ID";
            this.labelcatid.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.pictureBoxcross);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 68);
            this.panel1.TabIndex = 29;
            // 
            // categorymodule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 221);
            this.Controls.Add(this.btncatclear);
            this.Controls.Add(this.btncatupdate);
            this.Controls.Add(this.btncatsave);
            this.Controls.Add(this.textBoxcatname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelcatid);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "categorymodule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "categorymodule";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxcross)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btncatclear;
        public System.Windows.Forms.Button btncatupdate;
        public System.Windows.Forms.Button btncatsave;
        public System.Windows.Forms.TextBox textBoxcatname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxcross;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelcatid;
        private System.Windows.Forms.Panel panel1;
    }
}