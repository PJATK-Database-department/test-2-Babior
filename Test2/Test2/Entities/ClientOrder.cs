using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Entities;

public class ClientOrder
{
    [Key]
    public int IdClientOrder { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? OrderDate { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? CompletionDate { get; set; }

    public string Comments { get; set; }

    [ForeignKey("Client")] 
    public int ClientIdClient { get; set; }
    public virtual Client Client { get; set; } = null!;
    
    [ForeignKey("Employee")] 
    public int EmployeeIdEmployee { get; set; }
    public virtual Employee Employee { get; set; } = null!;
}