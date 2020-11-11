using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGame3D_
{
    class Actor
    {
        protected ConsoleColor _color;
        protected Color _rayColor;
        protected Actor _parent;
        protected Actor[] _children = new Actor[0];
        protected float _rotationAngle;
        private float _collisionRadius;

        protected Matrix3 _transform = new Matrix3();
        protected Matrix3 _translation = new Matrix3();
        protected Matrix3 _rotation = new Matrix3();
        protected Matrix3 _scale = new Matrix3();
        public bool Started { get; private set; }
        public object LocalPosition { get; private set; }
        public object Forward { get; private set; }

        private float x;
        private float y;
        private char icon;
        private ConsoleColor color;
        private object _icon;
        private object WorldPosition;

        public Actor(float x, float y, char icon, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.icon = icon;
            this.color = color;
        }



        void SetRotationX(float radians)
        {

        }

        public void SetRotationY(float radians)
        {

        }

        public void SetRotationZ(float radians)
        {

        }

        public void Rotate(float radians)
        {
            _rotation *= Matrix3.CreateRotation(radians);
            // _rotationAngle += radians;
            //SetRotation(_rotationAngle);
        }



        public virtual void Update(float deltaTime)
        {
            //UpdateTransform();

            ////Before the actor is moved, update the direction it's facing
            //UpdateFacing();
            //Rotate(0.1f);

            ////Increase position by the current velocity
            //LocalPosition += _velocity * deltaTime;


        }

        public virtual void Draw()
        {

            //Draws the actor and a line indicating it facing to the raylib window.
            //Scaled to match console movement
            //Raylib.DrawText(_icon.ToString(), (int)(LocalPosition.X * 32), (int)(LocalPosition.Y * 32), (int)(LocalPosition.Z * 32), 32, _rayColor);

            ////Player and NPC's sight of line draw
            //Raylib.DrawLine(
            //    (int)(WorldPosition.X * 32),
            //    (int)(WorldPosition.Y * 32),
            //    (int)(WorldPosition.Z * 32),
            //    (int)((WorldPosition.X + Forward.X) * 32),
            //    (int)((WorldPosition.Y + Forward.Y) * 32),
            //    (int)((WorldPosition.Z + Forward.Z) * 32),
            //    Color.WHITE

            //);

            ////Changes the color of the console text to be this actors color
            //Console.ForegroundColor = _color;

            ////Only draws the actor on the console if it is within the bounds of the window
            //if (WorldPosition.X >= 0 && WorldPosition.X && WorldPosition.Z < Console.WindowWidth
            //    && WorldPosition.Y >= 0 && WorldPosition.Y && WorldPosition.Z < Console.WindowHeight)
            //{
            //    Console.SetCursorPosition((int)WorldPosition.X, (int)WorldPosition.Y, (int)WorldPosition.Z);
            //    Console.Write(_icon);
            //}

            ////Reset console text color to be default color
            //Console.ForegroundColor = Game.DefaultColor;
        }

        public virtual void End()
        {
            Started = false;
        }

    }
}
