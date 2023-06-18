using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divo.Data;
using Divo.Models;
using Divo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Divo.Controllers
{
    public class VotingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VotingController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }








        public IActionResult Index()
        {
            var votings = _context.Votings
                .Where(c => c.Finished == false)
                .ToList();

            return View("Index", votings);
        }

        public IActionResult HistoryIndex()
        {
            var votings = _context.Votings
                .Where(c => c.Finished == true)
                .ToList();

            return View("HistoryIndex", votings);
        }

        public IActionResult New()
        {
            var parties = _context.Parties
                .Where(p => p.Active == true)
                .ToList();

            var viewModel = new VotingFormViewModel
            {
                Voting = new Voting(),
                Parties = parties
            };

            return View("VotingForm", viewModel);
        }


        public IActionResult Details(int id)
        {
            var voting = _context.Votings.SingleOrDefault(c => c.Id == id);
            var parties = _context.Parties.ToList();
            var participants = _context.Participants
                .Where(c => c.VotingId == id)
                .ToList();

            var viewModel = new VotingDetailsViewModel
            {
                Voting = voting,
                Parties = parties,
                Participants = participants

            };

            if (voting == null)
            {
                return NotFound();
            }

            return View("Details", viewModel);
        }


        public IActionResult Edit(int id)
        {
            var voting = _context.Votings.SingleOrDefault(c => c.Id == id);

            var participants = _context.Participants
                .Where(c => c.VotingId == id)
                .ToList();

            var parties = _context.Parties
                .Where(p => p.Active == true)
                .ToList();


            if (voting == null)
            {
                return NotFound();
            }

            var viewModel = new VotingFormViewModel
            {
                Voting = voting,
                Parties = parties,
                Participants = participants
            };
            return View("VotingForm", viewModel);
        }

        public IActionResult Delete(int id)
        {
            var voting = _context.Votings.SingleOrDefault(c => c.Id == id);
            var parties = _context.Parties.ToList();
            var participants = _context.Participants
                .Where(c => c.VotingId == id)
                .ToList();

            var viewModel = new VotingDeleteViewModel
            {
                Voting = voting,
                Parties = parties,
                Participants = participants

            };

            if (voting == null)
            {
                return NotFound();
            }

            return View("Delete", viewModel);
        }

        public IActionResult Status(int id)
        {
            var voting = _context.Votings.SingleOrDefault(c => c.Id == id);

            if (voting == null)
            {
                return NotFound();
            }

            return View("Status", voting);
        }

        public IActionResult Participants(int id)
        {
            var voting = _context.Votings.SingleOrDefault(c => c.Id == id);
            var parties = _context.Parties.ToList();
            var participants = _context.Participants
                .Where(c => c.VotingId == id)
                .ToList();

            var viewModel = new VotingParticipantsViewModel
            {
                Voting = voting,
                Parties = parties,
                Participants = participants
            };

            if (voting == null)
            {
                return NotFound();
            }

            return View("Participants", viewModel);
        }








        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(VotingFormViewModel votingFormModel)
        {
            var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));


            if (!ModelState.IsValid)
            {
                var parties = _context.Parties.ToList();
                var viewModel = new VotingFormViewModel
                {
                    Voting = new Voting(),
                    Parties = parties
                };

                return View("VotingForm", viewModel);
            }

            if (votingFormModel.Voting.Active == false && votingFormModel.Voting.Finished == false)
            {
                if (votingFormModel.Voting.Id == 0)
                {
                    var voting = votingFormModel.Voting;
                    var votingModel = new Voting
                    {
                        Name = voting.Name,
                        Description = voting.Description,
                        Active = voting.Active,
                        Finished = voting.Finished
                    };

                    _context.Votings.Add(votingModel);
                }
                else
                {
                    var voting = votingFormModel.Voting;
                    var votingInDb = _context.Votings.Single(c => c.Id == voting.Id);
                    votingInDb.Name = voting.Name;
                    votingInDb.Description = voting.Description;
                    votingInDb.Active = voting.Active;
                    votingInDb.Finished = voting.Finished;
                }

                foreach (var partyId in votingFormModel.AddParticipant ?? new int[] { })
                {
                    var addParticipant = new Participant()
                    {
                        VotingId = votingFormModel.Voting.Id,
                        PartyId = partyId
                    };

                    _context.Participants.Add(addParticipant);
                }
            }
            else
            {
                return RedirectToRoute(new { controller = "Voting", action = "Details", id = votingFormModel.Voting.Id });
            }

            

            await _context.SaveChangesAsync();

            if (votingFormModel.Voting.Id == 0)
            {
                return RedirectToRoute(new { controller = "Voting", action = "Index"});
            }
            
            return RedirectToRoute(new {controller = "Voting", action = "Details", id = votingFormModel.Voting.Id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Voting voting)
        {
            if (voting.Id != 0)
            {
                if (voting.Active == true || voting.Finished == true)
                {
                    return RedirectToRoute(new { controller = "Voting", action = "Details", id = voting.Id });
                }
                else
                {
                    _context.Votings.Remove(voting);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToRoute(new { controller = "Voting", action = "Index" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Status(Voting voting)
        {
            if (voting.Id != 0)
            {
                bool activeStatus;
                bool finishedStatus;

                if (voting.Active == false && voting.Finished == false)
                {
                    activeStatus = true;
                    finishedStatus = false;
                }
                else
                {
                    activeStatus = false;
                    finishedStatus = true;
                }

                var votingInDb = _context.Votings.Single(c => c.Id == voting.Id);
                votingInDb.Name = voting.Name;
                votingInDb.Description = voting.Description;
                votingInDb.Active = activeStatus;
                votingInDb.Finished = finishedStatus;
            }
            else
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();
            return RedirectToRoute(new { controller = "Voting", action = "Details", id = voting.Id });
        }
    }
}
