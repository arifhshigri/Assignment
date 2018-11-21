using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalculatorLogic.Logic;
using CalculatorLogic.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class CalculationController : BaseController
    {
        // GET: api/values
        [HttpGet]
        public string Get()
        {
         return $"Welcome to Calculator API";
        }

        [HttpGet("Sums")]
        public List<BasicArthematicModel> Sums()
        {
            return ArthematicLogic.GeneratesSumSet().ToList();
        }

        [HttpGet("Subtractions")]
        public List<BasicArthematicModel> Subtractions()
        {
            return ArthematicLogic.GeneratesSubtractionSet().ToList();
        }
    }
}
