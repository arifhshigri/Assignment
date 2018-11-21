// <copyright file="CalculationController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Calcultor.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Api.Controllers;
    using CalculatorLogic.Logic;
    using CalculatorLogic.Model;

    [Route("api/[controller]")]
    public class CalculationController : BaseApiController
    {
        /// <summary>
        /// This Method return Welcome Message
        /// </summary>
        /// <returns>Welcome to Calculator API</returns>
       [Route("Get")]
        [HttpGet]
        public string Get()
        {
            return $"Welcome to Calculator API";
        }

        /// <summary>
        ///   Generates a 16 sets of data, each set will hold 3 numbers,
        ///    a result of the sum of the 3 numbers and a boolean to tell if sum result is valid
        /// </summary>
        /// <returns> return 15 set of data</returns>
       [Route("Sums")]
        [HttpGet]
        public IList<BasicArthematicModel> Sums()
        {
            return ArthematicLogic.GeneratesSum().ToList();
        }
    }
}
