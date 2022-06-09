using Test2.Entities;

namespace Test2.DTOs;

public class OrderDto
{
    public IEnumerable<ConfectioneryDto> Confectioneries { get; set; }
    public decimal TotalAmount { get; set; }
}