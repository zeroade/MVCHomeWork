using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCHomeWork.Models;
using MVCHomeWork.Models.ViewModels;

namespace MVCHomeWork.Controllers
{
    public class AccountBooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AccountBooks
        public ActionResult MoneyBookList()
        {
            var viewTemp = db.AccountBooks.ToList();
            var viewList = new List<MoneyBook> { };
            foreach (var item in viewTemp)
            {
                MoneyBook tempItem = new MoneyBook
                {
                    UseMoneyType = (item.Categoryyy == 0) ? "支出" : "收入",
                    Money = 10,
                    Date = item.Dateee.ToString("yyyy-MM-dd")
                };
                viewList.Add(tempItem);
            }
            ViewData.Model = viewList;
            return View();
        }

        // GET: AccountBooks/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook accountBook = db.AccountBooks.Find(id);
            if (accountBook == null)
            {
                return HttpNotFound();
            }
            return View(accountBook);
        }

        // GET: AccountBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Categoryyy,Amounttt,Dateee,Remarkkk")] AccountBook accountBook)
        {
            if (ModelState.IsValid)
            {
                accountBook.Id = Guid.NewGuid();
                db.AccountBooks.Add(accountBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountBook);
        }

        // GET: AccountBooks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook accountBook = db.AccountBooks.Find(id);
            if (accountBook == null)
            {
                return HttpNotFound();
            }
            return View(accountBook);
        }

        // POST: AccountBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Categoryyy,Amounttt,Dateee,Remarkkk")] AccountBook accountBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountBook);
        }

        // GET: AccountBooks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook accountBook = db.AccountBooks.Find(id);
            if (accountBook == null)
            {
                return HttpNotFound();
            }
            return View(accountBook);
        }

        // POST: AccountBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AccountBook accountBook = db.AccountBooks.Find(id);
            db.AccountBooks.Remove(accountBook);
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
