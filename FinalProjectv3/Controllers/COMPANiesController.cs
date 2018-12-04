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
    public class COMPANiesController : Controller
    {
        private FinalProjectDBEntities db = new FinalProjectDBEntities();

        // GET: COMPANies
        public ActionResult Index()
        {
            return View(db.COMPANies.ToList());
        }

        // GET: COMPANies/Details/5
        public ActionResult Details(int? id)
        {
            byte ID = (byte)(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPANY cOMPANY = db.COMPANies.Find(ID);
            if (cOMPANY == null)
            {
                return HttpNotFound();
            }
            return View(cOMPANY);
        }

        // GET: COMPANies/Create
        public ActionResult Create()
        {
            ViewBag.IDOwnerBraider = new SelectList(db.BRAIDERs, "IDBraider", "EmailBraider");
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
            ViewBag.IDOwnerBraider = new SelectList(db.BRAIDERs, "IDBraider", "EmailBraider");
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
                //The current admin becomes a braider
                db.Database.ExecuteSqlCommand("UPDATE dbo.AspNetUsers SET Type = 2 WHERE Email = @p0", User.Identity.Name);
                db.Entry(cOMPANY).State = EntityState.Modified;
                db.SaveChanges();

                COMPANY comp = db.COMPANies.First<COMPANY>();
                int? newOwnerID = comp.IDOwnerBraider;
                BRAIDER admin = db.BRAIDERs.Where(b => b.IDBraider == newOwnerID).First();
                
                //The current admin in the database gets admin privliages
                db.Database.ExecuteSqlCommand("UPDATE dbo.AspNetUsers SET Type = 3 WHERE Email = @p0", admin.EmailBraider);
                
                var currentUser = db.AspNetUsers.Where(anu => anu.UserName == User.Identity.Name).First();

                switch(currentUser.Type)
                {
                    case 2:
                        var braider = db.BRAIDERs.Where(x => x.EmailBraider == User.Identity.Name).First();
                        return RedirectToAction("Details", "BRAIDERs", new { id = braider.IDBraider });
                    case 3:
                        return View("Details", "Companies", new {id = 1});
                }
                
                
            }
            return View(cOMPANY);
        }


        public ActionResult AddDeleteProducts()
        {
            return View();
        }

        public ActionResult PayBraider()
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
