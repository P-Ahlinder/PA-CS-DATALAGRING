namespace PA_Course_Submission.Models;

internal class Case
{
        public int      Id            { get; set; }
        public string   Title         { get; set; } = null!;
        public string   Description   { get; set; } = null!;
        public int      CustomerId    { get; set; }
        public string?  FirstName     { get; set; } = null!;
        public string?  LastName      { get; set; } = null!;
        public string   Status        { get; set; } = "Ej påbörjad";

}
