using System;
using Microsoft.Kinect;

namespace Recognet.Poses
{
    public class FunctionalPose : Pose
    {

        public FunctionalPose(Func<Skeleton, double> function)
        {
            Function = function;
        }

        public Func<Skeleton, double> Function { get; private set; }

        public override double Matches(Skeleton skeleton)
            => Function(skeleton);
    }
}
