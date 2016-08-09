using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ServiceLab.Models;
using ServiceLab.Repositories;
using ServiceLab.ViewModel;

namespace ServiceLab.Service
{
    public class OrderService : Repository<Order>
    {
        private readonly IRepository<Order> _orderRep;
        private readonly IRepository<Members> _membersRep;

        public OrderService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _orderRep = new Repository<Order>(unitOfWork);
            _membersRep = new Repository<Members>(unitOfWork);
        }

        public IEnumerable<OrderViewModel> Lookup()
        {
            var source = _orderRep.LookupAll();
            var result = source.Select(order => new OrderViewModel()
            {
                Id = order.Id,
                Email = order.Email,
                FirstName = order.FirstName,
                LastName = order.LastName,
                CreateTime = order.CreateTime,
                Phone = order.Phone
            }).ToList();
            return result;
        }


        public void Add(OrderViewModel order)
        {
            var result = new Order()
            {
                Id = order.Id,
                Email = order.Email,
                FirstName = order.FirstName,
                LastName = order.LastName,
                CreateTime = order.CreateTime,
                Phone = order.Phone
            };
            Add(result);
        }

        public void Add(Order order)
        {

            order.CreateTime = DateTime.Now;
            _orderRep.Create(order);
            var isMember = _membersRep.Query(d => d.Account == order.Email).Any();
            if (isMember == false)
            {
                var newMember = new Members()
                {
                    Id = Guid.NewGuid(),
                    Account = order.Email,
                    Password = Guid.NewGuid().ToString()
                };
                _membersRep.Create(newMember);
            }
        }

        public void Save()
        {
            _orderRep.Commit();
        }
    }
}