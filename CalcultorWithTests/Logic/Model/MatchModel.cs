// <copyright file="MatchModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorLogic.Model
{
    using System.Collections.Generic;
    using System.Linq;

    public class MatchModel
    {
        public MatchModel()
        {
            Pair = new List<long>();
        }

        public List<long> Pair { get; set; }

        public string Result => this.Pair.GroupBy(x => x).Count() == 1 ? "Equals" : "Different";
    }
}
