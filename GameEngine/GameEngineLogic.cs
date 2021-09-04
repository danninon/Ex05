using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
     public class GameEngineLogic : IFourInARow
     {
          // $G$ CSS-999 (-2) this member should be readonly.
          private GameBoard m_GameBoard;
          public const string k_AiOpponent = "2";
          public const string k_RealOpponent = "1";
          private int m_lastMoveForAI;

          public int LastMoveForAI
          {
              get => m_lastMoveForAI;
              set => m_lastMoveForAI = value;
          }

          public int GetLastMoveForAI()
          {
               return LastMoveForAI;
          }


          public enum eGameStatus
          {
               ContinuePlayingRound,
               Tie,
               Win,
               Forfeit
          }
          public enum ePlayerValue
          {
               NullValue,
               Player1,
               Player2
          }

          // $G$ DSN-004 (-5) Redundant code duplication, should call InitializePlayerSkeleton
          //ctor - actually initializes o_Player 1
          public GameEngineLogic()
          {
               Player1 = new Player(false); //fields are initialized to not AI, score - 0
               isCurrentPlayer1 = true;
               CurrentPlayer = Player1;
               CurrentOpponent = Player2;
          }

          // $G$ CSS-014 (-3) Bad parameter name (should be in the form of o_PascalCase).
          public void CreateGameBoard(string i_RowsInTable, string i_ColsInTable)
          {
               m_GameBoard = new GameBoard(i_RowsInTable, i_ColsInTable);
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
               }
               byte currentPlayer = 1;
               eGameStatus currentStatus = eGameStatus.ContinuePlayingRound;

               if (this.isCurrentPlayer1)
               {
                    m_GameBoard.AddDisk(UserChoice, ePlayerValue.Player1);
               }
               else
               {
                    if (Player2.IsAnAi)
                    {
                         m_GameBoard.AddDisk(aiIncredibleLogic(), ePlayerValue.Player2);
                    }
                    else
                    {
                         m_GameBoard.AddDisk(UserChoice, ePlayerValue.Player2);
                    }
                    currentPlayer = 2;
               }

               currentStatus = m_GameBoard.CheckGameStatus(currentPlayer);
               if (currentStatus == eGameStatus.Win)
               {
                    increaseScoreToPlayer(CurrentPlayer);
               }
               else
               {
                    SwitchToOtherPlayer();
               }
               return currentStatus;
          }

          private int aiIncredibleLogic()
          {
               LastMoveForAI =  new Random().Next(1, m_GameBoard.NumOfCols);
               return LastMoveForAI;
          }


          private void increaseScoreToPlayer(Player o_Player)
          {
               ++o_Player.Score;
          }

          public GameBoard GameBoard
          {
               get => m_GameBoard;
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

          public void InitializePlayerSkeleton(string i_PlayerName)
          {
               Player1 = new Player(false); //fields are initialized to not AI, score - 0
               Player1.Name = i_PlayerName;
               isCurrentPlayer1 = true;
               CurrentPlayer = Player1;
               CurrentOpponent = Player2;
          }

          public void ForfietRound()
          {
               increaseScoreToPlayer(CurrentOpponent);
               SwitchToOtherPlayer();
          }

          public void NewRound()
          {
               m_GameBoard.Clear();
          }
     }
}
