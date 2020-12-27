namespace LimitlessTyres
{
    partial class frmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.pcbHome1 = new System.Windows.Forms.PictureBox();
            this.pcbHome2 = new System.Windows.Forms.PictureBox();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.lblHome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbHome1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbHome2)).BeginInit();
            this.pnlHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcbHome1
            // 
            this.pcbHome1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbHome1.Image = ((System.Drawing.Image)(resources.GetObject("pcbHome1.Image")));
            this.pcbHome1.Location = new System.Drawing.Point(12, 12);
            this.pcbHome1.Name = "pcbHome1";
            this.pcbHome1.Size = new System.Drawing.Size(770, 320);
            this.pcbHome1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcbHome1.TabIndex = 2;
            this.pcbHome1.TabStop = false;
            // 
            // pcbHome2
            // 
            this.pcbHome2.Image = ((System.Drawing.Image)(resources.GetObject("pcbHome2.Image")));
            this.pcbHome2.Location = new System.Drawing.Point(576, 338);
            this.pcbHome2.Name = "pcbHome2";
            this.pcbHome2.Size = new System.Drawing.Size(206, 145);
            this.pcbHome2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbHome2.TabIndex = 0;
            this.pcbHome2.TabStop = false;
            // 
            // pnlHome
            // 
            this.pnlHome.BackColor = System.Drawing.Color.LightGray;
            this.pnlHome.Controls.Add(this.lblHome);
            this.pnlHome.Location = new System.Drawing.Point(12, 338);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(558, 145);
            this.pnlHome.TabIndex = 5;
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.lblHome.Location = new System.Drawing.Point(3, 10);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(438, 119);
            this.lblHome.TabIndex = 0;
            this.lblHome.Text = resources.GetString("lblHome.Text");
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(794, 491);
            this.Controls.Add(this.pnlHome);
            this.Controls.Add(this.pcbHome1);
            this.Controls.Add(this.pcbHome2);
            this.Name = "frmHome";
            this.Text = "frmHome";
            this.Load += new System.EventHandler(this.frmHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbHome1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbHome2)).EndInit();
            this.pnlHome.ResumeLayout(false);
            this.pnlHome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pcbHome1;
        private System.Windows.Forms.PictureBox pcbHome2;
        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.Label lblHome;
    }
}