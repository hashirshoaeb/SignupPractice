﻿using System;
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

        // GET: Identities
        public ActionResult Index()
        {
            //return View("Create");
            return View(db.Identies.ToList());
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
            return View(identity);
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
                return RedirectToAction("Index");
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
            return View(identity);
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
                return RedirectToAction("Index");
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
            return View(identity);
        }

        // POST: Identities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Identity identity = db.Identies.Find(id);
            db.Identies.Remove(identity);
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "email,password")] Identity identity)
        {
            if(db.identitycheck(identity.email, identity.password))
            {
                ViewBag.Message = "login successfull";
                return View();
            }
            ViewBag.Message = "login failed";
            return View();
            // sql query [SELECT ID FROM DATBASE THIS TABLE THIS WHERE EMAIL = IDENTITY.EMAIL AND PASSWORD = IDENTITY.PASSWORD]
            // check if email and password saved in identity parameter == to email and password in bd.identity
            // get index(ID) // Identity identity = db.Identies.Find(id);
            // build profile using that data.n
        }
    }
}