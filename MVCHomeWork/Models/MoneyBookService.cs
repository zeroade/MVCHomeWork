using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHomeWork.Models
{
    public class MoneyBookService
    {
        private ApplicationDbContext _db;
        public MoneyBookService()
        {
            _db = new ApplicationDbContext();
        }

        public IEnumerable<AccountBook> Lookup()
        {
            return _db.AccountBooks.ToList();
        }

        public AccountBook GetSingle(Guid AccountBookId)
        {
            return _db.AccountBooks.Find(AccountBookId);
        }

        public void Add(AccountBook accountBook)
        {
            accountBook.Dateee = DateTime.Now;
            _db.AccountBooks.Add(accountBook);            
        }

        public void Edit(AccountBook pageData, AccountBook oldData)
        {
            oldData.Amounttt = pageData.Amounttt;
            oldData.Dateee = DateTime.Now;
            oldData.Remarkkk = pageData.Remarkkk;
        }

        public void Delete(AccountBook data)
        {
            _db.AccountBooks.Remove(data);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}