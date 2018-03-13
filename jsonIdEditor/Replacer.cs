using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsonIdEditor
{
    /// <summary>  
    ///  This is the Replacer Class.  
    /// </summary> 
    class Replacer
    {
        string openBracket = "[";
        string closeBracket = "]";
        string fileStart = "{" + Environment.NewLine + "   \"title\":\"Insert Title Here\"," + Environment.NewLine + 
            "   \"description\":\"Insert Description Here\"," + Environment.NewLine + "   \"geometryDescriptor\":{" + 
            Environment.NewLine + "      \"type\":\"Insert Geometry Descriptor Type Here\"," + Environment.NewLine +
            "      \"name\":\"Insert Geometry Descriptor Name Here\"," + Environment.NewLine + 
            "      \"data\":\"Insert Geometry Descriptor Data Here\"" + Environment.NewLine + "   }," + Environment.NewLine + 
            "   \"attributeSetDefinitions\":{" + Environment.NewLine + "}," + Environment.NewLine + "   \"items\": {";
        string fileEnd = "";

        public void Replace1(string fullFilePN, string input, string word, string replacement)
        {
            using (StreamWriter writer = new StreamWriter(fullFilePN, true))
            {
                {
                    string output = input.Replace(word, replacement);
                    writer.Write(output);
                }
                writer.Close();
            }

                    }

        public void ReplaceMany(string fullFilePN, string input)
        {
            using (StreamWriter writer = new StreamWriter(fullFilePN, true))
            {
                {
                    string output = string.Copy(input);
                    output = output.Replace(openBracket, fileStart);
                    output = output.Replace(":\\{,", ":\\{");
                    output = output.Replace(closeBracket, fileEnd);
                    writer.Write(output);
                }
                writer.Close();
            }

        }

        public string getFileStart()
        {
            return fileStart;

        }
    }
}
