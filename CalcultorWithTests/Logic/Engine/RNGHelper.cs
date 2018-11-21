// <copyright file="RNGHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorLogic
{
    using System;
    using System.Security.Cryptography;

    internal static class RNGHelper
    {
        /// <summary>
        /// Generate a random long within a given range:
        /// </summary>
        /// <param name="min">min</param>
        /// <param name="max">max</param>
        /// <returns>Return a random number between the range provided</returns>
        public static int Next(int min, int max)
        {
            if (min > max)
            {
                var temp = max;
                max = min;
                min = max;
            }

            if (min == max)
            {
                return min;
            }

            using (var rng = new RNGCryptoServiceProvider())
            {
                var data = new byte[64];
                rng.GetBytes(data);

                int generatedValue = Math.Abs(BitConverter.ToInt32(data, startIndex: 0));

                int diff = max - min;
                int mod = generatedValue % diff;
                int normalizedNumber = min + mod;

                return normalizedNumber;
            }
        }

        /// <summary>
        /// Generate a random long within a given range:
        /// </summary>
        /// <param name="min">min</param>
        /// <param name="max">max</param>
        /// <returns>Return a random number between the range provided</returns>
        public static long Next(long min, long max)
        {
            if (min > max)
            {
                var temp = max;
                max = min;
                min = max;
            }

            if (min == max)
            {
                return min;
            }

            using (var rng = new RNGCryptoServiceProvider())
            {
                var data = new byte[64];
                rng.GetBytes(data);

                long generatedValue = Math.Abs(BitConverter.ToInt64(data, startIndex: 0));

                long diff = max - min;
                long mod = generatedValue % diff;
                long normalizedNumber = min + mod;

                return normalizedNumber;
            }
        }
    }
}
