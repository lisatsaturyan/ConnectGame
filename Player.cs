﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectGame
{
    public class Player(string name = "Player1")
    {
        public string Name { get; set; } = name;
    }
}
