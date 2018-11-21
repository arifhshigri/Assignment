// <copyright file="MultipleCalculationLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorLogic.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using CalculatorLogic.Model;
    using DynamicExpresso;

    public static class MultipleCalculationLogic
    {
        public static int MaxNumberOfElement { get; set; } = 25;

        public static IList<MultipleCalculationModel> GeneratesDivisionSet(int min = 1, int max = 25)
        {
            var interpreter = new Interpreter();
            var set = Enumerable.Range(1, MaxNumberOfElement).ToList().Select(x => new MultipleCalculationModel
            {
                Expression = string.Join(" ", Enumerable.Range(1, 3).Select(_ => $"{RNGHelper.Next(1, 99)} {GetOperands(RNGHelper.Next(1, 5))} ")) +
                 $"{RNGHelper.Next(1, 99)}",
            }).ToList();

            set.ForEach(x =>
            {
                x.Result = (int)interpreter.Eval(x.Expression);
            });
            return set;
        }

        private static string GetOperands(long number)
        {
            switch (number)
            {
                case 1:
                    return "+";
                case 2:
                    return "-";
                case 3:
                    return "/";
                case 4:
                    return "*";
                default:
                    return "+";
            }
        }
    }
}
