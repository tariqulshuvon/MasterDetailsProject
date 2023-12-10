using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTaskGNIS.Models;

[Table(name: "Individual_Customer_Tbl")]
[Display(Name ="Individual Customer")]
public class IndividualCustomer
{
    public long Id { get; set; }
    [Display(Name ="Customer Name")]
    public string CustomerName { get; set; } = string.Empty;
}
