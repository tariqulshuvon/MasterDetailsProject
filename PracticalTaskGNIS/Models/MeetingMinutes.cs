using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTaskGNIS.Models;

[Table(name: "Meeting_Minutes_Details_Tbl")]
[Display(Name ="Meeting Minutes")]
public class MeetingMinutes
{
    public int Id { get; set; }

    [Display(Name ="Date")]
    public DateTimeOffset StartDate { get; set; } = DateTimeOffset.Now;

    [Display(Name ="Meeting Place")]
    public string MeetingPlace { get; set; } = string.Empty;
}
