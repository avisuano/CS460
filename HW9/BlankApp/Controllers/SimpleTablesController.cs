using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlankApp.DAL;
using BlankApp.Models;

namespace BlankApp.Controllers
{
    public class SimpleTablesController : Controller
    {
        private SimpleDbContext db = new SimpleDbContext();

        // GET: SimpleTables
        public ActionResult Index()
        {
            return View(db.SimpleTables.ToList());
        }

        // GET: SimpleTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SimpleTable simpleTable = db.SimpleTables.Find(id);
            if (simpleTable == null)
            {
                return HttpNotFound();
            }
            return View(simpleTable);
        }



        // GET: SimpleTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SimpleTable simpleTable = db.SimpleTables.Find(id);
            if (simpleTable == null)
            {
                return HttpNotFound();
            }
            return View(simpleTable);
        }

        // POST: SimpleTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName")] SimpleTable simpleTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(simpleTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(simpleTable);
        }

        // GET: SimpleTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SimpleTable simpleTable = db.SimpleTables.Find(id);
            if (simpleTable == null)
            {
                return HttpNotFound();
            }
            return View(simpleTable);
        }

        // POST: SimpleTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SimpleTable simpleTable = db.SimpleTables.Find(id);
            db.SimpleTables.Remove(simpleTable);
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
    }
}
