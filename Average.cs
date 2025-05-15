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
            if (source.Count<TSource>() <= 0)
            {
                throw new ArgumentException(message: $"La cantidad de elementos de {nameof(source)} debe ser superior a 0",
                                            paramName: nameof(source));
            }

            return TResult.CreateChecked(value: source.Average<TSource>(selector: x => Convert.ToDouble(value: x)));
        }
    }
}