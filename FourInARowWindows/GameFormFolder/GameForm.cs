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
          private readonly List<ActionButton> actionButtons;
          private readonly List<GameButton> gameButtons;
          GameEngineLogic.eGameStatus status;

          public GameForm(IFourInARow i_Engine)
          {
               actionButtons = new List<ActionButton>();
               gameButtons = new List<GameButton>();
               r_engine = i_Engine;
               for(int i = 0; i < r_engine.GetGameBoard().NumOfCols; i++)
               {
                    actionButtons.Add(new ActionButton(i+1));
               }
               for(int j = 0; j < r_engine.GetGameBoard().NumOfCols * r_engine.GetGameBoard().NumOfRows; j++)
               {
                    gameButtons.Add(new GameButton());
               }

               InitializeComponent();

               foreach(ActionButton button in actionButtons)
               {
                    button.Click += new System.EventHandler(OnActionClicked);
                    flowLayoutPanel1.Controls.Add(button);
               }
               foreach(GameButton button in  gameButtons)
               {

                    flowLayoutPanel1.Controls.Add(button);
               }
               generatePlayersNames();
               ShowDialog();
          }

          private void generatePlayersNames()
          {
               label1.Text = r_engine.GetPlayer1().Name;
               label1.Text += ": ";
               label2.Text = r_engine.GetPlayer2().Name;
               label2.Text += ": ";
          }

          private void OnActionClicked(object sender, EventArgs e)
          {
               status = r_engine.CommitTurn((sender as Button).Text);
               if (r_engine.GetGameBoard().GameBoardMatrix[0, int.Parse((sender as Button).Text) - 1] != (byte)GameEngineLogic.ePlayerValue.NullValue)
               {
                    this.Enabled = false;
               }

               if (status == GameEngineLogic.eGameStatus.Win)
               {
                    MessageBox.Show(r_engine.GetCurrentPlayer().Name + "Won!!\nAnother Round?", "A Win!", MessageBoxButtons.YesNo);
               }
               else if(status == GameEngineLogic.eGameStatus.Tie)
               {
                    MessageBox.Show("Tie!!\nAnother Round?", "A Tie!", MessageBoxButtons.YesNo);
               }

               if (r_engine.GetPlayer2().IsAnAi)
               {
                    r_engine.CommitTurn(null);//This is a computer's automatic turn
               }
          }
     }
}
