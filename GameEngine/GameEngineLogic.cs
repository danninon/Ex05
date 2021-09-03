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

          public eGameStatus CommitTurn(string i_UserColumnInput, out int io_UserChoice)
          {
               //int io_UserChoice;
               byte currentPlayer = 1;
               eGameStatus currentStatus = eGameStatus.ContinuePlayingRound;

               //gets an int value \ throws i_UserColumnInput isn't parseable to int if it isn't int
               analyzeInputTypeAndReturnProperNumber(i_UserColumnInput, out io_UserChoice);

               //O.K input
               if (io_UserChoice >= 1
                    && io_UserChoice <= m_GameBoard.NumOfCols &&
                    m_GameBoard.GameBoardMatrix[0, io_UserChoice - 1] == (byte)ePlayerValue.NullValue)
               {
                    if (this.isCurrentPlayer1)
                    {
                         m_GameBoard.AddDisk(io_UserChoice, ePlayerValue.Player1);
                    }
                    else
                    {
                         m_GameBoard.AddDisk(io_UserChoice, ePlayerValue.Player2);
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
               }
               else if (io_UserChoice >= 1
                    && io_UserChoice <= m_GameBoard.NumOfCols)
               {
                    throw new Exception(i_UserColumnInput + " column is full, Please choose again.");
               }
               //throws if not a valid number
               else
               {
                    throw new Exception(i_UserColumnInput + " column is out of bound, Please choose again.");
               }

               return currentStatus;
          }

          private void analyzeInputTypeAndReturnProperNumber(string i_UserColumnInput, out int io_UserChoice)
          {
               //checks if human input or computer input
               //then it's an Ai
               if (i_UserColumnInput == null)
               {
                    //for now just randomizes a number
                    io_UserChoice = aiIncredibleLogic();
               }
               //checks real users input
               else
               {
                    //throws if not a number
                    if (!(int.TryParse(i_UserColumnInput, out io_UserChoice)))
                    {
                         throw new Exception("You've entered: " + i_UserColumnInput + " Which is an illegal input");
                    }
               }
          }

          private int aiIncredibleLogic()
          {
               return new Random().Next(1, m_GameBoard.NumOfCols);
          }


          private void increaseScoreToPlayer(Player o_Player)
          {
               ++o_Player.Score;
          }

          public GameBoard GetGameBoard
          {
               get => m_GameBoard;
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
