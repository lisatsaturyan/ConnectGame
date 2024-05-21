using ConnectGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectGame
{
    public class Game
    {
        public Player Player1 { get; }
        public Player Player2 { get; }
        public Player CurrentPlayer { get; private set; }
        public Player Winner { get; private set; }
        public Board Board { get; }

        public Game(string player1Name, string player2Name)
        {
            Player1 = new Player(player1Name);
            Player2 = new Player(player2Name);
            Board = new Board(9, 9);
            CurrentPlayer = new Random().Next(2) == 0 ? Player1 : Player2;
        }

        public void PlayTurn(int column)
        {
            if (Winner != null)
                throw new InvalidOperationException("Game is already won.");

            Board.DropToken(column, CurrentPlayer);
            if (CheckWin(CurrentPlayer))
            {
                Winner = CurrentPlayer;
            }
            else
            {
                CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
            }
        }

        private bool CheckWin(Player player)
        {
            // Check for winning conditions (4 in a row, column, or diagonal)
            // This method needs a detailed implementation.
            // Placeholder for now, returning false always.
            return false;
        }
    }
}
