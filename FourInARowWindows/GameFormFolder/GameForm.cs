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
          private readonly List<ActionButton> r_actionButtons;
          private readonly List<GameButton> r_gameButtons;
          GameEngineLogic.eGameStatus status;

          public GameForm(IFourInARow i_Engine)
          {
               r_actionButtons = new List<ActionButton>();
               r_gameButtons = new List<GameButton>();
               r_engine = i_Engine;
               for(int i = 0; i < r_engine.GetGameBoard().NumOfCols; i++)
               {
                    r_actionButtons.Add(new ActionButton(i+1));
               }
               for(int j = 0; j < r_engine.GetGameBoard().NumOfCols * r_engine.GetGameBoard().NumOfRows; j++)
               {
                    r_gameButtons.Add(new GameButton());
               }

               InitializeComponent();
               gameTable.RowCount = r_engine.GetGameBoard().NumOfRows;
               gameTable.ColumnCount = r_engine.GetGameBoard().NumOfCols;

               foreach (ActionButton button in r_actionButtons)
               {
                    button.Click += new System.EventHandler(OnActionClicked);
                    gameTable.Controls.Add(button);
               }
               foreach(GameButton button in  r_gameButtons)
               {
                    gameTable.Controls.Add(button);
                    button.Anchor = AnchorStyles.Top;
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
               drawDisk(int.Parse((sender as Button).Text) - 1);
               if (r_engine.GetGameBoard().GameBoardMatrix[0, int.Parse((sender as Button).Text) - 1] != (byte)GameEngineLogic.ePlayerValue.NullValue)
               {
                    r_actionButtons[int.Parse((sender as Button).Text)].Enabled = false;
               }
               showStatusMessage();

               if (r_engine.GetPlayer2().IsAnAi)
               {
                    commitAITurn();

               }
          }

          private void commitAITurn()
          {
               status = r_engine.CommitTurn(null); //This is a computer's automatic turn
               drawDisk(r_engine.GetLastMoveForAI());
               if (r_engine.GetGameBoard().GameBoardMatrix[0, r_engine.GetLastMoveForAI() - 1] != (byte)GameEngineLogic.ePlayerValue.NullValue)
               {
                    r_actionButtons[r_engine.GetLastMoveForAI()].Enabled = false;
               }
               showStatusMessage();
          }

          private void drawDisk(int i_col)
          {
               //for(int i = r_engine.GetGameBoard().NumOfRows - 1; i > 0; i--)
               {
                    if(r_gameButtons[i_col].Text == "")
                    {
                         r_gameButtons[0].ChangeText(!r_engine.isPlayer1()); // TODO: TEST ONLY - should be a proper index not 0
                         //break;
                    }
               }
          }

          private void showStatusMessage()
          {
               Player currentPlayer = r_engine.GetCurrentPlayer();
               if (status == GameEngineLogic.eGameStatus.Win)
               {
                    if (MessageBox.Show(currentPlayer.Name + "Won!!\nAnother Round?", "A Win!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                         label1.Text = r_engine.GetPlayer1().Score.ToString();
                         label2.Text = r_engine.GetPlayer2().Score.ToString();
                         //TODO: start a new game
                    }
                    else
                    {
                         this.Close();
                    }
               }
               else if (status == GameEngineLogic.eGameStatus.Tie)
               {
                    if (MessageBox.Show("Tie!!\nAnother Round?", "A Tie!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                         //TODO: start a new game
                    }
                    else
                    {
                         this.Close();
                    }
               }
          }
     }
}
