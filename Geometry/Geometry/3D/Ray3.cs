using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Geometry
{
    /// <summary>
    /// Represents a ray in 3D. It extends infinitely from
    /// its origin in the specified direction. However, unlike 
    /// the line, it does not exist in the opposite direction as well.
    /// </summary>
    public class Ray3
    {
        /// <summary>
        /// The underlying line, which many calculation are based on.
        /// </summary>
        public readonly Line3 Underline;

        /// <summary>
        /// Create a ray by specifying its defining components.
        /// </summary>
        /// <param name="Origin">The points from which this ray emanates.</param>
        /// <param name="Direction">The direction that the ray eminates from its origin.</param>
        public Ray3(Vector3 Origin, Vector3 Direction)
        {
            this.Underline = new Line3(Origin, Direction);
        }

        /// <summary>
        /// The closest distance of approach between this and another ray.
        /// If the rays are parallel, this will throw an exception.
        /// </summary>
        /// <param name="other">Another ray which approaches this one.</param>
        /// <returns></returns>
        public double ClosestApproachDistance(Ray3 other)
        {
            double otherDistance;
            double thisDistance = this.Underline.DistanceAlongAtClosestPoint(
                other.Underline, out otherDistance);

            if (otherDistance > 0 && thisDistance > 0)
                return this.Underline.ClosestApproachDistance(other.Underline);
            else if (otherDistance > 0 && thisDistance <= 0)
                return this.Underline.Origin.ClosestDistanceTo(other.Underline);
            else if (thisDistance > 0 && otherDistance <= 0)
                return other.Underline.Origin.ClosestDistanceTo(this.Underline);
            else
                return (this.Underline.Origin - other.Underline.Origin).Mag();
        }

        public Vector3 PointOfClosestApproach(Ray3 other)
        {
            double otherDistance;
            double thisDistance = this.Underline.DistanceAlongAtClosestPoint(
                other.Underline, out otherDistance);

            thisDistance = Math.Max(thisDistance, 0);
            otherDistance = Math.Max(otherDistance, 0);

            return (this.Underline.PointAlong(thisDistance) + other.Underline.PointAlong(otherDistance)) / 2;
        }

    }
}
