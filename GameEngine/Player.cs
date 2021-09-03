using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
     public class Player
     {
          private readonly bool m_IsAnAi;
          private int m_Score;

          public Player(bool i_IsPlayerAnAi)
          {
               m_IsAnAi = i_IsPlayerAnAi;
               m_Score = 0;
          }

          public bool IsAnAi
          {
               get => m_IsAnAi;
          }
          public int Score
          {
               get => m_Score;
               set => m_Score = value;
          }
     }
}
