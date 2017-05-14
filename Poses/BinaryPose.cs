using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace Recognet.Poses
{
    public abstract class BinaryPose : Pose
    {
        public BinaryPose(Pose first, Pose second)
        {
            First = first;
            Second = second;
        }

        public Pose First { get; private set; }

        public Pose Second { get; private set; }

        public override double Matches(Skeleton skeleton)
            => GetValue(First.Matches(skeleton), Second.Matches(skeleton));

        public abstract double GetValue(double first, double second);
    }
}
