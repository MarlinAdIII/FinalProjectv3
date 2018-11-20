using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _540FinalProject.Models;

namespace _540FinalProject.Controllers
{
    public class COMPANiesController : Controller
    {
        private FinalProjectDBEntities db = new FinalProjectDBEntities();

        // GET: COMPANies
        public ActionResult Index()
        {
            return View(db.COMPANies.ToList());
        }

        // GET: COMPANies/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPANY cOMPANY = db.COMPANies.Find(id);
            if (cOMPANY == null)
            {
                return HttpNotFound();
            }
            return View(cOMPANY);
        }

        // GET: COMPANies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: COMPANies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDComp,TitleComp,PhoneOffice,PhoneOwner,StreetComp,CountyComp,ZipcodeComp,EmailComp,WebsiteComp,PartPayeBraid,IDOwnerBraider,CostHairDeduct,PercentBrader,PriceTakeOff")] COMPANY cOMPANY)
        {
            if (ModelState.IsValid)
            {
                db.COMPANies.Add(cOMPANY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cOMPANY);
        }

        // GET: COMPANies/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPANY cOMPANY = db.COMPANies.Find(id);
            if (cOMPANY == null)
            {
                return HttpNotFound();
            }
            return View(cOMPANY);
        }

        // POST: COMPANies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDComp,TitleComp,PhoneOffice,PhoneOwner,StreetComp,CountyComp,ZipcodeComp,EmailComp,WebsiteComp,PartPayeBraid,IDOwnerBraider,CostHairDeduct,PercentBrader,PriceTakeOff")] COMPANY cOMPANY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPANY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cOMPANY);
        }

        // GET: COMPANies/Delete/5
        /*public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPANY cOMPANY = db.COMPANies.Find(id);
            if (cOMPANY == null)
            {
                return HttpNotFound();
            }
            return View(cOMPANY);
        }

        // POST: COMPANies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            COMPANY cOMPANY = db.COMPANies.Find(id);
            db.COMPANies.Remove(cOMPANY);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/
        
        //the methods below need views
        public ActionResult Discount()
        {
            return View();
        }

        public ActionResult CreateBraider(int id)
        {
            //the create view for the braider needs to be linked here
            return View();
        }

        public ActionResult AddDeleteProducts()
        {
            return View();
        }

        public ActionResult PayBraider()
        {
            return View();
        }

        public ActionResult ViewAppointments()
        {
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
