using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public class Vector3
    {
        private float _x;
        private float _y;
        private float _z;
        private int xDirection;
        private int yDirection;
        private int zDirection;
        private float v1;
        private float v2;
        private float v3;
        private float v4;
        private float v5;
        private float v6;
        private float v;

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

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public Vector3 Normalized
        {
            get
            {
                return Normalize(this);
            }
        }



        public Vector3()
        {
            _x = 0.0f;
            _y = 0.0f;
            _z = 0.0f;
        }

        public Vector3(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        //public Vector3(int xDirection, int yDirection, int zDirection)
        //{
        //    this.xDirection = xDirection;
        //    this.yDirection = yDirection;
        //    this.zDirection = zDirection;
        //}

        public Vector3(float x, float y, float z, float v1, float v2, float v3, float v4, float v5, float v6)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
        }

        public Vector3(float v)
        {
            this.v = v;
        }



        /// <summary>
        /// Returns the normalized version of a the vector passed in.
        /// </summary>
        /// <param name="vector">The vector that will be normalized</param>
        /// <returns></returns>
        public static Vector3 Normalize(Vector3 vector)
        {
            if (vector.Magnitude == 0)
            {
                return new Vector3(0);
            }
            return vector / vector.Magnitude;
        }

        /// <summary>
        /// Returns the dot product of the two vectors given.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static float DotProduct(Vector3 vector, Vector3 scalar)
        {
            return (vector.X * scalar.X) + (vector.Y * scalar.Y) + (vector.Z * scalar.Z);
        }

        public static Vector3 CrossProduct(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(0);
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X += rhs.X, lhs.Y += rhs.Y, lhs.Z += rhs.Z);
        }





        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }

        public static Vector3 operator *(Vector3 lhs, float scalar)
        {

            return new Vector3(lhs.X * scalar, lhs.Y * scalar, lhs.Z * scalar);
        }

        public static Vector3 operator *(float scalar, Vector3 lhs)
        {
            return new Vector3(lhs.X * scalar, lhs.Y * scalar, lhs.Z * scalar);
        }

        //public static Vector3 operator *(float scalar, Vector3 rhs)
        //{

        //    return new Vector3(rhs.X * scalar, rhs.Y * scalar, rhs.Z * scalar);
        //}

        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3
                (

                    //==============ONE ROW==================================================
                    //Row1, Column1
                    lhs.m11 * rhs.X + lhs.m12 * rhs.Y + lhs.m13 * rhs.Z,
                    //Row1, Column2
                    lhs.m11 * rhs.X + lhs.m12 * rhs.Y + lhs.m13 * rhs.Z,
                    //Row1, Column3
                    lhs.m11 * rhs.X + lhs.m12 * rhs.Y + lhs.m13 * rhs.Z,
                    //===============TWO ROW=================================================
                    //Row2, Column1
                    lhs.m21 * rhs.X + lhs.m22 * rhs.Y + lhs.m23 * rhs.Z,
                    //Row2, Column2
                    lhs.m21 * rhs.X + lhs.m22 * rhs.Y + lhs.m23 * rhs.Z,
                    //Row2, Column3
                    lhs.m21 * rhs.X + lhs.m22 * rhs.Y + lhs.m23 * rhs.Z,
                    //===============THREE ROW================================================
                    //Row3, Column1
                    lhs.m31 * rhs.X + lhs.m32 * rhs.Y + lhs.m33 * rhs.Z,
                    //Row3, Column2
                    lhs.m31 * rhs.X + lhs.m32 * rhs.Y + lhs.m33 * rhs.Z,
                    //Row3, Column3
                    lhs.m31 * rhs.X + lhs.m32 * rhs.Y + lhs.m33 * rhs.Z
                );
            
        }

        public static Vector3 operator *(Vector3 lhs, Matrix3 rhs)
        {
            return new Vector3
                (

                    //==============ONE ROW==================================================
                    //Row1, Column1
                    rhs.m11 * lhs.X + rhs.m12 * lhs.Y + rhs.m13 * lhs.Z,
                    //Row1, Column2
                    rhs.m11 * lhs.X + rhs.m12 * lhs.Y + rhs.m13 * lhs.Z,
                    //Row1, Column3
                    rhs.m11 * lhs.X + rhs.m12 * lhs.Y + rhs.m13 * lhs.Z,
                    //===============TWO ROW=================================================
                    //Row2, Column1
                    rhs.m21 * lhs.X + rhs.m22 * lhs.Y + rhs.m23 * lhs.Z,
                    //Row2, Column2
                    rhs.m21 * lhs.X + rhs.m22 * lhs.Y + rhs.m23 * lhs.Z,
                    //Row2, Column3
                    rhs.m21 * lhs.X + rhs.m22 * lhs.Y + rhs.m23 * lhs.Z,
                    //===============THREE ROW================================================
                    //Row3, Column1
                    rhs.m31 * lhs.X + rhs.m32 * lhs.Y + rhs.m33 * lhs.Z,
                    //Row3, Column2
                    rhs.m31 * lhs.X + rhs.m32 * lhs.Y + rhs.m33 * lhs.Z,
                    //Row3, Column3
                    rhs.m31 * lhs.X + rhs.m32 * lhs.Y + rhs.m33 * lhs.Z
                );

        }


        public static Vector3 operator /(Vector3 lhs, float scalar)
        {
            return new Vector3(lhs.X / scalar, lhs.Y / scalar, lhs.Z / scalar);
        }



    }
}

