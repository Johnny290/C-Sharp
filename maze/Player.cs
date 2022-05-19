using System;
using static System.Console;

namespace Maze
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        private char PlayerMarker;
        private ConsoleColor PlayerColor;

        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerMarker = '*';
            PlayerColor = ConsoleColor.Red;
        }
        
        public void Draw()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(X, Y);
            Write(PlayerMarker);
            ResetColor();

        }

        public void Undraw()
        {
            SetCursorPosition(X, Y);
            Write(' ');
        }
    }
}
