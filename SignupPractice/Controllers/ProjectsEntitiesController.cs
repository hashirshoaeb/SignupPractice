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
    public class ProjectsEntitiesController : Controller
    {
        private ProjectsEntityDBContext db = new ProjectsEntityDBContext();

        // GET: ProjectsEntities
        public ActionResult Index()
        {
            return View(db.projectsEntities.ToList());
        }

        // GET: ProjectsEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsEntity projectsEntity = db.projectsEntities.Find(id);
            if (projectsEntity == null)
            {
                return HttpNotFound();
            }
            return View(projectsEntity);
        }

        // GET: ProjectsEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectsEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,field,dateofcreation,deadline,teacher_id,progress")] ProjectsEntity projectsEntity)
        {
            if (ModelState.IsValid)
            {
                db.projectsEntities.Add(projectsEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectsEntity);
        }

        // GET: ProjectsEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsEntity projectsEntity = db.projectsEntities.Find(id);
            if (projectsEntity == null)
            {
                return HttpNotFound();
            }
            return View(projectsEntity);
        }

        // POST: ProjectsEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,field,dateofcreation,deadline,teacher_id,progress")] ProjectsEntity projectsEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectsEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectsEntity);
        }

        // GET: ProjectsEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsEntity projectsEntity = db.projectsEntities.Find(id);
            if (projectsEntity == null)
            {
                return HttpNotFound();
            }
            return View(projectsEntity);
        }

        // POST: ProjectsEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectsEntity projectsEntity = db.projectsEntities.Find(id);
            db.projectsEntities.Remove(projectsEntity);
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
