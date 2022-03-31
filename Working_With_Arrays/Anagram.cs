using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Working_With_Arrays
{
	public class Anagram
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Anagram"/> class.
        /// </summary>
        /// <param name="sourceWord">Source word.</param>
        /// <exception cref="ArgumentNullException">Thrown when source word is null.</exception>
        /// <exception cref="ArgumentException">Thrown when  source word is empty.</exception>
        private string word;

        public Anagram(string sourceWord)
        {
            if (sourceWord is null)
            {
                throw new ArgumentNullException(nameof(sourceWord));
            }

            if (string.IsNullOrEmpty(sourceWord))
            {
                throw new ArgumentException("The word cannot be empty.");
            }

            this.word = sourceWord;
        }

        /// <summary>
        /// From the list of possible anagrams selects the correct subset.
        /// </summary>
        /// <param name="candidates">A list of possible anagrams.</param>
        /// <returns>The correct sublist of anagrams.</returns>
        /// <exception cref="ArgumentNullException">Thrown when candidates list is null.</exception>
        public string[] FindAnagrams(string[] candidates)
        {
            if (candidates is null)
            {
                throw new ArgumentNullException(nameof(candidates));
            }

            string pattern = @"\.+?|\,+?|\ +?|\-+?|\:+?|\!+?";
            List<string> result = new List<string>();
            for (int i = 0; i < candidates.Length; i++)
            {
                if (candidates[i].ToUpper(CultureInfo.InvariantCulture) != this.word.ToUpper(CultureInfo.InvariantCulture))
                {
                    this.word = Regex.Replace(this.word, pattern, string.Empty);
                    candidates[i] = Regex.Replace(candidates[i], pattern, string.Empty);
                    char[] a = this.word.ToUpper(CultureInfo.InvariantCulture).ToCharArray();
                    char[] b = candidates[i].ToUpper(CultureInfo.InvariantCulture).ToCharArray();
                    Array.Sort(a);
                    Array.Sort(b);
                    string x = new string(a);
                    string y = new string(b);
                    if (Equals(x, y))
                    {
                        result.Add(candidates[i]);
                    }
                }
            }

            return result.ToArray();
        }
    }
}
