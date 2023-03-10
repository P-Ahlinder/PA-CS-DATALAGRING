using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA_Course_Submission.Models.Entities;

internal class CustomerEntity
{
    [Key]
    public int Id               { get; set; }

    [StringLength(40)] 
    public string FirstName     { get; set; } = null!;

    [StringLength(40)] 
    public string LastName      { get; set; } = null!;

    [StringLength(99)] 
    public string Email         { get; set; } = null!;

    [Column(TypeName = "char(13)")]
    public string? PhoneNumber { get; set; }

    public int CaseId { get; set; }
}
