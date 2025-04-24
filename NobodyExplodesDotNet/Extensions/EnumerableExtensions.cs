using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobodyExplodesDotNet.Extensions
{
    public static class EnumerableExtensions
    {
        private static Random Rng => CommonFuncs.SharedRng;

        /// <summary>
        /// Gets a random element from the <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="values">This.</param>
        /// <returns>A random element from the <see cref="IEnumerable{T}"/>.</returns>
        public static T GetRandomElement<T>(this IEnumerable<T> values)
        {
            return values.ElementAt(Rng.Next(values.Count()));
        }

        /// <summary>
        /// Gets a random element from the <see cref="IEnumerable{T}"/> using a specific rng.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="rng">The <see cref="Random"/> instance to use.</param>
        /// <param name="values">This.</param>
        /// <returns>A random element from the <see cref="IEnumerable{T}"/>.</returns>
        public static T GetRandomElement<T>(this IEnumerable<T> values, Random rng)
        {
            return values.ElementAt(rng.Next(values.Count()));
        }

    }
}
