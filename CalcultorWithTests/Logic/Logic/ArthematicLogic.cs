// <copyright file="ArthematicLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorLogic.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using CalculatorLogic.Engine;
    using CalculatorLogic.Model;

    public static class ArthematicLogic
    {
        public static int MaxNumberOfElement { get; set; } = 16;

        public static IList<SetModel> GeneratesSubtractionSet(int min = 100, int max = 999)
        {
            var set = new List<SetModel>();
            ResultHelper.CountTrueFalsePorpotion(1, MaxNumberOfElement, out int trueCount, out int falseCount);
            set.AddRange(GeneratesSubtractionList(min, max, trueCount, true));
            set.AddRange(GeneratesSubtractionList(min, max, falseCount, false));
            set = set.Shuffle();
            return set;
        }

        public static IList<SetModel> GeneratesSumSet(int min = 10, int max = 99)
        {
            var set = new List<SetModel>();
            ResultHelper.CountTrueFalsePorpotion(1, MaxNumberOfElement, out int trueCount, out int falseCount);
            set.AddRange(GenerateRandomSumSet(min, trueCount, true));
            set.AddRange(GenerateRandomSumSet(min, falseCount, false));
            set = set.Shuffle();
            return set;
        }

        public static IList<SetModel> GeneratesDivisionSet(int minValue = 100, int maxValue = 9999)
        {
            var set = new List<SetModel>();
            ResultHelper.CountTrueFalsePorpotion(1, MaxNumberOfElement, out int trueCount, out int falseCount);
            set.AddRange(GeneratesDivisionList(minValue, maxValue, trueCount, true));
            set.AddRange(GeneratesDivisionList(minValue, maxValue, falseCount, false));
            set = set.Shuffle();
            return set;
        }

        public static IList<SetModel> GeneratesMultiplicationSet(int minValue = 100, int maxValue = 999)
        {
            var set = new List<SetModel>();
            ResultHelper.CountTrueFalsePorpotion(1, MaxNumberOfElement, out int trueCount, out int falseCount);
            set.AddRange(GeneratesMultiplicationList(minValue, maxValue, trueCount, true));
            set.AddRange(GeneratesMultiplicationList(minValue, maxValue, falseCount, false));
            set = set.Shuffle();
            return set;
        }

        private static IEnumerable<SetModel> GenerateRandomSumSet(int min, int total, bool trueResult)
        {
            var max = 99;

         var set = Enumerable.Range(1, total).ToList().Select(x => new SetModel
            {
                Set = new BasicArthematicModel
                {
                    Numbers = Enumerable.Range(1, 3).ToList().Select(_ => RNGHelper.Next(min, max)).ToList(),
                }
            }).ToList();
            set.ForEach(x =>
            {
                x.Set.Result = trueResult ? x.Set.Numbers.Sum() : RNGHelper.Next(1, 200);
                x.Set.IsValidResult = trueResult;
            });
            return set;
        }

        private static IEnumerable<SetModel> GeneratesDivisionList(int min, int max, int count, bool flag)
        {
            var set = new List<SetModel>();
            for (int i = 0; i < count; i++)
            {
                var setModel = new SetModel();
                var firstNumber = RNGHelper.Next(min, max);
                var secondNumber = RNGHelper.Next(2, 9);
                setModel.Set.Numbers.Add(firstNumber);
                setModel.Set.Numbers.Add(secondNumber);
                setModel.Set.Result = flag ? firstNumber / secondNumber : RNGHelper.Next(secondNumber, firstNumber / secondNumber);
                setModel.Set.IsValidResult = firstNumber / secondNumber == setModel.Set.Result;
                set.Add(setModel);
            }

            return set;
        }

        private static IEnumerable<SetModel> GeneratesMultiplicationList(int min, int max, int count, bool flag)
        {
            var set = new List<SetModel>();
            for (int i = 0; i < count; i++)
            {
                var setModel = new SetModel();
                var firstNumber = RNGHelper.Next(min, max);
                var secondNumber = RNGHelper.Next(min, max);
                setModel.Set.Numbers.Add(firstNumber);
                setModel.Set.Numbers.Add(secondNumber);
                setModel.Set.Result = flag ? firstNumber * secondNumber : RNGHelper.Next(secondNumber, firstNumber * secondNumber);
                setModel.Set.IsValidResult = firstNumber * secondNumber == setModel.Set.Result;
                set.Add(setModel);
            }

            return set;
        }

        private static IEnumerable<SetModel> GeneratesSubtractionList(int min, int max, int count, bool flag)
        {
            var set = new List<SetModel>();
            for (int i = 0; i < count; i++)
            {
                var setModel = new SetModel();
                var firstNumber = RNGHelper.Next(min, max);
                var secondNumber = RNGHelper.Next(min, --firstNumber);
                setModel.Set.Numbers.Add(firstNumber);
                setModel.Set.Numbers.Add(secondNumber);
                setModel.Set.Result = flag ? setModel.Set.Numbers.First() - setModel.Set.Numbers.Last() : RNGHelper.Next(-200, 200);
                setModel.Set.IsValidResult = setModel.Set.Numbers.First() - setModel.Set.Numbers.Last() == setModel.Set.Result;
                set.Add(setModel);
            }

            return set;
        }
    }
}
