namespace PA_Course_Submission.Models;

internal class Case
{
        public int CaseId           { get; set; }
        public DateTime RegDate     { get; set; } = DateTime.Now;
        public string Description   { get; set; } = null!;
        public string Status        { get; set; } = null!;
        public string? Comment      { get; set; }
}
