using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        TextBox textBox = new TextBox();
        const string pathToFolder = @"C:\Users\Fiede\source\repos\BlackJack\BlackJack\";

        public Form1()
        {
            InitializeComponent();

            Text = "BlackJack - v0.1beta";
            BackgroundImage = Image.FromFile(@"C:\Users\Fiede\source\repos\BlackJack\BlackJack\background.jpg");
            Width = 800;
            Height = 500;

            Button startButton = new Button();
            startButton.Location = new Point(30, 30);
            startButton.Size = new Size(100, 40);
            startButton.Text = "Начать игру";
            startButton.Click += StartGame;
            Controls.Add(startButton);

            Button giveCardButton = new Button();
            giveCardButton.Location = new Point(150, 30);
            giveCardButton.Size = new Size(100, 40);
            giveCardButton.Text = "Выдать карту";
            giveCardButton.Click += GiveCard;
            Controls.Add(giveCardButton);

            Button stopButton = new Button();
            stopButton.Location = new Point(270, 30);
            stopButton.Size = new Size(100, 40);
            stopButton.Text = "Стоп-игра";
            stopButton.Click += StopGame;
            Controls.Add(stopButton);

            Button resetButton = new Button();
            resetButton.Location = new Point(570, 100);
            resetButton.Size = new Size(100, 40);
            resetButton.Text = "Заново";
            resetButton.Click += ResetGame;
            Controls.Add(resetButton);


            textBox.Location = new Point(Width - 350, Height - 450);
            textBox.Size = new Size(300, 200);
            Controls.Add(textBox);
        }

        private List<Card> CardsOfUser = new List<Card>();

        private List<Card> CardsOfBanker = new List<Card>();

        private List<int> UsedCards = new List<int>();

        Random random = new Random();
        private int sumPlayerCards = 0;
        private int sumBankerCards = 0;

        List<PictureBox> playerBox = new List<PictureBox>();
        List<PictureBox> bankerBox = new List<PictureBox>();

        private List<Card> DeckOfCards = new List<Card>()
        {
            new Card() {Name = "Две пики", Image = "2S.png", Number = 2},
            new Card() {Name = "Три пики", Image = "3S.png", Number = 3},
            new Card() {Name = "Четыре пики", Image = "4S.png", Number = 4},
            new Card() {Name = "Пять пики", Image = "5S.png", Number = 5},
            new Card() {Name = "Шесть пики", Image = "6S.png", Number = 6},
            new Card() {Name = "Семь пики", Image = "7S.png", Number = 7},
            new Card() {Name = "Восемь пики", Image = "8S.png", Number = 8},
            new Card() {Name = "Девять пики", Image = "9S.png", Number = 9},
            new Card() {Name = "Десять пики", Image = "10S.png", Number = 10},
            new Card() {Name = "Валет пики", Image = "JS.png", Number = 10},
            new Card() {Name = "Дама пики", Image = "QS.png", Number = 10},
            new Card() {Name = "Король пики", Image = "KS.png", Number = 10},
            new Card() {Name = "Туз пики", Image = "AS.png", Number = 11},


            new Card() {Name = "Две бубны", Image = "2D.png", Number = 2},
            new Card() {Name = "Три бубны", Image = "3D.png", Number = 3},
            new Card() {Name = "Четыре бубны", Image = "4D.png", Number = 4},
            new Card() {Name = "Пять бубны", Image = "5D.png", Number = 5},
            new Card() {Name = "Шесть бубны", Image = "6D.png", Number = 6},
            new Card() {Name = "Семь бубны", Image = "7D.png", Number = 7},
            new Card() {Name = "Восемь бубны", Image = "8D.png", Number = 8},
            new Card() {Name = "Девять бубны", Image = "9D.png", Number = 9},
            new Card() {Name = "Десять бубны", Image = "10D.png", Number = 10},
            new Card() {Name = "Валет бубны", Image = "JD.png", Number = 10},
            new Card() {Name = "Дама бубны", Image = "QD.png", Number = 10},
            new Card() {Name = "Король бубны", Image = "KD.png", Number = 10},
            new Card() {Name = "Туз бубны", Image = "AD.png", Number = 11},


            new Card() {Name = "Две трефы", Image = "2C.png", Number = 2},
            new Card() {Name = "Три трефы", Image = "3C.png", Number = 3},
            new Card() {Name = "Четыре трефы", Image = "4C.png", Number = 4},
            new Card() {Name = "Пять трефы", Image = "5C.png", Number = 5},
            new Card() {Name = "Шесть трефы", Image = "6C.png", Number = 6},
            new Card() {Name = "Семь трефы", Image = "7C.png", Number = 7},
            new Card() {Name = "Восемь трефы", Image = "8C.png", Number = 8},
            new Card() {Name = "Девять трефы", Image = "9C.png", Number = 9},
            new Card() {Name = "Десять трефы", Image = "10C.png", Number = 10},
            new Card() {Name = "Валет трефы", Image = "JC.png", Number = 10},
            new Card() {Name = "Дама трефы", Image = "QC.png", Number = 10},
            new Card() {Name = "Король трефы", Image = "KC.png", Number = 10},
            new Card() {Name = "Туз трефы", Image = "AC.png", Number = 11},


            new Card() {Name = "Две червы", Image = "2H.png", Number = 2},
            new Card() {Name = "Три червы", Image = "3H.png", Number = 3},
            new Card() {Name = "Четыре червы", Image = "4H.png", Number = 4},
            new Card() {Name = "Пять червы", Image = "5H.png", Number = 5},
            new Card() {Name = "Шесть червы", Image = "6H.png", Number = 6},
            new Card() {Name = "Семь червы", Image = "7H.png", Number = 7},
            new Card() {Name = "Восемь червы", Image = "8H.png", Number = 8},
            new Card() {Name = "Девять червы", Image = "9H.png", Number = 9},
            new Card() {Name = "Десять червы", Image = "10H.png", Number = 10},
            new Card() {Name = "Валет червы", Image = "JH.png", Number = 10},
            new Card() {Name = "Дама червы", Image = "QH.png", Number = 10},
            new Card() {Name = "Король червы", Image = "KH.png", Number = 10},
            new Card() {Name = "Туз червы", Image = "AH.png", Number = 11},
        };

        private int TakeRandomCard(Random random) => random.Next(0, DeckOfCards.Count);

        private void StartGame(object sender, EventArgs e)
        {
            if (sumPlayerCards > 0 || sumBankerCards > 0)
            {
                textBox.Text = "Игра уже начата. Играйте!";
                return;
            }

            int randomNumberCard = TakeRandomCard(random);
            Card card1 = DeckOfCards[randomNumberCard];
            UsedCards.Add(randomNumberCard);
            CardsOfUser.Add(card1);

            randomNumberCard = TakeRandomCard(random);
            while (UsedCards.Contains(randomNumberCard))
            {
                randomNumberCard = TakeRandomCard(random);
            }

            Card card2 = DeckOfCards[randomNumberCard];
            CardsOfUser.Add(card2);            

            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Image = Image.FromFile(pathToFolder + card1.Image);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Location = new Point(30, 80);
            pictureBox1.Size = new Size(71, 96);
            Controls.Add(pictureBox1);

            PictureBox pictureBox2 = new PictureBox();
            pictureBox2.Image = Image.FromFile(pathToFolder + card2.Image);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.Location = new Point(130, 80);
            pictureBox2.Size = new Size(71, 96);
            Controls.Add(pictureBox2);
            playerBox.Add(pictureBox1);
            playerBox.Add(pictureBox2);

            sumPlayerCards = SumCards(CardsOfUser);
            //для компьютера

            randomNumberCard = TakeRandomCard(random);
            while (UsedCards.Contains(randomNumberCard))
            {
                randomNumberCard = TakeRandomCard(random);
            }
            Card card3 = DeckOfCards[randomNumberCard];
            UsedCards.Add(randomNumberCard);
            CardsOfBanker.Add(card3);

            PictureBox pictureBox3 = new PictureBox();
            pictureBox3.Image = Image.FromFile(pathToFolder + card3.Image);
            pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox3.Location = new Point(30, 250);
            pictureBox3.Size = new Size(71, 96);
            bankerBox.Add(pictureBox3);

            randomNumberCard = TakeRandomCard(random);
            while (UsedCards.Contains(randomNumberCard))
            {
                randomNumberCard = TakeRandomCard(random);
            }
            Card card4 = DeckOfCards[randomNumberCard];
            UsedCards.Add(randomNumberCard);
            CardsOfBanker.Add(card4);

            PictureBox pictureBox4 = new PictureBox();
            pictureBox4.Image = Image.FromFile(pathToFolder + card4.Image);
            pictureBox4.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox4.Location = new Point(130, 250);
            pictureBox4.Size = new Size(71, 96);
            bankerBox.Add(pictureBox4);

            sumBankerCards = SumCards(CardsOfBanker);
            textBox.Text = $"Сумма ваших карт: {sumPlayerCards}";
        }

        private void GiveCard(object sender, EventArgs e)
        {
            if(sumPlayerCards == 0)
            {
                textBox.Text = "Игра не начата. Стартуем!";
                return;
            }
            else if(CardsOfUser.Count == 5)
            {
                textBox.Text = "Больше брать нельзя! Финишируем...";
                return;
            }

            sumPlayerCards = 0;

            int randomNumberCard = TakeRandomCard(random);
            while (UsedCards.Contains(randomNumberCard))
            {
                randomNumberCard = TakeRandomCard(random);
            }

            Card card = DeckOfCards[randomNumberCard];
            CardsOfUser.Add(card);
            UsedCards.Add(randomNumberCard);
            sumPlayerCards = SumCards(CardsOfUser);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(pathToFolder + card.Image);
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Location = new Point(30+((CardsOfUser.Count-1)*100), 80);
            pictureBox.Name = "pictureBox1";
            pictureBox.Size = new Size(71, 96);
            Controls.Add(pictureBox);
            playerBox.Add(pictureBox);

            textBox.Text = $"Сумма ваших карт: {sumPlayerCards}";
        }

        private void StopGame(object sender, EventArgs e)
        {
            if(sumPlayerCards == 0)
            {
                textBox.Text = "Игра еще не начата!";
                return;
            }
            sumBankerCards = 0;
            sumBankerCards = SumCards(CardsOfBanker);
            int multiplier = 2; // счетчик для правильного отображения картинок
            while(sumBankerCards < 17)
            {
                if(CardsOfBanker.Count >= 5)
                {
                    break;
                }
                int randomNumberCard = TakeRandomCard(random);
                while (UsedCards.Contains(randomNumberCard))
                {
                    randomNumberCard = TakeRandomCard(random);
                }
                Card card = DeckOfCards[randomNumberCard];
                UsedCards.Add(randomNumberCard);
                CardsOfBanker.Add(card);
                sumBankerCards = SumCards(CardsOfBanker);

                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Image.FromFile(pathToFolder + card.Image);
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox.Location = new Point(30+100*multiplier, 250);
                pictureBox.Size = new Size(71, 96);
                bankerBox.Add(pictureBox);
                
                multiplier++;
            }

            foreach(PictureBox pb in bankerBox)
            {
                Controls.Add(pb);
            }

            sumBankerCards = SumCards(CardsOfBanker);
            textBox.Text = $"Ваши очки:{sumPlayerCards}. Очки противника: {sumBankerCards}";

            if(sumBankerCards > 21 && sumPlayerCards < sumBankerCards)
            {
                MessageBox.Show($"Вы выиграли!!! Вы:{sumPlayerCards}, Противник:{sumBankerCards}", "BlackJack", MessageBoxButtons.OK);
            }
            else if(sumBankerCards < sumPlayerCards && sumBankerCards < 21 && sumPlayerCards < 21)
            {
                MessageBox.Show($"Вы выиграли!!! Вы:{sumPlayerCards}, Противник:{sumBankerCards}", "BlackJack", MessageBoxButtons.OK);
            }
            else if(sumBankerCards != sumPlayerCards && sumPlayerCards == 21)
            {
                MessageBox.Show($"Вы выиграли!!! Вы:{sumPlayerCards}, Противник:{sumBankerCards}", "BlackJack", MessageBoxButtons.OK);
            }
            else if(sumBankerCards > sumPlayerCards && sumPlayerCards < 21 && sumBankerCards > 21)
            {
                MessageBox.Show($"Вы выиграли!!! Вы:{sumPlayerCards}, Противник:{sumBankerCards}", "BlackJack", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show($"Вы проиграли!!! Вы:{sumPlayerCards}, Противник:{sumBankerCards}", "BlackJack", MessageBoxButtons.OK);
            }
            ResetGame(new object(), new EventArgs());
        }

        private void ResetGame(object sender, EventArgs e)
        {
            foreach (PictureBox pb in playerBox)
            {
                Controls.Remove(pb);
            }
            foreach (PictureBox pb in bankerBox)
            {
                Controls.Remove(pb);
            }

            bankerBox.Clear();
            playerBox.Clear();
            
            sumBankerCards = 0;
            sumPlayerCards = 0;

            CardsOfUser.Clear();
            CardsOfBanker.Clear();
            UsedCards.Clear();
            textBox.Text = String.Empty;
        }

        private int SumCards(List<Card> deck)
        {
            int sum = 0;
            foreach(Card card in deck)
            {
                sum += card.Number;
            }
            if (sum > 21)
            {
                foreach(Card card in deck)
                {
                    if(card.Number == 11)
                    {
                        sum -= 10;
                        if (sum <= 21)
                        {
                            break;
                        }
                    }
                    
                }
            }
            return sum;
        }
    }
}
