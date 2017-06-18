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

        public static readonly JointPairSelector BothShoulders = new JointPairSelector(Body.RightShoulder, Body.LeftShoulder);
        public static readonly JointPairSelector BothElbows = new JointPairSelector(Body.RightElbow, Body.LeftElbow);
        public static readonly JointPairSelector BothWrists = new JointPairSelector(Body.RightWrist, Body.LeftWrist);
        public static readonly JointPairSelector BothHands = new JointPairSelector(Body.RightHand, Body.LeftHand);
        public static readonly JointPairSelector BothHips = new JointPairSelector(Body.RightHip, Body.LeftHip);
        public static readonly JointPairSelector BothKnees = new JointPairSelector(Body.RightKnee, Body.LeftKnee);
        public static readonly JointPairSelector BothAnkles = new JointPairSelector(Body.RightAnkle, Body.LeftAnkle);
        public static readonly JointPairSelector BothFoots = new JointPairSelector(Body.RightFoot, Body.LeftFoot);

        #endregion

        #region Segments

        public static readonly SegmentSelector LeftForearm = new SegmentSelector(JointType.WristLeft, JointType.ElbowLeft);
        public static readonly SegmentSelector RightForearm = new SegmentSelector(JointType.WristRight, JointType.ElbowRight);

        #endregion
    }
}
