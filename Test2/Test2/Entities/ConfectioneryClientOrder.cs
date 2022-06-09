using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Entities;

public class ConfectioneryClientOrder
{
    [ForeignKey("IdClientOrder")]
    public int IdClientOrder { get; set; }
    [ForeignKey("IdConfectionery")]
    public int IdConfectionery { get; set; }
    public int Amount { get; set; }
    public string Comments { get; set; }
}