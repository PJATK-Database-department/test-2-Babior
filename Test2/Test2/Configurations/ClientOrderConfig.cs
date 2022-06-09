using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2.Entities;

namespace Test2.Configurations;

public class ClientOrderConfig : IEntityTypeConfiguration<ClientOrder>
{
    public void Configure(EntityTypeBuilder<ClientOrder> builder)
    {
        builder.HasData(
            new ClientOrder
            {
                IdClientOrder = 1,
                OrderDate = DateTime.Now.AddDays(-1),
                CompletionDate = DateTime.Now,
                Comments = "No problems occured",
                ClientIdClient = 1,
                EmployeeIdEmployee = 1
            });
    }
}