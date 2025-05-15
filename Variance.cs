using System;
using System.Collections.Generic;
using System.Numerics;

namespace Mathematics
{
    public static partial class Enumerable
    {
        #region Population Variance
        public static double Variance(this IEnumerable<long> source) => Variance<long, long, double>(source: source);

        public static float Variance(this IEnumerable<float> source) => (float)Variance<float, double, double>(source: source);

        public static double Variance(this IEnumerable<double> source) => Variance<double, double, double>(source: source);

        public static decimal Variance(this IEnumerable<decimal> source) => Variance<decimal, decimal, decimal>(source: source);

        private static TResult Variance<TSource, TAccumulator, TResult>(this IEnumerable<TSource> source)
            where TSource : struct, INumber<TSource>
            where TAccumulator : struct, INumber<TAccumulator>
            where TResult : struct, INumber<TResult>
        {
            #region Variables
            long count;
            TSource average;
            // TAccumulator sum;
            TAccumulator sumOfSquares;
            TAccumulator variance;
            #endregion

            if (source is null)
            {
                throw new ArgumentNullException(paramName: nameof(source));
            }
            
            count = 0;
            // sum = TAccumulator.Zero;
            
            // Primera pasada: calcular suma y cantidad
            foreach (TSource item in source)
            {
                // sum += TAccumulator.CreateChecked(value: item);

                count++;
            }

            if (count == 0)
            {
                throw new InvalidOperationException(message: "Sequence contains no elements.");
            }

            // average = TSource.CreateChecked(value: sum) / TSource.CreateChecked((TAccumulator)TAccumulator.CreateChecked(value: count));
            
            average = Average<TSource, TSource>(source);

            // Segunda pasada: calcular suma de cuadrados
            sumOfSquares = TAccumulator.Zero;

            foreach (TSource item in source)
            {
                TAccumulator diff = TAccumulator.CreateChecked(value: item - average);

                sumOfSquares += diff * diff;
            }

            variance = sumOfSquares / TAccumulator.CreateChecked(value: count);

            return TResult.CreateChecked(value: variance);
        }
        #endregion

        #region Sample Variance
        public static double SampleVariance(this IEnumerable<long> source) => SampleVariance<long, long, double>(source: source);

        public static float SampleVariance(this IEnumerable<float> source) => (float)SampleVariance<float, double, double>(source: source);

        public static double SampleVariance(this IEnumerable<double> source) => SampleVariance<double, double, double>(source: source);

        public static decimal SampleVariance(this IEnumerable<decimal> source) => SampleVariance<decimal, decimal, decimal>(source: source);

        private static TResult SampleVariance<TSource, TAccumulator, TResult>(this IEnumerable<TSource> source)
            where TSource : struct, INumber<TSource>
            where TAccumulator : struct, INumber<TAccumulator>
            where TResult : struct, INumber<TResult>
        {
            #region Variables
            long count;
            TSource average;
            TAccumulator sum;
            TAccumulator sumOfSquares;
            TAccumulator variance;
            #endregion

            if (source is null)
            {
                throw new ArgumentNullException(paramName: nameof(source));
            }

            count = 0;
            sum = TAccumulator.Zero;

            foreach (TSource item in source)
            {
                sum += TAccumulator.CreateChecked(value: item);

                count++;
            }

            if (count <= 1)
            {
                throw new InvalidOperationException(message: "Sequence contains not enough elements for sample variance.");
            }

            average = TSource.CreateChecked(value: sum) / TSource.CreateChecked(value: count);

            sumOfSquares = TAccumulator.Zero;

            foreach (TSource item in source)
            {
                TAccumulator diff = TAccumulator.CreateChecked(value: item - average);

                sumOfSquares += diff * diff;
            }

            variance = sumOfSquares / TAccumulator.CreateChecked(value: count - 1); // Dividiendo entre (n-1) para varianza muestral

            return TResult.CreateChecked(value: variance);
        }
        #endregion
    }
}