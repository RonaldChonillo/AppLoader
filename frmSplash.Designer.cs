namespace AppLoader
{
    partial class frmSplash
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplash));
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniLoadTest = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFwV = new System.Windows.Forms.Label();
            this.lblOsV = new System.Windows.Forms.Label();
            this.lblErrorInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.lblInfo.ForeColor = System.Drawing.Color.Black;
            this.lblInfo.Location = new System.Drawing.Point(22, 184);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(670, 18);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "...";
            // 
            // lblInfo2
            // 
            this.lblInfo2.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo2.ForeColor = System.Drawing.Color.White;
            this.lblInfo2.Location = new System.Drawing.Point(22, 9);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(420, 20);
            this.lblInfo2.TabIndex = 2;
            this.lblInfo2.Text = "F7 para iniciar aplicación de prueba.";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniLoadTest});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(258, 26);
            // 
            // mniLoadTest
            // 
            this.mniLoadTest.Name = "mniLoadTest";
            this.mniLoadTest.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mniLoadTest.Size = new System.Drawing.Size(257, 22);
            this.mniLoadTest.Text = "Cargar datos version de prueba";
            this.mniLoadTest.Click += new System.EventHandler(this.mniLoadTest_Click);
            // 
            // lblFwV
            // 
            this.lblFwV.BackColor = System.Drawing.Color.Transparent;
            this.lblFwV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFwV.ForeColor = System.Drawing.Color.White;
            this.lblFwV.Location = new System.Drawing.Point(22, 152);
            this.lblFwV.Name = "lblFwV";
            this.lblFwV.Size = new System.Drawing.Size(420, 15);
            this.lblFwV.TabIndex = 3;
            this.lblFwV.Text = "$$$";
            // 
            // lblOsV
            // 
            this.lblOsV.BackColor = System.Drawing.Color.Transparent;
            this.lblOsV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOsV.ForeColor = System.Drawing.Color.White;
            this.lblOsV.Location = new System.Drawing.Point(22, 169);
            this.lblOsV.Name = "lblOsV";
            this.lblOsV.Size = new System.Drawing.Size(420, 15);
            this.lblOsV.TabIndex = 4;
            this.lblOsV.Text = "$$$";
            this.lblOsV.Click += new System.EventHandler(this.lblOsV_Click);
            // 
            // lblErrorInfo
            // 
            this.lblErrorInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorInfo.ForeColor = System.Drawing.Color.Black;
            this.lblErrorInfo.Location = new System.Drawing.Point(22, 202);
            this.lblErrorInfo.Name = "lblErrorInfo";
            this.lblErrorInfo.Size = new System.Drawing.Size(670, 18);
            this.lblErrorInfo.TabIndex = 5;
            this.lblErrorInfo.Text = "...";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(583, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "V 3.0";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::AppLoader.Properties.Resources.screenshot_578_4;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(410, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 141);
            this.panel1.TabIndex = 7;
            // 
            // frmSplash
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(704, 225);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblErrorInfo);
            this.Controls.Add(this.lblOsV);
            this.Controls.Add(this.lblFwV);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblInfo2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSplash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSplash_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mniLoadTest;
        private System.Windows.Forms.Label lblFwV;
        private System.Windows.Forms.Label lblOsV;
        private System.Windows.Forms.Label lblErrorInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}

