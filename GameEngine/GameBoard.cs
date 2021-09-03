using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
     public class GameBoard
     {
          //[Rows, Cols]
          private byte[,] m_GameBoardMatrix; //TODO: should be readonly (?)
          public byte[,] GameBoardMatrix => m_GameBoardMatrix;

          private byte m_CellsFilled;
          public byte CellsFilled => m_CellsFilled;

          private readonly int m_NumOfCols;
          public int NumOfCols => m_NumOfCols; //a getter to m_NumOfCols

          private readonly int m_NumOfRows;
          public int NumOfRows => m_NumOfRows; //a getter to m_NumOfRows

          public byte MatrixValue(int i_Row, int i_Col)
          {
               return m_GameBoardMatrix[i_Row, i_Col];
          }

          public GameBoard(string i_StrNumOfRows, string i_StrNumOfCols)
          {
               //checks numbers were entered
               int.TryParse(i_StrNumOfRows, out m_NumOfRows);
               int.TryParse(i_StrNumOfCols, out m_NumOfCols);

               //checks between 4 and 8
               if (!(m_NumOfRows <= 8) || !(m_NumOfRows >= 4))
               {
                    throw new Exception("Illegal amount of rows chosen: You've been asked to choose a number between 4 and 8, whereas you've entered: " + i_StrNumOfRows + " which is, needless to say, an illegal amount.");
               }

               if (!(m_NumOfCols <= 8) || !(m_NumOfCols >= 4))
               {
                    throw new Exception("Illegal amount of columns chosen: You've been asked to choose a number between 4 and 8, whereas you've entered: " + i_StrNumOfCols + " which is, needless to say, an illegal amount.");
               }

               // $G$ DSN-001 (-5) Coins should be represented by either a struct, a class or an enum.
               //initializes tables with 0s of the requested amount of rows and columns
               m_GameBoardMatrix = new byte[m_NumOfRows, m_NumOfCols];
          }

          public void AddDisk(int i_UserChoice, GameEngineLogic.ePlayerValue i_NewValue)
          {
               for (int i = m_NumOfRows - 1; i >= 0; i--)
               {
                    if (m_GameBoardMatrix[i, i_UserChoice - 1] == (byte)GameEngineLogic.ePlayerValue.NullValue)
                    {
                         m_GameBoardMatrix[i, i_UserChoice - 1] = (byte)i_NewValue;
                         break;
                    }
               }
               m_CellsFilled++;
          }

          public GameEngineLogic.eGameStatus CheckGameStatus(byte i_CurrentPlayer)
          {
               GameEngineLogic.eGameStatus gameStatus = GameEngineLogic.eGameStatus.ContinuePlayingRound;

               if (m_CellsFilled == (m_NumOfCols * m_NumOfRows))
               {
                    gameStatus = GameEngineLogic.eGameStatus.Tie;
               }
               else
               {
                    verticalCheck(ref gameStatus, i_CurrentPlayer);
                    horizontalCheck(ref gameStatus, i_CurrentPlayer);
                    ascendingDiagonalCheck(ref gameStatus, i_CurrentPlayer);
                    descendingDiagonalCheck(ref gameStatus, i_CurrentPlayer);
               }
               return gameStatus;
          }

          private void verticalCheck(ref GameEngineLogic.eGameStatus status, byte i_CurrentPlayer)
          {
               for (int j = 0; j < m_NumOfCols; j++)
               {
                    for (int i = 0; i < m_NumOfRows - 3; i++)
                    {
                         if ((m_GameBoardMatrix[i, j] == i_CurrentPlayer) && (m_GameBoardMatrix[i + 1, j] == i_CurrentPlayer)
                              && (m_GameBoardMatrix[i + 2, j] == i_CurrentPlayer) && (m_GameBoardMatrix[i + 3, j] == i_CurrentPlayer))
                         {
                              status = GameEngineLogic.eGameStatus.Win;
                         }
                    }
               }
          }

          private void horizontalCheck(ref GameEngineLogic.eGameStatus status, byte i_CurrentPlayer)
          {
               for (int j = 0; j < m_NumOfCols - 3; j++)
               {
                    for (int i = 0; i < m_NumOfRows; i++)
                    {
                         if ((m_GameBoardMatrix[i, j] == i_CurrentPlayer) && (m_GameBoardMatrix[i, j + 1] == i_CurrentPlayer)
                              && (m_GameBoardMatrix[i, j + 2] == i_CurrentPlayer) && (m_GameBoardMatrix[i, j + 3] == i_CurrentPlayer))
                         {
                              status = GameEngineLogic.eGameStatus.Win;
                         }
                    }
               }
          }

          private void ascendingDiagonalCheck(ref GameEngineLogic.eGameStatus status, byte i_CurrentPlayer)
          {
               for (int j = 0; j < m_NumOfCols - 3; j++)
               {
                    for (int i = 3; i < m_NumOfRows; i++)
                    {
                         if ((m_GameBoardMatrix[i, j] == i_CurrentPlayer) && (m_GameBoardMatrix[i - 1, j + 1] == i_CurrentPlayer)
                              && (m_GameBoardMatrix[i - 2, j + 2] == i_CurrentPlayer) && (m_GameBoardMatrix[i - 3, j + 3] == i_CurrentPlayer))
                         {
                              status = GameEngineLogic.eGameStatus.Win;
                         }
                    }
               }
          }

          private void descendingDiagonalCheck(ref GameEngineLogic.eGameStatus status, byte i_CurrentPlayer)
          {
               for (int j = 0; j < m_NumOfCols - 3; j++)
               {
                    for (int i = 0; i < m_NumOfRows - 3; i++)
                    {
                         if ((m_GameBoardMatrix[i, j] == i_CurrentPlayer) && (m_GameBoardMatrix[i + 1, j + 1] == i_CurrentPlayer)
                              && (m_GameBoardMatrix[i + 2, j + 2] == i_CurrentPlayer) && (m_GameBoardMatrix[i + 3, j + 3] == i_CurrentPlayer))
                         {
                              status = GameEngineLogic.eGameStatus.Win;
                         }
                    }
               }
          }

          public void Clear()
          {
               m_GameBoardMatrix = new byte[m_NumOfRows, m_NumOfCols];
               m_CellsFilled = 0;
          }
     }
}
