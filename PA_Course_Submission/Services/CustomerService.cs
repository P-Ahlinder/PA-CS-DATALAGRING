using PA_Course_Submission.Models;
using PA_Course_Submission.Contexts;
using PA_Course_Submission.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace PA_Course_Submission.Services;


internal class CustomerService
{

    public static DataContext _context = new DataContext();
    public static async Task<int> SaveAsync(Customer customer)
    {
        var _customerEntity = new CustomerEntity
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber ?? "",
        };

        var _addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == customer.StreeName && x.PostalCode == customer.PostalCode && x.City == customer.City);

        if (_addressEntity != null)
        {
            _customerEntity.AddressId = _addressEntity.Id;
        }
        else
            _customerEntity.Address = new AddressEntity
            {
                StreetName = customer.StreeName,
                PostalCode = customer.PostalCode,
                City = customer.City,
            };

        _context.Add(_customerEntity);
        await _context.SaveChangesAsync();
        return _customerEntity.Id;
    }





}
