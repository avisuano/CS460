using Homework8.DAL;
using Homework8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework8.Controllers
{
    public class HomeController : Controller
    {
        private AuctionHouseContextDb db = new AuctionHouseContextDb();

        public ActionResult Index()
        {
            return View();
        }

        // GET: Allows for a user to add a new bid on an item
        public ActionResult NewBid()
        {
            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "Name");
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name");
            return View();
        }
        
        /// <summary>
        /// Add the bid to the database and then save
        /// </summary>
        /// <param name="bid">The value and info to pass to the database</param>
        /// <returns>On success, back to the Index</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewBid([Bind(Include = "BidID, ItemID, BuyerID, Price")] Bid bid)
        {
            bid.Timestamp = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Bids.Add(bid);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "Name", bid.BuyerID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", bid.ItemID);
            return View();
        }
    }
}