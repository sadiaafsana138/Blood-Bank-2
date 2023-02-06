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
    public class PatientTblsController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: PatientTbls
        public ActionResult Index()
        {
            return View(db.PatientTbls.ToList());
        }

        // GET: PatientTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTbl patientTbl = db.PatientTbls.Find(id);
            if (patientTbl == null)
            {
                return HttpNotFound();
            }
            return View(patientTbl);
        }

        // GET: PatientTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PNum,PName,PAge,PPhone,PGender,PBGroup,PAddress")] PatientTbl patientTbl)
        {
            if (ModelState.IsValid)
            {
                db.PatientTbls.Add(patientTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patientTbl);
        }

        // GET: PatientTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTbl patientTbl = db.PatientTbls.Find(id);
            if (patientTbl == null)
            {
                return HttpNotFound();
            }
            return View(patientTbl);
        }

        // POST: PatientTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PNum,PName,PAge,PPhone,PGender,PBGroup,PAddress")] PatientTbl patientTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientTbl);
        }

        // GET: PatientTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTbl patientTbl = db.PatientTbls.Find(id);
            if (patientTbl == null)
            {
                return HttpNotFound();
            }
            return View(patientTbl);
        }

        // POST: PatientTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientTbl patientTbl = db.PatientTbls.Find(id);
            db.PatientTbls.Remove(patientTbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ROPatient()
        {

            List<PatientTbl> PatientTbls = db.PatientTbls.ToList();
            return View(PatientTbls);
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
