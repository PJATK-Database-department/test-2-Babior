using System.ComponentModel.DataAnnotations;

namespace Test2.Entities;

public class Client
{
    [Key]
    public int IdClient { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}