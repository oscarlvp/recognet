using Microsoft.Kinect;
using System;

namespace Recognet.Poses.Selectors
{
    public class LimbSelector
    {

        public LimbSelector(JointType limbBase, JointType middle, JointType pointer)
        {
            Base = limbBase;
            Middle = middle;
            Pointer = pointer;

            Upper = new SegmentSelector(limbBase, middle);
            Lower = new SegmentSelector(middle, pointer);
        }

        public LimbSelector(SegmentSelector upper, SegmentSelector lower)
        {
            if (upper == null || lower == null)
                throw new ArgumentNullException("Both SegmentSelector instances can not be null");
            if (upper.To != lower.From)
                throw new ArgumentException("The upper limb must end at the beginning of the lower limb");

            Base = upper.From;
            Middle = upper.To;
            Pointer = lower.To;
        }

        public JointType Base { get; private set; }

        public JointType Middle { get; private set; } //NOTE: I avoided to use Joint here because it is widely used elsewhere.

        public JointType Pointer { get; private set; }

        public SegmentSelector Upper { get; private set; }

        public SegmentSelector Lower { get; private set; }


        //TODO: As in JointPair and Joint selectors this class could be seen as a SegmentSelector think of some refactoring
        
        public virtual Pose PointingLeft() => Lower.PointingLeft();

        public virtual Pose PointingRight() => Lower.PointingRight();

        public virtual Pose PointingUp() => Lower.PointingUp();

        public virtual Pose PointingDown() => Lower.PointingDown();

        public virtual Pose PointingBackwards() => Lower.PointingBackwards();

        public virtual Pose PointingForward() => Lower.PointingForward();

        public virtual Pose BendedInAngle(double angle)
        {
            return new FunctionalPose((sk) =>
            {
                SkeletonPoint a = sk.Joints[Base].Position.TranslateTo(sk.Joints[Middle].Position);
                SkeletonPoint b = sk.Joints[Pointer].Position.TranslateTo(sk.Joints[Middle].Position);
                //TODO: Check correctness 
                return Math.Cos((angle - a.AngleTo(b))/2);
            });
        }

        public virtual Pose IsStraight() => BendedInAngle(Math.PI);
    }
}
