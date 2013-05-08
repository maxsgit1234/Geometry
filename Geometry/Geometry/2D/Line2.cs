using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Geometry
{
    public class Line2
    {
        public Vector2 Point;
        public Vector2 Direction;

        public Line2(Vector2 Point, Vector2 Direction)
        {
            this.Point = Point;
            this.Direction = Direction;
        }
    }
}
