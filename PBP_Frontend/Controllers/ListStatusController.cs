using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PBP_Frontend.Models;

namespace PBP_Frontend.Controllers
{
    public class ListStatusController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: ListStatus
        public ActionResult Index()
        {
            return View(db.ListStatus.ToList());
        }

        // GET: ListStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListStatus listStatus = db.ListStatus.Find(id);
            if (listStatus == null)
            {
                return HttpNotFound();
            }
            return View(listStatus);
        }

        // GET: ListStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListStatus/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListStatusId,Status")] ListStatus listStatus)
        {
            if (ModelState.IsValid)
            {
                db.ListStatus.Add(listStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listStatus);
        }

        // GET: ListStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListStatus listStatus = db.ListStatus.Find(id);
            if (listStatus == null)
            {
                return HttpNotFound();
            }
            return View(listStatus);
        }

        // POST: ListStatus/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListStatusId,Status")] ListStatus listStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listStatus);
        }

        // GET: ListStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListStatus listStatus = db.ListStatus.Find(id);
            if (listStatus == null)
            {
                return HttpNotFound();
            }
            return View(listStatus);
        }

        // POST: ListStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListStatus listStatus = db.ListStatus.Find(id);
            db.ListStatus.Remove(listStatus);
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
