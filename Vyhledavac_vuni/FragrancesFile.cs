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
          if (parts.Length >= 4)
          {
            string name = parts[0];
            //převedení koncentrace, pohlaví a typu vůně na text bez diakritiky a tolerantní k velikosti písmen
            Fragrance.FragranceConcentration concentration;
            if (!Enum.TryParse(Diacritics.RemoveDiacritics(parts[1].Trim().ToLowerInvariant()), true, out concentration))
            {
              Console.WriteLine($"Neplatná koncentrace: {parts[1]}");
              continue; // přeskočí řádek, pokud koncentrace není platná
            }
            Fragrance.FragranceByGender gender;
            if (!Enum.TryParse(Diacritics.RemoveDiacritics(parts[2]).Trim().ToLowerInvariant(), true, out gender))
            {
              Console.WriteLine($"Neplatné pohlaví: {parts[2]}");
              continue; // přeskočí řádek, pokud pohlaví není platné
            }
            Fragrance.FragranceType type;
            if (!Enum.TryParse(Diacritics.RemoveDiacritics(parts[3].Trim().ToLowerInvariant()), true, out type))
            {
              Console.WriteLine($"Neplatný typ vůně: {parts[3]}");
              continue; // přeskočí řádek, pokud typ není platný
            }
            //odladit načtení všech složek vůně !!!
            List<string> components = new();
            for (int i = 4; i < parts.Length; i++)
            {
              if (!string.IsNullOrWhiteSpace(parts[i]))
              {
                components.Add(parts[i].Trim());
              }
            }


            Fragrance fragrance = new Fragrance(name, concentration, gender, type, components);
            fragrances.Add(fragrance);
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
  }
}