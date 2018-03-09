using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace jsonIdEditor
{
    class RegexMatcher
    {
        public List<string> MatchRegex(string input, string re, string word)
        {
            var maList = new List<string>;
            Regex r = new Regex(re, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            MatchCollection m = r.Matches(input);
            foreach(Match ma in m)
            {
                var maString = ma.ToString();
                maList.Add(maString);
            }

            return maList;

        }
    }
}
