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
    public class HAIRController : Controller
    {
        private FinalProjectDBEntities db = new FinalProjectDBEntities();

        // GET: HAIR
        public ActionResult Index()
        {
            var hAIR = db.HAIR.Include(h => h.PRODUCT);
            return View(hAIR.ToList());
        }

        // GET: HAIR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAIR hAIR = db.HAIR.Find(id);
            if (hAIR == null)
            {
                return HttpNotFound();
            }
            return View(hAIR);
        }

        // GET: HAIR/Create
        public ActionResult Create()
        {
            ViewBag.IDProd = new SelectList(db.PRODUCTs, "IDProd", "TitleProd");
            return View();
        }

        // POST: HAIR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDHair,TitleHair,IDProd")] HAIR hAIR)
        {
            if (ModelState.IsValid)
            {
                db.HAIR.Add(hAIR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDProd = new SelectList(db.PRODUCTs, "IDProd", "TitleProd", hAIR.IDProd);
            return View(hAIR);
        }

        // GET: HAIR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAIR hAIR = db.HAIR.Find(id);
            if (hAIR == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDProd = new SelectList(db.PRODUCTs, "IDProd", "TitleProd", hAIR.IDProd);
            return View(hAIR);
        }

        // POST: HAIR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDHair,TitleHair,IDProd")] HAIR hAIR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hAIR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDProd = new SelectList(db.PRODUCTs, "IDProd", "TitleProd", hAIR.IDProd);
            return View(hAIR);
        }

        // GET: HAIR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAIR hAIR = db.HAIR.Find(id);
            if (hAIR == null)
            {
                return HttpNotFound();
            }
            return View(hAIR);
        }

        // POST: HAIR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HAIR hAIR = db.HAIR.Find(id);
            db.HAIR.Remove(hAIR);
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
