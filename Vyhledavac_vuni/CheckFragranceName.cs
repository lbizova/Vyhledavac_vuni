using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vyhledavac_vuni
{
    public class CheckFragranceName
    {
            public static bool IsFragranceNameUnique(string name)
    {
      if (FragranceRepository.fragrances.Any(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
      {
        Console.WriteLine("Vůně s tímto názvem již existuje.");
        return false;
      }

      return true;
    }
    }
}