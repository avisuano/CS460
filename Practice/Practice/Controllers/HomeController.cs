using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice.DAL;
using Practice.Models;

namespace Practice.Controllers
{
    public class HomeController : Controller
    {
        private ArtHouseDbContext db = new ArtHouseDbContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Genres.ToList());
        }

        // Get a Json list result of the artist name and title based on Genre ID
        public JsonResult Genre(int? id)
        {
            List<Results> list = new List<Results>();

            var artList = db.Genres.Where(a => a.ID == id)
                            .Select(b => b.Classifications)
                            .FirstOrDefault()
                            .OrderBy(c => c.Artwork.Title)
                            .ToList();

            foreach (var art in artList)
            {
                Results tmp = new Results();

                tmp.artist = art.Artwork.Artist.ArtistName;
                tmp.artwork = art.Artwork.Title;

                list.Add(tmp);
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}