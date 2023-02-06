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
    public class TrasferTblsController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: TrasferTbls
        public ActionResult Index()
        {
            var trasferTbls = db.TrasferTbls.Include(t => t.BloodTbl).Include(t => t.PatientTbl);
            return View(trasferTbls.ToList());
        }

        // GET: TrasferTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrasferTbl trasferTbl = db.TrasferTbls.Find(id);
            if (trasferTbl == null)
            {
                return HttpNotFound();
            }
            return View(trasferTbl);
        }

        // GET: TrasferTbls/Create
        public ActionResult Create()
        {
            ViewBag.BGroup = new SelectList(db.BloodTbls, "BGroup", "BGroup");
            ViewBag.PNum = new SelectList(db.PatientTbls, "PNum", "PName");
            return View();
        }

        // POST: TrasferTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TNum,PNum,BGroup")] TrasferTbl trasferTbl)
        {
            if (ModelState.IsValid)
            {
                db.TrasferTbls.Add(trasferTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BGroup = new SelectList(db.BloodTbls, "BGroup", "BGroup", trasferTbl.BGroup);
            ViewBag.PNum = new SelectList(db.PatientTbls, "PNum", "PName", trasferTbl.PNum);
            return View(trasferTbl);
        }

        // GET: TrasferTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrasferTbl trasferTbl = db.TrasferTbls.Find(id);
            if (trasferTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.BGroup = new SelectList(db.BloodTbls, "BGroup", "BGroup", trasferTbl.BGroup);
            ViewBag.PNum = new SelectList(db.PatientTbls, "PNum", "PName", trasferTbl.PNum);
            return View(trasferTbl);
        }

        // POST: TrasferTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TNum,PNum,BGroup")] TrasferTbl trasferTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trasferTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BGroup = new SelectList(db.BloodTbls, "BGroup", "BGroup", trasferTbl.BGroup);
            ViewBag.PNum = new SelectList(db.PatientTbls, "PNum", "PName", trasferTbl.PNum);
            return View(trasferTbl);
        }

        // GET: TrasferTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrasferTbl trasferTbl = db.TrasferTbls.Find(id);
            if (trasferTbl == null)
            {
                return HttpNotFound();
            }
            return View(trasferTbl);
        }

        // POST: TrasferTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrasferTbl trasferTbl = db.TrasferTbls.Find(id);
            db.TrasferTbls.Remove(trasferTbl);
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
