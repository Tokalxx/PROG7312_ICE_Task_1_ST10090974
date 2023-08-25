using System;
using System.Collections.Generic;
using System.Windows;

namespace PROG7312_ICE_Task_1_ST10090974
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string[] words = new string[8]
            {"hello world","november","monitor","generic","horizontal","signature","generator","africa" };
        List<string> storedWords = new List<string>();
        Random ran = new Random();

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            string tempWord = Generate(words[ran.Next(0, 8)]);
            if (storedWords == null)
            {
                storedWords.Add(tempWord);
            }
            else
            {
                while (storedWords.Contains(tempWord))
                {
                    tempWord = Generate(words[ran.Next(0, 8)]);
                }

                storedWords.Add(tempWord);

            }

            textBlockDisRandom.Text = tempWord;
        }

        public static string Generate(string word)
        {
            char[] chars = new char[word.Length];
            char[] holder = word.ToCharArray();
            Random random = new Random(10000);
            string randomWord = "";
            int index = 0;
            while (word.Length > 0)
            {
                int next = random.Next(0, word.Length - 1);

                chars[index] = word[next];
                word = word.Substring(0, next) + word.Substring(next + 1);
                index++;
            }

            foreach (char x in chars)
            {
                randomWord += x;
            }
            return randomWord;
        }

        private void buttonCheck_Click(object sender, RoutedEventArgs e)
        {
            string temp = textBoxUserInput.Text;
            bool check = true;

            foreach (string x in words)
            {
                if (temp == x)
                {
                    check = true;
                    break;
                }
                else
                {
                    check = false;
                }
            }

            if (check)
            {
                MessageBox.Show("Correct");
            }
            else
            {
                MessageBox.Show($"{temp} does not match any words");
            }

        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textBlockDisRandom.Text = "";
            textBoxUserInput.Text = string.Empty;

            storedWords.Clear();
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
