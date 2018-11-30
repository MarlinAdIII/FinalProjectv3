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
    public class BRAIDERsController : Controller
    {
        private FinalProjectDBEntities db = new FinalProjectDBEntities();

        // GET: BRAIDERs
        public ActionResult Index()
        {
            return View(db.BRAIDERs.ToList());
        }

        // GET: BRAIDERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BRAIDER bRAIDER = db.BRAIDERs.Find(id);
            if (bRAIDER == null)
            {
                return HttpNotFound();
            }
            return View(bRAIDER);
        }

        // GET: BRAIDERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BRAIDERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBraider,FnameBraider,MnameBraider,LnameBraider,PhoneBraider,CelBraider,StreetBraider,CountyBraider,ZipCodeBraider,EmailBraider,IDUserBraider")] BRAIDER bRAIDER)
        {
            if (ModelState.IsValid)
            {
                String email = User.Identity.Name;
                bRAIDER.EmailBraider = email;
                var query = db.AspNetUsers.Where(x => x.UserName == email).First();
                String uID = query.Id;
                bRAIDER.IDUserBraider = uID;
                db.BRAIDERs.Add(bRAIDER);
                db.SaveChanges();
                var query2 = db.BRAIDERs.Where(x => x.IDUserBraider == uID).First();
                int clientID = query2.IDBraider;

                return RedirectToAction("Details", "BRAIDERs", new { id = clientID });

            }

            return View(bRAIDER);
        }

        // GET: BRAIDERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BRAIDER bRAIDER = db.BRAIDERs.Find(id);
            if (bRAIDER == null)
            {
                return HttpNotFound();
            }
            return View(bRAIDER);
        }

        // POST: BRAIDERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBraider,FnameBraider,MnameBraider,LnameBraider,PhoneBraider,CelBraider,StreetBraider,CountyBraider,ZipCodeBraider,EmailBraider,IDUserBraider")] BRAIDER bRAIDER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bRAIDER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bRAIDER);
        }

        // GET: BRAIDERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BRAIDER bRAIDER = db.BRAIDERs.Find(id);
            if (bRAIDER == null)
            {
                return HttpNotFound();
            }
            return View(bRAIDER);
        }

        // POST: BRAIDERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BRAIDER bRAIDER = db.BRAIDERs.Find(id);
            db.BRAIDERs.Remove(bRAIDER);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewPaycheck(int id)
        {
            //a view needs to be created to be returned
            return View();
        }
        
        public ActionResult SelectStyles(int id)
        {
            //a view needs to be created to be returned
            return View();
        }

        public ActionResult ViewAppointments(int id)
        {
            //a view needs to be created to be returned
            return View();
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
