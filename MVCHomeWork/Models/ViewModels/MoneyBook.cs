using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHomeWork.Models.ViewModels
{
    public class MoneyBook
    {
        public string UseMoneyType { get; set; }
        public int Money { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
    }
}