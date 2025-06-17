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
        int choice = ManageInput.ReadNumber(Instructions.Instructions0, 5);

        switch (choice)
        {
          case 1:
            {
              SearchMenu();
              break;
            }
          case 2:
            {
              System.Console.WriteLine(Instructions.Instructions2);
              //metoda pro doplnění vůně
              break;
            }
          case 3:
            {
              System.Console.WriteLine(Instructions.Instructions3);
              //metoda pro odstranění vůně
              break;
            }
          case 4:
            {
              System.Console.WriteLine(Instructions.Instructions4);
              //metoda pro uložení změn
              break;
            }
          case 5:
            {
              Console.WriteLine("Program byl ukončen.");
              return;
            }
          default:
            {
              Console.WriteLine("Neplatná volba. Zadejte číslo mezi 1 a 5.");
              break;
            }

        }
      } while (true);
    }



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
              System.Console.WriteLine(Instructions.Instructions14);
              //metoda pro vyhledávání podle typu vůně
              break;
            }
          case 5:
            {
              //metoda pro vyhledávání podle 1 složky
              break;
            }
          case 6:
            {
              //metoda pro vyhledávání podle 2 složek
              break;
            }
          case 7:
            {
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


  }
}