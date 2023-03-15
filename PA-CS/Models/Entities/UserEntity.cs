namespace PA_CS.Models.Entities;

internal class UserEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirsName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int UserTypeId { get; set; }
    public int AddressId { get; set; }

    public UserTypeEntity UserType { get; set; } = null!;
    public AddressEntity Address { get; set; } = null!;
    
    public ICollection<CaseEntity> Cases { get; set; } = new HashSet<CaseEntity>();
    public ICollection<CommentEntity> Comments { get; set; } = new HashSet<CommentEntity>();
}
