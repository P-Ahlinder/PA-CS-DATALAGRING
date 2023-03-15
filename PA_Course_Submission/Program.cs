using PA_Course_Submission.Services;

var menu = new MenuService();
bool MenuControl = true;

while (MenuControl)
{
    Console.Clear();
    Console.WriteLine("1. Skapa ett nytt ärende");
    Console.WriteLine("2. Visa alla ärenden");
    Console.WriteLine("3. Sök ärende via ID");
    Console.WriteLine("4. Avsluta programmet");

    switch (Console.ReadLine())
    {
        case "1":
            await menu.SaveCaseAsync();
            break;

        case "2":
            menu.ShowAllCasesAsync();
            break;

        case "3":
            
            break;

        case "4":
            Console.WriteLine("Programmet avslutas..");
            MenuControl = false;
            break;

        default:
            Console.WriteLine("Använd menyval 1-3 för att navigera.");
            break;
    }
    Console.ReadLine();
}