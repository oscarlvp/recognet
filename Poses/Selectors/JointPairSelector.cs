using Microsoft.Kinect;
using System;

namespace Recognet.Poses.Selectors
{
    public class JointPairSelector
    {
        public JointPairSelector(JointType one, JointType another)
        {
            Joints = new Tuple<JointType, JointType>(one, another);
        }

        public Tuple<JointType,JointType> Joints { get; private set; }

        //This method could be a read-only property, but
        //all other ways to build Pose instances are methods,
        //so this will also be a method for the sake of uniformity
        public virtual Pose AtSameHeight() =>
            new JointSelector(Joints.Item1).AtTheSameHeightOf(Joints.Item2);

        public virtual Pose AtSameDepth() =>
            new JointSelector(Joints.Item1).AtTheSameDepthOf(Joints.Item2);

        public virtual Pose AtSameLength() =>
            new JointSelector(Joints.Item1).AtTheSameLengthOf(Joints.Item2);
    }
}
