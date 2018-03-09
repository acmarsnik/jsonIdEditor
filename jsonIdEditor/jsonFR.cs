using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace jsonIdEditor
{
    class jsonFR
    {
        public int EditorialResponse(string replacement, string saveFileName)
        {
            string fullFilePath;
            OpenFileDialog file = new OpenFileDialog();
            try
            {
                string word = "babushka$$$";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    fullFilePath = file.FileName;
                    StreamReader reader = new StreamReader(fullFilePath);
                    string input = reader.ReadToEnd();
                    var dirFn = fullFilePath.Split('.');
                    var directory = dirFn[0];
                    var updatedFilePath = directory + " (Updated)" + ".json";

                    string re1 = "[";
                    string word1 = "{" + Environment.NewLine + "   \"title\":\"Insert Title Here\"," + Environment.NewLine;
                    word1 += "   \"description\":\"Insert Description Here\"," + Environment.NewLine + "   \"geometryDescriptor\":{";
                    word1 += Environment.NewLine + "     \"type\":\"Insert Geometry Descriptor Type Here\"," + Environment.NewLine;
                    word1 += "     \"name\":\"Insert Geometry Descriptor Name Here\"," + Environment.NewLine;
                    word1 += "     \"data\":\"Insert Geometry Descriptor Data Here\"" + Environment.NewLine + "   }," + Environment.NewLine;
                    word1 += "   \"attributeSetDefinitions\":{}," + Environment.NewLine + "   \"items\":{";
                    string re2 = "(\\{)";
                    string word2 = "";
                    string re3 = "(\\])";
                    string word3 = "";

                    var rm = new RegexMatcher();
                    var list1 = rm.MatchRegex(input, re2, word);

                    var rep = new Replacer();
                    rep.Replace(updatedFilePath, input, re1, word1);
                    rep.Replace(updatedFilePath, input, re2, word2);
                    rep.Replace(updatedFilePath, input, re3, word3);


                    return 0;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 1;
        }
    }
}
