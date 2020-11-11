using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Bullet : Actor
    {
        private Sprite _sprite;




        /// <param name="x">Position on the x axis</param>
        /// <param name="y">Position on the y axis</param>
        /// <param name="icon">The symbol that will appear when drawn</param>
        /// <param name="color">The color of the symbol that will appear when drawn</param>
        public Bullet(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {
            _sprite = new Sprite("Images/bullet.png");
        }

        /// <param name="x">Position on the x axis</param>
        /// <param name="y">Position on the y axis</param>
        /// <param name="rayColor">The color of the symbol that will appear when drawn to raylib</param>
        /// <param name="icon">The symbol that will appear when drawn</param>
        /// <param name="color">The color of the symbol that will appear when drawn to the console</param>
        public Bullet(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {
            _sprite = new Sprite("Images/bullet.png");
        }

        public new Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }

        public override void Update(float deltaTime)
        {

            int xDirection = -Convert.ToInt32(Game.GetKeyDown((int)MouseButton.MOUSE_RIGHT_BUTTON));
            int yDirection = -Convert.ToInt32(Game.GetKeyDown((int)MouseButton.MOUSE_RIGHT_BUTTON));

            Velocity = new Vector2(xDirection, yDirection);

            base.Update(deltaTime);
        }

        public override void Draw()
        {

            _sprite.Draw(_localTransform);
            base.Draw();
        }
    }
}
