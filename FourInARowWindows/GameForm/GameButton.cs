using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourInARowWindows
{
     public class GameButton : Button
     {
          public const string k_player1Figure = "X";
          public const string k_player2Figure = "O";
          public const string k_nullFigure = "";
        
          public GameButton()
          {
            this.Height = 40;
            this.Width = 40;
          }

     }
}
