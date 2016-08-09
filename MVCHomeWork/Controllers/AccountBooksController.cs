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
        private readonly MoneyBookService _moneyBookSvc;

        public AccountBooksController()
        {
            _moneyBookSvc = new MoneyBookService();
        }   
        // GET: AccountBooks
        public ActionResult MoneyBookList()
        {
            var viewTemp = _moneyBookSvc.Lookup();
            var viewList = new List<MoneyBook> { };
            foreach (var item in viewTemp)
            {
                MoneyBook tempItem = new MoneyBook
                {
                    UseMoneyType = (item.Categoryyy == 0) ? "支出" : "收入",
                    Money = item.Amounttt,
                    Date = item.Dateee.ToString("yyyy-MM-dd")
                };
                viewList.Add(tempItem);
            }
            ViewData.Model = viewList;
            return View();
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
                _moneyBookSvc.Add(accountBook);
                _moneyBookSvc.Save();
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
            AccountBook accountBook = _moneyBookSvc.GetSingle(id.Value);
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
            var oldData = _moneyBookSvc.GetSingle(accountBook.Id);
            if (ModelState.IsValid)
            {
                _moneyBookSvc.Edit(accountBook, oldData);
                _moneyBookSvc.Save();
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
            AccountBook accountBook = _moneyBookSvc.GetSingle(id.Value);
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
            AccountBook accountBook = _moneyBookSvc.GetSingle(id);
            _moneyBookSvc.Delete(accountBook);
            _moneyBookSvc.Save();
            return RedirectToAction("Index");
        }
    }
}
