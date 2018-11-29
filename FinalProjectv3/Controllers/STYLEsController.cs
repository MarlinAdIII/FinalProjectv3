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
    public class STYLEsController : Controller
    {
        private FinalProjectDBEntities db = new FinalProjectDBEntities();

        // GET: STYLEs
        public ActionResult Index()
        {
            return View(db.STYLEs.ToList());
        }

        //GET: Hairstyle
        public ActionResult Hairstyle()
        {
            return View(db.STYLEs.ToList());
        }


        //GET: Pricing
        public ActionResult Pricing()
        {
            return View(db.STYLEs.ToList());
        }

        // GET: STYLEs/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STYLE sTYLE = db.STYLEs.Find(id);
            if (sTYLE == null)
            {
                return HttpNotFound();
            }
            return View(sTYLE);
        }

        // GET: STYLEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: STYLEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDStyle,DesigStyle,DescriptStyle,HairProvStyle,PriceStyle,PriceExtrat,PictureStyle")] STYLE sTYLE)
        {
            if (ModelState.IsValid)
            {
                db.STYLEs.Add(sTYLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTYLE);
        }

        // GET: STYLEs/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STYLE sTYLE = db.STYLEs.Find(id);
            if (sTYLE == null)
            {
                return HttpNotFound();
            }
            return View(sTYLE);
        }

        // POST: STYLEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDStyle,DesigStyle,DescriptStyle,HairProvStyle,PriceStyle,PriceExtrat,PictureStyle")] STYLE sTYLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTYLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTYLE);
        }

        // GET: STYLEs/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STYLE sTYLE = db.STYLEs.Find(id);
            if (sTYLE == null)
            {
                return HttpNotFound();
            }
            return View(sTYLE);
        }

        // POST: STYLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            STYLE sTYLE = db.STYLEs.Find(id);
            db.STYLEs.Remove(sTYLE);
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
