using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Homework8.DAL;
using Homework8.Models;
using Newtonsoft.Json;

namespace Homework8.Controllers
{
    public class ItemsController : Controller
    {
        private AuctionHouseDbContext db = new AuctionHouseDbContext();

        // GET: Items
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Seller);
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.SellerID = new SelectList(db.Sellers, "SellerID", "SellerName");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ItemName,ItemDescription,SellerID")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SellerID = new SelectList(db.Sellers, "SellerID", "SellerName", item.SellerID);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.SellerID = new SelectList(db.Sellers, "SellerID", "SellerName", item.SellerID);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemName,ItemDescription,SellerID")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SellerID = new SelectList(db.Sellers, "SellerID", "SellerName", item.SellerID);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Lets go display a bid, up to the highest bid
        public JsonResult ListBids(int? id)
        {
            // Let's find each item by id
            var bids = db.Bids.Where(a => a.ItemID == id)
                .OrderByDescending(d => d.Price)
                .ToList();

            // New class object to grab Name (Buyer) and Price (Bid)
            List<GrabTheBids> bidTable = new List<GrabTheBids>();
            GrabTheBids tmp;

            // Fill that up with the Buyer name and the current bid Prices
            foreach (Bid bid in bids)
            {
                tmp = new GrabTheBids
                {
                    BuyerName = bid.Buyer.BuyerName,
                    Price = bid.Price                    
                };
                bidTable.Add(tmp);
            }

            // Convert back to a json object to send through
            string toJson = JsonConvert.SerializeObject(bidTable, Newtonsoft.Json.Formatting.Indented);
            return Json(toJson, JsonRequestBehavior.AllowGet);
        }

        // Can it be simplier? Short Answer is no...
        //public JsonResult GrabBids(int? id)
        //{
        //    var bids = db.Bids.Where(a => a.Item.ItemID == id)
        //        .Select(a => new { Buyer = a.Buyer.BuyerName, Price = a.Price })
        //        .OrderByDescending(d => d.Price)
        //        .ToList();

        //    return Json(bids, JsonRequestBehavior.AllowGet);
        //}
    }
}
