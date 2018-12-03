using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProjectv3.Models;

namespace FinalProjectv3.Controllers
{
    public class JOBDONEsController : Controller
    {
        private FinalProjectDBEntities db = new FinalProjectDBEntities();

        // GET: JOBDONEs
        public ActionResult Index()
        {
            var jOBDONEs = db.JOBDONEs.Include(j => j.APPOINTMENT).Include(j => j.DISCOUNT);
            return View(jOBDONEs.ToList());
        }

        // GET: JOBDONEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JOBDONE jOBDONE = db.JOBDONEs.Find(id);
            if (jOBDONE == null)
            {
                return HttpNotFound();
            }
            return View(jOBDONE);
        }

        // GET: JOBDONEs/Create
        public ActionResult Create(int appnID)
        {
            ViewBag.IDDiscount = new SelectList(db.DISCOUNTs, "IDDiscount", "TitleDiscount");
            ViewBag.AppointentID = appnID;
            return View();
        }

        // POST: JOBDONEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDJobDone,IDAppoint,DateJobDone,TimeEndJob,IDDiscount,DiscountAmount,feedback")] JOBDONE jOBDONE)
        {
            if (ModelState.IsValid)
            {
                db.JOBDONEs.Add(jOBDONE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDAppoint = new SelectList(db.APPOINTMENTs, "IDAppoint", "IDAppoint", jOBDONE.IDAppoint);
            ViewBag.IDDiscount = new SelectList(db.DISCOUNTs, "IDDiscount", "TitleDiscount", jOBDONE.IDDiscount);
            return View(jOBDONE);
        }

        // GET: JOBDONEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JOBDONE jOBDONE = db.JOBDONEs.Find(id);
            if (jOBDONE == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDAppoint = new SelectList(db.APPOINTMENTs, "IDAppoint", "IDAppoint", jOBDONE.IDAppoint);
            ViewBag.IDDiscount = new SelectList(db.DISCOUNTs, "IDDiscount", "TitleDiscount", jOBDONE.IDDiscount);
            return View(jOBDONE);
        }

        // POST: JOBDONEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDJobDone,IDAppoint,DateJobDone,TimeEndJob,IDDiscount,DiscountAmount,feedback")] JOBDONE jOBDONE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jOBDONE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDAppoint = new SelectList(db.APPOINTMENTs, "IDAppoint", "IDAppoint", jOBDONE.IDAppoint);
            ViewBag.IDDiscount = new SelectList(db.DISCOUNTs, "IDDiscount", "TitleDiscount", jOBDONE.IDDiscount);
            return View(jOBDONE);
        }

        // GET: JOBDONEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JOBDONE jOBDONE = db.JOBDONEs.Find(id);
            if (jOBDONE == null)
            {
                return HttpNotFound();
            }
            return View(jOBDONE);
        }

        // POST: JOBDONEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JOBDONE jOBDONE = db.JOBDONEs.Find(id);
            db.JOBDONEs.Remove(jOBDONE);
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
