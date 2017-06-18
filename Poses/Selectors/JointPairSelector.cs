using Microsoft.Kinect;
using System;

namespace Recognet.Poses.Selectors
{
    public class JointPairSelector
    {
        //TODO: At some point, it could be necessary to unite this class with JointSelector
        //      using a base class ofr interface.

        public JointPairSelector(JointType one, JointType another) :
            this(new JointSelector(one), new JointSelector(another))
        {

        }

        public JointPairSelector(JointSelector one, JointSelector another)
        {
            if (one == null || another == null)
                throw new ArgumentNullException("Both selectors passed to a JointPairSelector constructor can not be null");
            Joints = new Tuple<JointType, JointType>(one.Joint, another.Joint);
            this.one = one;
            this.another = another;
        }

        public Tuple<JointType,JointType> Joints { get; private set; }

        JointSelector one, another;

        //This method could be a read-only property, but
        //all other ways to build Pose instances are methods,
        //so this will also be a method for the sake of uniformity
        public virtual Pose AtSameHeight() =>
            new JointSelector(Joints.Item1).AtTheSameHeightOf(Joints.Item2);

        public virtual Pose AtSameDepth() =>
            new JointSelector(Joints.Item1).AtTheSameDepthOf(Joints.Item2);

        public virtual Pose AtSameLength() =>
            new JointSelector(Joints.Item1).AtTheSameLengthOf(Joints.Item2);

        public virtual Pose Above(JointType other) 
            => one.Above(other) & another.Above(other);

        public virtual Pose Below(JointType other) 
            => one.Below(other) & another.Below(other);

        public virtual Pose AtTheSameHeightOf(JointType other) 
            => one.AtTheSameHeightOf(other) & another.AtTheSameHeightOf(other);

        public virtual Pose After(JointType other)
            => one.After(other) & another.After(other);

        public virtual Pose Before(JointType other)
            => one.Before(other) & another.Before(other);

        public virtual Pose AtTheSameDepthOf(JointType other)
            => one.AtTheSameDepthOf(other) & another.AtTheSameDepthOf(other);

        public virtual Pose ToTheLeftOf(JointType other)
            => one.ToTheLeftOf(other) & another.ToTheLeftOf(other);

        public virtual Pose ToTheRightOf(JointType other)
            => one.ToTheRightOf(other) & another.ToTheRightOf(other);

        public virtual Pose AtTheSameLengthOf(JointType other)
            => one.AtTheSameLengthOf(other) & another.AtTheSameLengthOf(other);
        
        //NOTE: I could have used some fancy Reflection mechanism to call methods with the same name on both
        //      JointSelectorInstances but for the sake of simplicity I didn't
    }
}
