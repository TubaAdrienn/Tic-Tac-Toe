using System;

namespace TTT
{
    class StepAdvisor
    {
       
        //Simple MinMax algorithm
        public static Operator offerMove(GameState gameState, int depth, int supportedPlayer)
        {
            Operator best = null;
            Operator operators = new Operator();
            double max = int.MinValue;
           
            foreach (Operator op in operators.getOperators())
            {
                if (op.isApplicable(gameState.getState()))
                {
                    GameState nextState = op.applyMove(gameState);
                    double result = minSearch(nextState, supportedPlayer, ++depth);
                    if(max < result)
                    {
                        max = result;
                        best = op;
                    }
                }
            }
            return best;
        }

        public static double minSearch(GameState state, int sp, int depth)
        {
            if(state.isWinningState() || state.isOver())
            {
                return Heuristic.heurNum(state, sp) - 0.1 * depth;
            }

            double min = int.MaxValue;
            Operator operators = new Operator();

            foreach (Operator op in operators.getOperators())
            {
                if (op.isApplicable(state.getState()))
                {

                    GameState nextState = op.applyMove(state);
                
                    double result = maxSearch(nextState, sp, ++depth);
                    if (min > result) {
                        min = result;
                    }
                }
            }
            return min;
        }

        public static double maxSearch(GameState state, int sp, int depth)
        {
            if(state.isOver() || state.isWinningState())
            {
                return Heuristic.heurNum(state, sp)-0.1*depth;
            }

            double max = int.MinValue;
            Operator operators = new Operator();

            
            foreach (Operator op in operators.getOperators())
            {
                if (op.isApplicable(state.getState()))
                {
                    GameState nextState = op.applyMove(state);
                    double result = minSearch(nextState, sp, ++depth);
                    if (max < result)
                    {
                        max = result;
                    }
                }
            }

             return max;
        }
    }
}
