using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab13
{
    public partial class Form1 : Form
    {
        private int PreviousNumber = 1; // для проверки правильности нажатия кнопок на вкладке 2 и для сужения диапазона генерируемых случайных чисел
        
        public Form1()
        {
            InitializeComponent();
            textBox1.BackColor = Color.Coral;
            textBox1.BackColor = Color.Coral;
            textBox1.Font = new Font("Segoe UI", 10f);

            // tab page 1 - start
            button1.Text = "Додати";
            button1.Click += delegate { comboBox1.Items.Add(textBox1.Text);  }; //для простоты не выносил в отдельный метод

            button2.Text = "Видалити";
            button2.Click += delegate
            {
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.Items.RemoveAt(0);
                }
            };
            // tab page 1 - end

            // tab page 2 - start
            GenerateMatrix();
            textBox2.BackColor = Color.Chartreuse;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // tab page 2 - end
        }

        private void BtnClick(object sender, EventArgs e)
        {
            int indexList = 0;
            Button button = sender as Button;

            if (button.Text != PreviousNumber.ToString())
            {
                PreviousNumber = 1;
                panel1.Controls.Clear();
                GenerateMatrix();
                return;
            }

            panel1.Controls.Remove(button);
            List<int> list = RandomNumsCreate(PreviousNumber + 1);// сужаем здесь диапазон генерации(в качестве оптимизации
            if (list.Count == 0)
            {
                GenerateMatrix();
                textBox2.Text = "Молодець!!!";
                PreviousNumber = 1;
                return;
            }
            PreviousNumber++;
            foreach (Button btn in this.panel1.Controls)
            {
                btn.Text = list[indexList].ToString();
                indexList++;
            }
        }

        private void GenerateMatrix()
        {
            Panel panel = panel1;

            int counter = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button btn = new Button();
                    btn.Width = 40;
                    btn.Height = 20;
                    btn.Location = new Point(j * 50 + 40, i * 40 + 20);
                    btn.Text = counter.ToString();
                    btn.Click += BtnClick;
                    panel1.Controls.Add(btn);
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