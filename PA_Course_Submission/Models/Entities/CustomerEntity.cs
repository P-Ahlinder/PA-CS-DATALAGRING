using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PA_Course_Submission.Models.Entities;

[Index (nameof(Email), IsUnique = true)]
internal class CustomerEntity
{
    [Key]
    public int Id               { get; set; }

    [StringLength(50)]
    public string FirstName     { get; set; } = null!;

    [StringLength(50)]
    public string LastName      { get; set; } = null!;

    [StringLength(50)]
    public string Email         { get; set; } = null!;

    [Column (TypeName = "char(13)")]
    public string? MobilePhone  { get; set; }
    public int CaseId           { get; set; }
    public CaseEntity Case      { get; set; } = null!;
}
