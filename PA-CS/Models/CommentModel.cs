
namespace PA_CS.Models;

internal class CommentModel
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Comment { get; set; } = null!;
}
