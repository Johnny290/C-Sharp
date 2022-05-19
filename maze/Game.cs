using System;
using static System.Console;

namespace Maze
{
    class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;
        private static string filename = @".\maze.dat";
        public void Start()
        {
            
            Title = "Trpaslík";
            CursorVisible = false;
            char[][] map = World.LoadMaze(filename);
            MyWorld = new World(map);
            SetWindowSize(map[0].Length, map[1].Length);

            CurrentPlayer = new Player(1, 1);
            MyWorld.Draw();

            while (true)
            {

                CurrentPlayer.Draw();

                HandlePlayerInput();

                // Check if the player has reached the exit and end the game if so
                char elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPos == 'F')
                {
                    SetCursorPosition(0, map[1].Length);
                    WriteLine("Solved");
                    break;
                }
                System.Threading.Thread.Sleep(100);
            }
        }


        // Checks for player input and if it's valid position
        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.isPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Undraw();
                        CurrentPlayer.Y -= 1;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (MyWorld.isPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Undraw();
                        CurrentPlayer.Y += 1;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (MyWorld.isPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.Undraw();
                        CurrentPlayer.X -= 1;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (MyWorld.isPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.Undraw();
                        CurrentPlayer.X += 1;
                    }
                    break;

                default:
                    break;
            }
        }

    }
}
