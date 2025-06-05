using System.Net;

namespace Vyhledavac_vuni;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Vítejte v aplikaci pro vyhledávání vůní a správu seznamu vůní.");

        //budoucí while
        Console.WriteLine();
        Instructions0();
        string input = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(input))
        {
            System.Console.WriteLine("neplatný příkaz. Zkuste to znovu. ");
            //continue;
        }
    }
    private static void Instructions0()
    {
        Console.WriteLine($"Co chcete dělat? (zadejte číslo): \n 1. VYHLEDÁVAT, \n 2. DOPLNIT VŮNI, \n 3. ODSTRANIT VŮNI \n 4. ULOŽIT ZMĚNY \n 5. UKONČIT PROGRAM");
    }
}
