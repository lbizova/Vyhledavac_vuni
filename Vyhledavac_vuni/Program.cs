using System.Net;

namespace Vyhledavac_vuni;

class Program
{
  
  static void Main(string[] args)
  {
    SeedData.SeedDataFragrances();
    Console.WriteLine("Vítejte v aplikaci pro vyhledávání vůní a správu seznamu vůní.");
    Menus.MainMenu();




  }



}
