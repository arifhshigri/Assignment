// <copyright file="SeriesLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorLogic.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CalculatorLogic.Helper;
    using CalculatorLogic.Model;

    public static class SeriesLogic
    {
        public static long MaxNumberOfElement { get; set; } = 25;

        public static IEnumerable<DuplicateModel> GenerateDuplicates(int length = 20)
        {
            var list = Enumerable.Range(1, length).Select(_ => new DuplicateModel()).ToList();
            list.ForEach(x =>
           {
               // Generate Random 3 x 3 Matrix
               for (int i = 0; i < 4; i++)
               {
                   for (int j = 0; j < 4; j++)
                   {
                       x.Set[i, j] = RNGHelper.Next(1, 10);
                   }
               }

               // Find Duplicate in Column
               for (int col = 0; col < 4; col++)
               {
                   for (int row = 0; row < 4; row++)
                   {
                       var number = x.Set[col, row];
                       var c = row;
                       for (int r = row; r < 4; r++)
                       {
                           var element = x.Set[r, c];
                           if (element == number && (r != col))
                           {
                               x.ColumnWithDuplicate.Add(row);
                           }
                       }
                   }
               }

               // Find Duplicate in Row
               for (int row = 0; row < 4; row++)
               {
                   for (int col = 0; col < 3; col++)
                   {
                       var number = x.Set[row, col];
                       if (HasRowDuplicate(row, col, number, x))
                       {
                           x.RowWithDuplicate.Add(row);
                       }
                   }
               }

               x.ColumnWithDuplicate = x.ColumnWithDuplicate.Distinct().ToList();
               x.RowWithDuplicate = x.RowWithDuplicate.Distinct().ToList();
           });

            return list;
        }

        public static bool HasRowDuplicate(long row, long ignoreCol, long element, DuplicateModel duplicateModel)
        {
            for (int column = 1; column < 4; column++)
            {
                if (ignoreCol == column)
                {
                    continue;
                }

                if (duplicateModel.Set[row, column] == element)
                {
                    return true;
                }
            }
            return false;
        }

        public static IList<SeriesModel> GeneratesSeriesLogic(long min = 1, long max = 25)
        {
            List<SeriesModel> returnData = new List<SeriesModel>();
            for (int i = 0; i < 25; i++)
            {
                returnData.Add(SequenceGeneratorLogic.GenerateSequence());
            }

            return returnData;
        }

        public static List<MatchModel> GenerateMatches(long count = 25)
        {
            var set = new List<MatchModel>();
            Enumerable.Range(1, 13).ToList().ForEach(x =>
            {
                var data = new MatchModel();
                var random = RNGHelper.Next(0111111111, 9999999999);
                data.Pair.Add(random);
                data.Pair.Add(random);
                set.Add(data);
            });

            Enumerable.Range(1, 12).ToList().ForEach(x =>
            {
                var data = new MatchModel();
                data.Pair.Add(RNGHelper.Next(0111111111, 9999999999));
                data.Pair.Add(RNGHelper.Next(0111111111, 9999999999));
                set.Add(data);
            });

           set = set.OrderBy(x => RNGHelper.Next(1, 99)).ToList();
            return set;
        }

        public static SearchModel Search()
        {
            var searchModel = new SearchModel();
            searchModel.Array = Enumerable.Range(0, 625).Select(x => RNGHelper.Next(0, 9)).ToList();
            while (searchModel.NumbersToFind.Count <= 4)
            {
                var randomNumber = searchModel.Array.ElementAt((int)RNGHelper.Next(0, 625));
                if (!searchModel.NumbersToFind.Contains(randomNumber))
                {
                    searchModel.NumbersToFind.Add(randomNumber);
                }
            }

            foreach (var number in searchModel.NumbersToFind)
            {
                var result = searchModel.Array.Select((element, index) => new { element, index })
                  .Where(x => x.element == number)
                  .Select(y => y.index).ToList();

                searchModel.Result.Add("PositionsOfNumber" + searchModel.NumbersToFind.IndexOf(number), result);
            }

            return searchModel;
        }

        public static ExactSearchModel ExactSearch()
        {
            var maxCount = 625;
            var searchModel = new ExactSearchModel();
            searchModel.Array = Enumerable.Range(0, maxCount).Select(x => RNGHelper.Next(0, 9)).ToList();
            searchModel.ExactPairsToFind = Enumerable.Range(0, 3).Select(_ => ((int)RNGHelper.Next(0, maxCount)))
                 .Select((x, index) => new KeyValuePair<string, List<double>>($"Pair{++index}", new List<double>() { searchModel.Array[index], searchModel.Array[++index] }))
                 .ToList();
            var count = 0;

            foreach (var keyValue in searchModel.ExactPairsToFind)
            {
                var searchIndex = new List<int>();
                var numbers = keyValue.Value;
                for (int i = 0; i < searchModel.Array.Count(); i++)
                {
                    if ((i + 1) >= searchModel.Array.Count)
                    {
                        continue;
                    }

                    if (searchModel.Array[i] == numbers[0] && searchModel.Array[i + 1] == numbers[1])
                    {
                        searchIndex.Add(i);
                    }
                }

                searchModel.Result.Add($"PositionsOf{keyValue.Key}", searchIndex);
            }

            return searchModel;
        }

        private static long[] GetRowDuplicates(DuplicateModel x)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var element = x.Set[i, j];
                }
            }

            throw new NotImplementedException();
        }

    }
}
