using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PA_Course_Submission.Models.Entities;

[Index (nameof(Email), IsUnique = true)]
internal class CustomerEntity
{
    [Key]
    public int      Id               { get; set; }
    public string   FirstName        { get; set; } = null!;
    public string   LastName         { get; set; } = null!;
    public string   Email            { get; set; } = null!;
    public string?  PhoneNumber      { get; set; }


    public int AddressId             { get; set; }
    public AddressEntity Address     { get; set; } = null!;


    public ICollection<CaseEntity> Cases { get; set; } = new HashSet<CaseEntity> ();


}
