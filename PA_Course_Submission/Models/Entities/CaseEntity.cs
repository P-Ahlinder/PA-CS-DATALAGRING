using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA_Course_Submission.Models.Entities;

internal class CaseEntity
{
    [Key]
    public int Id               { get; set; }
    public DateTime RegDate         { get; set; } = DateTime.Now;
    public string Title             { get; set; } = null!;
    public string Description       { get; set; } = null!;
    public string Status            { get; set; } = null!;
    public string? Comment          { get; set; }


    public int CustomerID { get; set; }
    public CustomerEntity Customer { get; set; }  = null!;
    

}


