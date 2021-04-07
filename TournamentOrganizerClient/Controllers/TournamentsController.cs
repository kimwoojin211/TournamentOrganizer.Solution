// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using TournamentOrganizerClient.Models;

// namespace TournamentOrganizerClient.Controllers
// {
//   public class TournamentsController : Controller
//   {
//     public IActionResult Index()
//     {
//       var allTournaments = Tournament.GetTournaments();
//       return View(allTournaments);
//     }

//     public IActionResult Details(int id)
//     {
//       ViewBag.Matches = Review
//         .GetReviews()
//         .Where(review => review.TournamentId == id);
//       var thisTournament = Tournament.GetDetails(id);
//       return View(thisTournament);
//     }

//     public IActionResult Create()
//     {
//       return View();
//     }

//     [HttpPost]
//     public IActionResult Create(Tournament tournament)
//     {
//       Tournament.Post(tournament);
//       return RedirectToAction("Index");
//     }

//     [HttpPost]
//     public IActionResult Delete(int id)
//     {
//       Tournament.Delete(id);
//       return RedirectToAction("Index");
//     }
//   }
// }