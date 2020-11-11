using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;
using MathForGame3D_;
using System.Numerics;

namespace MathforGame3D_
{
    class Player : Actor
    {
        private float _speed = 3;
        private float zDirection;

        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        public object Velocity { get; private set; }

        /// <param name="x">Position on the x axis</param>
        /// <param name="y">Position on the y axis</param>
        /// <param name="icon">The symbol that will appear when drawn</param>
        /// <param name="color">The color of the symbol that will appear when drawn</param>
        public Player(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {
            
        }

        /// <param name="x">Position on the x axis</param>
        /// <param name="y">Position on the y axis</param>
        /// <param name="rayColor">The color of the symbol that will appear when drawn to raylib</param>
        /// <param name="icon">The symbol that will appear when drawn</param>
        /// <param name="color">The color of the symbol that will appear when drawn to the console</param>


        public override void Update(float deltaTime)
        {
            Player players = new Player(0.1f, 0.2f);
            //Gets the player's input to determine which direction the actor will move in on each axis 
            int xDirection = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_A))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_D));
            int yDirection = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));


            //Bullet fires

            //Set the actors current velocity to be the a vector with the direction found scaled by the speed
            Velocity = new Vector3(xDirection, yDirection, zDirection);

            //Velocity = Velocity.Normalized * Speed;



            //players.SetRotation(0.1f);         

            //players.Rotate(0.1f);
            //players.Rotate(0.2f);
            //players.Rotate(0.3f);
            //players.Rotate(0.4f);
            //players.Rotate(0.5f);
            //players.Rotate(0.6f);
            //players.Rotate(0.7f);
            //players.Rotate(0.8f);
            //players.Rotate(0.9f);
            //players.Rotate(0.1f);


            //players.SetRotation(0.2f);
            //players.SetRotation(0.3f);
            //players.SetRotation(0.4f);
            //players.SetRotation(0.5f);
            //players.SetRotation(0.6f);
            //players.SetRotation(0.7f);
            //players.SetRotation(0.8f);
            //players.SetRotation(0.9f);
            //players.SetRotation(1.0f);

            base.Update(deltaTime);
        }

        public override void Draw()
        {


            base.Draw();
        }
    }
}
