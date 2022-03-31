using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Working_With_Arrays
{
	public class Transformer
    {
        /// <summary>
        /// Transforms each element of source array into its 'word format'.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of 'word format' of elements of source array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <example>
        /// new[] { 2.345, -0.0d, 0.0d, 0.1d } => { "Two point three four five", "Minus zero", "Zero", "Zero point one" }.
        /// </example>
        public string[] Transform(double[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source == Array.Empty<double>())
            {
                throw new ArgumentException("Array cannot be empty.");
            }

            List<string> result = new List<string>();
            for (int i = 0; i < source.Length; i++)
            {
                result.Add(this.TransformToWords(source[i]));
            }

            return result.ToArray();
        }

        public string TransformToWords(double number)
        {
            if (double.IsNaN(number))
            {
                return "Not a Number";
            }

            if (double.IsPositiveInfinity(number))
            {
                return "Positive Infinity";
            }

            if (double.IsNegativeInfinity(number))
            {
                return "Negative Infinity";
            }

            if (number == double.Epsilon)
            {
                return "Double Epsilon";
            }

            StringBuilder result = new StringBuilder();
            string stringNumber = number.ToString("G", CultureInfo.InvariantCulture);
            for (int i = 0; i < stringNumber.Length; i++)
            {
                if (i > 0 && stringNumber[i] != 'E')
                {
                    result.AppendJoin(" ", this.GetString(stringNumber[i]).ToLower(CultureInfo.CurrentCulture) + ' ');
                }
                else
                {
                    result.AppendJoin(',', this.GetString(stringNumber[i]) + ' ');
                }
            }

            return result.ToString().Trim();
        }

        public string GetString(char signs)
        {
            Dictionary<char, string> pairs = new Dictionary<char, string>()
            {
                { '0', "Zero" },
                { '1', "One" },
                { '2', "Two" },
                { '3', "Three" },
                { '4', "Four" },
                { '5', "Five" },
                { '6', "Six" },
                { '7', "Seven" },
                { '8', "Eight" },
                { '9', "Nine" },
                { '.', "point" },
                { '-', "Minus" },
                { '+', "Plus" },
                { 'E', "E" },
            };
            string stringNum = string.Empty;
            foreach (var pair in pairs)
            {
                if (signs == pair.Key)
                {
                    stringNum = pair.Value;
                }
            }

            return stringNum;
        }
    }
}
