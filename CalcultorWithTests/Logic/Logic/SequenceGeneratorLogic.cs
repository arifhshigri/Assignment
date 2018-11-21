namespace CalculatorLogic.Helper
{
    using System;
    using CalculatorLogic.Model;

    public class SequenceGeneratorLogic
    {
        public static SeriesModel GenerateSequence()
        {
            var randomeOption = RNGHelper.Next(1, 7);
            switch (randomeOption)
            {
                case 1: // Generate Arthematic Sequence by common difference method
                    return GetArthematicSequence(RNGHelper.Next(0, 100), RNGHelper.Next(5, 10), RNGHelper.Next(4, 8), RNGHelper.Next(-10, 10), new SeriesModel());
                case 2: // Generate Geometric Sequence by common ratio
                    return GenerateGeometricSequence();
                case 3:
                    return GenerateMultiplicationSeries();
                case 4:
                    return GenerateDivisionSeries();
                default:
                    return GenerateDivisionSeries();
            }
        }

        private static SeriesModel GenerateGeometricSequence()
        {
            var series = new SeriesModel();
            var firstNumber = RNGHelper.Next(1, 5);
            var commonRation = RNGHelper.Next(1, 3);

            for (int i = RNGHelper.Next(4, 8); i > 0; i--)
            {
                var result = GetGeometricElement(firstNumber, commonRation, i);
                series.SeriesSet.Add(result);
                series.Explanation += $"{firstNumber} * {(int)Math.Pow(commonRation, i - 1)} = {result} , ";
            }

            series.Explanation = TrimEnds(series.Explanation);

            return series;
        }

        private static SeriesModel GenerateDivisionSeries()
        {
            var seriesModel = new SeriesModel();
            var iteration = RNGHelper.Next(5, 7);

            do
            {
                var number1 = RNGHelper.Next(1, 999);
                var number2 = RNGHelper.Next(1, 90);
                if (number1 > number2 && !seriesModel.SeriesSet.Contains(number2) && !seriesModel.SeriesSet.Contains(number1))
                {
                    seriesModel.SeriesSet.Add(number1);
                    seriesModel.SeriesSet.Add(number2);
                    seriesModel.SeriesSet.Add(number1 / number2);
                    seriesModel.Explanation += $"{number1} / {number2} = {number1 / number2} , ";
                    iteration--;
                }
            }
            while (iteration > 0);

            seriesModel.Explanation = TrimEnds(seriesModel.Explanation);

            return seriesModel;
        }

        private static SeriesModel GenerateMultiplicationSeries()
        {
            var seriesModel = new SeriesModel();
            var iteration = RNGHelper.Next(5, 7);

            do
            {
                var number1 = RNGHelper.Next(1, 90);
                var number2 = RNGHelper.Next(1, 90);
                if (number1 * number2 < 999 && !seriesModel.SeriesSet.Contains(number2) && !seriesModel.SeriesSet.Contains(number1))
                {
                    seriesModel.SeriesSet.Add(number1);
                   // seriesModel.SeriesSet.Add(number2);
                    seriesModel.SeriesSet.Add(number1 * number2);
                    seriesModel.Explanation += $"{number1} * {number2} = {number1 * number2} , ";
                    iteration--;
                }
            }
            while (iteration > 0);
            seriesModel.Explanation = TrimEnds(seriesModel.Explanation);
            return seriesModel;
        }

        private static SeriesModel GetArthematicSequence(int startingNumber, int n, int index, int diff, SeriesModel seriesModel)
        {
            seriesModel.SeriesSet.Add(startingNumber);
            var secondNumber = startingNumber + ((n - 1) * diff);

            if (index == 0)
            {
                seriesModel.Explanation= TrimEnds(seriesModel.Explanation);
                return seriesModel;
            }
            else
            {
                var commonDiff = (n - 1) * diff;
                seriesModel.Explanation += $"{startingNumber} {commonDiff.ToString("+ #;- #;0")} = {secondNumber}, ";
            }

            return GetArthematicSequence(secondNumber, n, --index, diff, seriesModel);
        }

        private static string TrimEnds(string explanation)
        {
            if (explanation.EndsWith(", "))
            {
                explanation = explanation.Substring(0, explanation.Length - 2);
            }
            return explanation;
        }

        private static int GetGeometricElement(int startingNumber, int comonRatio, int nth)
        {
            return startingNumber * (int)Math.Pow(comonRatio, nth - 1);
        }
    }
}
