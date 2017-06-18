using System;
using Microsoft.Kinect;

namespace Recognet.Poses
{
    public static class Extensions
    {
        public static bool WithTolerance(this double value, double tolerance)
            => Math.Abs(value) <= tolerance;

        public static double DistanceTo(this SkeletonPoint first, SkeletonPoint second)
        {
            double delthaX = first.X - second.X;
            double delthaY = first.Y - second.Y;
            double delthaZ = first.Z - second.Z;
            return Math.Sqrt(delthaX*delthaX + delthaY*delthaY + delthaZ*delthaZ);
        }

        public static SkeletonPoint TranslateTo(this SkeletonPoint point, SkeletonPoint origin)
        {
            SkeletonPoint result = new SkeletonPoint();
            result.X = origin.X - point.X;
            result.Y = origin.Y - point.Y;
            result.Z = origin.Z - point.Z;

            return result;
        }

        public static double Length(this SkeletonPoint point)
            => Math.Sqrt(point.X * point.X + point.Y * point.Y + point.Z * point.Z);


        public static double DotProduct(this SkeletonPoint one, SkeletonPoint other)
            => one.X * other.X + one.Y * other.Y + one.Z * other.Z;

        public static double AngleTo(this SkeletonPoint point, SkeletonPoint other)
            => Math.Acos(point.DotProduct(other) / (point.Length() * other.Length()));
        

        public static double DistanceTo(this Joint first, Joint second)
            => first.Position.DistanceTo(second.Position);

        public static double Holds(this Skeleton skeleton, Pose pose) 
            => pose.Matches(skeleton);
        

        public static bool Holds(this Skeleton skeleton, Pose pose, double tolerance) 
            => skeleton.Holds(pose).WithTolerance(tolerance);

        public static double DistanceBetween(this Skeleton skeleton, JointType first, JointType second)
            => skeleton.Joints[first].Position.DistanceTo(skeleton.Joints[second].Position);

        public static double PathLengthBetween(this Skeleton skeleton, JointType first, JointType second)
        {
            JointPath path = JointPath.Between(first, second);
            double length = 0;
            for (int i = 1; i < path.Count; i++)
            {
                length += skeleton.Joints[path[i - 1]].DistanceTo(skeleton.Joints[path[i]]);
            }
            return length;
        }

        public static double XDiff(this Skeleton skeleton, JointType first, JointType second)
            => skeleton.Joints[first].Position.X - skeleton.Joints[second].Position.X;

        public static double YDiff(this Skeleton skeleton, JointType first, JointType second)
            => skeleton.Joints[first].Position.Y - skeleton.Joints[second].Position.Y;

        public static double ZDiff(this Skeleton skeleton, JointType first, JointType second)
            => skeleton.Joints[first].Position.Z - skeleton.Joints[second].Position.Z;
    }
}
