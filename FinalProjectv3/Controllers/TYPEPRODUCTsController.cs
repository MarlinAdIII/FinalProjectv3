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
    public class TYPEPRODUCTsController : Controller
    {
        private FinalProjectDBEntities db = new FinalProjectDBEntities();

        // GET: TYPEPRODUCTs
        public ActionResult Index()
        {
            return View(db.TYPEPRODUCTs.ToList());
        }

        // GET: TYPEPRODUCTs/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPEPRODUCT tYPEPRODUCT = db.TYPEPRODUCTs.Find(id);
            if (tYPEPRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(tYPEPRODUCT);
        }

        // GET: TYPEPRODUCTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TYPEPRODUCTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTypeProd,TitleTypeProd")] TYPEPRODUCT tYPEPRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.TYPEPRODUCTs.Add(tYPEPRODUCT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tYPEPRODUCT);
        }

        // GET: TYPEPRODUCTs/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPEPRODUCT tYPEPRODUCT = db.TYPEPRODUCTs.Find(id);
            if (tYPEPRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(tYPEPRODUCT);
        }

        // POST: TYPEPRODUCTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTypeProd,TitleTypeProd")] TYPEPRODUCT tYPEPRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tYPEPRODUCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tYPEPRODUCT);
        }

        // GET: TYPEPRODUCTs/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPEPRODUCT tYPEPRODUCT = db.TYPEPRODUCTs.Find(id);
            if (tYPEPRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(tYPEPRODUCT);
        }

        // POST: TYPEPRODUCTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            TYPEPRODUCT tYPEPRODUCT = db.TYPEPRODUCTs.Find(id);
            db.TYPEPRODUCTs.Remove(tYPEPRODUCT);
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
