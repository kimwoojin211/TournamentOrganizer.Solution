using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournamentOrganizerClient.Models;

namespace TournamentOrganizerClient.Controllers
{
  public class ShopsController : Controller
  {
    public IActionResult Index()
    {
      var allMatches = Match.GetMatches();
      return View(allMatches);
    }

    [HttpPost]
    public IActionResult Index(Match match)
    {
      Match.Post(match);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var match = Match.GetDetails(id);
      return View(match);
    }

    public IActionResult Edit(int id)
    {
      var match = Match.GetDetails(id);
      return View(match);
    }

    [HttpPost]
    public IActionResult Details(int id, Match match)
    {
      match.MatchId = id;
      Match.Put(match);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Match.Delete(id);
      return RedirectToAction("Index");
    }
  }
}