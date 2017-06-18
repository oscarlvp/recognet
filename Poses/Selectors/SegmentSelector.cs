using Microsoft.Kinect;

namespace Recognet.Poses.Selectors
{
    public class SegmentSelector
    {
        public SegmentSelector(JointType from, JointType to)
        {
            To = to;
            From = from;
        }

        public JointType To { get; private set; }

        public JointType From { get; private set; }

        public virtual Pose PointingLeft()
        {
            return new FunctionalPose((sk) => 
                Utils.DifferenceDistanceRatio(
                    sk.XDiff(To, From),
                    sk.DistanceBetween(To, From)));
        }
        
        public virtual Pose PointingRight()
        {
            return new FunctionalPose((sk) =>
                Utils.DifferenceDistanceRatio(
                    sk.XDiff(From, To),
                    sk.DistanceBetween(To, From)));
        }

        public virtual Pose PointingUp()
        {
            return new FunctionalPose((sk) =>
                Utils.DifferenceDistanceRatio(
                    sk.YDiff(To, From),
                    sk.DistanceBetween(To, From)));
        }

        public virtual Pose PointingDown()
        {
            return new FunctionalPose((sk) =>
                Utils.DifferenceDistanceRatio(
                    sk.YDiff(From, To),
                    sk.DistanceBetween(To, From)));
        }

        public virtual Pose PointingBackwards()
        {
            return new FunctionalPose((sk) =>
                Utils.DifferenceDistanceRatio(
                    sk.ZDiff(To, From),
                    sk.DistanceBetween(To, From)));
        }

        public virtual Pose PointingForward()
        {
            return new FunctionalPose((sk) =>
                Utils.DifferenceDistanceRatio(
                    sk.YDiff(From, To),
                    sk.DistanceBetween(To, From)));
        }

    }
}
