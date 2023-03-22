using Microsoft.EntityFrameworkCore;
using PA_Course_Submission.Models.Entities;

namespace PA_Course_Submission.Contexts;

internal class DataContext : DbContext
{
    private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahlin\source\repos\PA_Course_Submission\Database\anotherDB.mdf;Integrated Security=True;Connect Timeout=30";

    #region Construct//Overrides//Options

    public DataContext()
    {
        
    }
    public DataContext(DbContextOptions <DataContext> options) : base(options)
    {

    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionString);
    }
    #endregion

    #region Entities
    public DbSet<CaseEntity>        Cases      { get; set; } = null!;
    public DbSet<CustomerEntity>    Customers  { get; set; } = null!;
    public DbSet<AddressEntity>     Addresses  { get; set; } = null!;

    #endregion

}
