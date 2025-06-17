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
      string input = string.Empty;
      bool valid;
      do
      {
        try
        {
          Console.WriteLine(instructions);
          input = Console.ReadLine() ?? string.Empty;
          valid = true;
          if (string.IsNullOrWhiteSpace(input))
          {
            Console.WriteLine("Neplatné zadání, vstup nemůže být prázdný. Zkuste to znovu. ");
            valid = false;
          }
        }
        catch (Exception ex)
        {

          Console.WriteLine($"Chyba při čtení vstupu: {ex.Message}. Zkuste to znovu.");
          valid = false;
        }
      }
      while (!valid);
      return input.Trim();
    }

    //tip jak to upravit od Petra:
    /*static string ReadValidInput()
  {
      Console.WriteLine("Please enter a non-empty string (Press ESC to exit):");
      while (true)
      {
          try
          {
              string input = Console.ReadLine(); 
              if (string.IsNullOrWhiteSpace(input))
              {
                  Console.WriteLine("Input cannot be empty. Try again.");
                  continue;
              }
              return input;
          }
          catch (Exception ex)
          {
              Console.WriteLine($"An error occurred: {ex.Message}. Try again.");
          }
          // Check if the ESC key is pressed
          if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
          {
              Console.WriteLine("Escape key pressed. Exiting...");
              return null;
          }
      }
  }*/
    public static int ReadNumber(string instructions, int max)
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
  }
}