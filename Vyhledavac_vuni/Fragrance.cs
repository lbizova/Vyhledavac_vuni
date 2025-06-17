using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Vyhledavac_vuni
{
  public class Fragrance
  {
    // název vůně:
    private string name = string.Empty;
    public string Name
    {
      get { return name; }
      private set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          throw new ArgumentException("Název vůně nesmí být prázdný.");
        }
        name = value.Trim();
      }
    }
    // koncentrace vůně (Kolínská, EDT, EDP, Parfém):
    public enum FragranceConcentration
    {
      //[Description("Kolínská")]
      Kolinska,
      EDT,
      EDP,
      //[Description("Parfém")]
      Parfem
    };
    private FragranceConcentration concentration;
    public FragranceConcentration Concentration
    {
      get { return concentration; }
      private set
      {
        if (!Enum.IsDefined(typeof(FragranceConcentration), value))
        {
          throw new ArgumentException("Neplatná koncentrace vůně.");
        }
        concentration = value;
      }
    }


    // pohlaví (dámská, pánská, unisex):  
    public enum FragranceForSex
    {
      //[Description("Dámská")]
      Damska,
      //[Description("Pánská")]
      Panska,
      Unisex
    };
    private FragranceForSex sex;
    public FragranceForSex Sex
    {
      get { return sex; }
      private set
      {
        if (!Enum.IsDefined(typeof(FragranceForSex), value))
        {
          throw new ArgumentException("Neplatné pohlaví.");
        }
        sex = value;
      }
    }
    // typ vůně (květinová, ovocná, citrusová, bylinná, mořská, orientální, pižmová, zemní, kouřová, kořeněná, dřevitá):
    public enum FragranceType
    {
      Kvetinova,
      Ovocna,
      Citrusova,
      Bylinna,
      Morska,
      Orientani,
      Pizmova,
      Zemni,
      Kourova,
      Korenena,
      Drevita
    };
    private FragranceType type;
    public FragranceType Type
    {
      get { return type; }
      private set
      {
        if (!Enum.IsDefined(typeof(FragranceType), value))
        {
          throw new ArgumentException("Neplatný typ vůně.");
        }

        type = value;
      }
    }
    //složky vůně:
    private List<string> componentsOfFragrance = new List<string>();
    public List<string> ComponentsOfFragrance
    {
      get { return componentsOfFragrance; }
      private set
      {
        if (value == null || value.Count == 0)
        {
          throw new ArgumentException("Složky vůně nesmí být prázdné.");
        }
        componentsOfFragrance = value;
      }
    }
    // konstruktor
    public Fragrance(string name, FragranceConcentration fragranceConcentration, FragranceForSex sex, FragranceType type, List<string> componentsOfFragrance)
    {
      Name = name;
      Concentration = fragranceConcentration;
      Sex = sex;
      Type = type;
      ComponentsOfFragrance = componentsOfFragrance;
    }
    
   

  }
}