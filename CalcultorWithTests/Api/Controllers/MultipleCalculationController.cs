// <copyright file="MultipleCalculationController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Api.Controllers
{
    using System.Collections.Generic;
    using CalculatorLogic.Logic;
    using CalculatorLogic.Model;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class MultipleCalculationController : ControllerBase
    {
        [Route("Expression")]
        [HttpGet]
        public IEnumerable<MultipleCalculationModel> Expression()
        {
            return MultipleCalculationLogic.GeneratesDivisionSet();
        }
    }
}
