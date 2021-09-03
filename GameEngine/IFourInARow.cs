using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
     public interface IFourInARow
     {
          void CreateGameBoard(string i_RowsInTable, string i_ColsInTable);
          bool InitializePlayer2AndOpponent(string i_ReadLine, string i_PlayerName);
          void InitializePlayerSkeleton(string i_PlayerName);
          GameEngineLogic.eGameStatus CommitTurn(string io_UserChoice);
          Player GetPlayer1();
          Player GetPlayer2();
          GameBoard GetGameBoard();
          Player GetCurrentPlayer();
     }
}
