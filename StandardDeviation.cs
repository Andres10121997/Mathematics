using System;
using System.Collections.Generic;

namespace Mathematics
{
    public static partial class Enumerable
    {
        #region Population Standard Deviation
        public static double StandardDeviation(this IEnumerable<long> source) => Math.Sqrt(d: Variance(source: source));

        public static float StandardDeviation(this IEnumerable<float> source) => (float)Math.Sqrt(d: Variance(source: source));

        public static double StandardDeviation(this IEnumerable<double> source) => Math.Sqrt(d: Variance(source: source));

        public static decimal StandardDeviation(this IEnumerable<decimal> source) => (decimal)Math.Sqrt(d: (double)Variance(source: source));
        #endregion

        #region Sample Standard Deviation
        public static double SampleStandardDeviation(this IEnumerable<long> source) => Math.Sqrt(d: SampleVariance(source: source));

        public static float SampleStandardDeviation(this IEnumerable<float> source) => (float)Math.Sqrt(d: SampleVariance(source: source));

        public static double SampleStandardDeviation(this IEnumerable<double> source) => Math.Sqrt(d: SampleVariance(source: source));

        public static decimal SampleStandardDeviation(this IEnumerable<decimal> source) => (decimal)Math.Sqrt(d: (double)SampleVariance(source: source));
        #endregion
    }
}