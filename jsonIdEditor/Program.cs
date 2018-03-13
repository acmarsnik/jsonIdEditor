using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace jsonIdEditor
{
    /// <summary>  
    ///  This is the Program Class.  
    /// </summary> 
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            var j = new jsonFR();

            var result = j.UpdateIds();
            Console.WriteLine(result);

            
        }
    }
}
