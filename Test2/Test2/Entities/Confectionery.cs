using System.ComponentModel.DataAnnotations;

namespace Test2.Entities;

public class Confectionery
{
    [Key]
    public int IdConfectionery { get; set; }
    
    public string Name { get; set; }
    
    public float PricePerOne { get; set; }
}