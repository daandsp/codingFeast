using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divo.Data;
using Divo.Models;
using Divo.ViewModels;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.EntityFrameworkCore;

namespace Divo.Controllers
{
    public class PartyMemberController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartyMemberController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }






        public IActionResult New()
        {
            var parties = _context.Parties
                .Where(p => p.Active == true)
                .ToList();

            var viewModel = new PartyMemberFormViewModel
            {
                PartyMember = new PartyMember(),
                Parties = parties
            };
            return View("PartyMemberForm", viewModel);
        }

        public IActionResult Index()
        {
            var partymembers = _context.PartyMembers.Include(c => c.Party);

            return View(partymembers);
        }

        public IActionResult Details(int id)
        {
            var partymember = _context.PartyMembers.Include(c => c.Party).SingleOrDefault(c => c.Id == id);

            if (partymember == null)
            {
                return NotFound();
            }

            return View(partymember);
        }

        public IActionResult Edit(int id)
        {
            var partymember = _context.PartyMembers.SingleOrDefault(c => c.Id == id);

            var parties = _context.Parties
                .Where(p => p.Active == true)
                .ToList();

            if (partymember == null)
            {
                return NotFound();
            }

            var viewModel = new PartyMemberFormViewModel
            {
                PartyMember = partymember,
                Parties = parties
            };
            return View("PartyMemberForm", viewModel);
        }

        public IActionResult Delete(int id)
        {
            var partyMember = _context.PartyMembers.Include(c => c.Party).SingleOrDefault(c => c.Id == id);

            if (partyMember == null)
            {
                return NotFound();
            }

            return View(partyMember);
        }





        public async Task<IActionResult> Save(PartyMember partyMember)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PartyMemberFormViewModel
                {
                    PartyMember = partyMember,
                    Parties = _context.Parties.ToList()
                };

                return View("PartyMemberForm", viewModel);
            }

            if (partyMember.Id == 0)
            {
                _context.PartyMembers.Add(partyMember);
            }
            else
            {
                var partyMemberInDb = _context.PartyMembers.Single(c => c.Id == partyMember.Id);
                partyMemberInDb.Name = partyMember.Name;
                partyMemberInDb.Role = partyMember.Role;
                partyMemberInDb.Description = partyMember.Description;
                partyMemberInDb.PartyId = partyMember.PartyId;
            }

            await _context.SaveChangesAsync();
            return RedirectToRoute(new { controller = "PartyMember", action = "Index" });
        }

        public async Task<IActionResult> Remove(PartyMember partyMember)
        {
            if (partyMember.Id == 0)
            {
                return NotFound();
            }

            if (partyMember != null)
            {
                _context.PartyMembers.Remove(partyMember);
            }

            await _context.SaveChangesAsync();
            return RedirectToRoute(new { controller = "PartyMember", action = "Index" });
        }
    }
}
