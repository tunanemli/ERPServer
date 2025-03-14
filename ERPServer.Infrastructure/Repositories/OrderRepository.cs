﻿using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using ERPServer.Infrastructure.Context;
using GenericRepository;

namespace ERPServer.Infrastructure.Repositories
{
    internal sealed class OrderRepository : Repository<Order, ApplicationDbContext>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
