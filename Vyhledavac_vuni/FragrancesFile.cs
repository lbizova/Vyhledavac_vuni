using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;


namespace Vyhledavac_vuni
{
  public class FragrancesFile
  {

    string pathToDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    string directoryWithFragrances = "Seznam_vuni";
    // kontrola existence adresáře:
    public void CheckDirectory()
    {
      string fullPath = Path.Combine(pathToDocuments, directoryWithFragrances);
      if (!Directory.Exists(fullPath))
      {
        Directory.CreateDirectory(fullPath);
      }
      else
      {
        Console.WriteLine($"Adresář {directoryWithFragrances} již existuje.");
      }
    }
    //metoda pro načtení vůní ze souboru:
    public List<Fragrance> LoadFragrancesFromFile(string fileName)
    {
      string fullPath = Path.Combine(pathToDocuments, directoryWithFragrances, fileName);
      List<Fragrance> fragrances = new List<Fragrance>();

      if (File.Exists(fullPath))
      {
        string[] lines = File.ReadAllLines(fullPath, encoding: System.Text.Encoding.UTF8);

        Console.WriteLine($"Načítám vůně ze souboru: {fileName}");


        foreach (string line in lines)
        {
          string[] parts = line.Split(';');
          if (parts.Length >= 6) // kontrola, zda řádek obsahuje dostatek informací (min. 2 složky)
          {
            string name = parts[0];
            //převedení koncentrace, pohlaví a typu vůně na text bez diakritiky a tolerantní k velikosti písmen
            Fragrance.FragranceConcentration concentration;
            Fragrance.FragranceByGender gender;
            Fragrance.FragranceType type;

            if (!TryParseToEnumFromFile(parts, out concentration, out gender, out type))
            {
              // pokud se nepodaří převést koncentraci, pohlaví nebo typ vůně, přeskočí řádek

              {
                continue;
              }
            }
            // vytvoření seznamu složek vůně, začíná od indexu 4
            List<string> components = new();
            for (int i = 4; i < parts.Length; i++)
            {
              if (!string.IsNullOrWhiteSpace(parts[i]))
              {
                components.Add(parts[i].Trim());
              }
            }


            Fragrance fragrance = new Fragrance(name, concentration, gender, type, components);
            //pokud název již neexistuje, přidá se do seznamu vůní
            if (CheckFragranceName.IsFragranceNameUnique(fragrance.Name))
            {
              fragrances.Add(fragrance);
            }
            else
            {
              Console.WriteLine($"Vůně s názvem '{fragrance.Name}' již existuje a nebude přidána.");
            }
          }
            else
            {
              Console.WriteLine($"Řádek '{line}' neobsahuje dostatek informací o vůni.");
            }
        }

      }
      else
      {
        Console.WriteLine($"Soubor {fileName} v adresáři {directoryWithFragrances} neexistuje.");
      }
      return fragrances;
    }

    private static bool TryParseToEnumFromFile(string[] parts, out Fragrance.FragranceConcentration concentration, out Fragrance.FragranceByGender gender, out Fragrance.FragranceType type)
    {

      if (!Enum.TryParse(Diacritics.RemoveDiacritics(parts[1].Trim().ToLowerInvariant()), true, out concentration))
      {
        Console.WriteLine($"Neplatná koncentrace: {parts[1]}");
        gender = default;
        type = default;
        return false; // přeskočí řádek, pokud koncentrace není platná
      }

      if (!Enum.TryParse(Diacritics.RemoveDiacritics(parts[2]).Trim().ToLowerInvariant(), true, out gender))
      {
        Console.WriteLine($"Neplatné pohlaví: {parts[2]}");
        type = default;
        return false; // přeskočí řádek, pokud pohlaví není platné
      }

      if (!Enum.TryParse(Diacritics.RemoveDiacritics(parts[3].Trim().ToLowerInvariant()), true, out type))
      {
        Console.WriteLine($"Neplatný typ vůně: {parts[3]}");
        return false; // přeskočí řádek, pokud typ není platný
      }

      return true;
    }
  }
}
