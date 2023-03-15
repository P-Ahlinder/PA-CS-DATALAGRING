using Microsoft.EntityFrameworkCore;
using PA_CS.Models.Entities;

namespace PA_CS.Contexts;

internal class DataContext : DbContext
{
    #region construct and override
    public DataContext()
    {
        
    }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahlin\source\repos\PA_Course_Submission\PA-CS\Contexts\local_db2.mdf;Integrated Security=True;Connect Timeout=30");
    }

    #endregion

    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<UserTypeEntity> UserTypes { get; set; }
    public DbSet<StatusTypeEntity> StatusTypes { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<CaseEntity> Cases { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }

}
