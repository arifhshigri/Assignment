namespace CalculatorLogic.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SearchModel
    {
        public SearchModel()
        {
            this.NumbersToFind = new List<int>();

            this.Array = new List<int>();

            this.Result = new Dictionary<string, List<int>>();
        }

        public List<int> NumbersToFind { get; set; }

        public List<int> Array { get; set; }

        public Dictionary<string, List<int>> Result { get; set; }
    }
}
