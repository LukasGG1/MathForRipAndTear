using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public class Vector4
    {
        private float _x;
        private float _y;
        private float _z;
        private float _w;
        private int xDirection;
        private int yDirection;
        private int zDirection;
        private int wDirection;
        private float v2;

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public float Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
            }
        }

        public float W
        {
            get
            {
                return _w;
            }
            set
            {
                _w = value;
            }
        }
        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
            }
        }

        public Vector4 Normalized
        {
            get
            {
                return Normalize(this);
            }
        }



        public Vector4(float v, float v1, float v2, int v3)
        {
            _x = 0.0f;
            _y = 0.0f;
            _z = 0.0f;
            _w = 0.0f;
        }

        public Vector4(float x, float y, int v, float z, float w)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
        }

        public Vector4(float v, int xDirection, int yDirection, int zDirection, int wDirection)
        {
            this.xDirection = xDirection;
            this.yDirection = yDirection;
            this.zDirection = zDirection;
            this.wDirection = wDirection;
        }

        public Vector4(float v, float v1)
        {
        }

        public Vector4(float v, float v1, float v2, float v3) : this(v, v1)
        {
            this.v2 = v2;
        }

        public Vector4()
        {
        }



        /// <summary>
        /// Returns the normalized version of a the vector passed in.
        /// </summary>
        /// <param name="vector">The vector that will be normalized</param>
        /// <returns></returns>
        public static Vector4 Normalize(Vector4 vector)
        {
            if (vector.Magnitude == 0)
            {
                return new Vector4();
            }
            return vector / vector.Magnitude;
        }


        //====================================================
        //====================================================
        //====================================================


        /// <summary>
        /// Returns the dot product of the two vectors given.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static float DotProduct(Vector4 vector, Vector4 scalar)
        {
            return (vector.X * scalar.X) + (vector.Y * scalar.Y) + (vector.Z * scalar.Z) + (vector.W * scalar.W);
        }

        public static float CrossProduct(Vector4 vector, Vector4 scalar)
        {
            return (vector.X * scalar.X) + (vector.Y * scalar.Y) + (vector.Z * scalar.Z) + (vector.W * scalar.W);
        }

        //=======PRODUCT YEE HAWWED========
        //==================================
        //==================================
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X += rhs.X, lhs.Y += rhs.Y, lhs.Z += rhs.Z, lhs.W += rhs.W);
        }

        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.W += rhs.W);
        }

        public static Vector4 operator *(Vector4 lhs, float scalar)
        {

            return new Vector4(lhs.X * scalar, lhs.Y * scalar, lhs.Z * scalar, lhs.W * scalar);
        }

        public static Vector4 operator *(float scalar, Vector4 lhs)
        {

            return new Vector4(lhs.X * scalar, lhs.Y * scalar, lhs.Z * scalar, lhs.W * scalar);
        }

        public static Vector4 operator /(Vector4 lhs, float scalar)
        {
            return new Vector4(lhs.X / scalar, lhs.Y / scalar, lhs.Z / scalar, lhs.W / scalar);
        }



    }
}

