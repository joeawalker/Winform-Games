using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Testing
{
    public partial class Wordle : Form
    {

        public int guesses = 0;
        string[] letters = {"A", "B", "C", "D", "E", "F"};
        int index = 1;
        public string row;
        string wordl;
        string guess = "";
        public List<string> wordList = new List<string>();

        public Wordle()
        {
            InitializeComponent();
            InitGame();
        }

        public void InitGame()
        {
            foreach (string line in File.ReadLines("wordList.txt"))
            {
                wordList.Add(line.ToLower());
            }

            int rand = new Random().Next(0,(wordList.Count-1));
            wordl = wordList[rand];
            //MessageBox.Show(wordl);
        }

        public void UpdateGuesses()
        {
            if (guesses < 5)
            {
                guesses += 1;
                index = 1;
                guess = "";
            }
            else
            {
                MessageBox.Show("Out of guesses\n"+wordl);
            }
        }

        public void AddLetter(string input)
        {
            if (index < 6)
            {
                row = letters[guesses];
                foreach (Button box in guessBox.Controls)
                {
                    if (box.Name.Contains(row))
                    {
                        if (box.Name.Contains(index.ToString()))
                        {
                            if (string.IsNullOrEmpty(box.Text))
                            {
                                box.Text = input;
                                index++;
                                guess += input;
                                break;
                            }
                        }
                    }
                } 
            }
            else
            {
                //MessageBox.Show("test");
            }
        }

        public void checkWord(string word)
        {
            if (wordl==word)
            {
                //MessageBox.Show("Found");
                foreach(char letter in word)
                {
                    var btn = guessBox.Controls.Find(row + (word.IndexOf(letter) + 1).ToString(), true);
                    btn[0].BackColor = Color.Green;

                    var btn2 = guessBox.Controls.Find(row + (word.LastIndexOf(letter) + 1).ToString(), true);
                    btn2[0].BackColor = Color.Green;
                }
            }
            else
            {
                //MessageBox.Show(word);
                foreach(char letter in word)
                {
                    int count = 0; //How many times the letter you are guessing appears in the word
                    foreach(char let in wordl)
                    {
                        if (letter == let)
                        {
                            count++;
                        }
                    }

                    if (wordl.Contains(letter.ToString()))
                    {
                        if (wordl.IndexOf(letter) == word.IndexOf(letter))
                        {
                            var btn = guessBox.Controls.Find(row+(word.IndexOf(letter)+1).ToString(),true);
                            btn[0].BackColor = Color.Green;
                            var btn2 = guessBox.Controls.Find(row + (word.LastIndexOf(letter) + 1).ToString(), true);
                            btn2[0].BackColor = Color.Green;
                            var ltr = this.Controls.Find(letter.ToString()+"Btn", true);
                            ltr[0].BackColor = Color.Green;
                            
                        }
                        else
                        {
                            var btn = guessBox.Controls.Find(row + (word.IndexOf(letter) + 1).ToString(), true);
                            btn[0].BackColor = Color.Orange;
                            var btn2 = guessBox.Controls.Find(row + (word.LastIndexOf(letter) + 1).ToString(), true);
                            btn2[0].BackColor = Color.Orange;
                            var ltr = this.Controls.Find(letter.ToString() + "Btn", true);
                            ltr[0].BackColor = Color.Orange;
                        }
                    }
                    else
                    {
                        var btn = guessBox.Controls.Find(row + (word.IndexOf(letter) + 1).ToString(), true);
                        btn[0].BackColor = Color.DimGray;
                        var btn2 = guessBox.Controls.Find(row + (word.LastIndexOf(letter) + 1).ToString(), true);
                        btn2[0].BackColor = Color.DimGray;
                        var ltr = this.Controls.Find(letter.ToString() + "Btn", true);
                        ltr[0].BackColor = Color.DimGray;
                    }
                }
            }
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            if (index==6)
            {
                checkWord("asdlp");
                UpdateGuesses();
            } 
        }
        private void E_Click(object sender, EventArgs e)
        {
            AddLetter("E");
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            foreach(Button box in guessBox.Controls)
            {
                var lastSpace = row + (index - 1).ToString();
                if (box.Name == lastSpace)
                {
                    box.Text = string.Empty;
                    guess = guess.Remove(guess.Length-1,1);
                    index--;
                    break;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if(btn.Text == "Enter")
            {
                if (index == 6)
                {
                    checkWord(guess);
                    UpdateGuesses();
                }
            }
            else if(btn.Text == "←")
            {
                foreach (Button box in guessBox.Controls)
                {
                    var lastSpace = row + (index - 1).ToString();
                    if (box.Name == lastSpace)
                    {
                        box.Text = string.Empty;
                        guess = guess.Remove(guess.Length - 1, 1);
                        index--;
                        break;
                    }
                }
            }
            else
            {
                AddLetter(btn.Text.ToLower());
            }
        }

        private void Wordle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
