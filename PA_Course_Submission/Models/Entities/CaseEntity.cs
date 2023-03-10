using System.ComponentModel.DataAnnotations;

namespace PA_Course_Submission.Models.Entities;

internal class CaseEntity
{
    [Key]
    public Guid CaseId          { get; set; }
    public DateTime RegDate     { get; set; }
    [Required]
    public string Description   { get; set; } = null!;
    public string Status        { get; set; } = null!;

}


