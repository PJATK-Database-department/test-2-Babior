using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2.Entities;

namespace Test2.Configurations;

public class ConfectioneryClientOrderConfig : IEntityTypeConfiguration<ConfectioneryClientOrder>
{
    public void Configure(EntityTypeBuilder<ConfectioneryClientOrder> builder)
    {
        builder.HasKey(pm => new {pm.IdClientOrder, pm.IdConfectionery});
    }
}