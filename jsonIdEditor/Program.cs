using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace jsonIdEditor
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            var j = new jsonFR();

            var result = j.EditorialResponse("babushka$$$", "(Updated).json");
            Console.WriteLine(result);

            
        }
    }
}
