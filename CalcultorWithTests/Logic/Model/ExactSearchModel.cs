// <copyright file="ExactSearchModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorLogic.Model
{
    using System.Collections.Generic;

    public class ExactSearchModel
    {
        public ExactSearchModel()
        {
            this.ExactPairsToFind = new List<KeyValuePair<string, List<double>>>();

            this.Array = new List<int>();

            this.Result = new Dictionary<string, List<int>>();
        }

        public List<KeyValuePair<string, List<double>>> ExactPairsToFind { get; set; }

        public List<int> Array { get; set; }

        public Dictionary<string, List<int>> Result { get; set; }
    }
}