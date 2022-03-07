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
    public partial class MS : Form
    {
        public int maxSize = 20;
        public int minSize = 10;
        public int xLen;
        public int yLen;
        public int btnGap = 4;
        public Size btnSize = new Size(25, 25);
        public int chance = 5;
        //public List<string> empties = new List<string>();
        public List<Button> empties = new List<Button>();

        public MS()
        {
            InitializeComponent();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(xLength.Text) && !string.IsNullOrEmpty(yLength.Text))
            {
                xLen = Int32.Parse(xLength.Text);
                yLen = Int32.Parse(yLength.Text);
                if (xLen > maxSize || yLen > 15)
                {
                    MessageBox.Show("Grid cannot exceed size of " + maxSize.ToString() + "x15");
                }
                else if (xLen < minSize || yLen < minSize)
                {
                    MessageBox.Show("Grid must be greater than " + minSize.ToString() + "x" + minSize.ToString());
                }
                else
                {
                    ResizeGrid();
                    foreach (Button btn in gameBox.Controls)
                    {
                        btn.BackgroundImage = Image.FromFile(@"C:\Users\joseph.walker\Documents\MyFiles\tile.png");
                        btn.BackgroundImageLayout = ImageLayout.Stretch;    
                    }
                    foreach (Button btn in gameBox.Controls)
                    {
                        List<string> tiles = new List<string>();
                        bool empty = true;
                        int bombs = 0;

                        int x = Int32.Parse(btn.Name.Split('-')[0]);
                        int y = Int32.Parse(btn.Name.Split('-')[1]);

                        string tl = (x - 1).ToString() + "-" + (y - 1).ToString();
                        string t = (x).ToString() + "-" + (y - 1).ToString();
                        string tr = (x + 1).ToString() + "-" + (y - 1).ToString();
                        string l = (x - 1).ToString() + "-" + (y).ToString();
                        string r = (x + 1).ToString() + "-" + (y).ToString();
                        string bl = (x - 1).ToString() + "-" + (y + 1).ToString();
                        string b = (x).ToString() + "-" + (y + 1).ToString();
                        string br = (x + 1).ToString() + "-" + (y + 1).ToString();

                        tiles.Add(tl); tiles.Add(t); tiles.Add(tr);
                        tiles.Add(l); tiles.Add(r);
                        tiles.Add(bl); tiles.Add(b); tiles.Add(br);

                        foreach (Button space in gameBox.Controls)
                        {
                            var match = tiles.FirstOrDefault(stringToCheck => stringToCheck == (space.Name));
                            if (match != null)
                            {
                                if (space.Tag != null)
                                {
                                    if (space.Tag.ToString() == "*")
                                    {
                                        bombs++;
                                    }
                                }
                                else
                                {
                                }
                            }
                        }
                        if (bombs == 0 && x > 3 && y > 3 && btn.Tag == null)
                        {
                            btn.BackgroundImage = null;
                            break;
                        }
                    }
                } 
            }
            else
            {
                MessageBox.Show("Please enter values");
            }
        }

        public void ResizeGrid()
        {
            testLabel.Text = string.Empty;
            gameBox.Controls.Clear();
            int dist = 5;
            int height = 10;
            int btnWidth = 25;

            Random rnd = new Random();
            for (int j = 1; j < yLen+1; j++)
            {
                dist = 5;
                for (int i = 0; i < xLen; i++)
                {
                    Button btn = new Button();
                    btn.Click += new EventHandler(button_Click);
                    btn.MouseDown += new MouseEventHandler(Button_MouseDown);
                    int num = rnd.Next(1,chance);
                    if (num == 1)
                    {
                        //btn.Text = "*";
                        btn.Tag = "*";
                        btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);
                    }
                    btn.Name = (i+1).ToString() +"-"+ j.ToString();
                    btn.Visible = true;
                    btn.Enabled = true;
                    btn.Size = btnSize;
                    btn.Location = new Point(dist, height);
                    dist += btn.Width + btnGap;
                    gameBox.Controls.Add(btn);
                }
                height += 30;
            }

            int borderX = (btnWidth+btnGap)*xLen;
            gameBox.Width = borderX+ btnGap;

            int borderY = (btnWidth + btnGap) * yLen;
            gameBox.Height = height+btnGap;
            this.Height = height + btnGap + 60;

            int xLocSets = borderX + 30;
            settingsBox.Location = new Point(xLocSets, 13);
            this.Width = settingsBox.Width + gameBox.Width + 60;
        }

        protected void button_Click(object sender, EventArgs e)
        {
            var tile = (Button)sender;
            if (tile.Tag != null)
            {
                if (tile.Tag.ToString() == "*")
                {
                    MessageBox.Show("Game Over");
                    foreach (Button btn in gameBox.Controls)
                    {
                        if (btn.Tag != null)
                        {
                            if (!string.IsNullOrEmpty(btn.Tag.ToString()))
                            {
                                if (btn.Tag.ToString() == "*")
                                {
                                    btn.Text = btn.Tag.ToString(); 
                                }
                            } 
                        }
                    }
                } 
            }
            tile.BackgroundImage = null;
            GetSurroundingTiles(tile);
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var tile = (Button)sender;
                if (tile.BackgroundImage == null)
                {
                    tile.BackgroundImage = Image.FromFile(@"C:\Users\joseph.walker\Documents\MyFiles\flag.png");
                    tile.BackgroundImageLayout = ImageLayout.Stretch; 
                }
                else
                {
                    tile.BackgroundImage = null;
                }
            }
        }

        public void GetSurroundingTiles(Button tile)
        {
            List<string> tiles = new List<string>();
            bool empty = true;
            int bombs = 0;

            int x = Int32.Parse(tile.Name.Split('-')[0]);
            int y = Int32.Parse(tile.Name.Split('-')[1]);

            string tl = (x - 1).ToString() + "-" + (y - 1).ToString();
            string t = (x).ToString() + "-" + (y - 1).ToString();
            string tr = (x + 1).ToString() + "-" + (y - 1).ToString();
            string l = (x - 1).ToString() + "-" + (y).ToString();
            string r = (x + 1).ToString() + "-" + (y).ToString();
            string bl = (x - 1).ToString() + "-" + (y + 1).ToString();
            string b = (x).ToString() + "-" + (y + 1).ToString();
            string br = (x + 1).ToString() + "-" + (y + 1).ToString();

            tiles.Add(tl); tiles.Add(t); tiles.Add(tr);
            tiles.Add(l);                tiles.Add(r);
            tiles.Add(bl); tiles.Add(b); tiles.Add(br);

            //MessageBox.Show("[" + tl + "][" + t + "][" + tr + "]\n" +
            //                "[" + l  +   "][     ]["   + r + "]\n" +
            //                "[" + bl + "][" + b + "][" + br + "]");


            foreach (Button space in gameBox.Controls)
            {
                var match = tiles.FirstOrDefault(stringToCheck => stringToCheck==(space.Name));
                if (match != null)
                {
                    if (space.Tag != null)
                    {
                        if (space.Tag.ToString() == "*")
                        {
                            //space.BackColor = Color.LightCoral;
                            bombs++;
                        } 
                    }
                    else
                    {
                        //space.BackColor = Color.PaleGreen;
                    }
                } 
            }
            tile.BackColor = Color.White;
            if(bombs == 0)
            {
                tile.Text = string.Empty;
                tile.Tag = "E";
                foreach (Button button in gameBox.Controls)
                {
                    var match = tiles.FirstOrDefault(stringToCheck => stringToCheck == (button.Name));
                    if(match != null)
                    {
                        if (button.Tag != null)
                        {
                            if (button.Tag.ToString() != "E")
                            {
                                empties.Add(button); 
                            } 
                        }
                    }    
                    //if (button.Text == string.Empty && button.BackColor == Color.White && button.Tag == null)
                    //{
                    //    empties.Add(button);
                    //}
                }

                foreach (Button btn in empties)
                {
                    btn.BackgroundImage = null;
                    GetSurroundingTiles(btn);
                    empties.Remove(btn);
                }
                //Test(tile);
                //RevealEmptyTiles(tile);
            }
            if (bombs == 1)
            {
                tile.Text = bombs.ToString();
                tile.ForeColor = Color.Blue;
            }
            if (bombs == 2)
            {
                tile.Text = bombs.ToString();
                tile.ForeColor = Color.Green;
            }
            if (bombs == 3)
            {
                tile.Text = bombs.ToString();
                tile.ForeColor = Color.Red;
            }
            if (bombs == 4)
            {
                tile.Text = bombs.ToString();
                tile.ForeColor = Color.Purple;
            }
            if (bombs == 5)
            {
                tile.Text = bombs.ToString();
                tile.ForeColor = Color.Orange;
            }
            if (bombs == 6)
            {
                tile.Text = bombs.ToString();
                tile.ForeColor = Color.DarkRed;
            }
            if (bombs == 7)
            {
                tile.Text = bombs.ToString();
                tile.ForeColor = Color.DarkGreen;
            }
            if (bombs == 8)
            {
                tile.Text = bombs.ToString();
                tile.ForeColor = Color.Cyan;
            }
        }

        public void RevealEmptyTiles(Button tile)
        {
            List<string> tiles = new List<string>();
            bool empty = true;
            int bombs = 0;

            int x = Int32.Parse(tile.Name.Split('-')[0]);
            int y = Int32.Parse(tile.Name.Split('-')[1]);

            string tl = (x - 1).ToString() + "-" + (y - 1).ToString();
            string t = (x).ToString() + "-" + (y - 1).ToString();
            string tr = (x + 1).ToString() + "-" + (y - 1).ToString();
            string l = (x - 1).ToString() + "-" + (y).ToString();
            string r = (x + 1).ToString() + "-" + (y).ToString();
            string bl = (x - 1).ToString() + "-" + (y + 1).ToString();
            string b = (x).ToString() + "-" + (y + 1).ToString();
            string br = (x + 1).ToString() + "-" + (y + 1).ToString();

            tiles.Add(tl); tiles.Add(t); tiles.Add(tr);
            tiles.Add(l); tiles.Add(r);
            tiles.Add(bl); tiles.Add(b); tiles.Add(br);

            foreach (Button space in gameBox.Controls)
            {
                var match = tiles.FirstOrDefault(stringToCheck => stringToCheck == (space.Name));
                if (match != null)
                {
                    space.BackColor = Color.White;
                    space.BackgroundImage = null;
                }
            }

        }

        public void Test(Button tile)
        {
            List<string> tiles = new List<string>();

            int x = Int32.Parse(tile.Name.Split('-')[0]);
            int y = Int32.Parse(tile.Name.Split('-')[1]);

            string tl = (x - 1).ToString() + "-" + (y - 1).ToString();
            string t  = (x).ToString() + "-" + (y - 1).ToString();
            string tr = (x + 1).ToString() + "-" + (y - 1).ToString();
            string l  = (x - 1).ToString() + "-" + (y).ToString();
            string r  = (x + 1).ToString() + "-" + (y).ToString();
            string bl = (x - 1).ToString() + "-" + (y + 1).ToString();
            string b  = (x).ToString() + "-" + (y + 1).ToString();
            string br = (x + 1).ToString() + "-" + (y + 1).ToString();

            tiles.Add(tl); tiles.Add(t); tiles.Add(tr);
            tiles.Add(l);                tiles.Add(r);
            tiles.Add(bl); tiles.Add(b); tiles.Add(br);

            foreach (Button space in gameBox.Controls)
            {
                var match = tiles.FirstOrDefault(stringToCheck => stringToCheck == (space.Name));
                if (match != null)
                {
                    //empties.Add(space.Name);
                    space.BackColor = Color.White;
                    space.BackgroundImage = null;
                }
            }
        }

        private void xLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void MS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
