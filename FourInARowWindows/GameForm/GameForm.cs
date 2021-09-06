using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

               for (int i = 0; i < r_engine.GetGameBoard().NumOfCols; i++)
               {
                    r_actionButtons.Add(new ActionButton(i + 1));
               }
               for (int j = 0; j < r_engine.GetGameBoard().NumOfCols * r_engine.GetGameBoard().NumOfRows; j++)
               {
                    r_gameButtons.Add(new GameButton());
               }

               InitializeComponent();

               gameTable.RowCount = r_engine.GetGameBoard().NumOfRows + 1;
               gameTable.ColumnCount = r_engine.GetGameBoard().NumOfCols;
               this.gameTable.Size = new Size(r_engine.GetNumOfCols() * 45, r_engine.GetNumOfRows() * 50);
               this.Size = new Size(gameTable.Size.Width + 50, gameTable.Size.Height + 90);

              foreach (ActionButton button in r_actionButtons)
               {
                    
                button.Click += OnActionClicked;
                gameTable.Controls.Add(button);

               }
               foreach (GameButton button in r_gameButtons)
               {
                    gameTable.Controls.Add(button);
                    button.Enabled = true;
                    
               }
               updatePlayerStampsFromEngine();
               ShowDialog();
          }

         
          private void updatePlayerStampsFromEngine()
          {
               Player player1 = r_engine.GetPlayer1();
               Player player2 = r_engine.GetPlayer2();

               label3.Text = player1.Name + ": " + player1.Score;
               label4.Text = player2.Name + ": " + player2.Score;
          }

          private void OnActionClicked(object sender, EventArgs e)
          {

               ActionButton pressedButton = sender as ActionButton;
               string stringToEngine = pressedButton.Text;
               turn(stringToEngine);
               if (r_engine.GetCurrentPlayer().IsAnAi == true)
               {
                    stringToEngine = null;
                    turn(stringToEngine);
               }
          }

          private void turn(string i_input)
          {
               GameEngineLogic.eGameStatus status = r_engine.CommitTurn(i_input);
               MarkFinishedColumnsIfExist();
               drawTable();
               if (status == GameEngineLogic.eGameStatus.Win)
               {
                    gameWon();
               }
               else if (status == GameEngineLogic.eGameStatus.Tie)
               {
                    gameTie();
               }
          }

          private void gameTie()
          {
               if (MessageBox.Show("Tie!!\nAnother Round?", "A Tie!", MessageBoxButtons.YesNo) == DialogResult.Yes)
               {
                    r_engine.NewRound();
                    drawTable();
               }
               else
               {
                    this.Close();
               }
          }

          private void gameWon()
          {
               if (MessageBox.Show(r_engine.GetOppositePlayer().Name + "Won!!\nAnother Round?", "A Win!", MessageBoxButtons.YesNo) == DialogResult.Yes)
               {
                    updatePlayerStampsFromEngine();
                    r_engine.NewRound();
                    drawTable();
               }
               else
               {
                    this.Close();
               }
          }

          private void MarkFinishedColumnsIfExist() //TODO: remove GetGameBoard
          {
               if (r_engine.GetGameBoard().GameBoardMatrix[0, r_engine.GetLastColMove() - 1] !=
                   (byte)GameEngineLogic.ePlayerDisk.NullValue)
               {
                    r_actionButtons[r_engine.GetLastColMove() - 1].Enabled = false;
               }

          }

          private void drawTable()
          {
               for (int i = 0; i < r_engine.GetNumOfRows(); i++)
               {
                    for (int j = 0; j < r_engine.GetNumOfCols(); j++)
                    {
                         GameEngineLogic.ePlayerDisk currentDisk = r_engine.GetMatrixValue(i, j);
                         if (currentDisk == GameEngineLogic.ePlayerDisk.Player1)
                         {
                              r_gameButtons[i * r_engine.GetGameBoard().NumOfCols + j].Text = GameButton.k_player1Figure;
                         }
                         else if (currentDisk == GameEngineLogic.ePlayerDisk.Player2)
                         {
                              r_gameButtons[i * r_engine.GetGameBoard().NumOfCols + j].Text = GameButton.k_player2Figure;
                         }
                         else
                         {
                              r_gameButtons[i * r_engine.GetGameBoard().NumOfCols + j].Text = GameButton.k_nullFigure;
                         }
                    }
               }
          }






        // private bool IsContinueRound()
        // {
        //     bool isAnotherRound = true;
        //     Player currentPlayer = r_engine.GetCurrentPlayer();
        //     if (status == GameEngineLogic.eGameStatus.Win)
        //     {
        //         if (MessageBox.Show(currentPlayer.Name + "Won!!\nAnother Round?", "A Win!", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //         {
        //             currentPlayer = 
        //         }
        //         else
        //         {
        //             this.Close();
        //         }
        //     }
        //     else if (status == GameEngineLogic.eGameStatus.Tie)
        //     {
        //
        //     }
        //     else
        //     {
        //         isAnotherRound = false;
        //
        //         this.Close();
        //     }
        //     return isAnotherRound;
        //     }

    }
}
