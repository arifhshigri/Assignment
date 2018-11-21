// <copyright file="ResultHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using CalculatorLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorLogic.Engine
{
    public static class ResultHelper
    {
        public static void CountTrueFalsePorpotion(int min, int max, out int trueCount, out int falseCount)
        {
            trueCount = (int)RNGHelper.Next(min, max - 1);
            falseCount = max - trueCount;
        }
    }

    public static class ExtensionMethod
    {
        public static List<T> Shuffle<T>(this List<T> list)
        {
            return list.OrderBy(a => Guid.NewGuid().ToString()).ToList();
        }
    }
}
