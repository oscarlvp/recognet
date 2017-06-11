using Microsoft.Kinect;

namespace Recognet.Poses.Selectors
{
    public class JointSelector
    {
        public JointSelector(JointType target)
        {
            Target = target;
        }

        public JointType Target { get; private set; }

        public virtual Pose Above(JointType other)
        {
            return new FunctionalPose((sk) =>
               Utils.DifferenceDistanceRatio(
                    sk.YDiff(Target, other), 
                    sk.PathLengthBetween(Target, other))
            );
        }

        public virtual Pose Below(JointType other)
        {
            return new FunctionalPose((sk) =>
               Utils.DifferenceDistanceRatio(
                   sk.YDiff(other, Target), 
                   sk.PathLengthBetween(other, Target)));
        }

        public virtual Pose AtTheSameHeightOf(JointType other)
        {
            return new FunctionalPose((sk) => 
                Utils.AbsoluteDifferenceDistanceRatio(
                    sk.YDiff(Target, other), 
                    sk.PathLengthBetween(Target, other)));
        }

        public virtual Pose After(JointType other)
        {
            return new FunctionalPose((sk) => 
                Utils.DifferenceDistanceRatio(
                    sk.ZDiff(Target, other), 
                    sk.PathLengthBetween(Target, other)));
        }

        public virtual Pose Before(JointType other)
        {
            return new FunctionalPose((sk) =>
                Utils.DifferenceDistanceRatio(
                    sk.ZDiff(Target, other),
                    sk.PathLengthBetween(other, Target)));
        }

        public virtual Pose AtTheSameDepthOf(JointType other)
        {
            return new FunctionalPose((sk) =>
                Utils.AbsoluteDifferenceDistanceRatio(
                    sk.ZDiff(Target, other),
                    sk.PathLengthBetween(Target, other)));
        }

        public virtual Pose ToTheLeftOf(JointType other)
        {
            return new FunctionalPose((sk) =>
                Utils.DifferenceDistanceRatio(
                    sk.XDiff(Target, other),
                    sk.PathLengthBetween(Target, other)));
        }

        public virtual Pose ToTheRightOf(JointType other)
        {
            return new FunctionalPose((sk) => 
                Utils.DifferenceDistanceRatio(
                    sk.XDiff(other, Target), 
                    sk.PathLengthBetween(other, Target)));
        }

        public virtual Pose AtTheSameLengthOf(JointType other)
        {
            return new FunctionalPose((sk) => 
                Utils.AbsoluteDifferenceDistanceRatio(
                    sk.XDiff(Target, other), 
                    sk.PathLengthBetween(Target, other)));
        }
    }
}
