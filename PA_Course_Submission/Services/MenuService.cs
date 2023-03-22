using PA_Course_Submission.Models;
namespace PA_Course_Submission.Services;

internal class MenuService
{
    public async Task SaveCaseAsync()
    {
        var customer = new Customer();
        var addCase = new AddCase();

        Console.Clear();
        Console.WriteLine("Ange ditt förnamn: ");
        customer.FirstName = Console.ReadLine() ?? "";
        Console.Clear();
        Console.WriteLine("Ange ditt efternamn: ");
        customer.LastName = Console.ReadLine() ?? "";
        Console.Clear();
        Console.WriteLine("Ange din epostadress: ");
        customer.Email = Console.ReadLine() ?? "";
        Console.Clear();
        Console.WriteLine("Ange ditt telefonnummer: ");
        customer.PhoneNumber = Console.ReadLine() ?? "";
        Console.Clear();
        Console.WriteLine("Ange din adress: ");
        customer.StreeName = Console.ReadLine() ?? "";
        Console.Clear();
        Console.WriteLine("Ange ditt postnr: ");
        customer.PostalCode = Console.ReadLine() ?? "";
        Console.Clear();
        Console.WriteLine("Ange din stad: ");
        customer.City = Console.ReadLine() ?? "";
        Console.Clear();
        Console.WriteLine("Vad gäller ditt ärende? ");
        addCase.Title = Console.ReadLine() ?? "";

        Console.Clear();
        Console.WriteLine("Beskriv ditt ärende så utförligt som möjligt");
        addCase.Description = Console.ReadLine() ?? "";
            
        addCase.CustomerId = await CustomerService.SaveAsync(customer);
        await CaseService.SaveAsync(addCase);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n\nTack för att du har registrerat ett ärende!\nTryck på en tangent för att fortsätta..");
        Console.ReadKey();
        Console.ResetColor();
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
                Console.WriteLine($"KundId:       {_case.CustomerId}\n");
                Console.WriteLine("*********************************************\n");

            }
        }else
        {
                Console.WriteLine("Det finns inga sparade ärenden..");
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
                Console.WriteLine($"Kundnummer:   {cases.CustomerId}");
                Console.WriteLine($"Titel:        {cases.Title}");
                Console.WriteLine($"Status:       {cases.Status}");
                Console.WriteLine($"Ärendenummer: {cases.Id}");
            }else
            {
                Console.Clear();
                Console.WriteLine($"Det finns ingen kund med detta kundnummer {customerId}");
            }
        }

    }

    public async Task UpdateCaseStatusAsync()
    {   Console.Clear();
        Console.Write("Sök med ett ärende id för att ändra status: ");
        var caseId = Convert.ToInt32(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Ange ny status för ärendet: \n");
        Console.ForegroundColor= ConsoleColor.DarkYellow;
        Console.WriteLine("1 - Pågående");
        Console.ResetColor();
        Console.ForegroundColor= ConsoleColor.Green;
        Console.WriteLine("2 - Åtgärdat");
        Console.ResetColor();
        Console.ForegroundColor= ConsoleColor.Blue;
        Console.WriteLine("3 - Fritext");
        Console.ResetColor();

        var newStatus = "";
        switch(Console.ReadLine())
        {
            case "1":
                newStatus = "Pågående";
                break;

            case "2":
                newStatus = "Åtgärdat";
                break;

            case "3":
                Console.Clear();
                Console.WriteLine("Ange en status manuellt för ärendet: \n");
                newStatus = Console.ReadLine();
                break;

            default:
                Console.WriteLine("Använd menyval 1 eller 2 för att sätta en status.");
                    break;
        }

        var caseService = new CaseService();
        var updatedCase = await caseService.UpdateCaseStatusAsync(caseId, newStatus);


        Console.Clear();
        Console.WriteLine($"Ärendestatus för ärende {updatedCase.Id} har uppdaterats till: {updatedCase.Status}");
    }
    

}
