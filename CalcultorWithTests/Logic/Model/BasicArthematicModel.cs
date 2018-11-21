namespace CalculatorLogic.Model
{
    using System.Collections.Generic;

    /// <summary>
    ///     This model is used for basic SUM & SUBTRACTION Arthematic Operation.
    /// </summary>
    public class BasicArthematicModel
    {
        public BasicArthematicModel()
        {
            this.Numbers = new List<int>();
        }

        public List<int> Numbers { get; set; }

        public int Result { get; set; }

        public bool IsValidResult { get; set; }
    }
}
