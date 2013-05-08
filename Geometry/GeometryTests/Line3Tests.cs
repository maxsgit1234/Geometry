using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z.Geometry;

namespace GeometryTests
{
    public static class Line3Tests
    {
        public static void ClosestApproachTest1()
        {
            Line3 line1 = new Line3(new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            Line3 line2 = new Line3(new Vector3(5, 5, 1), new Vector3(-1, 1, 0));
            double d = line1.ClosestApproachDistance(line2);
            Console.WriteLine("Closest approach: " + d);
            if (d == 1)
                Console.WriteLine("PASS");
            else
                Console.WriteLine("FAIL");
        }
        public static void ClosestApproachTest2()
        {
            Line3 line1 = new Line3(new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            Line3 line2 = new Line3(new Vector3(5, 5, 0), new Vector3(-1, 1, 0));
            double d = line1.ClosestApproachDistance(line2);
            Console.WriteLine("Closest approach: " + d);
            if (d == 0)
                Console.WriteLine("PASS");
            else
                Console.WriteLine("FAIL");
        }
        public static void ClosestApproachTest3()
        {
            Ray3 line1 = new Ray3(new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            Ray3 line2 = new Ray3(new Vector3(5, 5, 1), new Vector3(-1, 1, 0));
            double d = line1.ClosestApproachDistance(line2);
            Console.WriteLine("Closest approach: " + d);
            if (d == 1)
                Console.WriteLine("PASS");
            else
                Console.WriteLine("FAIL");
        }
        public static void ClosestApproachTest4()
        {
            Ray3 line1 = new Ray3(new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            Ray3 line2 = new Ray3(new Vector3(5, 5, 0), new Vector3(-1, 1, 0));
            double d = line1.ClosestApproachDistance(line2);
            Console.WriteLine("Closest approach: " + d);
            if (d == 0)
                Console.WriteLine("PASS");
            else
                Console.WriteLine("FAIL");
        }
        public static void ClosestApproachTest5()
        {
            Ray3 line1 = new Ray3(new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            Ray3 line2 = new Ray3(new Vector3(5, 5, 0), new Vector3(1, 1, 0));
            double d = line1.ClosestApproachDistance(line2);
            Console.WriteLine("Closest approach: " + d);
            if (d == 5 * Math.Sqrt(2))
                Console.WriteLine("PASS");
            else
                Console.WriteLine("FAIL");
        }
    }
}
