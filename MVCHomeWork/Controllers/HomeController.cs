using MVCHomeWork.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHomeWork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View("CreateRecord");
        }

        public ActionResult CreateRecord()
        {
            ViewBag.Title = "Crate Record";

            return View();
        }

        public ActionResult MoneyBookList()
        {
            ViewData.Model = new List<MoneyBook> {
                new MoneyBook {  UseMoneyType= "支出",Money=10, Date=DateTime.Now.ToString("yyyy-MM-dd")},
                new MoneyBook {  UseMoneyType= "收入",Money=100, Date=DateTime.Now.AddDays(2).ToString("yyyy-MM-dd")},
                new MoneyBook {  UseMoneyType= "支出",Money=1000, Date=DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")}
            };
            return View();
        }
    }
}
