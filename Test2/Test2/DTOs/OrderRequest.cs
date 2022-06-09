using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test2.Entities;

namespace Test2.DTOs;

public class OrderRequest
{
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? OrderDate { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? CompletionDate { get; set; }

    public string Comments { get; set; }
    
    public int ClientIdClient { get; set; }
    
    public int EmployeeIdEmployee { get; set; }

    public List<int> Confectioneries { get; set; }
}