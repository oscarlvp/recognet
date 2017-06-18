using Microsoft.Kinect;

namespace Recognet.Poses.Selectors
{
    public class JointSelector
    {
        public JointSelector(JointType joint)
        {
            Joint = joint;
        }

        public JointType Joint { get; private set; }

        public virtual Pose Above(JointType other)
        {
            return new FunctionalPose((sk) =>
               Utils.DifferenceDistanceRatio(
                    sk.YDiff(Joint, other), 
                    sk.PathLengthBetween(Joint, other))
            );
        }

        public virtual Pose Below(JointType other)
        {
            return new FunctionalPose((sk) =>
               Utils.DifferenceDistanceRatio(
                   sk.YDiff(other, Joint), 
                   sk.PathLengthBetween(other, Joint)));
        }

        public virtual Pose AtTheSameHeightOf(JointType other)
        {
            return new FunctionalPose((sk) => 
                Utils.AbsoluteDifferenceDistanceRatio(
                    sk.YDiff(Joint, other), 
                    sk.PathLengthBetween(Joint, other)));
        }

        public virtual Pose After(JointType other)
        {
            return new FunctionalPose((sk) => 
                Utils.DifferenceDistanceRatio(
                    sk.ZDiff(Joint, other), 
                    sk.PathLengthBetween(Joint, other)));
        }

        public virtual Pose Before(JointType other)
        {
            return new FunctionalPose((sk) =>
                Utils.DifferenceDistanceRatio(
                    sk.ZDiff(Joint, other),
                    sk.PathLengthBetween(other, Joint)));
        }

        public virtual Pose AtTheSameDepthOf(JointType other)
        {
            return new FunctionalPose((sk) =>
                Utils.AbsoluteDifferenceDistanceRatio(
                    sk.ZDiff(Joint, other),
                    sk.PathLengthBetween(Joint, other)));
        }

        public virtual Pose ToTheLeftOf(JointType other)
        {
            return new FunctionalPose((sk) =>
                Utils.DifferenceDistanceRatio(
                    sk.XDiff(Joint, other),
                    sk.PathLengthBetween(Joint, other)));
        }

        public virtual Pose ToTheRightOf(JointType other)
        {
            return new FunctionalPose((sk) => 
                Utils.DifferenceDistanceRatio(
                    sk.XDiff(other, Joint), 
                    sk.PathLengthBetween(other, Joint)));
        }

        public virtual Pose AtTheSameLengthOf(JointType other)
        {
            return new FunctionalPose((sk) => 
                Utils.AbsoluteDifferenceDistanceRatio(
                    sk.XDiff(Joint, other), 
                    sk.PathLengthBetween(Joint, other)));
        }
    }
}
