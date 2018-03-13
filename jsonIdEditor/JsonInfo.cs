using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonIdEditor
{
    class JsonInfo
    {
        public string fullFilePath;
        public int fileCnt = 0;
        public OpenFileDialog file = new OpenFileDialog();
    }
}
