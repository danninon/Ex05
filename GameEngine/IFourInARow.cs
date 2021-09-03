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
        bool InitializePlayer2AndOpponent(string i_StrUserRequest);
        void InitializePlayerSkeleton();

    }
}
