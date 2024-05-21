using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectGame
{

    public class Player
    {
        public string Name { get; }
        public char Token { get; }

        public Player(string name, char token)
        {
            Name = name;
            Token = token;
        }

        public override bool Equals(object obj)
        {
            if (obj is Player player)
            {
                return Name == player.Name && Token == player.Token;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Token);
        }
    }
}
