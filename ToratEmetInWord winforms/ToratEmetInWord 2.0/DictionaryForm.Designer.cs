namespace ToratEmetInWord_2._0
{
    partial class DictionaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DictionaryForm));
            this.translateHebrewToAramaic = new System.Windows.Forms.RadioButton();
            this.TranslateAramaicToHebrew = new System.Windows.Forms.RadioButton();
            this.hebrewListbox = new System.Windows.Forms.ListBox();
            this.hebrewTextBox = new System.Windows.Forms.TextBox();
            this.aramaicListbox = new System.Windows.Forms.ListBox();
            this.aramaicTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // translateHebrewToAramaic
            // 
            this.translateHebrewToAramaic.AutoSize = true;
            this.translateHebrewToAramaic.Location = new System.Drawing.Point(334, 344);
            this.translateHebrewToAramaic.Name = "translateHebrewToAramaic";
            this.translateHebrewToAramaic.Size = new System.Drawing.Size(134, 24);
            this.translateHebrewToAramaic.TabIndex = 14;
            this.translateHebrewToAramaic.Text = "עברית לארמית";
            this.translateHebrewToAramaic.UseVisualStyleBackColor = true;
            // 
            // TranslateAramaicToHebrew
            // 
            this.TranslateAramaicToHebrew.AutoSize = true;
            this.TranslateAramaicToHebrew.Location = new System.Drawing.Point(19, 344);
            this.TranslateAramaicToHebrew.Name = "TranslateAramaicToHebrew";
            this.TranslateAramaicToHebrew.Size = new System.Drawing.Size(134, 24);
            this.TranslateAramaicToHebrew.TabIndex = 13;
            this.TranslateAramaicToHebrew.Text = "ארמית לעברית";
            this.TranslateAramaicToHebrew.UseVisualStyleBackColor = true;
            // 
            // hebrewListbox
            // 
            this.hebrewListbox.FormattingEnabled = true;
            this.hebrewListbox.ItemHeight = 20;
            this.hebrewListbox.Location = new System.Drawing.Point(334, 54);
            this.hebrewListbox.Name = "hebrewListbox";
            this.hebrewListbox.Size = new System.Drawing.Size(300, 284);
            this.hebrewListbox.TabIndex = 12;
            // 
            // hebrewTextBox
            // 
            this.hebrewTextBox.Location = new System.Drawing.Point(334, 11);
            this.hebrewTextBox.Name = "hebrewTextBox";
            this.hebrewTextBox.Size = new System.Drawing.Size(300, 26);
            this.hebrewTextBox.TabIndex = 11;
            // 
            // aramaicListbox
            // 
            this.aramaicListbox.FormattingEnabled = true;
            this.aramaicListbox.ItemHeight = 20;
            this.aramaicListbox.Location = new System.Drawing.Point(19, 54);
            this.aramaicListbox.Name = "aramaicListbox";
            this.aramaicListbox.Size = new System.Drawing.Size(300, 284);
            this.aramaicListbox.TabIndex = 10;
            // 
            // aramaicTextBox
            // 
            this.aramaicTextBox.Location = new System.Drawing.Point(19, 11);
            this.aramaicTextBox.Name = "aramaicTextBox";
            this.aramaicTextBox.Size = new System.Drawing.Size(300, 26);
            this.aramaicTextBox.TabIndex = 9;
            // 
            // DictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 378);
            this.Controls.Add(this.translateHebrewToAramaic);
            this.Controls.Add(this.TranslateAramaicToHebrew);
            this.Controls.Add(this.hebrewListbox);
            this.Controls.Add(this.hebrewTextBox);
            this.Controls.Add(this.aramaicListbox);
            this.Controls.Add(this.aramaicTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(675, 434);
            this.MinimumSize = new System.Drawing.Size(675, 434);
            this.Name = "DictionaryForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "מילון ארמי עברי";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton translateHebrewToAramaic;
        private System.Windows.Forms.RadioButton TranslateAramaicToHebrew;
        private System.Windows.Forms.ListBox hebrewListbox;
        private System.Windows.Forms.TextBox hebrewTextBox;
        private System.Windows.Forms.ListBox aramaicListbox;
        private System.Windows.Forms.TextBox aramaicTextBox;
    }
}