using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;

namespace Maze
{
    class World
    {
        private char[][] Grid;
        private int Rows;
        private int Cols;

        public World(char[][] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Glenght(grid);
        }

        // Loads maze from a file and coverts it to array
        public static char[][] LoadMaze(string filePath)
        {
            var lines = new List<char[]>();
            string line;

            StreamReader file = new StreamReader(filePath);

            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line.ToCharArray());
            }

            return lines.ToArray();
        }
        private int Glenght(char[][] grid)
        {
            int lng = 0;
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int column = 0; column <= grid[row].Length; column++)
                {
                    if (column == grid[row].Length)
                    {
                        lng = column;
                        break;
                    }
                }
            }
            return lng;
        }

        public bool Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    char element = Grid[y][x];
                    SetCursorPosition(x, y);
                    Write(element);
                }
            }
            return true;
        }
        public char GetElementAt(int x, int y)
        {
            return Grid[y][x];
        }
        public bool isPositionWalkable(int x, int y)
        {
            // Check bounds
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false;
            }
            // Check Walakable position
            return Grid[y][x] == ' ' || Grid[y][x] == 'F' || Grid[y][x] == 'S';
        }

    }
}
