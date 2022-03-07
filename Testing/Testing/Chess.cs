using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace Testing
{
    public partial class Chess : Form
    {

        public string selectedPiece = "";
        public string pieceName = "";
        public string[] validMoves = { };
        public string[] oppertunities = { };
        public char[] letters = "ABCDEFGH".ToCharArray();
        public string piecesDir = @"C:\Users\joseph.walkaaaaer\Documents\MyFiles\pieces\";
        public int turn = 1;
        public Button tradePiece = new Button();

        public Chess()
        {
            InitializeComponent();
            SwitchTurn();
            AddPhotos();
        }

        public void AddPhotos()
        {
            if (!Directory.Exists(piecesDir))
            {
                //MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory);
                piecesDir = AppDomain.CurrentDomain.BaseDirectory+@"\pieces\";
            }
        }

        private void A1_Click(object sender, EventArgs e)
        {
            canKillTxt.Text = "Can Kill:";
            label2.Text = string.Empty;
            var btn = (Button)sender;

            //Switch White Pawn
            if (btn.Text == "P")
            {
                if (btn.Name[1].ToString() == "8")
                {
                    TradePawn(btn, "white");
                }
                else if (btn.Name[1].ToString() == "1")
                {
                    TradePawn(btn, "black");
                }
            }
            else
            {
                foreach (Button button in whiteBox.Controls)
                {
                    button.Enabled = false;
                }
                foreach (Button button in blackBox.Controls)
                {
                    button.Enabled = false;
                }
            }

            if (btn.BackColor == Color.PaleGreen || btn.BackColor == Color.LightCoral)
            {
                if(btn.BackColor == Color.LightCoral)
                {
                    SideBoard(btn);
                }
                //if (KingCheck(btn) == true)
                //{
                //    MessageBox.Show("Check");
                //}
                Control oldTile = Controls.Find(selectedPiece, true)[0];
                btn.Text = pieceName;
                MoveImage(oldTile, btn);
                btn.Tag = oldTile.Tag;
                oldTile.Tag = null;
                oldTile.Text = String.Empty;
                RemoveHighlights();
                SwitchTurn();
            }
            else
            {
                HighlightMoves(btn);
                selectedPiece = btn.Name;
                pieceName = btn.Text;
            }
        }

        public void TradePawn(Button pawn, string col)
        {
            if (col == "white")
            {
                if (whiteBox.Controls.Count != 0)
                {
                    tradePiece = pawn;
                    foreach (Button piece in whiteBox.Controls)
                    {
                        if (piece.BackgroundImage != null)
                        {
                            piece.Enabled = true;
                        }
                    } 
                }
            }

            if (col == "black")
            {
                tradePiece = pawn;
                foreach (Button piece in blackBox.Controls)
                {
                    if (piece.BackgroundImage != null)
                    {
                        piece.Enabled = true;
                    }
                }
            }
        }

        public void SideBoard(Button piece)
        {
            int minVal = 16;
            Button slot = new Button();

            if (piece.Tag.ToString() == "black")
            {
                foreach (Button btn in blackBox.Controls)
                {
                    string val = Regex.Match(btn.Name, @"\d+").Value;
                    int value = Int32.Parse(val);
                    if (value < minVal && btn.BackgroundImage == null)
                    {
                        minVal = value;
                        slot = btn;
                    }
                } 
            }
            if (piece.Tag.ToString() == "white")
            {
                foreach (Button btn in whiteBox.Controls)
                {
                    string val = Regex.Match(btn.Name, @"\d+").Value;
                    int value = Int32.Parse(val);
                    if (value < minVal && btn.BackgroundImage == null)
                    {
                        minVal = value;
                        slot = btn;
                    }
                }
            }
            slot.Visible = true;
            slot.BackgroundImage = piece.Image;
            slot.BackgroundImageLayout = ImageLayout.Stretch;
            slot.Text = piece.Text;
        }

        public void MoveImage(Control oldTile, Button newTile)
        {
            Button tile = oldTile as Button;
            newTile.Image = tile.Image;
            tile.Image = null;
        }

        public void SwitchTurn()
        {
            if (turn%2 != 0)
            {
                //Disable black pieces
                foreach (Button btn in boardBox.Controls)
                {
                    if(btn.Tag != null)
                    {
                        if(btn.Tag.ToString() == "black")
                        {
                            btn.Enabled = false;
                        }
                        if (btn.Tag.ToString() == "white")
                        {
                            btn.Enabled = true;
                        }
                    }
                }
            }
            if (turn % 2 == 0)
            {
                //Disable white pieces
                foreach (Button btn in boardBox.Controls)
                {
                    if (btn.Tag != null)
                    {
                        if (btn.Tag.ToString() == "white")
                        {
                            btn.Enabled = false;
                        }
                        if (btn.Tag.ToString() == "black")
                        {
                            btn.Enabled = true;
                        }
                    }
                }
            }
            turn++;
        }

        public string GetOrigColour(Button tile)
        {
            int currentY = tile.Name[1] - '0';
            int currentX = Array.IndexOf(letters, tile.Name[0])+1;

            if (currentX % 2 != 1)
            {
                if (currentY % 2 != 1)
                {
                    return "ButtonShadow";
                }
                else
                {
                    return "White";
                }
            }
            else
            {
                if (currentY % 2 != 1)
                {
                    return "White";
                }
                else
                {
                    return "ButtonShadow";
                }
            }
        }

        public void RemoveHighlights()
        {
            foreach (Button space in boardBox.Controls)
            {
                if (space.BackColor == Color.PaleGreen)
                {
                    string colour = GetOrigColour(space);
                    space.BackColor = (Color)new ColorConverter().ConvertFromString(colour);
                }
                if(space.BackColor == Color.LightCoral)
                {
                    string colour = GetOrigColour(space);
                    space.BackColor = (Color)new ColorConverter().ConvertFromString(colour);
                    space.Enabled = false;
                }
            }
        }

        public string GetPieceName(string piece)
        {
            if (!String.IsNullOrEmpty(piece))
            {
                if (piece == "P")
                {
                    piece = "Pawn";
                }
                else if (piece == "B")
                {
                    piece = "Bishop";
                }
                else if (piece == "R")
                {
                    piece = "Rook";
                }
                else if (piece == "K")
                {
                    piece = "King";
                }
                else if (piece == "Q")
                {
                    piece = "Queen";
                }
                else if (piece == "N")
                {
                    piece = "Knight";
                }
            }
            else
            {
                piece = "Empty";
            }
            return piece;
        }

        public void HighlightMoves(Button tile)
        {
            RemoveHighlights();

            //Pawn
            if (tile.Text == "P")
            {
                List<string> moves = new List<string>();
                List<string> canKill = new List<string>();

                int currentY = tile.Name[1] - '0';
                int currentX = Array.IndexOf(letters, tile.Name[0]);

                int direction = 0;
                if (tile.Tag.ToString() == "white")
                {
                    direction++;
                }
                else if (tile.Tag.ToString() == "black")
                {
                    direction--;
                }

                if (currentY+1 < 9 && currentY-1 > 0)
                {
                    string space = tile.Name[0].ToString() + (currentY + direction).ToString();
                    Control nextSpace = Controls.Find(space, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        if (currentY == 2 && tile.Tag.ToString() == "white")
                        {
                            string extraSpace = tile.Name[0].ToString() + (currentY + 2).ToString();
                            moves.Add(extraSpace);
                        }
                        if (currentY == 7 && tile.Tag.ToString() == "black")
                        {
                            string extraSpace = tile.Name[0].ToString() + (currentY - 2).ToString();
                            moves.Add(extraSpace);
                        }
                        moves.Add(space);
                    }

                    if (!tile.Name.Contains("A"))
                    {
                        int x = Array.IndexOf(letters, tile.Name[0]);
                        string letter = letters[x - 1].ToString();
                        string attack = letter + (currentY+direction).ToString();
                        Control canAttack = Controls.Find(attack, true)[0];
                        if (canAttack.Tag != null)
                        {
                            if (canAttack.Tag.ToString() != tile.Tag.ToString())
                            {
                                if (!String.IsNullOrEmpty(canAttack.Text))
                                {
                                    canAttack.Enabled = true;
                                    canAttack.BackColor = Color.LightCoral;
                                    canKill.Add(canAttack.Text);
                                }
                            } 
                        }
                    }

                    if (!tile.Name.Contains("H"))
                    {
                        int x = Array.IndexOf(letters, tile.Name[0]);
                        string letter = letters[x + 1].ToString();
                        string attack = letter + (currentY + direction).ToString();
                        Control canAttack = Controls.Find(attack, true)[0];
                        if (canAttack.Tag != null)
                        {
                            if (canAttack.Tag.ToString() != tile.Tag.ToString())
                            {
                                if (!String.IsNullOrEmpty(canAttack.Text))
                                {
                                    canAttack.Enabled = true;
                                    canAttack.BackColor = Color.LightCoral;
                                    canKill.Add(canAttack.Text);
                                }
                            } 
                        }
                    }

                    foreach (var victim in canKill)
                    {
                        string piece = GetPieceName(victim);
                        canKillTxt.Text += "\n" + piece;
                    }

                    foreach (var move in moves)
                    {
                        Control canMove = Controls.Find(move, true)[0];
                        if (String.IsNullOrEmpty(canMove.Text))
                        {
                            canMove.BackColor = Color.PaleGreen;
                        }
                    } 
                }
            }

            //Rook
            if (tile.Text == "R")
            {
                List<string> moves = new List<string>();
                List<string> canKill = new List<string>();

                int currentY = tile.Name[1] - '0';
                int currentX = Array.IndexOf(letters, tile.Name[0]);

                //Forward Spaces
                for (int x = currentY+1; x < 9; x++)
                {
                    string space = tile.Name[0].ToString() + x.ToString();
                    Control nextSpace = Controls.Find(space, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(space);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                            break;
                        }
                        if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                        {
                            break;
                        } 
                    }
                }

                //Backwards Spaces
                for (int x = currentY - 1; x > 0; x--)
                {
                    string space = tile.Name[0].ToString() + x.ToString();
                    Control nextSpace = Controls.Find(space, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(space);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                            break;
                        }
                        if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                        {
                            break;
                        }
                    }
                }

                //Right Side Spaces
                for (int x = currentX+1; x < 8; x++)
                {
                    string space = letters[x] + tile.Name[1].ToString();
                    Control nextSpace = Controls.Find(space, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(space);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                            break;
                        }
                        if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                        {
                            break;
                        }
                    }
                }

                //Left Side Spaces
                for (int x = currentX - 1; x >= 0; x--)
                {
                    string space = letters[x] + tile.Name[1].ToString();
                    Control nextSpace = Controls.Find(space, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(space);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                            break;
                        }
                        if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                        {
                            break;
                        }
                    }
                }

                foreach (var victim in canKill)
                {
                    string piece = GetPieceName(victim);
                    canKillTxt.Text += "\n" + piece;
                }

                foreach (var move in moves)
                {
                    Control canMove = Controls.Find(move, true)[0];
                    if (String.IsNullOrEmpty(canMove.Text))
                    {
                        canMove.BackColor = Color.PaleGreen;
                    }
                }

            }

            //Knight
            if (tile.Text == "N")
            {
                List<string> moves = new List<string>();
                List<string> canKill = new List<string>();

                int currentY = tile.Name[1] - '0';
                int currentX = Array.IndexOf(letters, tile.Name[0]);

                //North
                int ny = currentY + 2;
                int nx1 = currentX - 1;
                int nx2 = currentX + 1;

                if (ny < 9)
                {
                    if (nx1 >= 0)
                    {
                        string space = letters[nx1].ToString() + ny.ToString();
                        Control nextSpace = Controls.Find(space, true)[0];
                        if (string.IsNullOrEmpty(nextSpace.Text))
                        {
                            moves.Add(space);
                        }
                        if (nextSpace.Tag != null)
                        {
                            if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                            {
                                nextSpace.Enabled = true;
                                nextSpace.BackColor = Color.LightCoral;
                                canKill.Add(nextSpace.Text);
                            }
                        }
                    }
                    if (nx2 < 8)
                    {
                        string space = letters[nx2].ToString() + ny.ToString();
                        Control nextSpace = Controls.Find(space, true)[0];
                        if (string.IsNullOrEmpty(nextSpace.Text))
                        {
                            moves.Add(space);
                        }
                        if (nextSpace.Tag != null)
                        {
                            if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                            {
                                nextSpace.Enabled = true;
                                nextSpace.BackColor = Color.LightCoral;
                                canKill.Add(nextSpace.Text);
                            }
                        }
                    } 
                }

                //South
                int sy = currentY - 2;
                int sx1 = currentX - 1;
                int sx2 = currentX + 1;

                if (sy > 0)
                {
                    if (sx1 >= 0)
                    {
                        string space = letters[sx1].ToString() + sy.ToString();
                        Control nextSpace = Controls.Find(space, true)[0];
                        if (string.IsNullOrEmpty(nextSpace.Text))
                        {
                            moves.Add(space); 
                        }
                        if (nextSpace.Tag != null)
                        {
                            if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                            {
                                nextSpace.Enabled = true;
                                nextSpace.BackColor = Color.LightCoral;
                                canKill.Add(nextSpace.Text);
                            }
                        }
                    }
                    if (sx2 < 8)
                    {
                        string space = letters[sx2].ToString() + sy.ToString();
                        Control nextSpace = Controls.Find(space, true)[0];
                        if (string.IsNullOrEmpty(nextSpace.Text))
                        {
                            moves.Add(space);
                        }
                        if (nextSpace.Tag != null)
                        {
                            if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                            {
                                nextSpace.Enabled = true;
                                nextSpace.BackColor = Color.LightCoral;
                                canKill.Add(nextSpace.Text);
                            }
                        }
                    }
                }

                //East
                int ex = currentX + 2;
                int ey1 = currentY + 1;
                int ey2 = currentY - 1;

                if (ex < 8)
                {
                    if (ey1 <= 8)
                    {
                        string space = letters[ex].ToString() + ey1.ToString();
                        Control nextSpace = Controls.Find(space, true)[0];
                        if (string.IsNullOrEmpty(nextSpace.Text))
                        {
                            moves.Add(space);
                        }
                        if (nextSpace.Tag != null)
                        {
                            if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                            {
                                nextSpace.Enabled = true;
                                nextSpace.BackColor = Color.LightCoral;
                                canKill.Add(nextSpace.Text);
                            }
                        }
                    }
                    if (ey2 > 0)
                    {
                        string space = letters[ex].ToString() + ey2.ToString();
                        Control nextSpace = Controls.Find(space, true)[0];
                        if (string.IsNullOrEmpty(nextSpace.Text))
                        {
                            moves.Add(space);
                        }
                        if (nextSpace.Tag != null)
                        {
                            if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                            {
                                nextSpace.Enabled = true;
                                nextSpace.BackColor = Color.LightCoral;
                                canKill.Add(nextSpace.Text);
                            }
                        }
                    }
                }

                //West
                int wx = currentX - 2;
                int wy1 = currentY + 1;
                int wy2 = currentY - 1;

                if (wx >= 0)
                {
                    if (wy1 <= 8)
                    {
                        string space = letters[wx].ToString() + wy1.ToString();
                        Control nextSpace = Controls.Find(space, true)[0];
                        if (string.IsNullOrEmpty(nextSpace.Text))
                        {
                            moves.Add(space);
                        }
                        if (nextSpace.Tag != null)
                        {
                            if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                            {
                                nextSpace.Enabled = true;
                                nextSpace.BackColor = Color.LightCoral;
                                canKill.Add(nextSpace.Text);
                            }
                        }
                    }
                    if (wy2 > 0)
                    {
                        string space = letters[wx].ToString() + wy2.ToString();
                        Control nextSpace = Controls.Find(space, true)[0];
                        if (string.IsNullOrEmpty(nextSpace.Text))
                        {
                            moves.Add(space);
                        }
                        if (nextSpace.Tag != null)
                        {
                            if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                            {
                                nextSpace.Enabled = true;
                                nextSpace.BackColor = Color.LightCoral;
                                canKill.Add(nextSpace.Text);
                            }
                        }
                    }
                }

                foreach (var victim in canKill)
                {
                    string piece = GetPieceName(victim);
                    canKillTxt.Text += "\n" + piece;
                }

                foreach (var move in moves)
                {
                    Control canMove = Controls.Find(move, true)[0];
                    if (String.IsNullOrEmpty(canMove.Text))
                    {
                        canMove.BackColor = Color.PaleGreen;
                    }
                }
            }

            //Bishop
            if (tile.Text == "B")
            {
                List<string> moves = new List<string>();
                List<string> canKill = new List<string>();

                int currentY = tile.Name[1] - '0';
                int currentX = Array.IndexOf(letters, tile.Name[0]);

                //NorthWest
                int i = 1;
                while (true)
                {
                    int nextX = currentX - i;
                    int nextY = currentY + i;
                    
                    if (nextX >= 0)
                    {
                        if (nextY <= 8)
                        {
                            string space = letters[nextX].ToString() + nextY.ToString();
                            Control nextSpace = Controls.Find(space, true)[0];
                            if (string.IsNullOrEmpty(nextSpace.Text))
                            {
                                moves.Add(space);
                                i++;
                            }
                            if (nextSpace.Tag != null)
                            {
                                if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                                {
                                    nextSpace.Enabled = true;
                                    nextSpace.BackColor = Color.LightCoral;
                                    canKill.Add(nextSpace.Text);
                                    break;
                                }
                                if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                //NorthEast
                i = 1;
                while (true)
                {
                    int nextX = currentX + i;
                    int nextY = currentY + i;

                    if (nextX < 8)
                    {
                        if (nextY <= 8)
                        {
                            string space = letters[nextX].ToString() + nextY.ToString();
                            Control nextSpace = Controls.Find(space, true)[0];
                            if (string.IsNullOrEmpty(nextSpace.Text))
                            {
                                moves.Add(space);
                                i++;
                            }
                            if (nextSpace.Tag != null)
                            {
                                if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                                {
                                    nextSpace.Enabled = true;
                                    nextSpace.BackColor = Color.LightCoral;
                                    canKill.Add(nextSpace.Text);
                                    break;
                                }
                                if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                //SouthEast
                i = 1;
                while (true)
                {
                    int nextX = currentX + i;
                    int nextY = currentY - i;

                    if (nextX < 8)
                    {
                        if (nextY > 0)
                        {
                            string space = letters[nextX].ToString() + nextY.ToString();
                            Control nextSpace = Controls.Find(space, true)[0];
                            if (string.IsNullOrEmpty(nextSpace.Text))
                            {
                                moves.Add(space);
                                i++;
                            }
                            if (nextSpace.Tag != null)
                            {
                                if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                                {
                                    nextSpace.Enabled = true;
                                    nextSpace.BackColor = Color.LightCoral;
                                    canKill.Add(nextSpace.Text);
                                    break;
                                }
                                if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                //SouthWest
                i = 1;
                while (true)
                {
                    int nextX = currentX - i;
                    int nextY = currentY - i;

                    if (nextX >= 0)
                    {
                        if (nextY > 0)
                        {
                            string space = letters[nextX].ToString() + nextY.ToString();
                            Control nextSpace = Controls.Find(space, true)[0];
                            if (String.IsNullOrEmpty(nextSpace.Text))
                            {
                                moves.Add(space);
                                i++;
                            }
                            if (nextSpace.Tag != null)
                            {
                                if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                                {
                                    nextSpace.Enabled = true;
                                    nextSpace.BackColor = Color.LightCoral;
                                    canKill.Add(nextSpace.Text);
                                    break;
                                }
                                if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                //Colour
                foreach (var victim in canKill)
                {
                    string piece = GetPieceName(victim);
                    canKillTxt.Text += "\n" + piece;
                }

                foreach (var move in moves)
                {
                    Control canMove = Controls.Find(move, true)[0];
                    if (String.IsNullOrEmpty(canMove.Text))
                    {
                        canMove.BackColor = Color.PaleGreen;
                    }
                }
            }

            //King
            if (tile.Text == "K")
            {
                List<string> moves = new List<string>();
                List<string> canKill = new List<string>();

                int currentY = tile.Name[1] - '0';
                int currentX = Array.IndexOf(letters, tile.Name[0]);

                //North West
                if (currentX-1 >= 0 && currentY+1 < 9)
                {
                    string nw = letters[currentX - 1].ToString() + (currentY + 1).ToString();
                    Control nextSpace = Controls.Find(nw, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(nw);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                        }
                    }
                }

                //North
                if (currentY+1 < 9)
                {
                    string n = letters[currentX].ToString() + (currentY + 1).ToString();
                    Control nextSpace = Controls.Find(n, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(n);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                        }
                    }
                }

                //North East
                if (currentX + 1 < 8 && currentY + 1 < 9)
                {
                    string ne = letters[currentX + 1].ToString() + (currentY + 1).ToString();
                    Control nextSpace = Controls.Find(ne, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(ne);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                        }
                    }
                }

                //South West
                if (currentX - 1 >= 0 && currentY - 1 > 0)
                {
                    string sw = letters[currentX - 1].ToString() + (currentY - 1).ToString();
                    Control nextSpace = Controls.Find(sw, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(sw);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                        }
                    }
                }

                //South
                if (currentY - 1 > 0)
                {
                    string s = letters[currentX].ToString() + (currentY - 1).ToString();
                    Control nextSpace = Controls.Find(s, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(s);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                        }
                    }
                }

                //South East
                if (currentX + 1 < 8 && currentY - 1 > 0)
                {
                    string se = letters[currentX + 1].ToString() + (currentY - 1).ToString();
                    Control nextSpace = Controls.Find(se, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(se);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                        }
                    }
                }

                //East
                if (currentX + 1 < 8)
                {
                    string e = letters[currentX + 1].ToString() + (currentY).ToString();
                    Control nextSpace = Controls.Find(e, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(e);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                        }
                    }
                }

                //West
                if (currentX - 1 >= 0)
                {
                    string w = letters[currentX - 1].ToString() + (currentY).ToString();
                    Control nextSpace = Controls.Find(w, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(w);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                        }
                    }
                }

                //Colours
                foreach (var victim in canKill)
                {
                    string piece = GetPieceName(victim);
                    canKillTxt.Text += "\n" + piece;
                }

                foreach (var move in moves)
                {
                    Control canMove = Controls.Find(move, true)[0];
                    if (String.IsNullOrEmpty(canMove.Text))
                    {
                        canMove.BackColor = Color.PaleGreen;
                    }
                }
            }

            //Queen
            if (tile.Text == "Q")
            {
                List<string> moves = new List<string>();
                List<string> canKill = new List<string>();

                int currentY = tile.Name[1] - '0';
                int currentX = Array.IndexOf(letters, tile.Name[0]);

                //Forward Spaces
                for (int x = currentY + 1; x < 9; x++)
                {
                    string space = tile.Name[0].ToString() + x.ToString();
                    Control nextSpace = Controls.Find(space, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(space);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                            break;
                        }
                        if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                        {
                            break;
                        }
                    }
                }

                //Backwards Spaces
                for (int x = currentY - 1; x > 0; x--)
                {
                    string space = tile.Name[0].ToString() + x.ToString();
                    Control nextSpace = Controls.Find(space, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(space);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                            break;
                        }
                        if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                        {
                            break;
                        }
                    }
                }

                //Right Side Spaces
                for (int x = currentX + 1; x < 8; x++)
                {
                    string space = letters[x] + tile.Name[1].ToString();
                    Control nextSpace = Controls.Find(space, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(space);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                            break;
                        }
                        if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                        {
                            break;
                        }
                    }
                }

                //Left Side Spaces
                for (int x = currentX - 1; x >= 0; x--)
                {
                    string space = letters[x] + tile.Name[1].ToString();
                    Control nextSpace = Controls.Find(space, true)[0];

                    if (String.IsNullOrEmpty(nextSpace.Text))
                    {
                        moves.Add(space);
                    }
                    if (nextSpace.Tag != null)
                    {
                        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                        {
                            nextSpace.Enabled = true;
                            nextSpace.BackColor = Color.LightCoral;
                            canKill.Add(nextSpace.Text);
                            break;
                        }
                        if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                        {
                            break;
                        }
                    }
                }

                //NorthWest
                int i = 1;
                while (true)
                {
                    int nextX = currentX - i;
                    int nextY = currentY + i;

                    if (nextX >= 0)
                    {
                        if (nextY <= 8)
                        {
                            string space = letters[nextX].ToString() + nextY.ToString();
                            Control nextSpace = Controls.Find(space, true)[0];
                            if (string.IsNullOrEmpty(nextSpace.Text))
                            {
                                moves.Add(space);
                                i++;
                            }
                            if (nextSpace.Tag != null)
                            {
                                if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                                {
                                    nextSpace.Enabled = true;
                                    nextSpace.BackColor = Color.LightCoral;
                                    canKill.Add(nextSpace.Text);
                                    break;
                                }
                                if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                //NorthEast
                i = 1;
                while (true)
                {
                    int nextX = currentX + i;
                    int nextY = currentY + i;

                    if (nextX < 8)
                    {
                        if (nextY <= 8)
                        {
                            string space = letters[nextX].ToString() + nextY.ToString();
                            Control nextSpace = Controls.Find(space, true)[0];
                            if (string.IsNullOrEmpty(nextSpace.Text))
                            {
                                moves.Add(space);
                                i++;
                            }
                            if (nextSpace.Tag != null)
                            {
                                if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                                {
                                    nextSpace.Enabled = true;
                                    nextSpace.BackColor = Color.LightCoral;
                                    canKill.Add(nextSpace.Text);
                                    break;
                                }
                                if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                //SouthEast
                i = 1;
                while (true)
                {
                    int nextX = currentX + i;
                    int nextY = currentY - i;

                    if (nextX < 8)
                    {
                        if (nextY > 0)
                        {
                            string space = letters[nextX].ToString() + nextY.ToString();
                            Control nextSpace = Controls.Find(space, true)[0];
                            if (string.IsNullOrEmpty(nextSpace.Text))
                            {
                                moves.Add(space);
                                i++;
                            }
                            if (nextSpace.Tag != null)
                            {
                                if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                                {
                                    nextSpace.Enabled = true;
                                    nextSpace.BackColor = Color.LightCoral;
                                    canKill.Add(nextSpace.Text);
                                    break;
                                }
                                if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                //SouthWest
                i = 1;
                while (true)
                {
                    int nextX = currentX - i;
                    int nextY = currentY - i;

                    if (nextX >= 0)
                    {
                        if (nextY > 0)
                        {
                            string space = letters[nextX].ToString() + nextY.ToString();
                            Control nextSpace = Controls.Find(space, true)[0];
                            if (String.IsNullOrEmpty(nextSpace.Text))
                            {
                                moves.Add(space);
                                i++;
                            }
                            if (nextSpace.Tag != null)
                            {
                                if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                                {
                                    nextSpace.Enabled = true;
                                    nextSpace.BackColor = Color.LightCoral;
                                    canKill.Add(nextSpace.Text);
                                    break;
                                }
                                if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                //Colour
                foreach (var victim in canKill)
                {
                    string piece = GetPieceName(victim);
                    canKillTxt.Text += "\n" + piece;
                }

                foreach (var move in moves)
                {
                    Control canMove = Controls.Find(move, true)[0];
                    if (String.IsNullOrEmpty(canMove.Text))
                    {
                        canMove.BackColor = Color.PaleGreen;
                    }
                }
            }

        }

        public bool KingCheck(Button tile)
        {
            bool danger = false;
            Button Wking = new Button();
            Button Bking = new Button();

            foreach (Button btn in boardBox.Controls)
            {
                if (btn.Tag != null)
                {
                    if (btn.Text == "K" && btn.Tag.ToString() == "white")
                    {
                        Wking = btn;
                    }
                    if (btn.Text == "K" && btn.Tag.ToString() == "black")
                    {
                        Bking = btn;
                    } 
                }
            }

            List<string> moves = new List<string>();
            List<string> canKill = new List<string>();

            int currentY = tile.Name[1] - '0';
            int currentX = Array.IndexOf(letters, tile.Name[0]);

            //Forward Spaces
            for (int x = currentY + 1; x < 9; x++)
            {
                string space = tile.Name[0].ToString() + x.ToString();
                Control nextSpace = Controls.Find(space, true)[0];

                if (String.IsNullOrEmpty(nextSpace.Text))
                {
                    moves.Add(space);
                }
                if (nextSpace.Tag != null &&  tile.Tag != null)
                {
                    if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                    {
                        if (nextSpace.Text == "Q" || nextSpace.Text == "R")
                        {
                            return true;
                        }
                    }
                    if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                    {
                        break;
                    }
                }
            }

            //Backwards Spaces
            for (int x = currentY - 1; x > 0; x--)
            {
                string space = tile.Name[0].ToString() + x.ToString();
                Control nextSpace = Controls.Find(space, true)[0];

                if (String.IsNullOrEmpty(nextSpace.Text))
                {
                    moves.Add(space);
                }
                if (nextSpace.Tag != null && tile.Tag != null)
                {
                    if (nextSpace.Tag.ToString() != tile.Tag.ToString())
                    {
                        if (nextSpace.Text == "Q" || nextSpace.Text == "R")
                        {
                            return true;
                        }
                    }
                    if (nextSpace.Tag.ToString() == tile.Tag.ToString())
                    {
                        break;
                    }
                }
            }

            ////Right Side Spaces
            //for (int x = currentX + 1; x < 8; x++)
            //{
            //    string space = letters[x] + tile.Name[1].ToString();
            //    Control nextSpace = Controls.Find(space, true)[0];

            //    if (String.IsNullOrEmpty(nextSpace.Text))
            //    {
            //        moves.Add(space);
            //    }
            //    if (nextSpace.Tag != null)
            //    {
            //        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
            //        {
            //            nextSpace.Enabled = true;
            //            nextSpace.BackColor = Color.LightCoral;
            //            canKill.Add(nextSpace.Text);
            //            break;
            //        }
            //        if (nextSpace.Tag.ToString() == tile.Tag.ToString())
            //        {
            //            break;
            //        }
            //    }
            //}

            ////Left Side Spaces
            //for (int x = currentX - 1; x >= 0; x--)
            //{
            //    string space = letters[x] + tile.Name[1].ToString();
            //    Control nextSpace = Controls.Find(space, true)[0];

            //    if (String.IsNullOrEmpty(nextSpace.Text))
            //    {
            //        moves.Add(space);
            //    }
            //    if (nextSpace.Tag != null)
            //    {
            //        if (nextSpace.Tag.ToString() != tile.Tag.ToString())
            //        {
            //            nextSpace.Enabled = true;
            //            nextSpace.BackColor = Color.LightCoral;
            //            canKill.Add(nextSpace.Text);
            //            break;
            //        }
            //        if (nextSpace.Tag.ToString() == tile.Tag.ToString())
            //        {
            //            break;
            //        }
            //    }
            //}

            ////NorthWest
            //int i = 1;
            //while (true)
            //{
            //    int nextX = currentX - i;
            //    int nextY = currentY + i;

            //    if (nextX >= 0)
            //    {
            //        if (nextY <= 8)
            //        {
            //            string space = letters[nextX].ToString() + nextY.ToString();
            //            Control nextSpace = Controls.Find(space, true)[0];
            //            if (string.IsNullOrEmpty(nextSpace.Text))
            //            {
            //                moves.Add(space);
            //                i++;
            //            }
            //            if (nextSpace.Tag != null)
            //            {
            //                if (nextSpace.Tag.ToString() != tile.Tag.ToString())
            //                {
            //                    nextSpace.Enabled = true;
            //                    nextSpace.BackColor = Color.LightCoral;
            //                    canKill.Add(nextSpace.Text);
            //                    break;
            //                }
            //                if (nextSpace.Tag.ToString() == tile.Tag.ToString())
            //                {
            //                    break;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            ////NorthEast
            //i = 1;
            //while (true)
            //{
            //    int nextX = currentX + i;
            //    int nextY = currentY + i;

            //    if (nextX < 8)
            //    {
            //        if (nextY <= 8)
            //        {
            //            string space = letters[nextX].ToString() + nextY.ToString();
            //            Control nextSpace = Controls.Find(space, true)[0];
            //            if (string.IsNullOrEmpty(nextSpace.Text))
            //            {
            //                moves.Add(space);
            //                i++;
            //            }
            //            if (nextSpace.Tag != null)
            //            {
            //                if (nextSpace.Tag.ToString() != tile.Tag.ToString())
            //                {
            //                    nextSpace.Enabled = true;
            //                    nextSpace.BackColor = Color.LightCoral;
            //                    canKill.Add(nextSpace.Text);
            //                    break;
            //                }
            //                if (nextSpace.Tag.ToString() == tile.Tag.ToString())
            //                {
            //                    break;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            ////SouthEast
            //i = 1;
            //while (true)
            //{
            //    int nextX = currentX + i;
            //    int nextY = currentY - i;

            //    if (nextX < 8)
            //    {
            //        if (nextY > 0)
            //        {
            //            string space = letters[nextX].ToString() + nextY.ToString();
            //            Control nextSpace = Controls.Find(space, true)[0];
            //            if (string.IsNullOrEmpty(nextSpace.Text))
            //            {
            //                moves.Add(space);
            //                i++;
            //            }
            //            if (nextSpace.Tag != null)
            //            {
            //                if (nextSpace.Tag.ToString() != tile.Tag.ToString())
            //                {
            //                    nextSpace.Enabled = true;
            //                    nextSpace.BackColor = Color.LightCoral;
            //                    canKill.Add(nextSpace.Text);
            //                    break;
            //                }
            //                if (nextSpace.Tag.ToString() == tile.Tag.ToString())
            //                {
            //                    break;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            ////SouthWest
            //i = 1;
            //while (true)
            //{
            //    int nextX = currentX - i;
            //    int nextY = currentY - i;

            //    if (nextX >= 0)
            //    {
            //        if (nextY > 0)
            //        {
            //            string space = letters[nextX].ToString() + nextY.ToString();
            //            Control nextSpace = Controls.Find(space, true)[0];
            //            if (String.IsNullOrEmpty(nextSpace.Text))
            //            {
            //                moves.Add(space);
            //                i++;
            //            }
            //            if (nextSpace.Tag != null)
            //            {
            //                if (nextSpace.Tag.ToString() != tile.Tag.ToString())
            //                {
            //                    nextSpace.Enabled = true;
            //                    nextSpace.BackColor = Color.LightCoral;
            //                    canKill.Add(nextSpace.Text);
            //                    break;
            //                }
            //                if (nextSpace.Tag.ToString() == tile.Tag.ToString())
            //                {
            //                    break;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            return danger;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            RemoveHighlights();
            resetGame reset = new resetGame();
            //string imgPath = @"C:\Users\joseph.walker\Documents\MyFiles\pieces\";
            string imgPath = piecesDir;
            List<Button> btns = new List<Button>();
            foreach (Button button in boardBox.Controls)
            {
                button.Enabled = true;
                //Pawns
                if (button.Name.Contains("7"))
                {
                    button.Text = "P";
                    button.Tag = "black";
                    button.Enabled = false;
                    button.Image = Image.FromFile(imgPath + "blackPawn.png");
                }
                else if (button.Name.Contains("2"))
                {
                    button.Text = "P";
                    button.Tag = "white";
                    button.Enabled = true;
                    button.Image = Image.FromFile(imgPath + "whitePawn.png");
                }

                //Rooks
                else if (button.Name.Contains("A") || button.Name.Contains("H"))
                {
                    if (button.Name.Contains("1"))
                    {
                        button.Text = "R";
                        button.Tag = "white";
                        button.Enabled = true;
                        button.Image = Image.FromFile(imgPath + "whiteRook.png");
                    }
                    if (button.Name.Contains("8"))
                    {
                        button.Text = "R";
                        button.Tag = "black";
                        button.Enabled = false;
                        button.Image = Image.FromFile(imgPath + "blackRook.png");
                    }
                }

                //Knights
                else if (button.Name.Contains("B") || button.Name.Contains("G"))
                {
                    if (button.Name.Contains("1"))
                    {
                        button.Text = "N";
                        button.Tag = "white";
                        button.Enabled = true;
                        button.Image = Image.FromFile(imgPath + "whiteKnight.png");
                    }
                    if (button.Name.Contains("8"))
                    {
                        button.Text = "N";
                        button.Tag = "black";
                        button.Enabled = false;
                        button.Image = Image.FromFile(imgPath + "blackKnight.png");
                    }
                }

                //Bishops
                else if (button.Name.Contains("C") || button.Name.Contains("F"))
                {
                    if (button.Name.Contains("1"))
                    {
                        button.Text = "B";
                        button.Tag = "white";
                        button.Enabled = true;
                        button.Image = Image.FromFile(imgPath + "whiteBishop.png");
                    }
                    if (button.Name.Contains("8"))
                    {
                        button.Text = "B";
                        button.Tag = "black";
                        button.Enabled = false;
                        button.Image = Image.FromFile(imgPath + "blackBishop.png");
                    }
                }

                //Kings
                else if (button.Name == "E1")
                {
                    button.Text = "K";
                    button.Tag = "white";
                    button.Enabled = true;
                    button.Image = Image.FromFile(imgPath + "whiteKing.png");
                }

                else if (button.Name == "D8")
                {
                    button.Text = "K";
                    button.Tag = "black";
                    button.Enabled = false;
                    button.Image = Image.FromFile(imgPath + "blackKing.png");
                }

                //Queens
                else if (button.Name == "D1")
                {
                    button.Text = "Q";
                    button.Tag = "white";
                    button.Enabled = true;
                    button.Image = Image.FromFile(imgPath + "whiteQueen.png");
                }

                else if (button.Name == "E8")
                {
                    button.Text = "Q";
                    button.Tag = "black";
                    button.Enabled = false;
                    button.Image = Image.FromFile(imgPath + "blackQueen.png");
                }

                //Empty
                if (button.Name.Contains("3") || button.Name.Contains("4") || button.Name.Contains("5") || button.Name.Contains("6"))
                {
                    button.Text = string.Empty;
                    button.Tag = null;
                    button.Image = null;
                    button.Enabled = true;
                }
                
                turn = 0;
            }

            //White Box
            foreach (Button button in whiteBox.Controls)
            {
                button.Image = null;
                button.Visible = false;
                button.Enabled = false;
            }

            //Black Box
            foreach (Button button in blackBox.Controls)
            {
                button.Image = null;
                button.Visible = false;
                button.Enabled = false;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            var piece = (Button)sender;
            tradePiece.Image = piece.BackgroundImage;
            tradePiece.Text = piece.Text;
            piece.Text = string.Empty;
            piece.Image = null;
            piece.Enabled = false;
            piece.Visible = false;
            RemoveHighlights();
            SwitchTurn();
            foreach (Button btn in blackBox.Controls)
            {
                btn.Enabled = false;
                btn.Visible = true;
                btn.Text = btn.Name;
                btn.Image = null;
            }
            label1.Text = tradePiece.Name + "\n" + piece.Name;
            tradePiece = new Button();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var piece = (Button)sender;
            tradePiece.Image = piece.BackgroundImage;
            tradePiece.Text = piece.Text;
            piece.Text = string.Empty;
            piece.BackgroundImage = null;
            piece.Enabled = false;
            piece.Visible = false;
            RemoveHighlights();
            SwitchTurn();
            foreach (Button btn in whiteBox.Controls)
            {
                btn.Enabled = false;
                btn.Visible = true;
                btn.Text = btn.Name;
            }
            label1.Text = tradePiece.Name + "\n" + piece.Name;
            tradePiece = new Button();
            //ReorderBox("white");
        }

        public void ReorderBox(string colour)
        {
            int maxIndex = 15;
            int minVal = 16;
            Button slot = new Button();
            Button piece = new Button();

            if (colour == "white")
            {
                foreach(Button btn in whiteBox.Controls)
                {
                    //Find earliest tile without image
                    //Then find next image after that and place in space
                    //Go back to index of found space and repeat until last index reached
                    string val = Regex.Match(btn.Name, @"\d+").Value;
                    int value = Int32.Parse(val);
                    if (value < minVal && btn.BackgroundImage == null)
                    {
                        minVal = value;
                        slot = btn;
                    }
                    if (value > minVal && btn.BackgroundImage != null)
                    {
                        slot = btn;
                        btn.BackgroundImage = null;
                        btn.Text = string.Empty;
                    }
                }


            }
            else if (colour == "black")
            {

            }
        }

        private void Chess_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
