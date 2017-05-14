using System;
using Microsoft.Kinect;

namespace Recognet.Poses
{
    public static class Extensions
    {
        public static bool WithTolerance(this double value, double tolerance)
            => Math.Abs(value) <= tolerance;

        public static double Holds(this Skeleton skeleton, Pose pose) 
            => pose.Matches(skeleton);
        

        public static bool Holds(this Skeleton skeleton, Pose pose, double tolerance) 
            => skeleton.Holds(pose).WithTolerance(tolerance);
    }
}
