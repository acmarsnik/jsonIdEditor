using System;
using System.Collections.Generic;
using System.IO;
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
        public string strAns;
        public string strAns2;
        public int intAns;
        public Replacer rep = new Replacer();
        public StreamReader reader;
        public string orgJsonTxt;
        public String[] dirFn;
        public string directory;
        public string updatedFilePath;
        public String[] orgJsonObjects;
        public string akRe = "(\\{.*?\"ArticleKey\":.*?,)";
        public string onRe = "(\"OrderNumber\":.*?,)";
        public string vknRe = "(\"VKN\":.*?,)";
        public string ctRe = "(\"CatalogType\":.*?,)";
        public string cidRe = "(\"CatalogID\":.*?,)";
        public string lcidRe = "(\"Lcid\":.*?,)";
        public string sidRe = "(\"SupplierID\":.*?,)";
        public string id = "";
        public string akIdPrefix = "\"ak-";
        public string onIdPrefix = "-on-";
        public string vknIdPrefix = "-vkn-";
        public string ctIdPrefix = "-ct-";
        public string cidIdPrefix = "-cid-";
        public string lcidIdPrefix = "-lcid-";
        public string sidIdPrefix = "-sid-";
        public string idSuffix = "\": ";
        public int prevArtKey3Dig = 000;
        public int currArtKey3Dig = 000;
        public bool newCatalog = false;
        public RegexMatcher rm = new RegexMatcher();
    }
}
