using Microsoft.EntityFrameworkCore;
using PA_Course_Submission.Models;
using PA_Course_Submission.Models.Entities;

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
        Console.Clear();
        var cases = await CaseService.GetAllAsync();

        if (cases.Any()) 
        {
            foreach(Case _case in cases)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"Ärendenummer: {_case.Id}");
                Console.WriteLine($"Titel:        {_case.Title}");
                Console.WriteLine($"Beskrivning:  {_case.Description}");
                Console.WriteLine($"Status:       {_case.Status}");
                Console.WriteLine($"Kommentar:    {_case.Comment}");
                Console.WriteLine($"KundId:       {_case.CustomerId}\n\n");
                
            }
            
        }
        else
        { 
                Console.WriteLine("Det finns inga sparade ärenden..");
                Console.WriteLine("");
        }

       Console.ResetColor();
       Console.WriteLine("Tryck på en tangent för att återvända till menyn");
    }


    public async Task SearchSpecificCaseAsync()
    {
        Console.Write("Ange ett kundnummer:");
        var customerId = Convert.ToInt32(Console.ReadLine());

        if (customerId != null)
        {
            var cases = await CaseService.GetAsync(customerId);

            if (cases != null)
            {
                Console.WriteLine($"Kundnummer: {cases.CustomerId}");
                Console.WriteLine($"Titel:      {cases.Title}");
                Console.WriteLine($"Status:     {cases.Status}");
                Console.WriteLine($"Comment:    {cases.Comment}.");
                Console.WriteLine($"Ärendenummer: {cases.Id}");
                Console.WriteLine("");


            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Det finns ingen kund med detta kundnummer {customerId}");
                Console.WriteLine("");
            }
        }

    }

    public async Task UpdateSpecificCaseAsync()
    {
                Console.WriteLine("Ange ett ärende id: ");
                var caseId = Convert.ToInt32(Console.ReadLine());

        if (caseId != null!) 
        {
            var _case = await CaseService.GetAsync(caseId);
            if (_case != null)
            {
                Console.WriteLine("Ändra status på ärendet: ");

                Console.WriteLine("1 - Ej påbörjad");
                Console.WriteLine("2 - Pågående");
                Console.WriteLine("3 - Avslutad");
                
                switch (Console.ReadLine())
                {
                    case "1" :
                        _case.Status = "Ej påbörjad";
                        break;

                    case "2":
                        _case.Status = "Pågående";
                        break;

                    case "3":
                        _case.Status = "Avslutad";
                        break;
                }
            }
            else
            {
                Console.WriteLine("Inget matchande ärende id funnet.");
            }
        }

        
    }

}
