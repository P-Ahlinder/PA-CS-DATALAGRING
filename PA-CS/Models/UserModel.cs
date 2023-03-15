internal class UserModel
{
    public Guid Guid { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string UserType{ get; set; } = null!;
    public string StreetName { get; set; } = null!; 
    public string PostalCode { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string City { get; set; } = null!;
}
