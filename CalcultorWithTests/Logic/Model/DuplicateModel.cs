// <copyright file="DuplicateModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorLogic.Model
{
    using System.Collections.Generic;

    public class DuplicateModel
    {
        public DuplicateModel()
        {
            Set = new int[4, 4];

            ColumnWithDuplicate = new List<int>();

            RowWithDuplicate = new List<int>();
        }

        public int[,] Set { get; set; }

        public List<int> ColumnWithDuplicate { get; set; }

        public List<int> RowWithDuplicate { get; set; }
    }
}
