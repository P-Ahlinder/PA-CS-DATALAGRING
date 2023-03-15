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
           
        if(_addressEntity != null)
        {
            _customerEntity.AddressId = _addressEntity.Id;
        }else
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

    
   

    public static async Task<Customer> GetAsync(string email)
    {
        var _customer = await _context.Customers.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);
        if (_customer != null)
            return new Customer
            {
                FirstName = _customer.FirstName,
                LastName = _customer.LastName,
                Email = _customer.Email,
                PhoneNumber = _customer.PhoneNumber,
                StreeName = _customer.Address.StreetName,
                PostalCode = _customer.Address.PostalCode,
                City = _customer.Address.City,
            };
        else 
            return null;
    }
    /*
    public static async Task UpdateAsync(Customer customer)
    {
        var _customer = await _context.Customers.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == customer.Id);
        if (_customer != null)
        {


         
        }

    }
    */

    public static async Task DeleteAsync(string email)
    {
        var customer = await _context.Customers.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);
        if (customer != null)
        {
            _context.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
