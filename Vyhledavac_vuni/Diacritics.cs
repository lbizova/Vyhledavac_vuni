using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Text;

namespace Vyhledavac_vuni
{
    public class Diacritics
    {
    public static string RemoveDiacritics(string text)  // navrženo AI - prostudovat.
    {
      var normalized = text.Normalize(NormalizationForm.FormD);
      var chars = normalized.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
      return new string(chars.ToArray()).Normalize(NormalizationForm.FormC);
    }
    }
}