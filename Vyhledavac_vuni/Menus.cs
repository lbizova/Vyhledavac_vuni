using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vyhledavac_vuni
{
  public class Menus
  {

    //metoda zpracovávající vstup uživatele pro hlavní menu:
    public static void MainMenu()
    {

      do
      {
        int choice = ManageInput.ReadNumber(Instructions.Instructions0, 6);

        switch (choice)
        {
          case 1:
            {
              SearchMenu();
              break;
            }
          case 2:
            {
              AddFragrance();
              //metoda pro doplnění vůně
              break;
            }
          case 3:
            {
              System.Console.WriteLine("Bude doplněno v další verzi. ");
              //metoda pro odstranění vůně
              break;
            }
          case 4:
            {
              PrintFragrancesNames();
              //metoda pro výpis názvů vůní
              break;
            }
          case 5:
            {
              Console.WriteLine("Bude doplněno v další verzi.  ");
              //metoda pro uložení změn
              break;
            }
          case 6:
            {
              Console.WriteLine("Program byl ukončen.");
              return;
            }
          default:
            {
              Console.WriteLine("Neplatná volba. Zadejte číslo mezi 1 a 6.");
              break;
            }

        }
      } while (true);
    }


    // 1. metoda pro menu vyhledávání vůní:
    public static void SearchMenu()
    {

      do
      {
        int choice = ManageInput.ReadNumber(Instructions.Instructions1, 8); // vypíše instrukce pro vyhledávání a načte vstup od uživatele zkontroluje vstup a vrátí číslo mezi 1 a 8
        switch (choice)
        {
          case 1:
            {
              Searching.FindByFragrName();
              //metoda pro vyhledávání podle názvu vůně
              break;
            }
          case 2:
            {
              Searching.FindByFragrConcentration();
              //metoda pro vyhledávání podle koncentrace vůně
              break;
            }
          case 3:
            {
              Searching.FindFragrByGender();
              //metoda pro vyhledávání podle pohlaví
              break;
            }
          case 4:
            {
              Searching.FindByFragrType();
              //metoda pro vyhledávání podle typu vůně
              break;
            }
          case 5:
            {
              Searching.FindByFragrComponent();
              //metoda pro vyhledávání podle 1 složky
              break;
            }
          case 6:
            {
              Searching.FindBy2FragrComponents();
              //metoda pro vyhledávání podle 2 složek
              break;
            }
          case 7:
            {
              Searching.FindByNotInclFragrComponent();
              //metoda pro vyhledávání podle složky kterou vůně neobsahuje
              break;
            }
          case 8:
            {
              return; // návrat do hlavního menu
            }

          default:
            {
              Console.WriteLine("Neplatná volba. Zadejte číslo dle nabídky.");
              break;
            }
        }
      } while (true);
    }

    // 2. metoda pro menu doplnění vůně:
    public static void AddFragrance()
    {
      string input = ManageInput.ReadInput(Instructions.Instructions2);
      string[] parts = input.Split(';').Select(p => p.Trim()).ToArray();
      if (parts.Length < 6)
      {
        Console.WriteLine("Zadejte všechny požadované informace o vůni oddělené středníkem.");
        return;
      }
      string name = parts[0].Trim();
      if (string.IsNullOrWhiteSpace(name))
      {
        Console.WriteLine("Název vůně nesmí být prázdný.");
        return;
      }
      
      if (!CheckFragranceName.IsFragranceNameUnique(name))
      {
        return;
      }

      if (TryParseToEnumUserInput(parts, out Fragrance.FragranceConcentration concentration, out Fragrance.FragranceByGender gender, out Fragrance.FragranceType type))
      {
        return;
      }
      List<string> components = parts.Skip(4).Select(c => c.Trim()).Where(c => !string.IsNullOrWhiteSpace(c)).ToList(); // Složky vůně začínají od indexu 4
      if (components.Count < 2)
      {
        Console.WriteLine("Vůně musí obsahovat alespoň 2 složky.");
        return;
      }
      // Vytvoření nové vůně
      Fragrance newFragrance = new Fragrance(name, concentration, gender, type, components);
      // Přidání nové vůně do seznamu
      FragranceRepository.fragrances.Add(newFragrance);
      Console.WriteLine($"Vůně '{newFragrance.Name}' byla úspěšně přidána.");
    }



    private static bool TryParseToEnumUserInput(string[] parts, out Fragrance.FragranceConcentration concentration, out Fragrance.FragranceByGender gender, out Fragrance.FragranceType type)
    {
      if (!Enum.TryParse(parts[1].Trim(), true, out concentration))
      {
        Console.WriteLine("Neplatná koncentrace vůně. Zadejte Kolínská, EDT, EDP nebo Parfém.");
        gender = default;
        type = default;
        return false;
      }
      if (!Enum.TryParse(parts[2].Trim(), true, out gender))
      {
        Console.WriteLine("Neplatné pohlaví. Zadejte dámská, pánská nebo unisex.");
        type = default;
        return false;
      }
      if (!Enum.TryParse(parts[3].Trim(), true, out type))
      {
        Console.WriteLine("Neplatný typ vůně. Zadejte květinová, ovocná, citrusová, bylinná, mořská, orientální, pižmová, zemní, kouřová, kořeněná nebo dřevitá.");
        return false;
      }

      return true;
    }

    // 3. metoda pro menu odstranění vůně:

    //Bude doplněno v další verzi.  
    // 4. metoda pro menu výpis názvů vůní:
    public static void PrintFragrancesNames()
    {
      Console.WriteLine("Seznam obsahuje následující vůně:");
      //seřadí podle pohlaví a poté podle názvu vůně:
      var sortedFragrances = FragranceRepository.fragrances
        .OrderBy(f => f.Gender)
        .ThenBy(f => f.Name)
        .ToList();
      foreach (var fragrance in sortedFragrances)
      {
        Console.WriteLine($"{EnumHelper.GetDescription(fragrance.Gender)} vůně: {fragrance.Name}");
      }
    }
    // 5. metoda pro menu uložení změn:
    //Bude doplněno v další verzi. 


  }
}