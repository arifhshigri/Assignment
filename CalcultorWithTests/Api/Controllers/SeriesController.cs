// <copyright file="SeriesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Api.Controllers
{
    using System.Collections.Generic;
    using CalculatorLogic.Logic;
    using CalculatorLogic.Model;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class SeriesController : ControllerBase
    {
        [Route("NextNumber")]
        [HttpGet]
        public IEnumerable<SeriesModel> NextNumber()
        {
            return SeriesLogic.GeneratesSeriesLogic();
        }

        [Route("Matches")]
        [HttpGet]
        public IEnumerable<MatchModel> Matches()
        {
            return SeriesLogic.GenerateMatches();
        }

        [Route("Duplicates")]
        [HttpGet]
        public IEnumerable<DuplicateModel> Duplicates()
        {
            return SeriesLogic.GenerateDuplicates();
        }

        [Route("Search")]
        [HttpGet]
        public SearchModel Search()
        {
            return SeriesLogic.Search();
        }

        [Route("ExactSearch")]
        [HttpGet]
        public ExactSearchModel ExactSearch()
        {
            return SeriesLogic.ExactSearch();
        }
    }
}
