using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEngine;

namespace FourInARowWindows
{
     public partial class GameForm : Form 
     {
          private readonly IFourInARow r_engine;
          public GameForm(IFourInARow i_Engine)
          {
               r_engine = i_Engine;
               InitializeComponent();
               generatePlayersNames();
               ShowDialog();
          }

          private void generatePlayersNames()
          {
               label1.Text = r_engine.GetPlayer1().Name;
               label2.Text = r_engine.GetPlayer2().Name;
          }
     }
}
