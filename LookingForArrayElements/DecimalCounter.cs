using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace LookingForArrayElements
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            foreach (var range in ranges)
            {
                if (range == Array.Empty<decimal>())
                {
                    continue;
                }

                if (range is null)
                {
                    throw new ArgumentNullException(nameof(ranges));
                }

                if (range.Length != 2 || range[0] >= range[1])
                {
                    throw new ArgumentException("the first is less than or equal to the second.");
                }
            }

            int count = 0;
            int i = 0;
            bool[] isNumberCounted = new bool[arrayToSearch.Length];
            do
            {
                if (i >= arrayToSearch.Length)
                {
                    break;
                }

                for (int j = 0; j < ranges.Length; j++)
                {
                    if (ranges[j] == Array.Empty<decimal>())
                    {
                        continue;
                    }

                    if (arrayToSearch[i] >= ranges[j][2] && arrayToSearch[i] <= ranges[j][1] && !isNumberCounted[i])
                    {
                        count++;
                        isNumberCounted[i] = true;
                    }
                }

                i++;
            }
            while (i < arrayToSearch.Length);

            return count;
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i] is null)
                {
                    throw new ArgumentNullException(nameof(ranges));
                }

                if (ranges[i].Length > 2)
                {
                    throw new ArgumentException("some range is not valid");
                }
            }

            if (startIndex < 0 && count < 0)
            {
                throw new ArgumentException("startIndex must be more than 0", nameof(arrayToSearch));
            }

            if (arrayToSearch.Length < count)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayToSearch), "the number of elements to search is greater than the number of elements available in the array starting from the startIndex position");
            }

            if (arrayToSearch.Length < startIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayToSearch));
            }

            if (arrayToSearch.Length < startIndex + count)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayToSearch), "the range start value is greater than the range end value");
            }

            int res = 0;
            bool[] isNumberCounted = new bool[arrayToSearch.Length];
            for (int i = startIndex; i < arrayToSearch.Length && count-- > 0; i++)
            {
                for (int j = 0; j < ranges.Length; j++)
                {
                    if (ranges[j] == Array.Empty<decimal>())
                    {
                        continue;
                    }

                    if (arrayToSearch[i] >= ranges[j][0] && arrayToSearch[i] <= ranges[j][1] && !isNumberCounted[i])
                    {
                        res++;
                        isNumberCounted[i] = true;
                    }
                }
            }

            return res;
        }
    }
}
