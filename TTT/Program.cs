using System;

namespace TTT
{
    class Program
    {
        static byte askUser(String message)
        {
            byte number = 0;
            while (number==0) {
                try
                {
                    Console.WriteLine(message);
                    number = Byte.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("No good number.");
                }
            }

            return number;
        }

        static void Main(string[] args)
        {
            GameState game = new GameState();
            Operator step;
            int round = 0;
            byte row, column;

            game.showState();

            while (round < 9)
            {
                if (round % 2 == 0)
                {
                    row = askUser("Enter the row: ");
                    column = askUser("Enter the column: ");
                    step = new Operator(--row, --column);
                }

                else
                {
                    step = StepAdvisor.offerMove(game, 0, -1);
                }

                if (step.isApplicable(game.getState()))
                {
                    Console.WriteLine("Player making a move {0}", game.getCurrent());
                    game = step.applyMove(game);
                    game.showState();
                    if (game.isWinningState())
                    {
                        game.setGameOver();
                        break;
                    }

                    round++;

                    //In case of draw
                    if (round == 9)
                    {
                        Console.WriteLine("Noone won. Losers.");
                    }
                }
                else
                {
                    Console.WriteLine("Move cannot be applied.");
                }
            }
        }
    }
}
