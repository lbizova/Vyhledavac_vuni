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
      [Description("Kolínská")]
      Kolinska,
      EDT,
      EDP,
      [Description("Parfém")]
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
    public enum FragranceByGender
    {
      [Description("Dámská")]
      Damska,
      [Description("Pánská")]
      Panska,
      Unisex
    };
    private FragranceByGender gender;
    public FragranceByGender Gender
    {
      get { return gender; }
      private set
      {
        if (!Enum.IsDefined(typeof(FragranceByGender), value))
        {
          throw new ArgumentException("Neplatné pohlaví.");
        }
        gender = value;
      }
    }
    // typ vůně (květinová, ovocná, citrusová, bylinná, mořská, orientální, pižmová, zemitá, kouřová, kořeněná, dřevitá, svěží):
    public enum FragranceType
    {
      [Description("Květinová")]
      Kvetinova,
      [Description("Ovocná")]
      Ovocna,
      [Description("Citrusová")]
      Citrusova,
      [Description("Bylinná")]
      Bylinna,
      [Description("Mořská")]
      Morska,
      [Description("Orientální")]
      Orientalni,
      [Description("Pižmová")]
      Pizmova,
      [Description("Zemitá")]
      Zemita,
      [Description("Kouřová")]
      Kourova,
      [Description("Kořeněná")]
      Korenena,
      [Description("Dřevitá")]
      Drevita,
      [Description("Svěží")]
      Svezi
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
    public Fragrance(string name, FragranceConcentration fragranceConcentration, FragranceByGender gender, FragranceType type, List<string> componentsOfFragrance)
    {
      Name = name;
      Concentration = fragranceConcentration;
      Gender = gender;
      Type = type;
      ComponentsOfFragrance = componentsOfFragrance;
    }
    
   

  }
}