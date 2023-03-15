namespace PA_Course_Submission.Models;

internal class Case
{
        public int Id               { get; set; }
        public string Title         { get; set; } = null!;
        public string Description   { get; set; } = null!;
        public string Status        { get; set; } = null!;
        public string? Comment      { get; set; } = "Unhandled";
        public int CustomerId       { get; set; } 
}
