using System;
using System.Windows;
using System.Windows.Controls;

namespace תורת_אמת_בוורד_3._1._3.Models
{
    internal class OptionsWindow : Window
    {
        public int ClickedButton { get; private set; } // Changed to int

        public OptionsWindow(string textBlockContent, params string[] buttonContents)
        {
            CreateUI(textBlockContent, buttonContents);
        }

        private void CreateUI(string textBlockContent, params string[] buttonContents)
        {
            // Create a grid to hold the text block and buttons
            Grid grid = new Grid();

            // Define the rows and columns for the grid
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) }); // TextBlock row
            for (int i = 0; i < buttonContents.Length / 2; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) }); // Button row
            }
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            // Create a text block
            TextBlock textBlock = new TextBlock()
            {
                Text = textBlockContent,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Thickness(3),
            };
            Grid.SetRow(textBlock, 0);
            Grid.SetColumnSpan(textBlock, 2);

            // Create buttons
            int buttonIndex = 0;
            for (int row = 1; row < grid.RowDefinitions.Count; row++)
            {
                for (int col = 0; col < grid.ColumnDefinitions.Count; col++)
                {
                    if (buttonIndex < buttonContents.Length && !string.IsNullOrEmpty(buttonContents[buttonIndex]))
                    {
                        Button button = new Button() 
                        {
                            Content = buttonContents[buttonIndex] ,
                            Tag = buttonIndex + 1,
                            Background = null ,
                        };
                        button.Click += Button_Click;
                        Grid.SetRow(button, row);
                        Grid.SetColumn(button, col);
                        grid.Children.Add(button);
                    }
                    buttonIndex++;
                }
            }

            // Add controls to the grid
            grid.Children.Add(textBlock);

            // Set the grid as the content of the window
            Content = grid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ClickedButton = (int)button.Tag; // Store the number of the clicked button
            DialogResult = true; // Set DialogResult to true to indicate that a button was clicked
            Close(); // Close the window
        }
    }
}
