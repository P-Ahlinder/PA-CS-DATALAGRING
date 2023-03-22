using System.ComponentModel.DataAnnotations;

namespace PA_Course_Submission.Models.Entities;

internal class CaseEntity
{
    [Key]
    public int      Id                { get; set; }
    public DateTime RegDate           { get; set; } = DateTime.Now;
    public string   Title             { get; set; } = null!;
    public string   Description       { get; set; } = null!;
    public string   Status            { get; set; } = "Ej påbörjad";


    public int CustomerId             { get; set; }
    public CustomerEntity Customer    { get; set; }  = null!;
    
}


