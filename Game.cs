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
            Player1 = new Player(player1Name, 'X');
            Player2 = new Player(player2Name, 'O');
            Board = new Board(9, 9);

            // Randomly choose the starting player
            var random = new Random();
            CurrentPlayer = random.Next(2) == 0 ? Player1 : Player2;
        }

        public void PlayTurn(int column)
        {
            Board.DropToken(column, CurrentPlayer);

            // Check if the current player has won the game
            if (Board.CheckForWin(CurrentPlayer))
            {
                Winner = CurrentPlayer;
                return;
            }

            // Switch to the other player
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
        }
    }
}

