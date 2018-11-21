// <copyright file="CalculationController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using CalculatorLogic.Logic;
    using CalculatorLogic.Model;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class CalculationController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public string Get()
        {
         return $"Welcome to Calculator API";
        }

        [HttpGet("Sums")]
        public List<SetModel> Sums()
        {
            return ArthematicLogic.GeneratesSumSet().ToList();
        }

        [HttpGet("Subtractions")]
        public List<SetModel> Subtractions()
        {
            return ArthematicLogic.GeneratesSubtractionSet().ToList();
        }

        [HttpGet("Divisions")]
        public List<SetModel> Divisions()
        {
            return ArthematicLogic.GeneratesDivisionSet().ToList();
        }

        [HttpGet("Multiplications")]
        public List<SetModel> Multiplications()
        {
            return ArthematicLogic.GeneratesMultiplicationSet().ToList();
        }
    }
}
