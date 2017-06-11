using Microsoft.Kinect;
using System;

namespace Recognet.Poses
{
    public abstract class Pose
    {
        public abstract double Matches(Skeleton skeleton);

        public static implicit operator Func<Skeleton, double>(Pose pose)
        {
            return (skeleton) => pose.Matches(skeleton);
        }

        public static explicit operator Pose(Func<Skeleton, double> function)
            => new FunctionalPose(function);
       
        public static Pose operator &(Pose p, Pose q) => new AndPose(p, q);

        public static Pose operator |(Pose p, Pose q) => new OrPose(p, q);

    }
}
