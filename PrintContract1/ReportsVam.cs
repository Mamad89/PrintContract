using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintContract1
{
    public class ReportsVam
    {
        public string HesabNumber { get; internal set; }

        public string FullName { get; internal set; }

        public string NumberContract { get; internal set; }

        public long AghsatPardakhti { get; internal set; }

        public string AghsatBaghiMandeh { get; internal set; }

        public string DateOfPardakht { get; internal set; }

        public string VamType { get; internal set; }
        public int? TedadAghsat { get; internal set; }
    }
}
