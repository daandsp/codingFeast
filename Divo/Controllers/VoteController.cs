using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Divo.Data;
using Divo.Models;
using Divo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Divo.Controllers
{
    [Authorize]
    public class VoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        public IActionResult Index()
        {
            //var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var test = _context.Votings
            //    .Select(voting => voting.Id)
            //    .ToList();

            //var votings = _context.Votings
            //    .Where(c => c.Active == true && c.Finished == false)
            //    .ToList();

            //var votingsForUser = _context.Votes
            //    .Where(c => c.UserId != currentUserId)
            //    .ToList();

            //var viewModel = new VoteIndexViewModel
            //{
            //    Votings = votings,
            //    Votes = votingsForUser
            //};

            //return View("Index", viewModel);

            return View("Construction");
        }

        public IActionResult Construction()
        {
            return View();
        }
    }
}
