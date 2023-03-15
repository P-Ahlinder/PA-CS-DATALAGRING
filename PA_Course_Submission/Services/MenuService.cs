using PA_Course_Submission.Models;
using System.Runtime.InteropServices;

namespace PA_Course_Submission.Services;

internal class MenuService
{

    public async Task SaveAsync()
    {
        
        var customer = new Customer();
        Console.WriteLine("Ange ditt förnamn: ");
        customer.FirstName = Console.ReadLine();
        Console.WriteLine("Ange ditt efternamn: ");
        customer.LastName = Console.ReadLine();
        Console.WriteLine("Ange din epostadress: ");
        customer.Email = Console.ReadLine();
        Console.WriteLine("Ange ditt telefonnummer: ");
        customer.PhoneNumber = Console.ReadLine();

        
    }

    public void ListAllCases()
    {

    }

    public void SearchCase() 
    { 

    }
}
