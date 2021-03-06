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
    public class TeacherEntitiesController : Controller
    {
        private TeacherEntityDBContext db = new TeacherEntityDBContext();
        private static int? authorized_user_id = null;
        // GET: TeacherEntities
        public ActionResult Index(int? id)
        {
            if (id == null)
                return HttpNotFound();
            else if (authorized_user_id != id) // TODO: Login validation required... //done
                return RedirectToAction("Login");
            else
            {
                ViewBag.Authentication = true;
                return View(db.teacherEntities.Find(id));/*TODO: pass identity*/ //done
            }
            //return View(db.teacherEntities.ToList());
        }

        // GET: TeacherEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherEntity teacherEntity = db.teacherEntities.Find(id);
            if (teacherEntity == null)
            {
                return HttpNotFound();
            } 
            else if (authorized_user_id == id)
                return View(teacherEntity); // TODO: Login validation required... //done
            else
                return RedirectToAction("Login");
        }

        // GET: TeacherEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstname,lastname,designation,email,password,phone")] TeacherEntity teacherEntity)
        {
            if (ModelState.IsValid)
            {
                db.teacherEntities.Add(teacherEntity);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = teacherEntity.id});
            }

            return View(teacherEntity);
        }

        // GET: TeacherEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherEntity teacherEntity = db.teacherEntities.Find(id);
            if (teacherEntity == null)
            {
                return HttpNotFound();
            }
            else if (authorized_user_id == id)
                return View(teacherEntity);  // TODO: Login validation required... //done
            else
                return RedirectToAction("Login"); 
        }

        // POST: TeacherEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,firstname,lastname,designation,email,password,phone")] TeacherEntity teacherEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = teacherEntity.id});
            }
            return View(teacherEntity);
        }

        // GET: TeacherEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherEntity teacherEntity = db.teacherEntities.Find(id);
            if (teacherEntity == null)
            {
                return HttpNotFound();
            }
            else if (authorized_user_id == id)
                return View(teacherEntity);   // TODO: Login validation required... //done
            else
                return RedirectToAction("Login");
        }

        // POST: TeacherEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherEntity teacherEntity = db.teacherEntities.Find(id);
            db.teacherEntities.Remove(teacherEntity);
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
        public ActionResult Login([Bind(Include = "email,password")] TeacherEntity teacherEntity)
        {
            int? myidentity; TeacherEntity validIdentity = null;
            if (null == (myidentity = db.identitycheck(teacherEntity.email, teacherEntity.password, out validIdentity)))
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
