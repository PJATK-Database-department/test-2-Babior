using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2.Entities;

namespace Test2.Configurations;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasData(
            new Employee {IdEmployee = 1, FirstName = "William", LastName = "Shakespeare"},
            new Employee {IdEmployee = 2, FirstName = "Lizaveta", LastName = "Babior"},
            new Employee {IdEmployee = 3, FirstName = "Iman", LastName = "Sayyadzadeh"}
        );
    }
}