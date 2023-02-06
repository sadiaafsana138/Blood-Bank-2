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
    public class DonorTblsController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: DonorTbls
        public ActionResult Index()
        {
            return View(db.DonorTbls.ToList());
        }

        // GET: DonorTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorTbl donorTbl = db.DonorTbls.Find(id);
            if (donorTbl == null)
            {
                return HttpNotFound();
            }
            return View(donorTbl);
        }

        // GET: DonorTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonorTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DNum,DName,DAge,DGender,DPhone,DAddress,DBGroup")] DonorTbl donorTbl)
        {
            if (ModelState.IsValid)
            {
                db.DonorTbls.Add(donorTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donorTbl);
        }

        // GET: DonorTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorTbl donorTbl = db.DonorTbls.Find(id);
            if (donorTbl == null)
            {
                return HttpNotFound();
            }
            return View(donorTbl);
        }

        // POST: DonorTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DNum,DName,DAge,DGender,DPhone,DAddress,DBGroup")] DonorTbl donorTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donorTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donorTbl);
        }

        // GET: DonorTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorTbl donorTbl = db.DonorTbls.Find(id);
            if (donorTbl == null)
            {
                return HttpNotFound();
            }
            return View(donorTbl);
        }

        // POST: DonorTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonorTbl donorTbl = db.DonorTbls.Find(id);
            db.DonorTbls.Remove(donorTbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RODonor()
        {

            List<DonorTbl> DonorTbls = db.DonorTbls.ToList();
            return View(DonorTbls);
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
