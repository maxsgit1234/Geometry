using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Geometry
{
    public class Ray2
    {
        public Vector2 Origin;
        public Vector2 Direction;

        public Ray2(Vector2 Origin, Vector2 Direction)
        {
            this.Origin = Origin;
            this.Direction = Direction;
        }

        public Vector2 ClosestPointOfApproach(Ray2 other)
        {


            throw new NotImplementedException();
        }
    }
}
