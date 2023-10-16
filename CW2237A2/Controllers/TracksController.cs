using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CW2237A2.Controllers
{
    public class TracksController : Controller
    {
        private Manager m = new Manager();

        // GET: All Tracks
        public ActionResult Index()
        {
            var t = m.TrackGetAll();
            return View(t);
        }

        // GET: Longest 50 Tracks
        public ActionResult Longest()
        {
            var t = m.TrackGetTop50Longest();
            return View("Index", t);
        }

        // GET: Smallest 50 Tracks
        public ActionResult Smallest()
        {
            var t = m.TrackGetTop50Smallest();
            return View("Index", t);
        }

        // GET: Blue and Jazz Tracks
        public ActionResult BluesJazz()
        {
            var t = m.TrackGetBluesJazz();
            return View("Index", t);
        }

        // GET: Cantrell and Staley Tracks
        public ActionResult CantrellStaley()
        {
            var t = m.TrackGetCantrellStaley();
            return View("Index", t);
        }
    }
}