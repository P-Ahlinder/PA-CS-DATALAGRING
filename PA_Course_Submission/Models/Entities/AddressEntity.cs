using System.ComponentModel.DataAnnotations;

namespace PA_Course_Submission.Models.Entities;

internal class AddressEntity
{
    [Key]
    public int    Id            { get; set; }
    public string StreetName    { get; set; } = null!;
    public string City          { get; set; } = null!;
    public string PostalCode    { get; set; } = null!;

    public ICollection<CustomerEntity> CustomerEntities { get; set; } = new HashSet<CustomerEntity>();
}
