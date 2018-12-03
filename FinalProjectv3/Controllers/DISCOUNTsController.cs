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
    public class DISCOUNTsController : Controller
    {
        private FinalProjectDBEntities db = new FinalProjectDBEntities();

        // GET: DISCOUNTs
        public ActionResult Index()
        {
            return View(db.DISCOUNTs.ToList());
        }

        // GET: DISCOUNTs/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCOUNT dISCOUNT = db.DISCOUNTs.Find(id);
            if (dISCOUNT == null)
            {
                return HttpNotFound();
            }
            return View(dISCOUNT);
        }

        // GET: DISCOUNTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DISCOUNTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDiscount,TitleDiscount,AmountDiscount")] DISCOUNT dISCOUNT)
        {
            if (ModelState.IsValid)
            {
                db.DISCOUNTs.Add(dISCOUNT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dISCOUNT);
        }

        // GET: DISCOUNTs/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCOUNT dISCOUNT = db.DISCOUNTs.Find(id);
            if (dISCOUNT == null)
            {
                return HttpNotFound();
            }
            return View(dISCOUNT);
        }

        // POST: DISCOUNTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDiscount,TitleDiscount,AmountDiscount")] DISCOUNT dISCOUNT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISCOUNT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dISCOUNT);
        }

        // GET: DISCOUNTs/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCOUNT dISCOUNT = db.DISCOUNTs.Find(id);
            if (dISCOUNT == null)
            {
                return HttpNotFound();
            }
            return View(dISCOUNT);
        }

        // POST: DISCOUNTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            DISCOUNT dISCOUNT = db.DISCOUNTs.Find(id);
            db.DISCOUNTs.Remove(dISCOUNT);
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
