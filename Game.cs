using System;
using System.Collections.Generic;
using System.Linq;

namespace OopTicTacToe
{
    class Game
    {
        int forWin;
        int[,] field;
        int checkRow;
        int team;
        string gameState;
        public Game(int n_, int forWin_)
        {
            field = new int[n_, n_];
            forWin = forWin_;
            checkRow = 0;
            team = -1;
            gameState = "";
        }
        bool IsVictory(Point point)
        {

            int counthorizontal = 1;
            bool r = true;
            bool l = true;
            int countVertical = 1;
            bool u = true;
            bool d = true;
            int countDiagonalLeft = 1;
            bool dlu = true;
            bool dld = true;
            int countDiagonalRight = 1;
            bool dru = true;
            bool drd = true;
            for (int i = 1; i < forWin; i++)
            {
                if (dlu && point.X - i >= 0 && point.Y + i < field.GetLength(1) && field[point.X - i, point.Y + i] == team)
                {
                    countDiagonalLeft++;
                }
                else
                {
                    dlu = false;
                }
                if (dld && point.X + i < field.GetLength(0) && point.Y - i >= 0 && field[point.X + i, point.Y - i] == team)
                {
                    countDiagonalLeft++;
                }
                else
                {
                    dld = false;
                }

                if (drd && point.X + i < field.GetLength(0) && point.Y + i < field.GetLength(1) && field[point.X + i, point.Y + i] == team)
                {
                    countDiagonalRight++;
                }
                else
                {
                    drd = false;
                }
                if (dru && point.X - i >= 0 && point.Y - i >= 0 && field[point.X - i, point.Y - i] == team)
                {
                    countDiagonalRight++;
                }
                else
                {
                    dru = false;
                }
                if (r && point.X + i < field.GetLength(0) && field[point.X + i, point.Y] == team)
                {
                    counthorizontal++;
                }
                else
                {
                    r = false;
                }
                if (l && point.X - i >= 0 && field[point.X - i, point.Y] == team)
                {
                    counthorizontal++;
                }
                else
                {
                    l = false;
                }
                if (u && point.Y + i < field.GetLength(1) && field[point.X, point.Y + i] == team)
                {
                    countVertical++;
                }
                else
                {
                    u = false;
                }
                if (d && point.Y - i >= 0 && field[point.X, point.Y - i] == team)
                {
                    countVertical++;
                }
                else
                {
                    d = false;
                }

            }
            return counthorizontal >= forWin || countVertical >= forWin || countDiagonalRight >= forWin || countDiagonalLeft >= forWin;
        }
        bool IsDraw()
        {
            return checkRow >= field.GetLength(0) * field.GetLength(1);
        }
        bool IsCorrectInputCoordinates(Point place)
        {
            return field[place.X, place.Y] == 0;
        }
        void MakeTurn(Point point)
        {
            string ans = "Next";
            if (IsCorrectInputCoordinates(point))
            {
                if (IsDraw())
                {
                    team = 0;
                    ans = "Draw";
                }
                if (IsVictory(point))
                {
                    if (team == 1)
                    {
                        ans = "O is Winner";
                    }
                    else if (team == -1)
                    {
                        ans = "X is Winner";
                    }
                    
                    checkRow++;
                    field[point.X, point.Y] = team;
                    team = -team;
                }
                else
                {                    
                    checkRow++;
                    field[point.X, point.Y] = team;
                    team = -team;
                }
            }

            gameState = ans;
        }

        public int[,] CloneField()
        {
            int[,] cloneField = new int[field.GetLength(0),field.GetLength(1)];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); i++)
                {
                    cloneField[i, j] = field[i, j];
                }
            }
            return cloneField;
        }   

        public void Play(InputConsole PutConsole)
        {
            do
            {                                
                MakeTurn(PutConsole.InputPoint());   
                PutConsole.DrawField(CloneField());
            }
            while(gameState == "Next");
            PutConsole.OutputState(gameState);
        }
    }
}