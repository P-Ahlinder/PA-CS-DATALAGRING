namespace PA_Course_Submission.Models;

internal class AddCase
{
    public string   Title       { get; set; } = null!;
    public string   Description { get; set; } = null!;
    public int      CustomerId  { get; set; }
    public string   Status      { get; set; } = "Ej påbörjad";

    public DateTime DateAdded   { get; set; } = DateTime.Now;
}
