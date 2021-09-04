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
          private const string k_player1Figure = "X";
          private const string k_player2Figure = "O";

          public void ChangeText(bool i_isPlayer1)
          {
               if(i_isPlayer1)
               {
                    this.Text = k_player1Figure;
               }
               else
               {
                    this.Text = k_player2Figure;
               }
          }
     }
}
