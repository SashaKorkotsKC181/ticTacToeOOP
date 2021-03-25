using System;

namespace OopTicTacToe
{
    class InputConsole
    {
        static string BuidStringHorizontalLine(int weight)
        {
            string line = "";
            for (int k = 0; k <= weight * 2; k++)
            {
                line += "—";
            } 
            return line;
        }
        public void DrawField(int[,] field)
        {
            Console.Clear();
            for (int i = 0; i < field.GetLength(0); i++)
            {                  
                Console.WriteLine(BuidStringHorizontalLine(field.GetLength(1)));
                string row = "";      
                for (int j = 0; j < field.GetLength(1); j++)
                {                                        
                    if (field[i,j] == 1)
                    {
                        row += "|O";
                    }
                    else if (field[i,j] == -1)
                    {
                        row += "|X";
                    } 
                    else 
                    {
                        row += "| ";
                    }                    
                }
                Console.WriteLine(row + '|');
                if (i == field.GetLength(0) - 1)
                {
                    Console.WriteLine(BuidStringHorizontalLine(field.GetLength(1)));
                }
            }            
        }
        public void OutputState(string gameState)
        {
            Console.WriteLine(gameState);
        }
        public Point InputPoint()
        {
            string[] input = Console.ReadLine().Split(' ');
            return new Point(Convert.ToInt32(input[0]),Convert.ToInt32(input[1]));
        }

    }
}