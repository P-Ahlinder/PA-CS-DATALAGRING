using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA_Course_Submission.Models.Entities;

internal class CaseEntity
{
    [Key]
    [Column (TypeName = "int(10,1)")]
    public int CaseId       { get; set; }
    public DateTime RegDate { get; set; } = DateTime.Now;

    [Column (TypeName = "nvarchar(250)")]
    public string Description   { get; set; }     = null!;
    [Column(TypeName = "nvarchar(10)")]
    public string Status_Ongoing   { get; set; } = null!;
    [Column(TypeName = "nvarchar(10)")]
    public string Status_Unsolved { get; set; }  = null!;
    [Column(TypeName = "nvarchar(10)")]
    public string Status_Solved { get; set; }    = null!;

    [Column(TypeName = "nvarchar(150)")]
    public string? Comment { get; set; }

}


