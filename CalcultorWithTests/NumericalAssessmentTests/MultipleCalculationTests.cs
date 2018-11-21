

namespace NumericalAssessmentTests
{
    using System.Collections.Generic;
    using System.Linq;
    using CalculatorLogic.Logic;
    using CalculatorLogic.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MultipleCalculationTests
    {
        /// <summary>
        /// We cannot have all sets false
        /// </summary>
        [TestMethod]
        public void All_IsValidResults_Cannot_Be_False()
        {
            for (int i = 0; i < 400000; i++)
            {
                List<SetModel> items
                    = ArthematicLogic.GeneratesMultiplicationSet().ToList();
                int totalOfFalseValidResult = items.Where(x => x.Set.IsValidResult == false).ToList().Count();

                Assert.AreNotEqual(items.Count(), totalOfFalseValidResult);
            }
        }

        /// <summary>
        /// We cannot have all sets true
        /// </summary>
        [TestMethod]
        public void All_IsValidResults_Cannot_Be_True()
        {
            for (int i = 0; i < 400000; i++)
            {
                List<SetModel> items = ArthematicLogic.GeneratesMultiplicationSet().ToList();
                int totalOfTrueValidResult = items.Where(x => x.Set.IsValidResult == true).ToList().Count();

                Assert.AreNotEqual(items.Count(), totalOfTrueValidResult);
            }
        }
    }
}
