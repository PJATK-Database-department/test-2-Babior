using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.DTOs;
using Test2.Entities;
using Test2.Exceptions;
using Test2.Extensions;
using Test2.Services.Contracts;

namespace Test2.Services;

public class OrdersService : IOrdersService
{
    private readonly ApplicationDbContext _context;

    public OrdersService(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<List<OrderDto>> GetOrdersByClient(int idClient)
    {
        
        var orders = await _context.ClientOrders
            .Include(clientOrder => clientOrder.Client)
            .Include(clientOrder => clientOrder.Employee)
            .Where(d => d.Client.IdClient == idClient)
            .ToListAsync();
        if (orders == null)
        {
            throw new EntityNotFoundException(nameof(ClientOrder), idClient);
        }

        var list = new List<OrderDto>();

        foreach (var order in orders)
        {
            var conf = GetConfectionaryByOrder(order.IdClientOrder).Result;
            list.Add(new OrderDto
            {
                Confectioneries = conf,
                TotalAmount = GetTotalAmountForOrder(conf)
            });
        }
        
        return list;
    }

    public async Task<IEnumerable<ConfectioneryDto>> GetConfectionaryByOrder(int idOrder)
    {
        var confectionaries = await 
            (from co in _context.ClientOrders
                from cco in _context.ConfectioneryClientOrders
                    .Where(x => x.IdClientOrder == co.IdClientOrder)
                    .DefaultIfEmpty()
                from c in _context.Confectioneries
                    .Where(m => m.IdConfectionery == cco.IdConfectionery)
                    .DefaultIfEmpty()
                select c).ToListAsync();
        
        return confectionaries.ConvertToDtos();
    }

    private decimal GetTotalAmountForOrder(IEnumerable<ConfectioneryDto> confectioneries)
    {
        decimal sum = 0;
        foreach (var conf in confectioneries)
        {
            sum += conf.PricePerOne;
        }

        return sum;
    }
    
    public async Task UpdateOrder(OrderRequest orderRequest, int idOrder)
    {
        await using var context = new ApplicationDbContext();
        var clientOrder = await context.ClientOrders.FirstOrDefaultAsync(d => d.IdClientOrder == idOrder);
        if (clientOrder == null)
        {
            throw new EntityNotFoundException(nameof(ClientOrder), idOrder);
        }

        clientOrder.Client.IdClient = orderRequest.ClientIdClient;
        clientOrder.Employee.IdEmployee = orderRequest.EmployeeIdEmployee;
        clientOrder.Comments = orderRequest.Comments;
        clientOrder.OrderDate = orderRequest.OrderDate;
        clientOrder.CompletionDate = orderRequest.CompletionDate;
        
        var confectionaries = _context.Confectioneries.Where(r => orderRequest.Confectioneries.Contains(r.IdConfectionery));


        var confclorders = _context.ConfectioneryClientOrders.Where(c => orderRequest.Confectioneries.Contains(c.IdConfectionery));
        
        
        
        await context.SaveChangesAsync();
    }
    
    
}