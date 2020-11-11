using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;
using MathForGame3D_;

namespace MathforGame3D_
{
    class Program
    {
        public static int Main()
        {

            //Create a new instance of the game class
            Game game = new Game();

            //Call run to begin the game.
            game.Run();

            return 0;
        }
    }
}
