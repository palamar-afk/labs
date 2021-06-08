using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab16
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int PreviousNumber = 1;
        
        public MainWindow()
        {
            InitializeComponent();
            GenerateMatrix();
        }

        private void ButtonAdd_CLick(object sender, EventArgs e)
        {
            if (InputField.Text != String.Empty)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = InputField.Text;
                InputField.Text = String.Empty;
                MainComboxBox.Items.Add(textBlock);
            }
        }
        private void ButtonRemove_CLick(object sender, EventArgs e)
        {
            if (MainComboxBox.Items.Count > 0)
            {
                MainComboxBox.Items.RemoveAt(MainComboxBox.Items.Count-1);
            }
        }
        
        private void ButtonNumber_Click(object sender, EventArgs e)
        {
            int indexList = 0;
            Button button = sender as Button;

            if (button.Content.ToString() != PreviousNumber.ToString())
            {
                PreviousNumber = 1;
                WrapPanelBox.Children.Clear();
                GenerateMatrix();
                return;
            }

            WrapPanelBox.Children.Remove(button);
            List<int> list = RandomNumsCreate(PreviousNumber + 1);// сужаем здесь диапазон генерации(в качестве оптимизации
            if (list.Count == 0)
            {
                GenerateMatrix();
                MessageBox.Show("Молодець!!!");
                PreviousNumber = 1;
                return;
            }
            PreviousNumber++;
            foreach (Button _button in WrapPanelBox.Children)
            {
                _button.Content = list[indexList].ToString();
                indexList++;
            }
        }
        private void GenerateMatrix()
        {
            int counter = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button button = new Button()
                    {
                        Margin = new Thickness(0, 0, 10, 10),
                        Width = 60,
                        Height = 60,
                        Content = counter.ToString()
                    };
                    button.Click += ButtonNumber_Click;
                    WrapPanelBox.Children.Add(button);
                    counter++;
                }
            }
        }
        private List<int> RandomNumsCreate(int a, int b=17)
        {
            List<int> nums = new List<int>();
            Random rand = new Random();
            int num = rand.Next(a, b);
            while (nums.Count < (b-a))
            {
                while (nums.Contains(num))
                {
                    num = rand.Next(a, b);
                }
                nums.Add(num);
            }
            return nums;
        }
    }
}