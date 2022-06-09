using System.ComponentModel.DataAnnotations;

namespace Test2.Entities;

public class Employee
{
    [Key]
    public int IdEmployee { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }
}