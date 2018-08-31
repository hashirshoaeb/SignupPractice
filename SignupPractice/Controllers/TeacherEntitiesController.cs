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
    public class TeacherEntitiesController : Controller
    {
        private TeacherEntityDBContext db = new TeacherEntityDBContext();

        // GET: TeacherEntities
        public ActionResult Index()
        {
            return View(db.teacherEntities.ToList());
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
            return View(teacherEntity);
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
                return RedirectToAction("Index");
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
            return View(teacherEntity);
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
                return RedirectToAction("Index");
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
            return View(teacherEntity);
        }

        // POST: TeacherEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherEntity teacherEntity = db.teacherEntities.Find(id);
            db.teacherEntities.Remove(teacherEntity);
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
        public ActionResult Login([Bind(Include = "email,password")] TeacherEntity teacherEntity)
        {
            int? myidentity; TeacherEntity validIdentity = null;
            if (null == (myidentity = db.identitycheck(teacherEntity.email, teacherEntity.password, out validIdentity)))
            {
                ViewBag.Message = "login failed";
                return View();
            }
            //ViewBag.Message = myidentity + "login successfull";
            //authorized_user_id = myidentity;
            return RedirectToAction("Index", new { id = myidentity });
        }
    }
}
