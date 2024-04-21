using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Core.Functions
{
    public class Validations
    {
        public static bool IsEmail(string strEmail)
        {
            if (strEmail == null)return false;
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            return System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo);
        }
    }
}
