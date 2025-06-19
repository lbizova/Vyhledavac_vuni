using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Vyhledavac_vuni
{
  //převzato od AI, prostudovat
    public class EnumHelper
  {
    public static string GetDescription(Enum value)
    {
      var field = value.GetType().GetField(value.ToString());
      if (field != null)
      {
        var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attributes.Length > 0)
        {
          return attributes[0].Description;
        }
      }
      return value.ToString();
    }
  }
}