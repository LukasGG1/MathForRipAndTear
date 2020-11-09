﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{

    /// <summary>
    /// This is the base class for all objects that will 
    /// be moved or interacted with in the game
    /// 
    /// Create new matrices to transform the actors matrix. The user sho
    /// </summary>
    class Actor
    {

        protected char _icon = ' ';
        // protected Vector2 _position;
        protected Vector2 _velocity;

        protected Matrix3 _globalTransform;
        protected Matrix3 _localTransform = new Matrix3();
        
        protected Matrix3 _transform = new Matrix3();
        protected Matrix3 _translation = new Matrix3();
        protected Matrix3 _rotation = new Matrix3();
        protected Matrix3 _scale = new Matrix3();

        protected Sprite sprite_;

        //private Vector2 _facing;
        protected ConsoleColor _color;
        protected Color _rayColor;
        protected Actor _parent;
        protected Actor[] _children = new Actor[0];
        protected float _rotationAngle;
        private float _collisionRadius;
        public bool Started { get; private set; }

        //==========================================================================
        public Vector2 WorldPosition
        {
            get
            {
                return new Vector2(_globalTransform.m13, _globalTransform.m23);
            }
        }

        public Vector2 LocalPosition
        {
            get
            {
                return new Vector2(_localTransform.m13, _localTransform.m23);
            }
            set
            {
                _translation.m13 = value.X;
                _translation.m23 = value.Y;
            }
        }
        public Vector2 Forward
        {
            get
            {
                return new Vector2(_localTransform.m11, _localTransform.m21);
            }
            set
            {
                Vector2 lookPosition = LocalPosition + value.Normalized;
                LookAt(lookPosition);
            }

        }



        public Vector2 Position
        {
            get
            {
                return new Vector2(_transform.m13, _transform.m23);
            }
            set
            {
                _translation.m13 = value.X;
                _translation.m23 = value.Y;
            }
        }

        public Vector2 Velocity
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
        //Matrix Transform
        //========================




        //Martix Set
        //=======================
        public void SetTranslate(Vector2 position)
        {
            _translation.m13 = position.X;
            _translation.m23 = position.Y;

        }

        public void SetRotation(float radians)
        {
            //_rotationAngle
            _rotation.m11 = (float)Math.Cos(radians);
            _rotation.m21 = -(float)Math.Sin(radians);
            _rotation.m12 = (float)Math.Sin(radians);
            _rotation.m22 = (float)Math.Cos(radians);
        }

         public void Rotate(float radians)
         {
            _rotationAngle += radians;
           SetRotation(_rotationAngle);
         }


        //Checks to see if this actor overlaps another.


        //The actor that this actor is checking collision against.
        public bool CheckCollision()
        {
            return false;
        }

        //Called whenever a collision occurs between this actor and another.
        //Use this to define game logic for this actors collision.
        public virtual void OnCollision(Actor other)
        {

        }

        public void SetScale(float x, float y)
        {
            _scale.m11 = x;     // _scale.m12 = 0; _scale.m13 = 0;
            _scale.m22 = y;     // _scale.m22 = 0; _scale.m23 = 0;
            //_scale.m31 = 0; _scale.m32 = 0; _scale.m33 = 0;
        }



        private void UpdateTransform()
        {
            _localTransform = _translation * _rotation * _scale;


        }

        /// <param name="x">Position on the x axis</param>
        /// <param name="y">Position on the y axis</param>
        /// <param name="icon">The symbol that will appear when drawn</param>
        /// <param name="color">The color of the symbol that will appear when drawn</param>
        public Actor(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _rayColor = Color.WHITE;
            _icon = icon;
            _localTransform = new Matrix3();
            //_scale = new Matrix3(x,y);  // <--- This could be culplit causes player and enemy's size enlarging.
            LocalPosition = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
            //Forward = new Vector2(1, 0);
        }

        public void AddChild(Actor child)
        {
            Actor[] tempArray = new Actor[_children.Length + 1];

            for (int i = 0; i < _children.Length; i++)
            {
                tempArray[i] = _children[i];
            }

            tempArray[_children.Length] = child;
            _children = tempArray;
            child._parent = this;
        }

        public bool RemoveChild(Actor child)
        {
            bool childRemoved = false;

            if (child == null)
                return false;

            Actor[] tempArray = new Actor[_children.Length - 1];

            int j = 0;
            for (int i = 0; i < _children.Length; i++)
            {
                if (child != _children[i])
                {
                    tempArray[j] = _children[i];
                    j++;
                }
                else
                {
                    childRemoved = true;
                }
            }

            _children = tempArray;
            child._parent = null;
            return childRemoved;

        }

        public void LookAt(Vector2 position)
        {
            //Find the direction that the actor should look in
            Vector2 direction = (position - LocalPosition).Normalized;

            //Use the dotproduct to find the angle the actor needs to rotate
            float dotProd = Vector2.DotProduct(Forward, direction);
            if (Math.Abs(dotProd) > 1)
                return;
            float angle = (float)Math.Acos(dotProd);

            //Find a perpindicular vector to the direction
            Vector2 perp = new Vector2(direction.Y, -direction.X);

            //Find the dot product of the perpindicular vector and the current forward
            float perpDot = Vector2.DotProduct(perp, Forward);

            //If the result isn't 0, use it to change the sign of the angle to be either positive or negative
            if (perpDot != 0)
                angle *= -perpDot / Math.Abs(perpDot);

            Rotate(angle);
        
        }

        /// <param name="x">Position on the x axis</param>
        /// <param name="y">Position on the y axis</param>
        /// <param name="rayColor">The color of the symbol that will appear when drawn to raylib</param>
        /// <param name="icon">The symbol that will appear when drawn</param>
        /// <param name="color">The color of the symbol that will appear when drawn to the console</param>
        public Actor(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : this(x, y, icon, color)
        {
            _localTransform = new Matrix3();
            _rayColor = rayColor;
        }

        /// <summary>
        /// Updates the actors forward vector to be
        /// the last direction it moved in
        /// </summary>
        private void UpdateFacing()
        {
            if (_velocity.Magnitude <= 0)
                return;

            Forward = Velocity.Normalized;

        }
        

        public virtual void Start()
        {
            Started = true;
        }


        public virtual void Update(float deltaTime)
        {
            UpdateTransform();

            //Before the actor is moved, update the direction it's facing
            UpdateFacing();

            //Increase position by the current velocity
            LocalPosition += _velocity * deltaTime;


        }

        public virtual void Draw()
        {
            if(sprite_ != null)
            {
               // sprite_.Draw(_transform);
                //sprite_.Draw(_rotation);
                //sprite_.Draw(_scale);
                //sprite_.Draw(_translation);
                //sprite_.Draw(_transform);
            }
            //Draws the actor and a line indicating it facing to the raylib window.
            //Scaled to match console movement
            Raylib.DrawText(_icon.ToString(), (int)(LocalPosition.X * 32), (int)(LocalPosition.Y * 32), 32, _rayColor);
           
            //Player and NPC's sight of line draw
            Raylib.DrawLine(
                (int)(LocalPosition.X * 32),
                (int)(LocalPosition.Y * 32),
                (int)((LocalPosition.X + Forward.X) * 32),
                (int)((LocalPosition.Y + Forward.Y) * 32),
                Color.WHITE
                
            );

            //Changes the color of the console text to be this actors color
            Console.ForegroundColor = _color;

            //Only draws the actor on the console if it is within the bounds of the window
            if (LocalPosition.X >= 0 && LocalPosition.X < Console.WindowWidth
                && LocalPosition.Y >= 0 && LocalPosition.Y < Console.WindowHeight)
            {
                Console.SetCursorPosition((int)LocalPosition.X, (int)LocalPosition.Y);
                Console.Write(_icon);
            }

            //Reset console text color to be default color
            Console.ForegroundColor = Game.DefaultColor;
        }

        public virtual void End()
        {
            Started = false;
        }

    }
}
