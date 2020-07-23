using System;
using System.Collections.Generic;
using System.Text;

namespace TTT
{
    class Heuristic
    {
        
        //Chooses how good a gamestate is for the MinMax algorithm
       public static int heurNum(GameState gameState, int supportedPlayer)
        {
            
            if (supportedPlayer == gameState.getWinner()){
                return -10;
            } else if (gameState.getWinner() == 0)
            {
                return 0;
            }
            else
            {
                return 10;
            }
            
        }

    }
}
