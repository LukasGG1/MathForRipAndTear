﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{

    public class Matrix3
    {
        public float m11, m12, m13, m21, m22, m23, m31, m32, m33;

        public Matrix3()
        {
            m11 = 1; m12 = 0; m13 = 0;
            m21 = 0; m22 = 1; m23 = 0;
            m31 = 0; m32 = 0; m33 = 1;
        }

        public Matrix3(float m11, float m12, float m13,
                       float m21, float m22, float m23,
                       float m31, float m32, float m33)
        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13;
            this.m21 = m21; this.m22 = m22; this.m23 = m23;
            this.m31 = m31; this.m32 = m32; this.m33 = m33;
        }


        /// <summary>
        /// Creates a new matrix that has been rotated by the given radians
        /// </summary>
        /// <param name="radians">The angle the new matrix will be rotated</param>
        /// <returns></returns>
        public static Matrix3 CreateRotation(float radians)
        {
            return new Matrix3
                (
                    (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                    -(float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                    0, 0, 1
                );
        }


        /// <summary>
        /// Creates a new matrix that has been translated by the given value
        /// </summary>
        /// <param name="position">The position of the new matrix</param>
        /// <returns></returns>
        public static Matrix3 CreateTranslation(Vector2 position)
        {
            return new Matrix3
                (
                    1, 0, position.X,
                    0, 1, position.Y,
                    0, 0, 1
                );
        }

        /// <summary>
        /// Creates a new matrix that has been scaled by the given value
        /// </summary>
        /// <param name="scale">The scale of the new matrix</param>
        /// <returns></returns>
        public static Matrix3 CreateScale(Vector2 scale)
        {
            return new Matrix3
                (
                    scale.X, 0, 0,
                    0, scale.Y, 0,
                    0, 0, 1
                );
        }

        //public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        //{
        //    return new Matrix3
        //        (
        //            lhs.m11 + rhs.m11, lhs.m12 + rhs.m12, lhs.m13 + rhs.m13,
        //            lhs.m21 + rhs.m21, lhs.m22 + rhs.m22, lhs.m23 + rhs.m23,
        //            lhs.m31 + rhs.m31, lhs.m32 + rhs.m32, lhs.m33 + rhs.m33
        //        );
        //}

        //public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        //{
        //    return new Matrix3
        //        (
        //            lhs.m11 - rhs.m11, lhs.m12 - rhs.m12, lhs.m13 - rhs.m13,
        //            lhs.m21 - rhs.m21, lhs.m22 - rhs.m22, lhs.m23 - rhs.m23,
        //            lhs.m31 - rhs.m31, lhs.m32 - rhs.m32, lhs.m33 - rhs.m33
        //        );
        //}

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3
                (
                    //Row1, Column1
                    lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31,
                    //Row1, Column2
                    lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32,
                    //Row1, Column3
                    lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33,

                    //Row2, Column1
                    lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31,
                    //Row2, Column2
                    lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32,
                    //Row2, Column3
                    lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33,

                    //Row3, Column1
                    lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31,
                    //Row3, Column2
                    lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32,
                    //Row3, Column3
                    lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33
                );
        }

        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3(
                    lhs.m11 * rhs.X + lhs.m21 * rhs.Y + lhs.m31 * rhs.Z,
                    lhs.m12 * rhs.X + lhs.m22 * rhs.Y + lhs.m32 * rhs.Z,
                    lhs.m13 * rhs.X + lhs.m23 * rhs.Y + lhs.m33 * rhs.Z);
        }

        public static Vector3 operator *(Vector3 lhs, Matrix3 rhs)
        {
            return new Vector3();
        }

        //Back-up


        //public class Matrix3
        //{
        //return new Vector3(
        //        lhs.m11* rhs.X + lhs.m21* rhs.Y + lhs.m31* rhs.Z,
        //        lhs.m12* rhs.X + lhs.m22* rhs.Y + lhs.m32* rhs.Z,
        //        lhs.m13* rhs.X + lhs.m23* rhs.Y + lhs.m33* rhs.Z);




        //    public float m11, m12, m13, m21, m22, m23, m31, m32, m33;
        //    private float x;
        //    private float y;
        //    private float z;
        //    private int v1;
        //    private int v2;
        //    private int v;

        //    public Matrix3()
        //    {
        //        m11 = 1.0f; m12 = 0; m13 = 0;
        //        m21 = 0; m22 = 1.0f; m23 = 0;
        //        m31 = 0; m32 = 0; m33 = 1.0f;
        //    }
        //    /// <summary>
        //    /// ==========================================================
        //    /// </summary>
        //    /// <param name="x"></param>
        //    /// <param name="y"></param>
        //    /// <param name="z"></param>
        //    //THIS THIS THIS THIS THIS THIS


        //    public Matrix3(float m11, float m12, float m13,
        //                   float m21, float m22, float m23,
        //                   float m31, float m33, float m32)
        //    {

        //    }
        //    //===========================================================
        //    //======================================THISTHISTHISTHISTHIS=
        //    public Matrix3(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33, int v1, int v2) : this(m11, m12, m13, m21, m22, m23, m31, m32, m33)
        //    {
        //        this.v1 = v1;
        //        this.v2 = v2;
        //    }





        //    public static Matrix3 CreateRotation(float radians)
        //    {
        //        return new Matrix3(
        //            (float)Math.Cos(radians), -(float)Math.Sin(radians), 0, 0,
        //            (float)Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
        //            0, 0, 1);
        //    }

        //    public static Matrix3 CreateTranslation(Vector2 position)
        //    {
        //        return new Matrix3
        //            (
        //                3, 2, position.X,
        //                3, 5, position.Y,

        //                0, 0, 1
        //            );
        //    }

        //    public static Matrix3 CreateScale(Vector2 scale)
        //    {
        //        return new Matrix3
        //            (
        //                scale.X, 0, 0,
        //                0, scale.Y, 0,
        //                0, scale.Z,
        //                0, 0, 1
        //            );
        //    }

        //    public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        //    {
        //        return new Matrix3
        //            (
        //                lhs.m11 + rhs.m11, lhs.m12 + rhs.m12, lhs.m13 + rhs.m13,
        //                lhs.m21 + rhs.m21, lhs.m22 + rhs.m22, lhs.m23 + rhs.m23,
        //                lhs.m31 + rhs.m31, lhs.m32 + rhs.m32, lhs.m33 + rhs.m33
        //            );
        //    }

        //    public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        //    {
        //        return new Matrix3
        //            (
        //                lhs.m11 - rhs.m11, lhs.m12 - rhs.m12, lhs.m13 - rhs.m13,
        //                lhs.m21 - rhs.m21, lhs.m22 - rhs.m22, lhs.m23 - rhs.m23,
        //                lhs.m31 - rhs.m31, lhs.m32 - rhs.m32, lhs.m33 - rhs.m33
        //            );
        //    }

        //    public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        //    {
        //        return new Matrix3
        //            (

        //            //==============ONE ROW==================================================
        //                //Row1, Column1
        //                lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31,
        //                //Row1, Column2
        //                lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32,
        //                //Row1, Column3
        //                lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33,
        //            //===============TWO ROW=================================================
        //                //Row2, Column1
        //                lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31,
        //                //Row2, Column2
        //                lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32,
        //                //Row2, Column3
        //                lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33,
        //            //===============THREE ROW================================================
        //                //Row3, Column1
        //                lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31,
        //                //Row3, Column2
        //                lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32,
        //                //Row3, Column3
        //                lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33
        //            );
        //    }
        //    public static Vector3 operator *(Vector3 rhs, Matrix3 lhs)
        //    {
        //        return new Vector3();
        //    }
    }
}
