// <copyright file="SeriesModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorLogic.Model
{
    using System.Collections.Generic;

    public class SeriesModel
    {
        public SeriesModel()
        {
           this.SeriesSet = new List<int>();
        }

        public string Series => string.Join(",", this.SeriesSet);

        public string Explanation { get; set; }

        internal List<int> SeriesSet { get; set; }
    }
}
