using System;
using System.Drawing;
using System.Windows.Forms;
namespace Lab12
{
    public partial class Form1 : Form
    {

        TextBox textbox = new TextBox();
        string Symbol = String.Empty;
        bool IsEnter = false; // для очистки текстбокса при вводе второго операнда
        double Operand1 = 0, Operand2 = 0; // operands
        private bool Operand2IsSet = false; // для запоминания второго операнда для многократных вычислений

        public Form1()
        {
            InitializeComponent();
            //создание текстбокса
            textbox.Location = new Point(11, 10);
            textbox.ReadOnly = true;
            textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            textbox.Width = 155;
            textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Controls.Add(textbox);

            //создание кнопки "+/-"
            Button btn_sign = new Button();
            btn_sign.Text = "+/-";
            btn_sign.Location = new Point(11, 35);
            btn_sign.Size = new Size(35, 35);
            btn_sign.Click += ButtonClick;
            btn_sign.Width = 50;
            btn_sign.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            Controls.Add(btn_sign);

            //создание кнопки "C"
            Button btn_clear = new Button();
            btn_clear.Text = "C";
            btn_clear.Location = new Point(115, 35);
            btn_clear.Size = new Size(35, 35);
            btn_clear.Click += ButtonClick;
            btn_clear.Width = 50;
            btn_clear.ForeColor = Color.Brown;
            btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            Controls.Add(btn_clear);

            //создание кнопки .
            Button button_point = new Button();
            button_point.Text = ".";
            button_point.Size = new Size(35, 35);
            button_point.Location = new Point(51, 195);
            this.Controls.Add(button_point);
            button_point.Click += ButtonClick;
            
            //создание кнопки 0
            Button button_zero = new Button();
            button_zero.Text = "0";
            button_zero.Size = new Size(35, 35);
            button_zero.Location = new Point(11, 195);
            this.Controls.Add(button_zero);
            button_zero.Click += ButtonClick;
            button_zero.ForeColor = Color.DarkRed;
            button_zero.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            
            //создание кнопок цифр 1-9
            int counter = 7;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button();
                    button.Text = counter.ToString();
                    button.Size = new Size(35, 35);
                    button.Location = new Point(j * 40 + 11, i * 40 + 75);
                    Controls.Add(button);
                    button.Click += ButtonClick;
                    button.ForeColor = Color.DarkRed;
                    button.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    counter++;
                }
                counter -= 6;
            }

            //создание кнопки "=" 
            Button btn_res = new Button();
            btn_res.Text = "=";
            btn_res.Location = new Point(91, 195);
            btn_res.Size = new Size(35, 35);
            btn_res.Click += ButtonClick;
            this.Controls.Add(btn_res);

            //создание кнопки "+"
            Button btn_add = new Button();
            btn_add.Text = "+";
            btn_add.Location = new Point(131, 195);
            btn_add.Size = new Size(35, 35);
            btn_add.Click += ButtonClick;
            this.Controls.Add(btn_add);

            //создание кнопки "-"
            Button btn_sub = new Button();
            btn_sub.Text = "-";
            btn_sub.Location = new Point(131, 155);
            btn_sub.Size = new Size(35, 35);
            btn_sub.Click += ButtonClick;
            this.Controls.Add(btn_sub);

            //создание кнопки "*"
            Button btn_mul = new Button();
            btn_mul.Text = "*";
            btn_mul.Location = new Point(131, 115);
            btn_mul.Size = new Size(35, 35);
            btn_mul.Click += ButtonClick;
            this.Controls.Add(btn_mul);

            //создание кнопки "/"
            Button btn_div = new Button();
            btn_div.Text = "/";
            btn_div.Location = new Point(131, 75);
            btn_div.Size = new Size(35, 35);
            btn_div.Click += ButtonClick;
            this.Controls.Add(btn_div);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (IsEnter)
            {
                IsEnter = false;
                textbox.Text = "";
            }
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    ButtonAction(btn, new EventArgs());
                    return;
                case "=":
                    ButtonResult(btn, new EventArgs());
                    return;
                case "C":
                    ButtonReset(btn, new EventArgs());
                    return;
                case "+/-":
                    ButtonSign(btn, new EventArgs());
                    return;
            }
            textbox.Text += btn.Text;

        }

        private void ButtonAction(object sender, EventArgs e)
        {
            Operand1 = double.Parse(textbox.Text);
            Symbol = (sender as Button)?.Text;
            IsEnter = true;
            Operand2IsSet = false;
        }

        private void ButtonResult(object sender, EventArgs e)
        {
            if (!Operand2IsSet)
            {
                Operand2 = double.Parse(textbox.Text);
                Operand2IsSet = true;
            }

            switch (Symbol)
            {
                case "+":
                    Operand1 += Operand2;
                    textbox.Text = (Operand1).ToString(); break;
                case "-":
                    Operand1 -= Operand2;
                    textbox.Text = (Operand1).ToString(); break;
                case "*":
                    Operand1 *= Operand2;
                    textbox.Text = (Operand1).ToString(); break;
                case "/":
                    Operand1 /= Operand2;
                    textbox.Text = (Operand1).ToString(); break;
            }
        }

        private void ButtonReset(object sender, EventArgs e)
        {
            Symbol = String.Empty;
            IsEnter = false;
            Operand1 = Operand2 = 0;
            textbox.Text = "";
        }

        private void ButtonSign(object sender, EventArgs e)
        {
            double num = double.Parse(textbox.Text);
            num *= (-1);
            textbox.Text = num.ToString();
        }
    }
}