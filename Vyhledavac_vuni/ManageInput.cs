using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vyhledavac_vuni
{
  public static class ManageInput
  {
    //metoda pro čtení z konzole se základní kontrolou:
    public static string ReadInput(string instructions)
    {
      string input;
      do
      {
        Console.WriteLine(instructions);
        input = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(input))
        {
          Console.WriteLine("Neplatné zadání. Zkuste to znovu. ");
        }
      }
      while (string.IsNullOrWhiteSpace(input));
      return input.Trim();
    }
    /* pokud už nebude potřeba, vymazat.
    private static int CheckInputInt(string input, int max)
    {
      if (!int.TryParse(input, out int nrOfChoice) || nrOfChoice < 1 || nrOfChoice > max)
      {
        Console.WriteLine("Neplatná volba. Zadejte číslo dle nabídky.");

      }

      return nrOfChoice;
    }*/
    public static int NumberFromUser(string instructions, int max)
    {
      string input;
      bool valid;
      int nrOfChoice;
      do
      {

        input = ReadInput(instructions);
        valid = true;
        if (!int.TryParse(input, out nrOfChoice) || nrOfChoice < 1 || nrOfChoice > max)
        {
          Console.WriteLine("Neplatná volba. Zadejte číslo dle nabídky.");
          valid = false;
        }

      }
      while (!valid);
      return nrOfChoice;
    }
    //string input = ManageInput.ReadInput(Instructions.Instructions0); // vypíše instrukce pro hlavní menu a načte vstup od uživatele
    //int choice = CheckInputInt(input, 1, 5); // zkontroluje vstup a vrátí číslo mezi 1 a 5
  }
}