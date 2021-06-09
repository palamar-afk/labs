using System;
using System.Windows;
using System.Text.Json;
using System.IO;

namespace Lab19
{
    public partial class MainWindow : Window
    {
        private string fileName = @"C:\Users\Fiede\Desktop\data.json";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void WriteDataButton_OnClick(object sender, RoutedEventArgs e)
        {
            DataFromWindow data = new DataFromWindow();
            data.CheckBox1 = (bool)check1.IsChecked;
            data.CheckBox2 = (bool)check2.IsChecked;
            data.CheckBox3 = (bool)check3.IsChecked;

            data.TextFieldContent = TextBoxContent.Text;

            data.ScreenHeight = Height;
            data.ScreenWidth = Width;

            string json = JsonSerializer.Serialize(data);
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(fileName))
                {
                    string settings = JsonSerializer.Serialize(data);
                    streamWriter.Write(settings);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Не удалось записать файл!");
            }
        }
    }
}