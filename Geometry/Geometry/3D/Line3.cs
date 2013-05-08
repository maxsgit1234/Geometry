using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Geometry
{
    /// <summary>
    /// A 3D object defined by an origin and a direction.
    /// It represents a line of infinite extent in the given 
    /// direction which passes through the specified origin.
    /// This class is particularly designed to be useful for
    /// calculating intersections with other lines and forming
    /// a fundamental building block of other 3D objects.
    /// </summary>
    public class Line3
    {
        /// <summary>
        /// Any point along the line. Defines the origin when
        /// referring to other points along the line.
        /// </summary>
        public readonly Vector3 Origin;

        /// <summary>
        /// The direction of the line.
        /// </summary>
        public readonly Vector3 Direction;

        /// <summary>
        /// Create a 3D line.
        /// </summary>
        /// <param name="Origin">Any point along the line.</param>
        /// <param name="Direction">The direction which the line 
        /// continues in both directions.</param>
        public Line3(Vector3 Origin, Vector3 Direction)
        {
            this.Origin = Origin;
            this.Direction = Direction.Unitize();
        }

        /// <summary>
        /// Create a copy from another line.
        /// </summary>
        /// <param name="other">The line to copy.</param>
        public Line3(Line3 other)
        {
            this.Origin = other.Origin;
            this.Direction = other.Direction;
        }

        /// <summary>
        /// Returns the point along the line that is a given
        /// distance in the direction of the line from
        /// the origin.
        /// </summary>
        /// <param name="distance">The distance to travel in the direction
        /// of this line from the origin.</param>
        /// <returns></returns>
        public Vector3 PointAlong(double distance)
        {
            return Origin + distance * Direction;
        }

        /// <summary>
        /// The distance along this line at which point is attains
        /// its closest point of approach to another line. If the 
        /// lines are parallel, an exception is thrown.
        /// </summary>
        /// <param name="other">Another line which approaches this one.</param>
        /// <returns></returns>
        public double DistanceAlongAtClosestPoint(Line3 other)
        {
            double x;
            return DistanceAlongAtClosestPoint(other, out x);
        }

        /// <summary>
        /// The distance along this line at which point is attains
        /// its closest point of approach to another line. If the 
        /// lines are parallel, an exception is thrown.
        /// </summary>
        /// <param name="other">Another line which approaches this one.</param>
        /// <param name="otherDistanceAlong">The distance along the other 
        /// line at closest approach to this one</param>
        /// <returns></returns>
        public double DistanceAlongAtClosestPoint(
            Line3 other, out double otherDistanceAlong)
        {
            double a = this.Direction.Dot(this.Direction);
            double b = this.Direction.Dot(other.Direction);
            double c = other.Direction.Dot(other.Direction);
            Vector3 w = other.Origin - this.Origin;
            double d = w.Dot(this.Direction);
            double e = w.Dot(other.Direction);
            double denom = (a * c - b * b);
            if (denom == 0)
                throw new ArgumentException("Lines are parallel.");

            otherDistanceAlong = (d * b - a * e) / denom;

            return (d * c - e * b) / denom;
        }

        /// <summary>
        /// The closest distance that these lines have wrt each other.
        /// If the lines are parallel, this will throw an exception.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public double ClosestApproachDistance(Line3 other)
        {
            double otherDistanceAlong;
            double thisDistanceAlong = DistanceAlongAtClosestPoint(
                other, out otherDistanceAlong);

            return (this.PointAlong(thisDistanceAlong) 
                - other.PointAlong(otherDistanceAlong)).Mag();
        }
    }
}
