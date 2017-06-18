using System;

namespace Recognet.Poses
{
    static class Utils
    {
        public static double DifferenceDistanceRatio(double difference, double distance)
        {
            if (difference < 0) return 0;
            return Math.Min(1, difference / distance);
        }

        public static double AbsoluteDifferenceDistanceRatio(double difference, double distance)
            => Math.Abs(difference) / distance;
    }
}
