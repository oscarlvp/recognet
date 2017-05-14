using System;
using Microsoft.Kinect;

namespace Recognet.Poses
{
    public class OrPose : BinaryPose
    {
        public OrPose(Pose first, Pose second) : base(first, second) { }

        public override double GetValue(double first, double second)
            => Math.Max(first, second);
    }

    public class AndPose : BinaryPose
    {
        public AndPose(Pose first, Pose second) : base(first, second) { }

        public override double GetValue(double first, double second)
            => Math.Min(first, second);
    }

    public class NotPose : Pose
    {
        public NotPose(Pose operand)
        {
            Operand = operand;
        }

        public Pose Operand { get; private set; }

        public override double Matches(Skeleton skeleton)
        {
            return 1 - Operand.Matches(skeleton);
        }
    }
}
