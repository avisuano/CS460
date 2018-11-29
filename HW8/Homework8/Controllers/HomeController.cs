using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework8.Models;
using Homework8.DAL;

namespace Homework8.Controllers
{
    public class HomeController : Controller
    {
        private AuctionHouseDbContext db = new AuctionHouseDbContext();

        public ActionResult Index()
        {
            return View();
        }
        
        // GET: Bids/Create
        public ActionResult NewBid()
        {
            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "BuyerName");
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName");
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewBid([Bind(Include = "BidID,ItemID,BuyerID,Price,Timestamp")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                db.Bids.Add(bid);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "BuyerName", bid.BuyerID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", bid.ItemID);
            return View(bid);
        }
    }
}