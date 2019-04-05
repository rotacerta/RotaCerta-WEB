using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PBP_Frontend.Models;

namespace PBP_Frontend.Controllers
{
   [Authorize]
   public class ChangeLogsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: ChangeLogs
        public ActionResult Index()
        {
            var changeLogs = db.ChangeLogs.Include(c => c.List).Include(c => c.ListStatus);
            return View(changeLogs.ToList());
        }

        // GET: ChangeLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeLog changeLog = db.ChangeLogs.Find(id);
            if (changeLog == null)
            {
                return HttpNotFound();
            }
            return View(changeLog);
        }

        // GET: ChangeLogs/Create
        public ActionResult Create()
        {
            ViewBag.ListId = new SelectList(db.Lists, "ListId", "Name");
            ViewBag.ListStatusId = new SelectList(db.ListStatus, "ListStatusId", "Status");
            return View();
        }

        // POST: ChangeLogs/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChangeLogId,Date,ListId,ListStatusId")] ChangeLog changeLog)
        {
            if (ModelState.IsValid)
            {
                db.ChangeLogs.Add(changeLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListId = new SelectList(db.Lists, "ListId", "Name", changeLog.ListId);
            ViewBag.ListStatusId = new SelectList(db.ListStatus, "ListStatusId", "Status", changeLog.ListStatusId);
            return View(changeLog);
        }

        // GET: ChangeLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeLog changeLog = db.ChangeLogs.Find(id);
            if (changeLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListId = new SelectList(db.Lists, "ListId", "Name", changeLog.ListId);
            ViewBag.ListStatusId = new SelectList(db.ListStatus, "ListStatusId", "Status", changeLog.ListStatusId);
            return View(changeLog);
        }

        // POST: ChangeLogs/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChangeLogId,Date,ListId,ListStatusId")] ChangeLog changeLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(changeLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListId = new SelectList(db.Lists, "ListId", "Name", changeLog.ListId);
            ViewBag.ListStatusId = new SelectList(db.ListStatus, "ListStatusId", "Status", changeLog.ListStatusId);
            return View(changeLog);
        }

        // GET: ChangeLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeLog changeLog = db.ChangeLogs.Find(id);
            if (changeLog == null)
            {
                return HttpNotFound();
            }
            return View(changeLog);
        }

        // POST: ChangeLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChangeLog changeLog = db.ChangeLogs.Find(id);
            db.ChangeLogs.Remove(changeLog);
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
