using Microsoft.Kinect;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Recognet.Poses
{
    public class JointPath : IEnumerable<JointType>
    {

        static JointPath()
        {
            int[,] nextInPath = new int[20, 20]
            {
                {  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1, 12, 12, 12, 12, 16, 16, 16, 16 },
                {  0,  1,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,  0 },
                {  1,  1,  2,  3,  4,  4,  4,  4,  8,  8,  8,  8,  1,  1,  1,  1,  1,  1,  1,  1 },
                {  2,  2,  2,  3,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2 },
                {  2,  2,  2,  2,  4,  5,  5,  5,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2 },
                {  4,  4,  4,  4,  4,  5,  6,  6,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4 },
                {  5,  5,  5,  5,  5,  5,  6,  7,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5 },
                {  6,  6,  6,  6,  6,  6,  6,  7,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6 },
                {  2,  2,  2,  2,  2,  2,  2,  2,  8,  9,  9,  9,  2,  2,  2,  2,  2,  2,  2,  2 },
                {  8,  8,  8,  8,  8,  8,  8,  8,  8,  9, 10, 10,  8,  8,  8,  8,  8,  8,  8,  8 },
                {  9,  9,  9,  9,  9,  9,  9,  9,  9,  9, 10, 11,  9,  9,  9,  9,  9,  9,  9,  9 },
                { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 11, 10, 10, 10, 10, 10, 10, 10, 10 },
                {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 12, 13, 13, 13,  0,  0,  0,  0 },
                { 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 13, 14, 14, 12, 12, 12, 12 },
                { 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 14, 15, 13, 13, 13, 13 },
                { 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 15, 14, 14, 14, 14 },
                {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 16, 17, 17, 17 },
                { 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 17, 18, 18 },
                { 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 18, 19 },
                { 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 19 }
            };

            pathBetween = new JointPath[20, 20];

            for (int start = 0; start < 20; start++)
            {
                for (int end = 0; end < 20; end++)
                {
                    List<int> path = new List<int>();
                    int current = start;
                    while(nextInPath[current, end] != current)
                    {
                        path.Add(current);
                        current = nextInPath[current, end];
                    }
                    pathBetween[start, end] = new JointPath(path.Select(i => (JointType)i));
                }
            }
        }


        private static JointPath[,] pathBetween;

        public static JointPath Between(JointType first, JointType last)
        {
            return pathBetween[(int)first, (int)last];
        }

        JointType[] points;

        public JointPath(IEnumerable<JointType> points)
        {
            //Avoiding to use Clone method as it is controversial and is not presente in .NET Core
            this.points = points.ToArray();
        }

        //public double GetLengthIn(Skeleton skeleton)
        //{
        //    double length = 0;
        //    for (int i = 1; i < this.points.Length; i++)
        //    {
        //        length += skeleton.Joints[points[i - 1]].DistanceTo(skeleton.Joints[points[i]]);
        //    }
        //    return length;
        //}

        public int Count { get => points.Length; }

        public JointType this[int index] { get => points[index]; }
             
        public IEnumerator<JointType> GetEnumerator()
            => (IEnumerator<JointType>)points.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
