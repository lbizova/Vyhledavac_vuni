using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Text;

namespace Vyhledavac_vuni
{
  public class Searching
  {
    //vyhledání podle názvu vůně:
    public static void FindByFragrName()
    {
      string input = ManageInput.ReadInput(Instructions.Instructions11); // načte vstup od uživatele
      string keyword = input.ToLowerInvariant();
      var foundFragrances = SeedData.fragrances
        .Where(f => f.Name.ToLowerInvariant().Contains(keyword))
        .ToList();

      if (foundFragrances.Count == 0)
      {
        Console.WriteLine("Žádná vůně nebyla nalezena.");
      }
      else
      {
        Console.WriteLine("Nalezené vůně:");
        foreach (var fragrance in foundFragrances)
        {
          //výpis všech parametrů vůně
          PrintCompleteFragranceInfo(fragrance);
        }
      }
    }


    //vyhledání podle koncentrace vůně:
    public static void FindByFragrConcentration()
    {
      string input = ManageInput.ReadInput(Instructions.Instructions12);
      string normalizedInput = RemoveDiacritics(input).ToLowerInvariant();
      //pokud uživatel zadá koncentraci s diakritikou, tak se převede na malá písmena a odstraní se diakritika

      if (Enum.TryParse(normalizedInput, true, out Fragrance.FragranceConcentration concentration))
      {
        var foundFragrances = SeedData.fragrances
          .Where(f => f.Concentration == concentration)
          .ToList();
        if (foundFragrances.Count == 0)
        {
          Console.WriteLine("Žádná vůně s touto koncentrací nebyla nalezena.");
        }
        else
        {
          Console.WriteLine("Nalezené vůně:");
          foreach (var fragrance in foundFragrances)
          {
            //výpis všech parametrů vůně
            PrintCompleteFragranceInfo(fragrance);
          }
        }
      }
      else
      {
        Console.WriteLine("Neplatná koncentrace vůně.");
      }
    }

    //vyhledání podle pohlaví:
    public static void FindFragrByGender()
    {
      string input = ManageInput.ReadInput(Instructions.Instructions13);
      string normalizedInput = RemoveDiacritics(input).ToLowerInvariant();
      //pokud uživatel zadá pohlaví s diakritikou, tak se převede na malá písmena a odstraní se diakritika

      if (Enum.TryParse(normalizedInput, true, out Fragrance.FragranceByGender gender))
      {
        var foundFragrances = SeedData.fragrances
          .Where(f => f.Gender == gender)
          .ToList();
        if (foundFragrances.Count == 0)
        {
          Console.WriteLine("Žádná vůně pro toto pohlaví nebyla nalezena.");
        }
        else
        {
          Console.WriteLine("Nalezené vůně:");
          foreach (var fragrance in foundFragrances)
          {
            //výpis všech parametrů vůně
            PrintCompleteFragranceInfo(fragrance);
          }
        }
      }
      else
      {
        Console.WriteLine("Neplatné zadání pohlaví.");

      }
    }
    //vyhledání podle typu vůně:
    public static void FindByFragrType()
    {
      string input = ManageInput.ReadInput(Instructions.Instructions14);
      string normalizedInput = RemoveDiacritics(input).ToLowerInvariant();
      //pokud uživatel zadá typ s diakritikou, tak se převede na malá písmena a odstraní se diakritika

      if (Enum.TryParse(normalizedInput, true, out Fragrance.FragranceType type))
      {
        var foundFragrances = SeedData.fragrances
          .Where(f => f.Type == type)
          .ToList();
        if (foundFragrances.Count == 0)
        {
          Console.WriteLine("Žádná vůně tohoto typu nebyla nalezena.");
        }
        else
        {
          Console.WriteLine("Nalezené vůně:");
          foreach (var fragrance in foundFragrances)
          {
            //výpis všech parametrů vůně
            PrintPartialFragranceInfo(fragrance);
            Console.WriteLine("Pro více informací o vůni vyhledávejte podle názvu vůně.");
          }
        }
      }
      else
      {
        Console.WriteLine("Neplatný typ vůně.");
      }
    }

