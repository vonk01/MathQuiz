using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace MathQuiz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int plusA;
        int plusB;
        int answerPlus;

        int minusA;
        int minusB;
        int answerMinus;

        int multiA;
        int multiB;
        int answerMulti;

        double divideA;
        double divideB;
        double answerDivide;

        private void RandomNumber()
        {
            Random randomV = new Random();
            plusA = randomV.Next(-90, 99);
            plusB = randomV.Next(-90, 99);

            minusA = randomV.Next(-90, 100);
            minusB = randomV.Next(-90, 100);

            multiA = randomV.Next(-15, 15);
            multiB = randomV.Next(-15, 15);

            divideA = randomV.Next(1, 100);
            divideB = randomV.Next(1, 10);
        }

        private void AnswerNumber()
        {
            RandomNumber();
            answerPlus = plusA + plusB;
            answerMinus = minusA - minusB;
            answerMulti = multiA * multiB;
            answerDivide = Math.Round(divideA / divideB, 2);
        }

        private void LabelText()
        {
            PlusLeftLabel.Content = Convert.ToString(plusA);
            PlusRightLabel.Content = Convert.ToString(plusB);

            MinusLeftLabel.Content = Convert.ToString(minusA);
            MinusRightLabel.Content = Convert.ToString(minusB);

            MultiLeftLabel.Content = Convert.ToString(multiA);
            MultiRightLabel.Content = Convert.ToString(multiB);

            DivideLeftLabel.Content = Convert.ToString(divideA);
            DivideRightLabel.Content = Convert.ToString(divideB);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClickButton.IsEnabled = false;
            RandomNumber();
            LabelText();
            AnswerNumber();
            StopClickButton.IsEnabled = true;
        }

        private void StopClickButton_Click(object sender, RoutedEventArgs e)
        {
            TextAnswerPlus.IsEnabled = false;
            TextAnswerMinus.IsEnabled = false;
            TextAnswerMulti.IsEnabled = false;
            TextAnswerDivide.IsEnabled = false;
            try
            {
                int correctAnswer = 0;
                int textAnswerA = Convert.ToInt32(TextAnswerPlus.Text);
                if (textAnswerA == answerPlus) { correctAnswer++; }
                int textAnswerB = Convert.ToInt32(TextAnswerMinus.Text);
                if (textAnswerB == answerMinus) { correctAnswer++; }
                int textAnswerC = Convert.ToInt32(TextAnswerMulti.Text);
                if (textAnswerC == answerMulti) { correctAnswer++; }
                double textAnswerD = Convert.ToDouble(string.Format("{0:0.00}", TextAnswerDivide.Text));
                if (textAnswerD == answerDivide) { correctAnswer++; }
                if (correctAnswer == 0)
                { 
                    MessageBox.Show("У вас 0 правильных ответов");
                }
                else if (correctAnswer == 1)
                {
                    MessageBox.Show("У вас 1 правильный ответ");
                }
                else
                {
                    MessageBox.Show($"У вас {correctAnswer} правильных ответа", Convert.ToString(correctAnswer));
                }
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("В поле отсутствуют ответы");
                Close();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
