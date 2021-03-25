using System;

namespace OopTicTacToe
{
    struct Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point(int x_, int y_)
        {
            X = x_;
            Y = y_;
        }
    }
}