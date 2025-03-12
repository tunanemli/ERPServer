﻿using ERPServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERPServer.Application.Features.Orders.GetAllOrders
{
    public sealed record GetAllOrdersQuery : IRequest<Result<List<Order>>>;
}
