using PA_Course_Submission.Models;

namespace PA_Course_Submission.Services;

internal class MenuService
{

    public async Task SaveCaseAsync()
    {
        
        var customer = new Customer();
        var addCase = new AddCase();
        Console.WriteLine("Ange ditt förnamn: ");
        customer.FirstName = Console.ReadLine() ?? "";

        Console.WriteLine("Ange ditt efternamn: ");
        customer.LastName = Console.ReadLine() ?? "";

        Console.WriteLine("Ange din epostadress: ");
        customer.Email = Console.ReadLine() ?? "";

        Console.WriteLine("Ange ditt telefonnummer: ");
        customer.PhoneNumber = Console.ReadLine() ?? "";

        Console.WriteLine("Ange din adress: ");
        customer.StreeName = Console.ReadLine() ?? "";

        Console.WriteLine("Ange ditt postnr: ");
        customer.PostalCode = Console.ReadLine() ?? "";

        Console.WriteLine("Ange din stad: ");
        customer.City = Console.ReadLine() ?? "";
            
        Console.WriteLine("Vad gäller ditt ärende? ");
        addCase.Title = Console.ReadLine() ?? "";

        Console.WriteLine("Beskriv ditt ärende så utförligt som möjligt");
        addCase.Description = Console.ReadLine() ?? "";
            
        addCase.CustomerId = await CustomerService.SaveAsync(customer);
        await CaseService.SaveAsync(addCase);
    
    }
    
    public async void ShowAllCasesAsync()
    {
        var cases = await CaseService.GetAllAsync();

        if (cases.Any()) 
        {
            foreach(Case _case in cases)
            {
                Console.WriteLine($"Ärendenummer: {_case.Id}");
                Console.WriteLine($"Titel: {_case.Title}");
                Console.WriteLine($"Beskrivning: {_case.Description}");
                Console.WriteLine($"Status: {_case.Status}");
                Console.WriteLine($"Kommentar  {_case.Comment}");
                Console.WriteLine($"KundId: {_case.CustomerId}");
                Console.WriteLine("");
            }
            
        }else
        { 
            Console.WriteLine("Det finns inga sparade ärenden..");
            Console.WriteLine("");
        }
        
    }

   
    public void SearchCase() 
    { 

    }
    
}
