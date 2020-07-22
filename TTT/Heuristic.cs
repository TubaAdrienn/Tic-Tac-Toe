using System;
using System.Collections.Generic;
using System.Text;

namespace TTT
{
    class Heuristic
    {
        
       public static int heurNum(GameState gameState, int supportedPlayer)
        {
            supportedPlayer *= -1;
            if (supportedPlayer == gameState.getWinner()){
                return 10;
            } else if (gameState.getWinner() == 0)
            {
                return 0;
            }
            else
            {
                return -10;
            }
            
        }

    }
}
