using ConnectGame;
using System;

Console.WriteLine("Please Player1 Enter your Name:");
string player1Name = Console.ReadLine();

Console.WriteLine("Please Player2 Enter your Name:");
string player2Name = Console.ReadLine();

var game = new Game(player1Name, player2Name);
Console.WriteLine($"Welcome, {game.Player1.Name} and {game.Player2.Name}.");
Console.WriteLine("The dimensions of the board are 9x9.");
Console.WriteLine($"The player who starts the game is {game.CurrentPlayer.Name}.");

while (game.Winner == null)
{
    game.Board.PrintBoard();
    Console.WriteLine($"{game.CurrentPlayer.Name}, choose column? (0-8)");

    if (int.TryParse(Console.ReadLine(), out int column) && column >= 0 && column < 9)
    {
        try
        {
            game.PlayTurn(column);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    else
    {
        Console.WriteLine("Invalid column, please choose another one.");
    }
}

game.Board.PrintBoard();
Console.WriteLine($"Congratulations {game.Winner.Name}, you won the game!");
