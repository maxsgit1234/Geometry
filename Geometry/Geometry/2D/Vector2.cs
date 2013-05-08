using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Geometry
{
    public class Vector2
    {
        public double X;
        public double Y;

        public Vector2()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Vector2(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public Vector2(Vector2 other)
        {
            this.X = other.X;
            this.Y = other.Y;
        }

        public double Mag2()
        {
            return this.X * this.X + this.Y * this.Y;
        }

        public double Mag()
        {
            return Math.Sqrt(this.Mag2());
        }

        public Vector2 Unitize()
        {
            double mag = this.Mag();
            return new Vector2(this.X / mag, this.Y / mag);
        }
        
        #region Overator Overloads
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2 operator +(Vector2 v, double value)
        {
            return new Vector2(v.X + value, v.Y + value);
        }

        public static Vector2 operator -(Vector2 v, double value)
        {
            return new Vector2(v.X - value, v.Y - value);
        }

        public static Vector2 operator *(Vector2 v, double value)
        {
            return new Vector2(v.X * value, v.Y * value);
        }

        public static Vector2 operator /(Vector2 v, double value)
        {
            return new Vector2(v.X / value, v.Y / value);
        }
        #endregion
    }
}
