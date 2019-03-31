
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PBP_Frontend.Models;
using PBP_Frontend.Service;
using PBP_Frontend.ViewModels;

namespace PBP_Frontend.Controllers
{
    public class ListsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        private ListService listService;

        public ListsController()
        {
            listService = new ListService(db);
        }

        // GET: Lists
        public ActionResult Index()
        {
            return View(db.Lists.ToList());
        }

        // GET: Lists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = db.Lists.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // GET: Lists/ChooseProducts
        public ActionResult ChooseProducts()
        {
            ProductToChooseService productToChooseService = new ProductToChooseService(db);
            ChooseProductsViewModel cp = new ChooseProductsViewModel
            {
                ProductsToChoose = productToChooseService.GetProductsToChoose()
            };
            return View(cp);
        }

        // POST: Lists/ChooseProducts
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChooseProducts(ChooseProductsViewModel cp)
        {
            List<ProductToChoose> chosenProducts = cp.ProductsToChoose?.Where(item => item.Chosen == true).ToList();
            if (chosenProducts?.Count() > 0)
            {
                ListViewModel lvm = new ListViewModel { ProductsChosen = new List<ProductChosen>() };
                foreach(var cpr in chosenProducts)
                {
                    lvm.ProductsChosen.Add(new ProductChosen
                    {
                        ProductId = cpr.ProductId,
                        ProductName = cpr.ProductName
                    });
                }
                TempData["chosenProducts"] = lvm;
                return RedirectToAction("CreateList");
            }
            else
            {
                ModelState.AddModelError("", "Selecione, ao menos, um produto.");
            }
            return View(cp);
        }

        // GET: Lists/CreateList
        public ActionResult CreateList()
        {
            if (TempData["chosenProducts"] == null)
            {
                return RedirectToAction("ChooseProducts");
            }
            return View(TempData["chosenProducts"] as ListViewModel);
        }

        // POST: Lists/CreateList
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateList(ListViewModel productsViewmodel)
        {
            if (ModelState.IsValid)
            {
                List<string> errors = listService.PreInsertList(productsViewmodel);
                if (errors.Count == 0)
                {
                    return RedirectToAction("Index");
                }
                errors.ForEach(message => ModelState.AddModelError("", message));
            }
            return View(productsViewmodel);
        }

        // GET: Lists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = db.Lists.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: Lists/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListId,Name,Requester")] List list)
        {
            if (ModelState.IsValid)
            {
                db.Entry(list).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(list);
        }

        // GET: Lists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = db.Lists.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: Lists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List list = db.Lists.Find(id);
            db.Lists.Remove(list);
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
