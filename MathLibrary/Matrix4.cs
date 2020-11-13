using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public class Matrix4
    {
        public float m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44; 
        private float x;
        private float y;
        private float z;
        private float w;
        
        
        //===============
        private int v1;
        private float y1;
        private int v2;
        private int v3;
        private int v4;
        private int v5;
        private float z1;
        private int v6;
        private int v7;
        private int v8;
        private int v9;
        private float w1;
        //================

        public Matrix4(float v, int v2, int v3, int v4, float y, int v1, int v5, float z, int v6, int v7, float v11, float w)
        {
            m11 = 1.0f; m12 = 0; m13 = 0; m14 = 0;
            m21 = 0; m22 = 1.0f; m23 = 0; m24 = 0;
            m31 = 0; m32 = 0; m33 = 1.0f; m34 = 0;
            m41 = 0; m42 = 0; m43 = 0; m44 = 1.0f;
            
        }


        //Golden Ratio
        //Spin User

        public  Matrix4 SetRotationX()
        {
            return new Matrix4();
        }


        //It is Matrix and Vector's stand waycry.
        //THIS THIS THIS THIS THIS THIS THIS AND FLOAT FLOAT FLOAT FLOAT FLOAT AND NOW INT INT INT INT INT INT INT


    //===================================================================================================
    //===================================================================================================
        public Matrix4(float x, float y, float v2, int v, int v3, float z, float v1, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Matrix4(float m11, float m12, float m13, float m14,
                       float m21, float m22, float m23, float m24,
                       float m31, float m32, float m33, float m34,
                       float m41, float m42, float m43, float m44)
            //========================================================
            //========================================================
            //THIS
        {
            _ = (
            this.m11 = m11, this.m12 = m12, this.m13 = m13, this.m14 = m14,
            this.m21 = m21, this.m22 = m22, this.m23 = m23, this.m24 = m24,
            this.m31 = m31, this.m32 = m32, this.m33 = m33, this.m34 = m34,
            this.m41 = m41, this.m42 = m42, this.m43 = m43, this.m44 = m44
            );
        }

        public Matrix4(float x, float y, float z, int v1, float y1, int v2, int v3, int v4, int v5) : this(x, y, z)
        {
            this.v1 = v1;
            this.y1 = y1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
        }

        public Matrix4(float x, float y, float z, float w, int v1, int v2, float y1, int v3, int v4, float z1, int v5, int v6, int v7) : this(x, y, z, w)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.y1 = y1;
            this.v3 = v3;
            this.v4 = v4;
            this.z1 = z1;
            this.v5 = v5;
            this.v6 = v6;
            this.v7 = v7;
        }

        public Matrix4(float x, int v6, float y, int v, float z, float v1, int v2, int v3, int v4, int v5) : this(x, y, v, z, v1)
        {
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
        }

        public Matrix4(float x, float y, int v, float z, float v1)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Matrix4(float x, float y, float z, int v, float w, float v1)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Matrix4(float x, float y, float v2, int v, float z, float w, float v1, float V, float v8, int v5, int v6, int v7, int V8, int v9) : this(x, y, v2, v, z, v1, w)
        {
            this.v5 = v5;
            this.v6 = v6;
            this.v7 = v7;
        }

        public Matrix4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Matrix4(float x, float y, float v2, int v, int v3, float z, float v1, float w, float z1, int v4, int v5, object w1, int v6, int v7, int v8) : this(x, y, v2, v, v3, z, v1, w)
        {
            this.z1 = z1;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
            this.v7 = v7;
        }

        public Matrix4(float v, int v2, int v3, int v4, float y, int v1, int v5, float z, int v6, int v7, float v11, float w, int v8, int v9) : this(v, v2, v3, v4, y, v1, v5, z, v6, v7, v11, w)
        {
            this.v8 = v8;
            this.v9 = v9;
        }

        public Matrix4(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Matrix4(float x, float y, float v2, int v, int v3, float z, float v1, float w, int v4, int v5, int v6, int v7, int v8) : this(x, y, v2, v, v3, z, v1, w)
        {
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
            this.v7 = v7;
            this.v8 = v8;
        }

        public Matrix4(float x, float y, float z, int v, float w, float v1, float w1) : this(x, y, z, v, w, v1)
        {
            this.w1 = w1;
        }

        public Matrix4()
        {
        }

     //=============================================================
     //==========     fin.         ==================================
    //=================================================================


    //================================================================
    //=========  Golden Ratio. Ball Breaker  =========================
    //================================================================
        public static Matrix4 CreateRotationX(float radians)
        {
            return new Matrix4(
                (float)Math.Cos(radians), -(float)Math.Sin(radians),(float)Math.Abs(radians), 0, 0,
                (float)Math.Sin(radians), (float)Math.Cos(radians), (float)Math.Abs(radians),0, 0,
                0, 0, 1);
        }

        public static Matrix4 CreateRotationY(float radians)
        {
            return new Matrix4(
                (float)Math.Cos(radians), -(float)Math.Sin(radians), (float)Math.Abs(radians), 0, 0,
                (float)Math.Sin(radians), (float)Math.Cos(radians), (float)Math.Abs(radians), 0, 0,
                0, 0, 1);
        }

        public static Matrix4 CreateRotationZ(float radians)
        {
            return new Matrix4(
                (float)Math.Cos(radians), -(float)Math.Sin(radians), (float)Math.Abs(radians), 0, 0,
                (float)Math.Sin(radians), (float)Math.Cos(radians), (float)Math.Abs(radians), 0, 0,
                0, 0, 1);
        }
        
        public static Matrix4 CreateRotationW(float radians)
        {
            return new Matrix4(
                (float)Math.Cos(radians), -(float)Math.Sin(radians), (float)Math.Abs(radians), 0, 0,
                (float)Math.Sin(radians), (float)Math.Cos(radians), (float)Math.Abs(radians), 0, 0,
                0, 0, 1);
        }

        public static Matrix4 CreateTranslation(Vector4 position)
        {
            return new Matrix4
                (
                    0, 0, position.X,
                    0, 0, position.Y,
                    0, 0, position.Z,
                    0, 0, position.W,
                    0, 0, 1
                );
        }

        public static Matrix4 CreateScale(Vector4 scale)
        {
            return new Matrix4
                (
                    scale.X,
                    0, 0,0,
                    scale.Y,
                    0, 0, 
                    scale.Z,
                    0,0,
                    scale.W,
                    0, 0, 0
                );
        }

        public static Matrix4 operator +(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4
                (
                    lhs.m11 + rhs.m11, lhs.m12 + rhs.m12, lhs.m13 + rhs.m13, lhs.m14 + rhs.m14,
                    lhs.m21 + rhs.m21, lhs.m22 + rhs.m22, lhs.m23 + rhs.m23, lhs.m24 + rhs.m24,
                    lhs.m31 + rhs.m31, lhs.m32 + rhs.m32, lhs.m33 + rhs.m33, lhs.m34 + rhs.m34,
                    lhs.m41 + rhs.m41, lhs.m42 + rhs.m42, lhs.m43 + rhs.m43, lhs.m44 + rhs.m44
                );
        }

        public static Matrix4 operator -(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4
                (
                    lhs.m11 - rhs.m11, lhs.m12 - rhs.m12, lhs.m13 - rhs.m13, lhs.m14 - rhs.m14,
                    lhs.m21 - rhs.m21, lhs.m22 - rhs.m22, lhs.m23 - rhs.m23, lhs.m24 - rhs.m24,
                    lhs.m31 - rhs.m31, lhs.m32 - rhs.m32, lhs.m33 - rhs.m33, lhs.m34 - rhs.m34,
                    lhs.m41 - rhs.m41, lhs.m42 - rhs.m42, lhs.m43 - rhs.m43, lhs.m44 - rhs.m44
                );
        }

        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4
                (
                    lhs.m11 * rhs.m11, lhs.m12 * rhs.m12, lhs.m13 * rhs.m13, lhs.m14 * rhs.m14,
                    lhs.m21 * rhs.m21, lhs.m22 * rhs.m22, lhs.m23 * rhs.m23, lhs.m24 * rhs.m24,
                    lhs.m31 * rhs.m31, lhs.m32 * rhs.m32, lhs.m33 * rhs.m33, lhs.m34 * rhs.m34,
                    lhs.m41 * rhs.m41, lhs.m42 * rhs.m42, lhs.m43 * rhs.m43, lhs.m44 * rhs.m44

                );
        }

        public static Vector4 operator * (Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4();
        }
    }
}
