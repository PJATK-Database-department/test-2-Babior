using Test2.DTOs;
using Test2.Entities;

namespace Test2.Services.Contracts;

public interface IOrdersService
{
    Task<List<OrderDto>> GetOrdersByClient(int idClient);
    Task<IEnumerable<ConfectioneryDto>> GetConfectionaryByOrder(int idOrder);
    
    Task UpdateOrder(OrderRequest orderRequest, int idOrder);
}