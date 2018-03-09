using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace jsonIdEditor
{
    class jsonFR
    {
        public int EditorialResponse(string word, string replacement, string saveFileName)
        {
            string fullFilePath;
            OpenFileDialog file = new OpenFileDialog();
            try
            {
                if (file.ShowDialog() == DialogResult.OK)
                {
                    fullFilePath = file.FileName;
                    StreamReader reader = new StreamReader(fullFilePath);
                    string input = reader.ReadToEnd();
                    var dirFn = fullFilePath.Split('.');
                    var directory = dirFn[0];

                    using (StreamWriter writer = new StreamWriter(directory + saveFileName, true))
                    {
                        {
                            string output = input.Replace(word, replacement);
                            writer.Write(output);
                        }
                        writer.Close();

                    }
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
