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
        }
    }

