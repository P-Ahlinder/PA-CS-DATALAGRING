using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA_CS.Models.Entities;

internal class CommentEntity
{
    public CommentEntity()
    {
        Id = Guid.NewGuid();
        Created = DateTime.Now;
    }

    public Guid Id          { get; set; }
    public DateTime Created { get; set; }
    public string Comment   { get; set; } = null!;
    public Guid CaseId      { get; set; }
    public Guid UserId      { get; set; }


    [ForeignKey("CaseId")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public CaseEntity Case  { get; set; } = null!;

    [ForeignKey("UserId")]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public UserEntity User  { get; set; } = null!;
}
