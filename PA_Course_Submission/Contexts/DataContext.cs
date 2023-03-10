using Microsoft.EntityFrameworkCore;
namespace PA_Course_Submission.Contexts;

internal class DataContext : DbContext
{
    private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahlin\source\repos\PA_Course_Submission\PA_Course_Submission\Data\local_db.mdf;Integrated Security=True;Connect Timeout=30";

    #region Data

    public DataContext()
    {
        
    }
    public DataContext(DbContextOptions <DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionString);
    }
    #endregion

}
