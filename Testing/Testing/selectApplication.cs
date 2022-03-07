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
    public partial class selectApplication : Form
    {
        public selectApplication()
        {
            InitializeComponent();
        }

        private void launchBtn_Click(object sender, EventArgs e)
        {
            if (chessBtn.Checked)
            {
                this.Hide();
                Chess chess = new Chess();
                chess.ShowDialog();
            }
            else if (TicTacToeBtn.Checked)
            {
                this.Hide();
                TicTacToe ttt = new TicTacToe();
                ttt.ShowDialog();
            }
            else if (MSbtn.Checked)
            {
                this.Hide();
                MS ms = new MS();
                ms.ShowDialog();
            }
            else if (wordleBtn.Checked)
            {
                this.Hide();
                Wordle w = new Wordle();
                w.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
