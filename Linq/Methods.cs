using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public static class Methods
    {
        public static IEnumerable<int> WhereEven(this IEnumerable<int> x)
        {
            foreach(var item in x)
            {
                if (item % 2 == 0)
                    yield return item;
            }
        }

        public static IEnumerable<IReadOnlyList<T>> Batch<T>(
        this IEnumerable<T> source,
        int size)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));

            List<T>? bucket = null;

            foreach (var item in source)
            {
                bucket ??= new List<T>(size);
                bucket.Add(item);

                if (bucket.Count == size)
                {
                    yield return bucket;
                    bucket = null; // start next batch
                }
            }

            if (bucket != null && bucket.Count > 0)
                yield return bucket;
        }
    }
}
