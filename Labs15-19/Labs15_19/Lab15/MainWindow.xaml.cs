using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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

namespace Lab15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double FirstOperand = 0;
        private double SecondOperand = 0;
        private String Symbol = string.Empty;
        private bool SecondOperandIsSet = false;
        private bool IsSmthEntered = false;
        public MainWindow()
        {
            InitializeComponent();
            GenerateKeyboard();
        }
        
        public void GenerateKeyboard()
        {
            for (int i = 9; i >= 0; i--)
            {
                Button button = new Button()
                {
                    Content = $"{i}",
                    Height = 60,
                    Width = 60,
                    Margin = new Thickness(6)
                };
                button.Click += WriteNumber;
                button.Background = new SolidColorBrush(Colors.Khaki);
                WrapBlock.Children.Add(button);
            }
            
            Button ButtonPlus = new Button()
            {
                Content = "+",
                Height = 60,
                Width = 60,
                Margin = new Thickness(6),
                Background = new SolidColorBrush(Colors.Bisque)
            };
            Button ButtonMinus = new Button()
            {
                Content = "-",
                Height = 60,
                Width = 60,
                Margin = new Thickness(6),
                Background = new SolidColorBrush(Colors.Bisque)
            };
            Button ButtonMultiply = new Button()
            {
                Content = "*",
                Height = 60,
                Width = 60,
                Margin = new Thickness(6),
                Background = new SolidColorBrush(Colors.Bisque)
            };
            
            Button ButtonDivide = new Button()
            {
                Content = "/",
                Height = 60,
                Width = 60,
                Margin = new Thickness(6),
                Background = new SolidColorBrush(Colors.Bisque)
            };
            ButtonPlus.Click += ChooseOperation;
            ButtonMinus.Click += ChooseOperation;
            ButtonMultiply.Click += ChooseOperation;
            ButtonDivide.Click += ChooseOperation;
                    
            WrapBlockOperations.Children.Add(ButtonPlus);
            WrapBlockOperations.Children.Add(ButtonMinus);
            WrapBlockOperations.Children.Add(ButtonMultiply);
            WrapBlockOperations.Children.Add(ButtonDivide);
            
            Button ButtonPlusMinus = new Button()
            {
                Content = "+/-",
                Height = 60,
                Width = 60,
                Margin = new Thickness(6),
                Background = new SolidColorBrush(Colors.Khaki)
            };
            ButtonPlusMinus.Click += (s, e) =>
            {
                double temp = 0;
                if (double.TryParse(TextArea.Text, out temp))
                {
                    TextArea.Text = ((-1)*temp).ToString();
                }
            };
            WrapBlock.Children.Add(ButtonPlusMinus);
            
            Button ButtonClear = new Button()
            {
                Content = "Clear",
                Height = 60,
                Width = 60,
                Margin = new Thickness(6),
                Background = new SolidColorBrush(Colors.Khaki)
            };
            ButtonClear.Click += (s, e) =>
            {
                TextArea.Text = "";
                FirstOperand = 0;
                SecondOperand = 0;
                Symbol = string.Empty;
                SecondOperandIsSet = false;
                IsSmthEntered = false;
            };
            WrapBlock.Children.Add(ButtonClear);
            
            Button ButtonGetResult = new Button()
            {
                Content = "Get Result (=)",
                Height = 40,
                Background = new SolidColorBrush(Colors.BurlyWood)
            };
            WrapBlockResult.Children.Add(ButtonGetResult);
            ButtonGetResult.Click += GetResult;
        }

        
        private void WriteNumber(object sender, EventArgs e)
        {
            IsSmthEntered = true;
            TextArea.Text += (sender as Button).Content;
        }

        private void ChooseOperation(object sender, EventArgs e)
        {
            if (!IsSmthEntered)
            {
                return;
            }
            FirstOperand = double.Parse(TextArea.Text);
            Symbol = (sender as Button).Content.ToString();
            TextArea.Text = "";
            SecondOperandIsSet = false;
        }
        private void GetResult(object sender, EventArgs e)
        {
            if (!SecondOperandIsSet && double.TryParse(TextArea.Text, out SecondOperand))
            {
                SecondOperandIsSet = true;
            }

            switch (Symbol)
            {
                case "+":
                    FirstOperand += SecondOperand;
                    TextArea.Text = FirstOperand.ToString(); break;
                case "-": 
                    FirstOperand -= SecondOperand;
                    TextArea.Text = FirstOperand.ToString(); break;
                case "*": 
                    FirstOperand *= SecondOperand;
                    TextArea.Text = FirstOperand.ToString(); break;
                case "/": 
                    FirstOperand /= SecondOperand;
                    TextArea.Text = FirstOperand.ToString(); break;
            }
        }
    }
}