﻿using System;
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
    public class CLIENTsController : Controller
    {
        private FinalProjectDBEntities db = new FinalProjectDBEntities();

        // GET: CLIENTs
        public ActionResult Index()
        {
            return View(db.CLIENTs.ToList());
        }

        // GET: CLIENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENT cLIENT = db.CLIENTs.Find(id);
            if (cLIENT == null)
            {
                return HttpNotFound();
            }
            return View(cLIENT);
        }

        // GET: CLIENTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CLIENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDClient,FnameClient,MnameClient,LnameClient,PhoneClient,CelClient,StreetClient,CountyClient,ZipCodeClient,EmailClient,IDUserClient,StateClient")] CLIENT cLIENT)
        {
            //There needs to be a way to get the UserID from the user table for IDUserClient attribute
            //this doesn't have a value for it so you get an error
            if (ModelState.IsValid)
            {
                String email = User.Identity.Name;
                cLIENT.EmailClient = email;
                var query1 = db.AspNetUsers.Where(x => x.UserName == email).First();
                String uID = query1.Id;
                cLIENT.IDUserClient = uID;
                db.CLIENTs.Add(cLIENT);
                db.SaveChanges();

                var query2 = db.CLIENTs.Where(x => x.IDUserClient == uID).First();
                int clientID = query2.IDClient;

                return RedirectToAction("Details", "CLIENTs", new {id = clientID});
            }

            return View(cLIENT);
        }

        // GET: CLIENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENT cLIENT = db.CLIENTs.Find(id);
            if (cLIENT == null)
            {
                return Content("The Client was not found");
            }
            return View(cLIENT);
        }

        // POST: CLIENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDClient,FnameClient,MnameClient,LnameClient,PhoneClient,CelClient,StreetClient,CountyClient,ZipCodeClient,EmailClient,IDUserClient,StateClient")] CLIENT cLIENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "CLIENTs", new { id = cLIENT.IDClient });
            }
            return View(cLIENT);
        }

        // GET: CLIENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENT cLIENT = db.CLIENTs.Find(id);
            if (cLIENT == null)
            {
                return HttpNotFound();
            }
            return View(cLIENT);
        }

        // POST: CLIENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENT cLIENT = db.CLIENTs.Find(id);
            db.CLIENTs.Remove(cLIENT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //the methods below need views
        public ActionResult ViewPastOrder(int id)
        {
            return View();
        }

        public ActionResult ScheduleAppointment(int id)
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
