using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class CategoryModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CategoryModels
        public ActionResult Index()
        {
            
            return View(db.categoryModels.ToList());
        }

        // GET: CategoryModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryModels categoryModels = db.categoryModels.Find(id);
            if (categoryModels == null)
            {
                return HttpNotFound();
            }
            return View(categoryModels);
        }

        // GET: CategoryModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] CategoryModels categoryModels)
        {
            if (ModelState.IsValid)
            {
                db.categoryModels.Add(categoryModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryModels);
        }

        // GET: CategoryModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryModels categoryModels = db.categoryModels.Find(id);
            if (categoryModels == null)
            {
                return HttpNotFound();
            }
            return View(categoryModels);
        }

        // POST: CategoryModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] CategoryModels categoryModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryModels);
        }

        // GET: CategoryModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryModels categoryModels = db.categoryModels.Find(id);
            if (categoryModels == null)
            {
                return HttpNotFound();
            }
            return View(categoryModels);
        }

        // POST: CategoryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryModels categoryModels = db.categoryModels.Find(id);
            db.categoryModels.Remove(categoryModels);
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
