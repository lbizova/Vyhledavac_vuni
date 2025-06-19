using System.Net;

namespace Vyhledavac_vuni;

class Program
{

  static void Main(string[] args)
  {
    //načtení dat ze souboru:
    FragrancesFile fragrancesFile = new FragrancesFile();
    fragrancesFile.CheckDirectory();
    FragranceRepository.fragrances = fragrancesFile.LoadFragrancesFromFile("Seznam_vuni_se_slozkami_50radku.csv"); // větší soubor má v názvu 135radku, menší 50radku

    //pokud není soubor s vůněmi, tak se použijí seed data:
    if (FragranceRepository.fragrances.Count == 0)
    {
      Console.WriteLine("Soubor s vůněmi nebyl nalezen nebo je prázdný. Používám seed data.");
      SeedData.SeedDataFragrances();
    }
    else
    {
      Console.WriteLine($"Načteno {FragranceRepository.fragrances.Count} vůní ze souboru.");
    }

    Console.WriteLine("Vítejte v aplikaci pro vyhledávání vůní a správu seznamu vůní.");
    Menus.MainMenu();
    




  }



}
