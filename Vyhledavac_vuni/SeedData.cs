using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vyhledavac_vuni
{
  public class SeedData
  {
    public static List<Fragrance> fragrances = new List<Fragrance>();

    private static void SeedDataFragrances()
    {
      fragrances.AddRange(new[]
      {
          new Fragrance ("Freya", Fragrance.FragranceConcentration.EDT, Fragrance.FragranceForSex.Damska, Fragrance.FragranceType.Citrusova, componentsOfFragrance: new List<string> {"Citron", "Grapefruit", "Pomeranč", "Jasmín", "Konvalinka", "Zázvor" }),
          new Fragrance ("Giordani Gold", Fragrance.FragranceConcentration.Parfem, Fragrance.FragranceForSex.Damska, Fragrance.FragranceType.Ovocna, componentsOfFragrance: new List<string> {"Mandarinka","Italský pomeranč", "Italský citron", "Madonina lilie", "Bílý jasmín", "Pomerančové kvítky", "Bílé pižmo", "Pačuli", "Mech" }),
          new Fragrance ("Elvie", Fragrance.FragranceConcentration.EDT, Fragrance.FragranceForSex.Damska, Fragrance.FragranceType.Kvetinova, componentsOfFragrance: new List<string> {"Frézie", "Lístky fialky", "Konvalinka", "Citrusové tóny", "Směs bílých květů", "Květy ovocných stomů", "Pižmo", "Ambra", "Exotické dřeviny" }),
          new Fragrance ("Eclat Sport for Men", Fragrance.FragranceConcentration.EDT, Fragrance.FragranceForSex.Panska, Fragrance.FragranceType.Korenena, componentsOfFragrance: new List<string> {"Mandarinka", "Bergamot", "Růžový pepř", "Oregano", "Bílý tymián", "Pryskyřice Elemi", "Pižmo", "Pačuli", "Cedrové dřevo", "Tonkové semeno" }),
          new Fragrance ("Frey", Fragrance.FragranceConcentration.EDT, Fragrance.FragranceForSex.Panska, Fragrance.FragranceType.Citrusova, componentsOfFragrance: new List<string> {"Citron", "Grapefruit", "Pomeranč", "Kardamom", "Majoránka", "Červený tymián", "Dřevité pižmo" }),
          new Fragrance ("Aromacare Povzbuzující", Fragrance.FragranceConcentration.Kolinska, Fragrance.FragranceForSex.Unisex, Fragrance.FragranceType.Ovocna, componentsOfFragrance: new List<string> {"Mandarinka", "Grapefruit", "Pomeranč", "Černý rybíz", "Ananas", "Broskev", "černý pepř", "Citron", "Bílý tymián", "Lilie", "Zelené jablko", "Zelený čaj", "Máta", "Bílý cedr", "Pižmo" }),
      });



      }
    

  }
}