using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Geometry
{
    /// <summary>
    /// Represents a point or a vector in 3D.
    /// </summary>
    public class Vector3
    {
        public double X;
        public double Y;
        public double Z;

        /// <summary>
        /// Create a vector from its constituent components.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public Vector3(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        /// <summary>
        /// Create a vector by copying an existing vector's
        /// constituent components.
        /// </summary>
        /// <param name="other"></param>
        public Vector3(Vector3 other)
        {
            this.X = other.X;
            this.Y = other.Y;
            this.Z = other.Z;
        }

        /// <summary>
        /// The magnitude-squared of this vector. Sometimes
        /// desirable for performance reasons because it 
        /// avoids the Math.Sqrt() operation.
        /// </summary>
        /// <returns></returns>
        public double Mag2()
        {
            return this.X * this.X + this.Y * this.Y + this.Z * this.Z;
        }

        /// <summary>
        /// The magnitude of this vector.
        /// </summary>
        /// <returns></returns>
        public double Mag()
        {
            return Math.Sqrt(this.Mag2());
        }

        /// <summary>
        /// Divide this vector by its magnitude 
        /// to produce a unit vector.
        /// </summary>
        /// <returns></returns>
        public Vector3 Unitize()
        {
            double mag = this.Mag();
            return new Vector3(this.X / mag, this.Y / mag, this.Z / mag);
        }

        /// <summary>
        /// Vector dot product.
        /// </summary>
        /// <param name="other">The other vector needed for the dot
        /// product operation.</param>
        /// <returns></returns>
        public double Dot(Vector3 other)
        {
            return this.X * other.X + this.Y * other.Y + this.Z * other.Z;
        }

        /// <summary>
        /// The shortest distance in 3D from this point
        /// to any point on the specified line. Derived by considering
        /// the fact that the shortest path is perpendicular to the line.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public double ClosestDistanceTo(Line3 line)
        {
            double a = line.Direction.Dot(line.Direction);
            double b = (this - line.Origin).Dot(line.Direction);
            return (this - line.Origin + b / a * line.Direction).Mag();
        }

        #region Overator Overloads
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }
        public static Vector3 operator +(Vector3 v, double value)
        {
            return new Vector3(v.X + value, v.Y + value, v.Z + value);
        }
        public static Vector3 operator +(double value, Vector3 v)
        {
            return new Vector3(v.X + value, v.Y + value, v.Z + value);
        }
        public static Vector3 operator -(Vector3 v, double value)
        {
            return new Vector3(v.X - value, v.Y - value, v.Z - value);
        }
        public static Vector3 operator -(double value, Vector3 v)
        {
            return new Vector3(v.X - value, v.Y - value, v.Z - value);
        }
        public static Vector3 operator *(Vector3 v, double value)
        {
            return new Vector3(v.X * value, v.Y * value, v.Z * value);
        }
        public static Vector3 operator *(double value, Vector3 v)
        {
            return new Vector3(v.X * value, v.Y * value, v.Z * value);
        }
        public static Vector3 operator /(Vector3 v, double value)
        {
            return new Vector3(v.X / value, v.Y / value, v.Z / value);
        }
        public static Vector3 operator /(double value, Vector3 v)
        {
            return new Vector3(v.X / value, v.Y / value, v.Z / value);
        }
        #endregion
    }
}
