﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProjectv3.Models;
using Microsoft.AspNet.Identity;

namespace FinalProjectv3.Controllers
{
    public class APPOINTMENTsController : Controller
    {
        private FinalProjectDBEntities db = new FinalProjectDBEntities();

        // GET: APPOINTMENTs
        public ActionResult Index()
        {
            var aPPOINTMENTs = db.APPOINTMENTs.Include(a => a.CLIENT).Include(a => a.STYLE);
            return View(aPPOINTMENTs.ToList());
        }

        // GET: APPOINTMENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPOINTMENT aPPOINTMENT = db.APPOINTMENTs.Find(id);
            if (aPPOINTMENT == null)
            {
                return HttpNotFound();
            }
            return View(aPPOINTMENT);
        }
        //******************************************************

        //****************************************************
        
        public ActionResult DetailClientAppoint()
        {

            //Dim user_id = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();

            //var CurClientUserId = db.AspNetUsers.Where(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault().Id;

            string email = User.Identity.Name;

            var CurClientId = db.CLIENTs.Where(z => z.EmailClient.Equals(email)).First();//.Select(u => u.IDClient);

            int idc = CurClientId.IDClient;

           // var userAppointments = from cli in db.APPOINTMENTs.Include("APPOINTMENT")
                         //          where cli.IDClientAppoint.Equals(idc)
                            //       select cli.CLIENT;


            ViewBag["UserAppointments"] = CurClientId.IDClient;
            return View();

        }
    
        //***************************************************************

        // GET: APPOINTMENTs/Create
        public ActionResult Create()
        {

            ViewBag.IDClientAppoint = new SelectList(db.CLIENTs, "IDClient", "FnameClient");
            ViewBag.IDStypeAppoint = new SelectList(db.STYLEs, "IDStyle", "DesigStyle");
            return View();
        }

  

        // POST: APPOINTMENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAppoint,IDClientAppoint,IDStypeAppoint,DateAppoint,AddTakeOffAppoint,BeginnTimeAppoint")] APPOINTMENT aPPOINTMENT)
        {
            if (ModelState.IsValid)
            {
                db.APPOINTMENTs.Add(aPPOINTMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDClientAppoint = new SelectList(db.CLIENTs, "IDClient", "FnameClient", aPPOINTMENT.IDClientAppoint);
            ViewBag.IDStypeAppoint = new SelectList(db.STYLEs, "IDStyle", "DesigStyle", aPPOINTMENT.IDStypeAppoint);
            return View(aPPOINTMENT);
        }


        //*******************************************Client Appointment******************************************
        
        // GET: APPOINTMENTs/Create Client Appointment
        public ActionResult CreateClientAppoint()
        {
         
            ViewBag.IDClientAppoint = new SelectList(db.CLIENTs, "IDClient", "FnameClient");
            ViewBag.IDStypeAppoint = new SelectList(db.STYLEs, "IDStyle", "DesigStyle");
            return View();
        }
        
        //*************************************************************************************************************

        // POST: APPOINTMENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClientAppoint([Bind(Include = "IDAppoint,IDClientAppoint,IDStypeAppoint,DateAppoint,AddTakeOffAppoint,BeginnTimeAppoint")] APPOINTMENT aPPOINTMENT)
        {
            string email = User.Identity.Name;

            var CurClientId = db.CLIENTs.Where(z => z.EmailClient.Equals(email)).First();//.Select(u => u.IDClient);

            int idc = CurClientId.IDClient;

            aPPOINTMENT.IDClientAppoint = idc;

            if (ModelState.IsValid)
            {
                db.APPOINTMENTs.Add(aPPOINTMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDClientAppoint = new SelectList(db.CLIENTs, "IDClient", "FnameClient", aPPOINTMENT.IDClientAppoint);
            ViewBag.IDStypeAppoint = new SelectList(db.STYLEs, "IDStyle", "DesigStyle", aPPOINTMENT.IDStypeAppoint);
            return View(aPPOINTMENT);
        }
        // GET: APPOINTMENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPOINTMENT aPPOINTMENT = db.APPOINTMENTs.Find(id);
            if (aPPOINTMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDClientAppoint = new SelectList(db.CLIENTs, "IDClient", "FnameClient", aPPOINTMENT.IDClientAppoint);
            ViewBag.IDStypeAppoint = new SelectList(db.STYLEs, "IDStyle", "DesigStyle", aPPOINTMENT.IDStypeAppoint);
            return View(aPPOINTMENT);
        }

        // POST: APPOINTMENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAppoint,IDClientAppoint,IDStypeAppoint,DateAppoint,AddTakeOffAppoint,BeginnTimeAppoint")] APPOINTMENT aPPOINTMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPPOINTMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDClientAppoint = new SelectList(db.CLIENTs, "IDClient", "FnameClient", aPPOINTMENT.IDClientAppoint);
            ViewBag.IDStypeAppoint = new SelectList(db.STYLEs, "IDStyle", "DesigStyle", aPPOINTMENT.IDStypeAppoint);
            return View(aPPOINTMENT);
        }

        // GET: APPOINTMENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPOINTMENT aPPOINTMENT = db.APPOINTMENTs.Find(id);
            if (aPPOINTMENT == null)
            {
                return HttpNotFound();
            }
            return View(aPPOINTMENT);
        }

        // POST: APPOINTMENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            APPOINTMENT aPPOINTMENT = db.APPOINTMENTs.Find(id);
            db.APPOINTMENTs.Remove(aPPOINTMENT);
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
