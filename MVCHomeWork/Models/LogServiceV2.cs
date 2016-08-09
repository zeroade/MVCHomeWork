using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ServiceLab.Models;
using ServiceLab.Repositories;

namespace ServiceLab.Service
{

    public class LogService : Repository<Log>
    {
        private readonly IRepository<Log> _logRep;

        public LogService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _logRep = new Repository<Log>(unitOfWork);
        }

        public void Add(string firstName, string lastName, string email, Guid orderId)
        {
            _logRep.Create(new Log
            {
                Name = firstName + lastName,
                Email = email,
                OrderId = orderId
            });
        }

        public void Save()
        {
            _logRep.Commit();
        }
    }
}