using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlankApp.DAL;
using BlankApp.Models;

namespace BlankApp.Controllers
{
    public class HomeController : Controller
    {
        private SimpleDbContext db = new SimpleDbContext();

        public ActionResult Index()
        {
            return View(db.SimpleTables.OrderByDescending(a => a.LastName).ToList());
        }
        
        // GET: SimpleTables/Create
        public ActionResult AddNew()
        {
            return View();
        }

        // POST: SimpleTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNew([Bind(Include = "ID,FirstName,LastName")] SimpleTable simpleTable)
        {
            if (ModelState.IsValid)
            {
                db.SimpleTables.Add(simpleTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(simpleTable);
        }
    }
}