using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divo.Data;
using Divo.Models;
using Divo.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Divo.Controllers
{
    public class PartyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartyController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }








        public IActionResult Index()
        {
            var parties = _context.Parties.FromSqlRaw("select * from parties where Active = 1").ToList();

            return View("Index", parties);
        }


        public IActionResult InactiveParties()
        {
            var parties = _context.Parties
                .Where(p => p.Active == false)
                .ToList();

            return View(parties);
        }


        public IActionResult New()
        {
            var party = new Party();

            return View("PartyForm", party);
        }


        public IActionResult Details(int id)
        {
            var party = _context.Parties.SingleOrDefault(c => c.Id == id);
            var partyMembers = _context.PartyMembers
                .Where(c => c.PartyId == id)
                .ToList();

            var participants = _context.Participants
                .Where(p => p.PartyId == id)
                .ToList();

            var viewModel = new PartyDetailsViewModel
            {
                Party = party,
                PartyMembers = partyMembers,
                Participants = participants
            };

            if (party == null)
            {
                return NotFound();
            }

            return View("Details", viewModel);
        }


        public IActionResult Edit(int id)
        {
            var party = _context.Parties.SingleOrDefault(c => c.Id == id);


            if (party == null)
            {
                return NotFound();
            }

            return View("PartyForm", party);
        }

        public IActionResult Delete(int id)
        {
            var party = _context.Parties.SingleOrDefault(c => c.Id == id);
            var partyMembers = _context.PartyMembers
                .Where(c => c.PartyId == id)
                .ToList();

            var participants = _context.Participants
                .Where(p => p.PartyId == id)
                .ToList();

            var viewModel = new PartyDeleteViewModel
            {
                Party = party,
                PartyMembers = partyMembers,
                Participants = participants
            };

            if (party == null)
            {
                return NotFound();
            }

            return View("Delete", viewModel);
        }

        public IActionResult Participating(int id)
        {
            var party = _context.Parties.SingleOrDefault(c => c.Id == id);
            var votings = _context.Votings.ToList();
            var participants = _context.Participants
                .Where(c => c.PartyId == id)
                .ToList();

            var viewModel = new PartyParticipatingViewModel()
            {
                Party = party,
                Votings = votings,
                Participants = participants
            };

            if (party == null)
            {
                return NotFound();
            }

            return View("Participating", viewModel);
        }

        public IActionResult PartyMembers(int id)
        {
            var party = _context.Parties.SingleOrDefault(c => c.Id == id);
            var partymembers = _context.PartyMembers
                .Where(c => c.PartyId == id)
                .ToList();

            var viewModel = new PartyPartyMembersViewModel
            {
                Party = party,
                PartyMembers = partymembers
            };

            if (party == null)
            {
                return NotFound();
            }

            return View("PartyMembers", viewModel);
        }








        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Party party)
        {
            var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));


            if (!ModelState.IsValid)
            {
                var returnParty = new Party();

                return View("PartyForm", returnParty);
            }

            if (party.Id == 0)
            {
                _context.Parties.Add(party);
            }
            else
            {
                var votingInDb = _context.Parties.Single(c => c.Id == party.Id);
                votingInDb.Name = party.Name;
                votingInDb.Description = party.Description;
                votingInDb.Active = party.Active;
            }

            await _context.SaveChangesAsync();

            return RedirectToRoute(new { controller = "Party", action = "Index"});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Party party)
        {
            if (party.Id != 0)
            {
                var participating = _context.Participants
                    .Where(c => c.PartyId == party.Id)
                    .ToList();

                if (participating.Any())
                {
                    return RedirectToRoute(new { controller = "Party", action = "Details", id = party.Id });
                }
                else
                {
                    _context.Parties.Remove(party);
                }

                await _context.SaveChangesAsync();
                return RedirectToRoute(new { controller = "Party", action = "Index"});
            }
            return NotFound();

        }
    }
}
