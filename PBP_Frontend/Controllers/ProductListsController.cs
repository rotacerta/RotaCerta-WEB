using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PBP_Frontend.Models;

namespace PBP_Frontend.Controllers
{
    [Authorize]
    [OutputCache(NoStore = false, Duration = 0)]
    public class ProductListsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: ProductLists
        public ActionResult Index()
        {
            var productLists = db.ProductLists.Include(p => p.List).Include(p => p.Product);
            return View(productLists.ToList());
        }

        // GET: ProductLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductList productList = db.ProductLists.Find(id);
            if (productList == null)
            {
                return HttpNotFound();
            }
            return View(productList);
        }

        // GET: ProductLists/Create
        public ActionResult Create()
        {
            ViewBag.ListId = new SelectList(db.Lists, "ListId", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            return View();
        }

        // POST: ProductLists/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductListId,QuantityCatched,RequiredQuantity,ListId,ProductId")] ProductList productList)
        {
            if (ModelState.IsValid)
            {
                db.ProductLists.Add(productList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListId = new SelectList(db.Lists, "ListId", "Name", productList.ListId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", productList.ProductId);
            return View(productList);
        }

        // GET: ProductLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductList productList = db.ProductLists.Find(id);
            if (productList == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListId = new SelectList(db.Lists, "ListId", "Name", productList.ListId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", productList.ProductId);
            return View(productList);
        }

        // POST: ProductLists/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductListId,QuantityCatched,RequiredQuantity,ListId,ProductId")] ProductList productList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListId = new SelectList(db.Lists, "ListId", "Name", productList.ListId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", productList.ProductId);
            return View(productList);
        }

        // GET: ProductLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductList productList = db.ProductLists.Find(id);
            if (productList == null)
            {
                return HttpNotFound();
            }
            return View(productList);
        }

        // POST: ProductLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductList productList = db.ProductLists.Find(id);
            db.ProductLists.Remove(productList);
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
