namespace PA_Course_Submission.Models;

internal class Customer
{
    public int Id               { get; set; }
    public string FirstName     { get; set; } = null!;
    public string LastName      { get; set; } = null!;
    public string Email         { get; set; } = null!;
    public string? PhoneNumber  { get; set; }

    public Case CaseId          { get; set; } = new Case();
    public string Description   { get; set; } = null!;
    
}
