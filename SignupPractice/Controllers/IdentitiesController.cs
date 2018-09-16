using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SignupPractice.Models;

namespace SignupPractice.Controllers
{
    public class IdentitiesController : Controller
    {
        private IdentityDBContext db = new IdentityDBContext();
        private static int? authorized_user_id = null;
        // GET: Identities
        public ActionResult Index(int? id )/*TODO: int? id*/ //done
        {
            if (id == null)
                return HttpNotFound();
            else if (authorized_user_id != id) // TODO: Login validation required... //done
                return RedirectToAction("Login");
            else
            {
                ViewBag.Authentication = true;
                return View(db.Identies.Find(id));/*TODO: pass identity*/ //done
            }    
        }

        // GET: Identities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identity identity = db.Identies.Find(id);
            if (identity == null)
            {
                return HttpNotFound();
            }
            else if (authorized_user_id == id)
                return View(identity); // TODO: Login validation required... // done
            else
                return RedirectToAction("Login");
        }

        // GET: Identities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Identities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstname,lastname,email,password,phone")] Identity identity)
        {
            if (ModelState.IsValid)
            {
                db.Identies.Add(identity);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = identity.id });
            }

            return View(identity);
        }

        // GET: Identities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identity identity = db.Identies.Find(id);
            if (identity == null)
            {
                return HttpNotFound();
            }
            else if (authorized_user_id == id)
                return View(identity); // TODO: Login validation required... //done
            else
                return RedirectToAction("Login");
        }

        // POST: Identities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,firstname,lastname,email,password,phone")] Identity identity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(identity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = identity.id });
            }
            return View(identity);
        }

        // GET: Identities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identity identity = db.Identies.Find(id);
            if (identity == null)
            {
                return HttpNotFound();
            }
            else if (authorized_user_id == id)
                return View(identity); // TODO: Login validation required... //done
            else
                return RedirectToAction("Login");
        }

        // POST: Identities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Identity identity = db.Identies.Find(id);
            db.Identies.Remove(identity);
            db.SaveChanges();
            return RedirectToAction("Index", "Home"); //TODO: change //done
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "email,password")] Identity identity)
        {
            int? myidentity; Identity validIdentity = null;
            if(null == (myidentity = db.identitycheck(identity.email, identity.password, out validIdentity)))
            {
                ViewBag.Message = "login failed"; 
                return View();
            }
            //ViewBag.Message = myidentity + "login successfull";
            authorized_user_id = myidentity;
            return RedirectToAction("Index", new { id = myidentity });
        }
        public ActionResult Logout()
        {
            authorized_user_id = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
