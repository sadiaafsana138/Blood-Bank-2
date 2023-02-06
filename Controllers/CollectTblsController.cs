using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class CollectTblsController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: CollectTbls
        public ActionResult Index()
        {
            var collectTbls = db.CollectTbls.Include(c => c.BloodTbl).Include(c => c.DonorTbl);
            return View(collectTbls.ToList());
        }

        // GET: CollectTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectTbl collectTbl = db.CollectTbls.Find(id);
            if (collectTbl == null)
            {
                return HttpNotFound();
            }
            return View(collectTbl);
        }

        // GET: CollectTbls/Create
        public ActionResult Create()
        {
            ViewBag.BGroup = new SelectList(db.BloodTbls, "BGroup", "BGroup");
            ViewBag.DNum = new SelectList(db.DonorTbls, "DNum", "DName");
            return View();
        }

        // POST: CollectTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CNum,DNum,BGroup")] CollectTbl collectTbl)
        {
            if (ModelState.IsValid)
            {
                db.CollectTbls.Add(collectTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BGroup = new SelectList(db.BloodTbls, "BGroup", "BGroup", collectTbl.BGroup);
            ViewBag.DNum = new SelectList(db.DonorTbls, "DNum", "DName", collectTbl.DNum);
            return View(collectTbl);
        }

        // GET: CollectTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectTbl collectTbl = db.CollectTbls.Find(id);
            if (collectTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.BGroup = new SelectList(db.BloodTbls, "BGroup", "BGroup", collectTbl.BGroup);
            ViewBag.DNum = new SelectList(db.DonorTbls, "DNum", "DName", collectTbl.DNum);
            return View(collectTbl);
        }

        // POST: CollectTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CNum,DNum,BGroup")] CollectTbl collectTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collectTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BGroup = new SelectList(db.BloodTbls, "BGroup", "BGroup", collectTbl.BGroup);
            ViewBag.DNum = new SelectList(db.DonorTbls, "DNum", "DName", collectTbl.DNum);
            return View(collectTbl);
        }

        // GET: CollectTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectTbl collectTbl = db.CollectTbls.Find(id);
            if (collectTbl == null)
            {
                return HttpNotFound();
            }
            return View(collectTbl);
        }

        // POST: CollectTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CollectTbl collectTbl = db.CollectTbls.Find(id);
            db.CollectTbls.Remove(collectTbl);
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
