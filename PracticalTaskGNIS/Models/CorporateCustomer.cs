using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTaskGNIS.Models;

[Table(name: "Corporate_Customer_Tbl")]
[Display(Name ="Corporate Customer")]
public class CorporateCustomer
{
    public long Id { get; set; }
    [Display(Name ="Customer Name")]
    public string CustomerName { get; set; } = string.Empty;
}
