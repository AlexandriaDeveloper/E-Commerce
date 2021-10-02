using System;
using System.Linq.Expressions;
using Core.Entities.OrderAggregate;

namespace Core.Specification
{
    public class OrderWithItemsAbdIrderingSpecification : BaseSpecification<Order>
    {
        public OrderWithItemsAbdIrderingSpecification(string email) : base(x => x.BuyerEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
            AddOrderByDescending(o => o.OrderDate);
        }

        public OrderWithItemsAbdIrderingSpecification(int id, string email) : base(x => x.Id == id && x.BuyerEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
        }
    }
}