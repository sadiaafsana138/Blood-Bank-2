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
    public class EmployeeTblsController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();
       // private BloodBankEntities data = new BloodBankEntities();
        // GET: EmployeeTbls
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public ActionResult SignUp()
        {
            //return View(db.EmployeeTbls.ToList());
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(EmployeeTbl employee)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeTbls.Add(employee);
                db.SaveChanges();
            }
            ViewBag.Message = "SignUp Successful";
            return RedirectToAction("Index","Home" );
          
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            //return View(db.EmployeeTbls.ToList());
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(TempEmp Tempemployee)
        {
            if (ModelState.IsValid)
            {
                var employee = db.EmployeeTbls.Where(u => u.EmpId.Equals(Tempemployee.EmpId) 
                && u.EmpPass.Equals(Tempemployee.EmpPass)).FirstOrDefault();
                if (employee != null)
                {
                    return RedirectToAction("DashBoard",new { Name = employee.EmpId });
                }
                else
                {
                    ViewBag.LoginFailed = "Not Found";
                   return View();
                }
            }
            return View();
        }

        public ActionResult DashBoard(String Name)
        {
            var employee = db.EmployeeTbls.Where(u => u.EmpId.Equals(Name)).FirstOrDefault();
            return View(employee);

        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        // GET: EmployeeTbls/Details/5
         public ActionResult Details(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              EmployeeTbl employeeTbl = db.EmployeeTbls.Find(id);
              if (employeeTbl == null)
              {
                  return HttpNotFound();
              }
              return View(employeeTbl);
          }

          // GET: EmployeeTbls/Create
          public ActionResult Create()
          {
              return View();
          }

          // POST: EmployeeTbls/Create
          // To protect from overposting attacks, enable the specific properties you want to bind to, for 
          // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create([Bind(Include = "EmpNum,EmpId,EmpPass")] EmployeeTbl employeeTbl)
          {
              if (ModelState.IsValid)
              {
                  db.EmployeeTbls.Add(employeeTbl);
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }

              return View(employeeTbl);
          }

          // GET: EmployeeTbls/Edit/5
          public ActionResult Edit(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              EmployeeTbl employeeTbl = db.EmployeeTbls.Find(id);
              if (employeeTbl == null)
              {
                  return HttpNotFound();
              }
              return View(employeeTbl);
          }

          // POST: EmployeeTbls/Edit/5
          // To protect from overposting attacks, enable the specific properties you want to bind to, for 
          // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit([Bind(Include = "EmpNum,EmpId,EmpPass")] EmployeeTbl employeeTbl)
          {
              if (ModelState.IsValid)
              {
                  db.Entry(employeeTbl).State = EntityState.Modified;
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }
              return View(employeeTbl);
          }

          // GET: EmployeeTbls/Delete/5
          public ActionResult Delete(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              EmployeeTbl employeeTbl = db.EmployeeTbls.Find(id);
              if (employeeTbl == null)
              {
                  return HttpNotFound();
              }
              return View(employeeTbl);
          }

          // POST: EmployeeTbls/Delete/5
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public ActionResult DeleteConfirmed(int id)
          {
              EmployeeTbl employeeTbl = db.EmployeeTbls.Find(id);
              db.EmployeeTbls.Remove(employeeTbl);
              db.SaveChanges();
              return RedirectToAction("Index");
          }

        /*  protected override void Dispose(bool disposing)
          {
              if (disposing)
              {
                  db.Dispose();
              }
              base.Dispose(disposing);
          }*/
    }
}
