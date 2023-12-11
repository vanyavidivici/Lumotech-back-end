﻿using System.Linq.Dynamic.Core;
using Entities.Models;
using Repository.Extensions.Utility;

namespace Repository.Extensions;

public static class RepositoryOrderExtensions
{
    public static IQueryable<Order> Sort(this IQueryable<Order> orders, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return orders.OrderBy(e => e.OrderDate);
        
        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Order>(orderByQueryString);
        
        if (string.IsNullOrWhiteSpace(orderQuery))
            return orders.OrderBy(e => e.OrderDate);
        
        return orders.OrderBy(orderQuery);
    }
}