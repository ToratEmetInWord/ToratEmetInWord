using System;
using System.Drawing;
using System.Windows.Forms;

namespace ToratEmetInWord_2._0
{
    public partial class FontSettings : Form
    {
        public Font SelectedFont { get; private set; }
        int fontsize = Properties.Settings.Default.fontSize;
        decimal linespacing = Properties.Settings.Default.fontlineSpacing;


        public FontSettings()
        {
            InitializeComponent();
            searchFontsBox.TextChanged += SearchFontsBox_TextChanged;
            fontListBox.SelectedIndexChanged += FontListBox_SelectedIndexChanged;

            // Populate the fontListBox with available fonts
            foreach (FontFamily fontFamily in FontFamily.Families)
            {
                fontListBox.Items.Add(fontFamily.Name);
            }
            numericUpDown1.Value = fontsize;
            numericUpDown2.Value = linespacing;
            SelectedFont = new Font(Properties.Settings.Default.fontName, 15); // Set a default size
            previewBox.Font = SelectedFont;
            previewBox.Text = "תצוגה\r\nמקדימה";
        }

        private void FontListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFontName = fontListBox.SelectedItem as string;
            if (selectedFontName != null)
            {
                SelectedFont = new Font(selectedFontName, 15); // Set a default size
                previewBox.Font = SelectedFont;
            }
        }

        private void SearchFontsBox_TextChanged(object sender, EventArgs e)
        {     
        string searchText = searchFontsBox.Text.ToLower(); // Convert search text to lowercase
            fontListBox.Items.Clear();

            // Filter and display fonts that match the search text (case-insensitive)
            foreach (FontFamily fontFamily in FontFamily.Families)
            {
                if (fontFamily.Name.ToLower().Contains(searchText))
                {
                    fontListBox.Items.Add(fontFamily.Name);
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.fontName = SelectedFont.Name;
            Properties.Settings.Default.fontSize = fontsize;
            Properties.Settings.Default.fontlineSpacing = linespacing;
            Properties.Settings.Default.Save();
            this.Dispose();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            fontsize = (int)numericUpDown1.Value; // Explicit cast from decimal to int
            // Assuming numericUpDown1 is set to Decimal, you can convert it to float.
            ///*previewBox.Font = new Font(previewBox.Font.FontFamily, (float)fontsize - 15*/);            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            linespacing = numericUpDown2.Value;
        }

    }
}
