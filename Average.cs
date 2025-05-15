using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Mathematics
{
    public static partial class Enumerable
    {
        private static TResult Average<TSource, TResult>(IEnumerable<TSource> source)
            where TSource : struct, INumber<TSource>
            where TResult : struct, INumber<TResult>
        {
            #region Variables
            long count;
            TSource sum;
            TResult average;
            #endregion

            count = 0;
            sum = TSource.Zero;

            if (source.ToArray().Length <= 0)
            {
                throw new ArgumentException();
            }

            // Primera pasada: calcular suma y cantidad
            foreach (TSource item in source)
            {
                sum += TSource.CreateChecked(value: item);

                count++;
            }

            if (count == 0)
            {
                throw new InvalidOperationException(message: "Sequence contains no elements.");
            }

            average = TResult.CreateChecked(value: sum) / TResult.CreateChecked((TSource)TSource.CreateChecked(value: count));

            return average;
        }
    }
}