using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Geometry
{
    public class Matlab
    {
        public List<Ray3> lines1;
        public List<Ray3> lines2;
        public Matlab(List<Ray3> lines1, List<Ray3> lines2)
        {
            this.lines1 = lines1;
            this.lines2 = lines2;
        }

        public double AverageClosestApproach()
        {
            return lines1.AverageClosestApproach(lines2);
        }
    }

    public static class Extensions
    {
        public static double AverageClosestApproach(this List<Ray3> lines1, List<Ray3> lines2)
        {
            if (lines1.Count != lines2.Count)
                throw new ArgumentException("Both sets of lines must be the same length.");

            if (lines1.Count == 0)
                throw new ArgumentException("There must be at least one line in each set.");

            double totalError = 0;
            for (int i = 0; i < lines1.Count; i++)
            {
                totalError += lines1[i].ClosestApproachDistance(lines2[i]);
            }

            return totalError / lines1.Count;
        }
    }
}
