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
    public class BloodTblsController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: BloodTbls
        public ActionResult Index()
        {
            return View(db.BloodTbls.ToList());
        }

        // GET: BloodTbls/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTbl bloodTbl = db.BloodTbls.Find(id);
            if (bloodTbl == null)
            {
                return HttpNotFound();
            }
            return View(bloodTbl);
        }

        // GET: BloodTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BloodTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BGroup,BStock")] BloodTbl bloodTbl)
        {
            if (ModelState.IsValid)
            {
                db.BloodTbls.Add(bloodTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloodTbl);
        }

        // GET: BloodTbls/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTbl bloodTbl = db.BloodTbls.Find(id);
            if (bloodTbl == null)
            {
                return HttpNotFound();
            }
            return View(bloodTbl);
        }

        // POST: BloodTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BGroup,BStock")] BloodTbl bloodTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloodTbl);
        }

        // GET: BloodTbls/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTbl bloodTbl = db.BloodTbls.Find(id);
            if (bloodTbl == null)
            {
                return HttpNotFound();
            }
            return View(bloodTbl);
        }

        // POST: BloodTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BloodTbl bloodTbl = db.BloodTbls.Find(id);
            db.BloodTbls.Remove(bloodTbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ROBlood()
        {

            List<BloodTbl> BloodTbls = db.BloodTbls.ToList();
            return View(BloodTbls);
           
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
