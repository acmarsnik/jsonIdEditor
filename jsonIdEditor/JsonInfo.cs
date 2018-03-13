using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jsonIdEditor
{
    class JsonInfo
    {
        public string fullFilePath;
        public int fileCnt;
        public int intAns;
        public OpenFileDialog file = new OpenFileDialog();
        public Replacer rep = new Replacer();
        public string strAns;
        public string strAns2;
        public String[] dirFn;
        public StreamReader reader;
        public string input;
        public string directory;
        public string updatedFilePath;
        public String[] objects;
        public string akRe = "(\\{.*?\"ArticleKey\":.*?,)";
        public string onRe = "(\"OrderNumber\":.*?,)";
        public string vknRe = "(\"VKN\":.*?,)";
        public string ctRe = "(\"CatalogType\":.*?,)";
        public string cidRe = "(\"CatalogID\":.*?,)";
        public string lcidRe = "(\"Lcid\":.*?,)";
        public string sidRe = "(\"SupplierID\":.*?,)";
        public string idCurr = "";
        public List<string> ids = new List<string>();
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
        public string updJsonCurrObj;
        public string updJsonCurrFile;
        public string updJsonFull = "";
        public List<string> updJsonObjs = new List<string>();
        public AttributeExtractor ae = new AttributeExtractor();
        public string att = "";
        public string attText = "";
        public String[] atts;
        public string[] ArtKey3Dig1;
        public string akAtt = "";
        public string openBracket = "[";
        public string closeBracket = "]";
        public string fileStart = "{" + Environment.NewLine + "   \"title\":\"Insert Title Here\"," + Environment.NewLine +
            "   \"description\":\"Insert Description Here\"," + Environment.NewLine + "   \"geometryDescriptor\":{" +
            Environment.NewLine + "      \"type\":\"Insert Geometry Descriptor Type Here\"," + Environment.NewLine +
            "      \"name\":\"Insert Geometry Descriptor Name Here\"," + Environment.NewLine +
            "      \"data\":\"Insert Geometry Descriptor Data Here\"" + Environment.NewLine + "   }," + Environment.NewLine +
            "   \"attributeSetDefinitions\":{" + Environment.NewLine + "}," + Environment.NewLine + "   \"items\": {";
        public string fileEnd = "";
        public string openBraceComma = ":\\{,";
        public string openBrace = ":\\{";

    }
}
