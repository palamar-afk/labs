using System.Drawing;
using System.Windows.Forms;


namespace Lab14
{
    public partial class Form1 : Form
    {
        private int MouseX;
        private int MouseY;
        private const int Step = 10; //шаг перемещения кнопки
        private int CounterBlinks = 0;

        private const int BorderSize = 8;
        private const int GapFromBorder = 100;
        private const int MinBorderGap = 5;
        private bool ShowText = true;
        private Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            Text = "Нажмите кнопку ОК";

            // кнопка ОК
            button1.Text = "OK";
            button1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button1.TabStop = false;
            button1.Click += (s, e) => MessageBox.Show("Кнопка ОК нажата");
            button1.Click += (s, e) =>
            {
                timer.Stop();
                timer.Tick -= Timer_tick;
                timer.Tick += TimerTickClose;
                timer.Interval = 500;
                timer.Start();
            };
            // кнопка Cancel
            button2.Text = "Cancel";
            button2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button2.ForeColor = Color.Red;
            button2.Click += (s, e) => Close();
            ActiveControl = button2;

            // мигание названия формы

            panel1.MouseMove += PanelHover;
            panel1.MouseEnter += (s, e) => button1.Height -= 1;
            button1.MouseMove += OKMouseMove;
        }
        private void OKMouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                panel1.Location = new Point(panel1.Location.X + 10, panel1.Location.Y + 10);

                button1.Size = new Size(button1.Size.Width - 1, button1.Size.Height - 1);
            }
        }
        private void PanelHover(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            
            MouseX = MousePosition.X - this.Location.X - BorderSize;
            MouseY = MousePosition.Y - this.Location.Y - SystemInformation.CaptionHeight - BorderSize;
            Panel panel = sender as Panel;

            if (panel == null)
            {
                return;
            }
            if ((MouseX == panel1.Location.X && MouseY <= panel1.Location.Y + panel1.Height / 2) ||
                (MouseY == panel1.Location.Y && MouseX <= panel1.Location.X + panel1.Width / 2))  //левый верхний
            {
                panel.Location = new Point(panel.Location.X + Step, panel.Location.Y + Step);
            }
            else if ((MouseX == panel1.Location.X + panel1.Width - 1 && MouseY <= panel1.Location.Y + panel1.Height / 2) ||
                     (MouseY == panel1.Location.Y && MouseX > panel1.Location.X + panel1.Width / 2)) // правый верхний
            {
                panel.Location = new Point(panel.Location.X - Step, panel.Location.Y + Step);
            }
            else if ((MouseX == panel1.Location.X + panel1.Width - 1 && MouseY > panel1.Location.Y + panel1.Height / 2) ||
                     (MouseY == panel1.Location.Y + panel1.Height - 1 && MouseX >= panel1.Location.X + panel1.Width / 2)) // правый нижний
            {
                panel.Location = new Point(panel.Location.X - Step, panel.Location.Y - Step);
            }
            else if ((MouseX == panel1.Location.X && MouseY >= panel1.Location.Y + panel1.Height / 2) ||
                     (MouseY == panel1.Location.Y + panel1.Height - 1 && MouseX < panel1.Location.X + panel1.Width / 2)) // левый нижний
            {
                panel.Location = new Point(panel.Location.X + Step, panel.Location.Y - Step);
            }

//ограничения, чтобы кнопка ОК не выходила за рамки формы
            if (panel1.Location.X + panel1.Width >= this.Width - MinBorderGap)
            {
                panel.Location = new Point(panel.Location.X - GapFromBorder, panel.Location.Y);
            }
            if (panel1.Location.X < MinBorderGap)
            {
                panel.Location = new Point(panel.Location.X + GapFromBorder, panel.Location.Y);
            }
            if (panel1.Location.Y < MinBorderGap)
            {
                panel.Location = new Point(panel.Location.X, panel.Location.Y + GapFromBorder);
            }
            if (panel1.Location.Y + panel1.Height >= this.Height - SystemInformation.CaptionHeight - MinBorderGap)
            {
                panel.Location = new Point(panel.Location.X, panel.Location.Y - GapFromBorder);
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            timer.Tick += Timer_tick;
            timer.Interval = 500;
            timer.Start();
        }

        private void Timer_tick(object sender, System.EventArgs e)
        {
            if (ShowText)
            {
                Text = "";
                ShowText = false;
            }
            else
            {
                Text = "Нажмите кнопку ОК";
                ShowText = true;
            }

            if (CounterBlinks == 16)
            {
                Text = "Нажмите кнопку ОК";
                timer.Stop();
                ShowText = true;
            }

            CounterBlinks++;
        }

        private void TimerTickClose(object sender, System.EventArgs e)
        {
            if (ShowText)
            {
                Text = "";
                ShowText = false;
            }
            else
            {
                Text = "Кнопка ОК нажата";
                ShowText = true;
            }
        }


    }
}