using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdd_Database.Helpers
{
    public class DateConverter
    {
        public static string Converter(DateTime data, string formato)
        {
            var str = "";

            if (formato=="YYYY-MM-DD")
                str = data.Year + "-" + data.Month + "-" + data.Day;
                
            return str;

        }
    }
}
