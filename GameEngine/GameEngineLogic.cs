using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameEngine
{
     public class GameEngineLogic : IFourInARow
     {
          private readonly GameBoard r_GameBoard;
          public const string k_AiOpponent = "2";
          public const string k_RealOpponent = "1";
          private int m_LastColColMove;

          public GameEngineLogic.ePlayerDisk GetMatrixValue(int i_Row, int i_Col)
          {
               return r_GameBoard.GameBoardMatrix[i_Row, i_Col];
          }

          public int LastColMove
          {
              get => m_LastColColMove;
              set => m_LastColColMove = value;
          }

          public int GetLastColMove()
          {
               return LastColMove;
          }

          public int GetNumOfCols()
          {
               return r_GameBoard.NumOfCols;
          }

          public int GetNumOfRows()
          {
               return r_GameBoard.NumOfRows;
          }

          public enum eGameStatus
          {
               ContinuePlayingRound,
               Tie,
               Win,
               Forfeit
          }
          public enum ePlayerDisk
          {
               NullValue,
               Player1,
               Player2
          }

          public GameEngineLogic(string i_RowsInTable, string i_ColsInTable)
          {
               r_GameBoard = new GameBoard(i_RowsInTable, i_ColsInTable);
               Player1 = new Player(false); //fields are initialized to not AI, score - 0
               isCurrentPlayer1 = true;
               CurrentPlayer = Player1;
               CurrentOpponent = Player2;
          }

          //assumes no turns have been made into the game yet, a
          public bool InitializePlayer2AndOpponent(string i_ReadLine, string i_PlayerName)
          {
               if (i_ReadLine == k_AiOpponent)
               {
                    Player2 = new Player(true);
               }
               else if (i_ReadLine == k_RealOpponent)
               {
                    Player2 = new Player(false);
               }
               else //then error, throw it
               {
                    throw new Exception("You may only enter 1 for an AI or 2 for a real opponent");
               }
               Player2.Name = i_PlayerName;
               CurrentOpponent = Player2;
               return true;
          }

          public eGameStatus CommitTurn(string io_UserChoice)
          {
               int UserChoice = 0;
               if (io_UserChoice!= null)
               {
                    UserChoice = int.Parse(io_UserChoice);
                    LastColMove = UserChoice;
               }
               GameEngineLogic.ePlayerDisk currentPlayer = GameEngineLogic.ePlayerDisk.Player1;
               eGameStatus currentStatus = eGameStatus.ContinuePlayingRound;


               if (this.isCurrentPlayer1)
               {
                    r_GameBoard.AddDisk(UserChoice, ePlayerDisk.Player1);
               }
               else
               {
                    if (Player2.IsAnAi)
                    {

                         r_GameBoard.AddDisk(SimpleAiLogic(), ePlayerDisk.Player2);
                    }
                    else
                    {
                         r_GameBoard.AddDisk(UserChoice, ePlayerDisk.Player2);
                    }
                    currentPlayer = GameEngineLogic.ePlayerDisk.Player2;
               }

               currentStatus = r_GameBoard.CheckGameStatus(currentPlayer);
               if (currentStatus == eGameStatus.Win)
               {
                    increaseScoreToPlayer(CurrentPlayer);
               }
               SwitchToOtherPlayer();
            return currentStatus;
          }

          public int SimpleAiLogic()
          {
               
              int LastMoveForAI = new Random().Next(1, r_GameBoard.NumOfCols + 1);
               while(r_GameBoard.GameBoardMatrix[0, LastMoveForAI - 1] != GameEngineLogic.ePlayerDisk.NullValue)
               {
                    LastMoveForAI = new Random().Next(1, r_GameBoard.NumOfCols + 1);
               }

               return LastMoveForAI;
          }


          private void increaseScoreToPlayer(Player o_Player)
          {
               ++o_Player.Score;
          }

          public GameBoard GameBoard
          {
               get => r_GameBoard;
          }

          public GameBoard GetGameBoard()
          {
               return GameBoard;
          }

          private Player m_Player1;
          private Player Player1
          {
               get => m_Player1;
               set => m_Player1 = value;
          } //fields are initialized to not AI, score - 0

          public Player GetPlayer1()
          {
               return Player1;
          }

          public Player GetPlayer2()
          {
               return Player2;
          }

          private Player m_Player2;
          public Player Player2
          {
               get => m_Player2;
               set => m_Player2 = value;
          }

          private Player m_CurrentPlayer;
          public Player CurrentPlayer
          {
               get => m_CurrentPlayer;
               set => m_CurrentPlayer = value;
          }

          public Player GetCurrentPlayer()
          {
               return CurrentPlayer;
          }

          public Player GetOppositePlayer()
          {
               return CurrentOpponent;
          }

          private Player m_CurrentOpponent;

          public Player CurrentOpponent
          {
               get => m_CurrentOpponent;
               set => m_CurrentOpponent = value;
          } 

          private bool m_IsCurrentPlayer1;

          public bool IsCurrentAi()
          {
               bool currentIsAnAiStatus = false;
               if (!isCurrentPlayer1)
               {
                    if (Player2.IsAnAi)
                    {
                         currentIsAnAiStatus = true;
                    }
               }

               return currentIsAnAiStatus;
          }

          public bool isCurrentPlayer1
          {
               get => m_IsCurrentPlayer1;
               set => m_IsCurrentPlayer1 = value;
          }

          public bool isPlayer1()
          {
               return isCurrentPlayer1;
          }


          public void SwitchToOtherPlayer()
          {
               isCurrentPlayer1 = !isCurrentPlayer1;
               if (CurrentPlayer == Player1)
               {
                    CurrentPlayer = Player2;
                    CurrentOpponent = Player1;
               }
               else
               {
                    CurrentPlayer = Player1;
                    CurrentOpponent = Player2;
               }

          }

          public int GetUserScore(bool i_Player1)
          {
               int retValue;
               retValue = i_Player1 ? Player1.Score : Player2.Score;

               return retValue;
          }

          public void ForfietRound()
          {
               increaseScoreToPlayer(CurrentOpponent);
               SwitchToOtherPlayer();
          }

          public void NewRound()
          {
               r_GameBoard.Clear();
          }
     }
}
