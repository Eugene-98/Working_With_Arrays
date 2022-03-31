using System;

namespace Working_With_Arrays
{
	public static class MatrixExtension
    {
        /// <summary>
        /// Fills the matrix with natural numbers, starting from 1 in the top-left corner, increasing in an inward, clockwise spiral order.
        /// </summary>
        /// <param name="size">Matrix size.</param>
        /// <returns>Filled matrix.</returns>
        /// <exception cref="ArgumentException">Thrown when matrix size less or equal zero.</exception>
        /// <example> size = 3
        ///     1 2 3
        ///     8 9 4
        ///     7 6 5.
        /// </example>
        /// <example> size = 4
        ///     1  2  3  4
        ///     12 13 14 5
        ///     11 16 15 6
        ///     10 9  8  7.
        /// </example>
        public static int[,] GetMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Size of matrix '{size}' cannot be less or equal zero.");
            }

            int[,] arr = new int[size, size];
            int count = size;
            int value = -size;
            int sum = -1;
            int num = 1;

            do
            {
                value = -1 * value / size;
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    arr[sum / size, sum % size] = num;
                    num++;
                }

                value *= size;
                count--;
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    arr[sum / size, sum % size] = num;
                    num++;
                }
            }
            while (count > 0);

            return arr;
        }
    }
}
