using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognet.Poses.Selectors
{
    public class SegmentSelector
    {
        public SegmentSelector(JointType first, JointType second)
        {
            First = first;
            Second = second;
        }

        public JointType First { get; private set; }

        public JointType Second { get; private set; }


        public virtual Pose PointingLeft()
        {
            return new FunctionalPose((sk) => 
                Utils.DifferenceDistanceRatio(
                    sk.XDiff(First, Second),
                    sk.DistanceBetween(First, Second)));
        }
        
        public virtual Pose PointingRight()
        {
            return new FunctionalPose((sk) =>
                Utils.DifferenceDistanceRatio(
                    sk.XDiff(Second, First),
                    sk.DistanceBetween(First, Second)));
        }

        public virtual Pose PointingUp()
        {
            return new FunctionalPose((sk) =>
                Utils.DifferenceDistanceRatio(
                    sk.YDiff(First, Second),
                    sk.DistanceBetween(First, Second)));
        }

        public virtual Pose PointingDown()
        {
            return new FunctionalPose((sk) =>
                Utils.DifferenceDistanceRatio(
                    sk.YDiff(Second, First),
                    sk.DistanceBetween(First, Second)));
        }

        public virtual Pose PointingBackwards()
        {
            return new FunctionalPose((sk) =>
                Utils.DifferenceDistanceRatio(
                    sk.ZDiff(First, Second),
                    sk.DistanceBetween(First, Second)));
        }

        public virtual Pose PointingForward()
        {
            return new FunctionalPose((sk) =>
                Utils.DifferenceDistanceRatio(
                    sk.YDiff(Second, First),
                    sk.DistanceBetween(First, Second)));
        }

    }
}
