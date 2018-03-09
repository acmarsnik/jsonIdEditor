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
            Console.WriteLine("Find: ");
            var find = Console.ReadLine();
            Console.WriteLine("Replace With: ");
            var replace = Console.ReadLine();

            var result = j.EditorialResponse(find, replace, " (Updated).json");
            Console.WriteLine(result);

            
        }
    }
}
