﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment10.Models;
using Microsoft.EntityFrameworkCore;
using Assignment10.Models.ViewModels;

namespace Assignment10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }
        
        public IActionResult Index(long? teamid, string team, int pageNum = 0)
        {
            int pageSize = 5;


            return View(new IndexViewModel
            {
                Bowler = (context.Bowlers.Where(m => m.TeamId == teamid || teamid == null)
                    .OrderBy(m => m.BowlerLastName)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    //If no team has been selected, get full count, otherwise, only count number from specific team
                    TotalNumItems = (teamid == null ? context.Bowlers.Count() :
                    context.Bowlers.Where(x => x.TeamId == teamid).Count())
                },

                Team = team
                
            });
                
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
