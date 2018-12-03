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

        public ActionResult SelectStyles()
        {

            StyleList sList = new StyleList();
            sList.Styles = db.STYLEs.ToList();
            return View(db.STYLEs.ToList());
        }

        [HttpPost, ActionName("SelectStyles")]
        public ActionResult CreateSkill(System.Web.Mvc.FormCollection form)
        {
            string braiderEmail = User.Identity.Name;
            var query = db.BRAIDERs.Where(x => x.EmailBraider == braiderEmail).First();
            int braiderID = query.IDBraider;
 /*This is how form works
 *you access the values you want with form["nameOfAttributeInView"]
* form["isSkill"] is a comma separated list string of true or false for each check box
* There is a fourth value and I don't know why, it is always false
* form["item.IDStyle"] is a comma separated list string of integer values for each id
* Separate the string by the commas, parseInt the styleIDs and use them to create Skills      
 */
            for (int i = 0; i <= form["item.IDStyle"].Length; i++)
            {
                char key = form["item.IDStyle"][i];
            }
            /*
            //This is getting a null error
            for (int i = 0; i <sl.Length; i++)
            {
                var testQuery = db.SKILLS.Where(x =>
                    x.IDBraider == braiderID &&
                    x.IDStyle == sl[i].IDStyle);

                if(testQuery.Equals(null))
                {
                    db.SKILLS.Add(new SKILL
                    {
                        IDBraider = braiderID,
                        IDStyle = sl[i].IDStyle
                    });

                    db.SaveChanges();
                }
            }*/

            String email = User.Identity.Name;
            var currentUser = db.BRAIDERs.Where(x => x.EmailBraider == email).First();
            

            return RedirectToAction("Index", "Home");
        }
    }
}
