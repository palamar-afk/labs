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
using System.Windows.Threading;

namespace Lab17
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int Step = 10;
        private int MinBorderGap = 50;
        private int GapFromBorder = 50;
        private bool ShowName = false;
        private string TitleText = "Натисніть кнопку OK!!!";
        private int TimerCount = 0;
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();

            CancelButton.Click += (s, e) => Close();
            MainButton.Click += (s, e) =>
            {
                MessageBox.Show("Молодець!!!");
            };
            timer = new DispatcherTimer();
 
            timer.Tick += TimerTick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        
        private void MouseHover(object sender, EventArgs e)
        {
            double MouseX = PointToScreen(Mouse.GetPosition(this)).X;
            double MouseY = PointToScreen(Mouse.GetPosition(this)).Y;

            double WinX = PointToScreen(new Point(0, 0)).X;
            double WinY = PointToScreen(new Point(0, 0)).Y;
            
            
            double AreaX = HoverArea.PointToScreen(new Point(0, 0)).X+1;
            double AreaY = HoverArea.PointToScreen(new Point(0, 0)).Y;
            if (MainButton.Height <= 0)
            {
                MessageBox.Show("Кнопку ОК теперь нажать нельзя!!!");
                MainGrid.Children.Remove(HoverArea);
                return;
            }
                
            if ((MouseX == AreaX && MouseY <= AreaY + HoverArea.Height / 2) ||
                (MouseY == AreaY && MouseX <= AreaX + HoverArea.Width / 2))  //левый верхний
            {
                HoverArea.Margin = new Thickness(HoverArea.Margin.Left+Step,HoverArea.Margin.Top+Step, HoverArea.Margin.Right-Step, HoverArea.Margin.Bottom-Step);
                MainButton.Height -= 2;
            }
            else if ((MouseX >= AreaX + HoverArea.Width - 50 && MouseY <= AreaY + HoverArea.Height / 2) ||
                     (MouseY == AreaY && MouseX > AreaX + HoverArea.Width / 2)) // правый верхний
            {
                HoverArea.Margin = new Thickness(HoverArea.Margin.Left-Step,HoverArea.Margin.Top+Step, HoverArea.Margin.Right+Step, HoverArea.Margin.Bottom-Step);
                MainButton.Height -= 2;
            }
            else if ((MouseX == AreaX + HoverArea.Width && MouseY > AreaY + HoverArea.Height / 2) ||
                     (MouseY <= AreaY + HoverArea.Height && MouseX >= AreaX + HoverArea.Width / 2)) // правый нижний
            {
                HoverArea.Margin = new Thickness(HoverArea.Margin.Left-Step,HoverArea.Margin.Top-Step, HoverArea.Margin.Right+Step, HoverArea.Margin.Bottom+Step);
                MainButton.Height -= 2;
            }
            else if ((MouseX == AreaX && MouseY >= AreaY + HoverArea.Height / 2) ||
                     (MouseY == AreaY + HoverArea.Height  && MouseX < AreaX + HoverArea.Width / 2)) // левый нижний
            {
                HoverArea.Margin = new Thickness(HoverArea.Margin.Left+Step,HoverArea.Margin.Top-Step, HoverArea.Margin.Right-Step, HoverArea.Margin.Bottom+Step);
                MainButton.Height -= 2;
            }
            
            if (AreaX < WinX+MinBorderGap)
            {
                HoverArea.Margin = new Thickness(
                    HoverArea.Margin.Left+GapFromBorder,
                    HoverArea.Margin.Top,
                    HoverArea.Margin.Right-GapFromBorder,
                    HoverArea.Margin.Bottom);
            }
            if (AreaX + HoverArea.Width > WinX + Width + MinBorderGap)
            {
                HoverArea.Margin = new Thickness(
                    HoverArea.Margin.Left-GapFromBorder,
                    HoverArea.Margin.Top,
                    HoverArea.Margin.Right+GapFromBorder,
                    HoverArea.Margin.Bottom);
                
            }
            if (AreaY < WinY+MinBorderGap)
            {
                HoverArea.Margin = new Thickness(
                    HoverArea.Margin.Left,
                    HoverArea.Margin.Top+GapFromBorder,
                    HoverArea.Margin.Right,
                    HoverArea.Margin.Bottom-GapFromBorder);
            }
            if (AreaY + HoverArea.Height > WinY + Height + MinBorderGap)
            {
                HoverArea.Margin = new Thickness(
                    HoverArea.Margin.Left,
                    HoverArea.Margin.Top-GapFromBorder,
                    HoverArea.Margin.Right,
                    HoverArea.Margin.Bottom+GapFromBorder);            
            }
        }
        private void OkMouseMove(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                HoverArea.Margin = new Thickness(
                    HoverArea.Margin.Left+Step*3,
                    HoverArea.Margin.Top+Step*3, 
                    HoverArea.Margin.Right-Step*3, 
                    HoverArea.Margin.Bottom-Step*3);

                MainButton.Height -= 2;
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if(ShowName)
            {
                Application.Current.MainWindow.Title = "";
                ShowName = false;
            }
            else
            {
               Application.Current.MainWindow.Title = TitleText;
               ShowName = true;
            }

            if(TimerCount == 8)
            {
                Application.Current.MainWindow.Title = TitleText;
                TimerCount = 0;
                timer.Stop();
            }
            
            TimerCount++;
        }
    }
    
}