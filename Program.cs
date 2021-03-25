using System;

namespace OopTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game first = new Game(3,3);

            first.Play(new InputConsole());
        }
    }
}
