using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTaskGNIS.Models;
[Table(name: "CorporateOrIndividual")]
[Display(Name ="Corporate or Individual")]
public class CorporateOrIndividual
{
    public long Id { get; set; }
    public string CorporateOrIndividualCustomer { get; set; } = string.Empty;

}
