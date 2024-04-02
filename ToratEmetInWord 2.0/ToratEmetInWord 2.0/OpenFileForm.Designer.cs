namespace ToratEmetInWord_2._0
{
    partial class OpenFileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenFileForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "img.icons82.png");
            this.imageList1.Images.SetKeyName(1, "redbook.png");
            this.imageList1.Images.SetKeyName(2, "slectedbook.png");
            this.imageList1.Images.SetKeyName(3, "תורת אמת2.png");
            this.imageList1.Images.SetKeyName(4, "down3.png");
            this.imageList1.Images.SetKeyName(5, "up3.png");
            this.imageList1.Images.SetKeyName(6, "magnifier2.PNG");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(428, 456);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox1);
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(420, 423);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "חפש ספר";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(3, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(414, 385);
            this.listBox1.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(414, 32);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.button3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(414, 28);
            this.panel5.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(40, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(374, 26);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "דוגמא לחיפוש: בראשית (א,יא)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(27, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = " ";
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ImageIndex = 6;
            this.button3.ImageList = this.imageList1;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 28);
            this.button3.TabIndex = 0;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(420, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ספרי תורת אמת";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 1;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeView1.RightToLeftLayout = true;
            this.treeView1.SelectedImageIndex = 2;
            this.treeView1.Size = new System.Drawing.Size(414, 417);
            this.treeView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(420, 423);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "הספרים שלי";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // treeView2
            // 
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.ImageIndex = 1;
            this.treeView2.ImageList = this.imageList1;
            this.treeView2.Location = new System.Drawing.Point(3, 3);
            this.treeView2.Name = "treeView2";
            this.treeView2.RightToLeftLayout = true;
            this.treeView2.SelectedImageIndex = 2;
            this.treeView2.Size = new System.Drawing.Size(414, 417);
            this.treeView2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 24);
            this.panel1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.ImageIndex = 1;
            this.label2.Location = new System.Drawing.Point(348, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(80, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "פתח ספר";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CloseButton
            // 
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CloseButton.Location = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(24, 24);
            this.CloseButton.TabIndex = 14;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // OpenFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "OpenFileForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(428, 480);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBox1;
    }
}