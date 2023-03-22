using PA_Course_Submission.Services;



var menu = new MenuService();

while (true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("*********************************************\n");
    Console.WriteLine("\t1. Skapa ett nytt ärende");
    Console.WriteLine("\t2. Visa alla ärenden");
    Console.WriteLine("\t3. Sök ärende via ID");
    Console.WriteLine("\t4. Visa/ ändra ärendestatus");
    Console.WriteLine("\t5. Avsluta programmet\n");
    Console.WriteLine("*********************************************\n\n");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Detta program är skapat av Per Ahlinder Cordes, WIN-22.\nKursinlämning Datalaring" );
    Console.ResetColor();


    switch (Console.ReadLine())
    {
        case "1":
            await menu.SaveCaseAsync();
            break;

        case "2":
            menu.ShowAllCasesAsync();
            break;

        case "3":
            await menu.SearchSpecificCaseAsync();
            break;

        case "4":
            await menu.UpdateCaseStatusAsync();
            break;

        case "5":
            Console.WriteLine("Programmet avslutas..");
            Environment.Exit(1);
            break;

        default:
            Console.WriteLine("Använd menyval 1-3 för att navigera.");
            break;
    }
    Console.ReadLine();
}