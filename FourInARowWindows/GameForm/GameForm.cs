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

            foreach (ActionButton button in r_actionButtons)
            {
                button.Click += new System.EventHandler(OnActionClicked);
                gameTable.Controls.Add(button);
                // button.Anchor = (AnchorStyles)(Top);

            }
            foreach (GameButton button in r_gameButtons)
            {
                gameTable.Controls.Add(button);
                button.Enabled = false;
                // button.Anchor = AnchorStyles.Top;
            }
            updatePlayerStampsFromEngine();

            ShowDialog();
        }

        private void updatePlayerStampsFromEngine()
        {
            Player player1 = r_engine.GetPlayer1();
            Player player2 = r_engine.GetPlayer2();
            string label1String;

            label1.Text = "Player1: " + player1.Name + " | Score: " + player1.Score;

            if (player2.IsAnAi)
            {
                label2.Text = "Player2( " + player2.Name + ") | Score: " + player2.Score;
            }
            else
            {
                label2.Text = "Player2: " + player2.Name + " | Score: " + player2.Score;
            }
        }

        private void OnActionClicked(object sender, EventArgs e)
        {
            
            bool anotherRound = false;
            ActionButton pressedButton = sender as ActionButton;
            string stringToEngine = pressedButton.Text;
            if (r_engine.GetCurrentPlayer().IsAnAi == true)
            {
                stringToEngine = null;
            }

            GameEngineLogic.eGameStatus status = r_engine.CommitTurn(stringToEngine);

            if (status == GameEngineLogic.eGameStatus.Win)
            {
                MessageBox.Show(r_engine.GetCurrentPlayer().Name + "Won!!\nAnother Round?", "A Win!",
                    MessageBoxButtons.YesNo);
               
                    updatePlayerStampsFromEngine();
                    r_engine.NewRound();
                
            }

            else if (status == GameEngineLogic.eGameStatus.Tie)
            {
                MessageBox.Show("Tie!!\nAnother Round?", "A Tie!", MessageBoxButtons.YesNo);
              
                    r_engine.GetGameBoard().Clear();
                    r_engine.NewRound();
                
            }
            else
            {
                MarkFinishedColumnsIfExist();
                drawDiskTable(r_engine.GetNumOfCols() - 1);

                if (r_engine.GetCurrentPlayer().IsAnAi)
                {
                    r_engine.CommitTurn(null);
                    MarkFinishedColumnsIfExist();
                    drawDiskTable(r_engine.GetNumOfCols() - 1);
                }
            }
        }

        private void MarkFinishedColumnsIfExist()
        {
            if (r_engine.GetGameBoard().GameBoardMatrix[0, r_engine.GetLastColMove() - 1] !=
                (byte)GameEngineLogic.ePlayerDisk.NullValue)
            {
                r_actionButtons[r_engine.GetLastColMove() - 1].Enabled = false;
            }

        }

        private void drawDiskTable(int i_col)
        {
            for (int i = r_engine.GetGameBoard().NumOfRows - 1; i >= 0; i--)
            {
                if (r_gameButtons[i * r_engine.GetGameBoard().NumOfCols + i_col].Text == "")
                {
                    r_gameButtons[i * r_engine.GetGameBoard().NumOfCols + i_col].ChangeText(!r_engine.isPlayer1());
                    break;
                }
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

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
