using System;

namespace TTT
{
    class GameState
    {
        private char[,] gameState;
        int currentPlayer;


        public GameState()
        {
            this.gameState = new char[3, 3]
            {
                {' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };

            this.currentPlayer = 1;
        }

        //Get gamestate object
        public GameState(char[,] gameState, int current)
        {
            this.gameState = gameState;
            this.currentPlayer = current;
        }

        //Get current player
        public int getCurrent()
        {
            return this.currentPlayer;
        }

        //Get gamestate structure
        public char[,] getState()
        {
            return this.gameState;
        }

        //Writes the state
        public void showState()
        {
            Console.WriteLine("Game state right now: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("[ {0} ]", this.gameState[i, j]);
                    if (j == 2)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }


        public void setGameOver()
        {
            switch (this.currentPlayer)
            {
                case -1:
                    Console.WriteLine("Game Won. Winner is Player With O.");
                    break;
                case 1:
                    Console.WriteLine("Game Won. Winner is Player With X");
                    break;

            }


        }

        public bool isWinningState()
        {
            for (int i = 0; i < 3; i++)
            {
                if ((this.gameState[i, 0] == this.gameState[i, 1]
                      && this.gameState[i, 1] == this.gameState[i, 2]) && this.gameState[i, 0] != ' ')
                {
                    return true;
                }
                else if ((this.gameState[0, i] == this.gameState[1, i]
                    && this.gameState[1, i] == this.gameState[2, i]) && this.gameState[0, i] != ' ')
                {
                    return true;
                }
            }

            if (this.gameState[0, 0] == this.gameState[1, 1] && this.gameState[1, 1] == this.gameState[2, 2] && this.gameState[1, 1] != ' ')
            {
                return true;
            }

            if (this.gameState[2, 0] == this.gameState[1, 1] && this.gameState[1, 1] == this.gameState[0, 2] && this.gameState[1, 1] != ' ')
            {
                return true;
            }

            return false;
        }

    
    public bool isOver()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (this.gameState[i, j] == ' ')
                        return false;
            return true;
        }

    public int getWinner()
        {
            if (isWinningState())
            {
                return this.currentPlayer;
            }
            else
            {
                return 0;
            }
        }

    }
}