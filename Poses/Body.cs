using Microsoft.Kinect;
using Recognet.Poses.Selectors;

namespace Recognet.Poses
{
    public static class Body
    {
        #region Individual Joints

        public static readonly JointSelector Head = new JointSelector(JointType.Head);
        public static readonly JointSelector ShoulderCenter = new JointSelector(JointType.ShoulderCenter);
        public static readonly JointSelector Spine = new JointSelector(JointType.Spine);
        public static readonly JointSelector HipCenter = new JointSelector(JointType.HipCenter);

        public static readonly JointSelector RightShoulder = new JointSelector(JointType.ShoulderRight);
        public static readonly JointSelector RightElbow = new JointSelector(JointType.ElbowRight);
        public static readonly JointSelector RightWrist = new JointSelector(JointType.WristRight);
        public static readonly JointSelector RightHand = new JointSelector(JointType.HandRight);

        public static readonly JointSelector RightHip = new JointSelector(JointType.HipRight);
        public static readonly JointSelector RightKnee = new JointSelector(JointType.KneeRight);
        public static readonly JointSelector RightAnkle= new JointSelector(JointType.AnkleRight);
        public static readonly JointSelector RightFoot = new JointSelector(JointType.FootRight);

        public static readonly JointSelector LeftShoulder = new JointSelector(JointType.ShoulderLeft);
        public static readonly JointSelector LeftElbow = new JointSelector(JointType.ElbowLeft);
        public static readonly JointSelector LeftWrist = new JointSelector(JointType.WristLeft);
        public static readonly JointSelector LeftHand = new JointSelector(JointType.HandLeft);

        public static readonly JointSelector LeftHip = new JointSelector(JointType.HipLeft);
        public static readonly JointSelector LeftKnee = new JointSelector(JointType.KneeLeft);
        public static readonly JointSelector LeftAnkle = new JointSelector(JointType.AnkleLeft);
        public static readonly JointSelector LeftFoot = new JointSelector(JointType.FootLeft);

        #endregion

        #region Joint Pairs 

        public static readonly JointPairSelector BothShoulders = new JointPairSelector(JointType.ShoulderRight, JointType.ShoulderLeft);
        public static readonly JointPairSelector BothElbows = new JointPairSelector(JointType.ElbowRight, JointType.ElbowLeft);
        public static readonly JointPairSelector BothWrists = new JointPairSelector(JointType.WristRight, JointType.WristLeft);
        public static readonly JointPairSelector BothHands = new JointPairSelector(JointType.HandRight, JointType.HandLeft);
        public static readonly JointPairSelector BothHips = new JointPairSelector(JointType.HipRight, JointType.HipLeft);
        public static readonly JointPairSelector BothKnees = new JointPairSelector(JointType.KneeRight, JointType.KneeLeft);
        public static readonly JointPairSelector BothAnkles = new JointPairSelector(JointType.AnkleRight, JointType.AnkleLeft);
        public static readonly JointPairSelector BothFoots = new JointPairSelector(JointType.FootRight, JointType.FootLeft);

        #endregion

        #region Segments

        public static readonly SegmentSelector LeftForearm = new SegmentSelector(JointType.WristLeft, JointType.ElbowLeft);
        public static readonly SegmentSelector RightForearm = new SegmentSelector(JointType.WristRight, JointType.ElbowRight);

        #endregion
    }
}