    //vyhledání podle 1 složky vůně (vyhledávání v listu componentsOfFragrance):
    public static void FindByFragrComponent()
    {
      string input = ManageInput.ReadInput(Instructions.Instructions15).ToLowerInvariant();

      var foundFragrances = SeedData.fragrances
        .Where(f => f.ComponentsOfFragrance.Any(c => c.ToLowerInvariant().Contains(input)))
        .ToList();
      if (foundFragrances.Count == 0)
      {
        Console.WriteLine("Žádná vůně s touto složkou nebyla nalezena.");
      }
      else
      {
        Console.WriteLine("Nalezené vůně:");
        foreach (var fragrance in foundFragrances)
        {
          //výpis vybraných parametrů vůně
          PrintPartialFragranceInfo(fragrance);
        }
        Console.WriteLine("Pro více informací o vůni vyhledávejte podle názvu vůně.");
      }
    }

    // vyhledání podle 2 složek vůně (vyhledávání v listu componentsOfFragrance):
    public static void FindBy2FragrComponents()
    {
      string input = ManageInput.ReadInput(Instructions.Instructions16);
      string[] components = input.Split(',').Select(c => c.Trim().ToLowerInvariant()).ToArray();
      if (components.Length != 2)
      {
        Console.WriteLine("Zadejte přesně dvě složky oddělené čárkou.");
        return;
      }
      var foundFragrances = SeedData.fragrances
        .Where(f => f.ComponentsOfFragrance.Count(c => components.Contains(c.ToLowerInvariant())) == 2)
        .ToList();
      if (foundFragrances.Count == 0)
      {
        Console.WriteLine("Žádná vůně s těmito dvěmi složkami nebyla nalezena.");
      }
      else
      {
        Console.WriteLine("Nalezené vůně:");
        foreach (var fragrance in foundFragrances)
        {
          //výpis vybraných parametrů vůně
          PrintPartialFragranceInfo(fragrance);
        }
        Console.WriteLine("Pro více informací o vůni vyhledávejte podle názvu vůně.");
      }
    }
      //vyhledání podle složky, kterou vůně neobsahuje:
    public static void FindByNotInclFragrComponent()
    {
      string input = ManageInput.ReadInput(Instructions.Instructions17).ToLowerInvariant();

      var foundFragrances = SeedData.fragrances
        .Where(f => !f.ComponentsOfFragrance.Any(c => c.ToLowerInvariant().Contains(input)))
        .ToList();
      if (foundFragrances.Count == 0)
      {
        Console.WriteLine("Všechny vůně obsahují tuto složku.");
      }
      else
      {
        Console.WriteLine("Nalezené vůně:");
        foreach (var fragrance in foundFragrances)
        {
          //výpis vybraných parametrů vůně
          PrintPartialFragranceInfo(fragrance);
        }
        Console.WriteLine("Pro více informací o vůni vyhledávejte podle názvu vůně.");
      }
    }

    
    //pomocné metody:
    private static void PrintCompleteFragranceInfo(Fragrance fragrance)
    {
      Console.WriteLine($"{fragrance.Name}; {fragrance.Concentration}; {fragrance.Gender}; {fragrance.Type}; {string.Join(", ", fragrance.ComponentsOfFragrance)}");
    }
    private static void PrintPartialFragranceInfo(Fragrance fragrance)
    {
      Console.WriteLine($"{fragrance.Name}; {fragrance.Concentration}; {fragrance.Gender}");
    }
    private static string RemoveDiacritics(string text)  // navrženo AI - prostudovat.
    {
      var normalized = text.Normalize(NormalizationForm.FormD);
      var chars = normalized.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
      return new string(chars.ToArray()).Normalize(NormalizationForm.FormC);
    }

  }
}
