using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Testing
{
    class resetGame
    {
        //public Button[] buttons { get; set; }
        public Button button { get; set; }
        public string imgPath = @"C:\Users\joseph.walker\Documents\MyFiles\pieces\";

        public void ResetBoard()
        {
            //Pawns
            if (button.Name.Contains("7"))
            {
                button.Text = "P";
                button.Tag = "black";
                button.Enabled = false;
                button.Image = Image.FromFile(imgPath+"blackPawn.png");
            }

            //Rooks


            //Knights


            //Bishops


            //Queens


            //Kings
        }

        public void ResetButton()
        {

        }

    }
}
