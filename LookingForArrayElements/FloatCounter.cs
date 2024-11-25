using System;
using System.Reflection.Metadata.Ecma335;

namespace LookingForArrayElements
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart is null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("length of ranges is different", nameof(rangeStart));
            }

            for (int i = 0; i < rangeStart.Length; i++)
            {
                if (rangeStart[i] > rangeEnd[i])
                {
                    throw new ArgumentException("rangeEnd have less value than rangeStart");
                }
            }

            int count = 0;
            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                for (int j = 0; j < rangeStart.Length; j++)
                {
                    if (arrayToSearch[i] >= rangeStart[j] && arrayToSearch[i] <= rangeEnd[j])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart is null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (startIndex < 0 && count < 0)
            {
                throw new ArgumentException("startIndex must be more than 0", nameof(arrayToSearch));
            }

            if (rangeEnd.Length != rangeStart.Length)
            {
                throw new ArgumentException("ranges length are diff");
            }

            for (int k = 0; k < rangeStart.Length; k++)
            {
                if (rangeStart[k] > rangeEnd[k])
                {
                    throw new ArgumentException(")))))))");
                }
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

            if (rangeStart.Length == 0)
            {
                return 0;
            }

            int i = startIndex, j, res = 0;
            do
            {
                j = 0;
                do
                {
                    if (arrayToSearch[i] >= rangeStart[j] && arrayToSearch[i] <= rangeEnd[j])
                    {
                        res++;
                    }
                }
                while (j++ < rangeStart.Length - 1);
            }
            while (++i < arrayToSearch.Length - 1 && --count > 0);

            return res;
        }
    }
}
