using ConnectGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectGame
{
    public class Board
    {
        private Player[,] grid;
        public int Rows { get; }
        public int Columns { get; }

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new Player[rows, columns];
        }

        public void DropToken(int column, Player player)
        {
            if (column < 0 || column >= Columns)
                throw new ArgumentOutOfRangeException(nameof(column), "Column out of range.");

            for (int row = Rows - 1; row >= 0; row--)
            {
                if (grid[row, column] == null)
                {
                    grid[row, column] = player;
                    return;
                }
            }

            throw new InvalidOperationException("Column is full.");
        }

        public Player GetToken(int row, int column)
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                throw new ArgumentOutOfRangeException();

            return grid[row, column];
        }

        public void PrintBoard()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    var player = grid[row, col];
                    if (player == null)
                    {
                        Console.Write(". ");
                    }
                    else
                    {
                        Console.Write(player.Token + " ");
                    }
                }
                Console.WriteLine();
            }

            for (int col = 0; col < Columns; col++)
            {
                Console.Write("--");
            }
            Console.WriteLine();

            for (int col = 0; col < Columns; col++)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }

        public bool CheckForWin(Player player)
        {
            // Check horizontal lines
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns - 3; col++)
                {
                    if (grid[row, col] == player &&
                        grid[row, col + 1] == player &&
                        grid[row, col + 2] == player &&
                        grid[row, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Check vertical lines
            for (int col = 0; col < Columns; col++)
            {
                for (int row = 0; row < Rows - 3; row++)
                {
                    if (grid[row, col] == player &&
                        grid[row + 1, col] == player &&
                        grid[row + 2, col] == player &&
                        grid[row + 3, col] == player)
                    {
                        return true;
                    }
                }
            }

            // Check diagonal lines (bottom-left to top-right)
            for (int row = 3; row < Rows; row++)
            {
                for (int col = 0; col < Columns - 3; col++)
                {
                    if (grid[row, col] == player &&
                        grid[row - 1, col + 1] == player &&
                        grid[row - 2, col + 2] == player &&
                        grid[row - 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Check diagonal lines (top-left to bottom-right)
            for (int row = 0; row < Rows - 3; row++)
            {
                for (int col = 0; col < Columns - 3; col++)
                {
                    if (grid[row, col] == player &&
                        grid[row + 1, col + 1] == player &&
                        grid[row + 2, col + 2] == player &&
                        grid[row + 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsColumnValid(int column)
        {
            return column >= 0 && column < Columns && grid[0, column] == null;
        }

        public bool IsBoardFull()
        {
            for (int col = 0; col < Columns; col++)
            {
                if (grid[0, col] == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
