using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vyhledavac_vuni
{
  public class Fragrances
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
    private string concentration = string.Empty;
    public string Concentration
    {
      get { return concentration; }
      private set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          throw new ArgumentException("Koncentrace vůně nesmí být prázdná.");
        }
        concentration = value.Trim();
      }
    }
    // pohlaví (dámská, pánská, unisex):
    private string sex = string.Empty;
    public string Sex
    {
      get { return sex; }
      private set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          throw new ArgumentException("Pohlaví nesmí být prázdné.");
        }
        sex = value.Trim();
        //string[] validSexes = { "dámská", "pánská", "unisex" };

      }
    }
    // typ vůně:
    private string type = string.Empty;
    public string Type
    {
      get { return type; }
      private set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          throw new ArgumentException("Typ vůně nesmí být prázdný.");
        }
        type = value.Trim();
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
    public Fragrances(string name, string concentration, string sex, string type, List<string> componentsOfFragrance)
    {
      Name = name;
      Concentration = concentration;
      Sex = sex;
      Type = type;
      ComponentsOfFragrance = componentsOfFragrance;
    }

  }
}