using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace jsonIdEditor
{
    /// <summary>  
    ///  This is the RegexMatcher Class.  
    /// </summary> 
    class RegexMatcher
    {
        public string MatchRegex(string input, string re)
        {
            Regex r = new Regex(re, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(input);
            string maString = m.ToString();

            return maString;

        }
    }
}
