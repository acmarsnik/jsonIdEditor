using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsonIdEditor
{
    class Replacer
    {
        public void Replace(string fullFilePN, string input, string word, string replacement)
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

        public void Replace(string fullFilePN, string input, List<string> words, List<string> replacements)
        {
            using (StreamWriter writer = new StreamWriter(fullFilePN, true))
            {
                {
                    string output = "";
                    var count = 0;
                    while(count > words.Count)
                    {
                        output = input.Replace(words[count], replacements[count]);
                    }
                    writer.Write(output);
                }
                writer.Close();
            }

        }
    }
}
