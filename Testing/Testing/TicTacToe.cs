using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing
{
    public partial class TicTacToe : Form
    {
        public TicTacToe()
        {
            InitializeComponent();
        }

        public int turn = 1;
        public string symbol;
        public int xWins = 0;
        public int oWins = 0;

        public void SelectTile(Button tile)
        {
            if (turn == 1)
            {
                symbol = "X";
            }
            else if(turn == 2)
            {
                symbol = "O";
            }
            else
            {
                MessageBox.Show("Error");
            }

            if (String.IsNullOrEmpty(tile.Text))
            {
                tile.Text = symbol;
                //tile.Enabled = false;
                if(turn == 1)
                {
                    turn = 2;
                }
                else if(turn == 2)
                {
                    turn = 1;
                }

                //WINNER
                if (CheckGameWin() == true)
                {
                    if (symbol == "X")
                    {
                        xWins += 1;
                    }
                    else if(symbol == "O")
                    {
                        oWins += 1;
                    }

                    Score.Text = "X:"+xWins.ToString()+"   O:"+oWins.ToString();

                    foreach (Button tiles in tileBox.Controls)
                    {
                        //tiles.Enabled = false;
                    }
                    MessageBox.Show(symbol+" WINS!");
                }
            }
        }

        public bool CheckGameWin()
        {
            //Horizontal Wins
            if (tile1.Text == tile2.Text && tile2.Text == tile3.Text && String.IsNullOrEmpty(tile1.Text) == false)
            {
                tile1.BackColor = Color.PaleGreen;
                tile2.BackColor = Color.PaleGreen;
                tile3.BackColor = Color.PaleGreen;
                return true;
            }

            else if (tile4.Text == tile5.Text && tile5.Text == tile6.Text && String.IsNullOrEmpty(tile4.Text) == false)
            {
                tile4.BackColor = Color.PaleGreen;
                tile5.BackColor = Color.PaleGreen;
                tile6.BackColor = Color.PaleGreen;
                return true;
            }

            else if (tile7.Text == tile8.Text && tile8.Text == tile9.Text && String.IsNullOrEmpty(tile7.Text) == false)
            {
                tile7.BackColor = Color.PaleGreen;
                tile8.BackColor = Color.PaleGreen;
                tile9.BackColor = Color.PaleGreen;
                return true;
            }

            //Vertical Wins
            else if (tile1.Text == tile4.Text && tile4.Text == tile7.Text && String.IsNullOrEmpty(tile1.Text) == false)
            {
                tile1.BackColor = Color.PaleGreen;
                tile4.BackColor = Color.PaleGreen;
                tile7.BackColor = Color.PaleGreen;
                return true;
            }

            else if (tile2.Text == tile5.Text && tile5.Text == tile8.Text && String.IsNullOrEmpty(tile2.Text) == false)
            {
                tile2.BackColor = Color.PaleGreen;
                tile5.BackColor = Color.PaleGreen;
                tile8.BackColor = Color.PaleGreen;
                return true;
            }

            else if (tile3.Text == tile6.Text && tile6.Text == tile9.Text && String.IsNullOrEmpty(tile3.Text) == false)
            {
                tile3.BackColor = Color.PaleGreen;
                tile6.BackColor = Color.PaleGreen;
                tile9.BackColor = Color.PaleGreen;
                return true;
            }

            //Diagonal Wins
            else if (tile1.Text == tile5.Text && tile5.Text == tile9.Text && String.IsNullOrEmpty(tile1.Text) == false)
            {
                tile1.BackColor = Color.PaleGreen;
                tile5.BackColor = Color.PaleGreen;
                tile9.BackColor = Color.PaleGreen;
                return true;
            }

            else if (tile3.Text == tile5.Text && tile5.Text == tile7.Text && String.IsNullOrEmpty(tile3.Text) == false)
            {
                tile3.BackColor = Color.PaleGreen;
                tile5.BackColor = Color.PaleGreen;
                tile7.BackColor = Color.PaleGreen;
                return true;
            }

            //No Wins
            else
            {
                return false;
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            foreach (Button tile in tileBox.Controls)
            {
                tile.BackColor = default;
                tile.Text = String.Empty;
                tile.Enabled = true;
            }
        }

        private void tile1_Click(object sender, EventArgs e)
        {
            SelectTile(tile1);
        }

        private void tile2_Click(object sender, EventArgs e)
        {
            SelectTile(tile2);
        }

        private void tile3_Click(object sender, EventArgs e)
        {
            SelectTile(tile3);
        }

        private void tile4_Click(object sender, EventArgs e)
        {
            SelectTile(tile4);
        }

        private void tile5_Click(object sender, EventArgs e)
        {
            SelectTile(tile5);
        }

        private void tile6_Click(object sender, EventArgs e)
        {
            SelectTile(tile6);
        }

        private void tile7_Click(object sender, EventArgs e)
        {
            SelectTile(tile7);
        }

        private void tile8_Click(object sender, EventArgs e)
        {
            SelectTile(tile8);
        }

        private void tile9_Click(object sender, EventArgs e)
        {
            SelectTile(tile9);
        }
    }
}
