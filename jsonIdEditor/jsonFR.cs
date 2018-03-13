using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace JsonIdEditor
{
    /// <summary>  
    ///  This is the JsonFR Class.  
    /// </summary> 
    class JsonFR
    {
        public int UpdateIds()
        {
            string fullFilePath;
            int fileCnt = 0;
            OpenFileDialog file = new OpenFileDialog();
            try
            {
                if (file.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("Do you want to split the file by the first 3 digits of the Article Key?" + Environment.NewLine + 
                        "Enter y for yes or n for no");
                    string strAns = Console.ReadLine();

                    int intAns = 0;

                    if (strAns == "y" || strAns == "Y" || strAns == "Yes" || strAns == "YES" || strAns == "yes")
                    {
                        intAns = 1;
                        Console.WriteLine("Do you want all of the Catalogs in 1 file or separate files?" + Environment.NewLine +
                        "Enter 1 for 1 file or s for seperate");
                        string strAns2 = Console.ReadLine();
                        if (strAns2.Trim() != "1")
                        {
                            intAns = 2;
                        }


                    }

                    fullFilePath = file.FileName;
                    Replacer rep = new Replacer();
                    StreamReader reader = new StreamReader(fullFilePath);
                    string input = reader.ReadToEnd();
                    String[] dirFn = fullFilePath.Split('.');
                    string directory = dirFn[0];
                    string updatedFilePath = directory + " (Updated)" + ".json";
                    String[] objects = input.Split('}');

                    string akRe = "(\\{.*?\"ArticleKey\":.*?,)";
                    string onRe = "(\"OrderNumber\":.*?,)";
                    string vknRe = "(\"VKN\":.*?,)";
                    string ctRe = "(\"CatalogType\":.*?,)";
                    string cidRe = "(\"CatalogID\":.*?,)";
                    string lcidRe = "(\"Lcid\":.*?,)";
                    string sidRe = "(\"SupplierID\":.*?,)";
                    string id = "";
                    string akIdPrefix = "\"ak-";
                    string onIdPrefix = "-on-";
                    string vknIdPrefix = "-vkn-";
                    string ctIdPrefix = "-ct-";
                    string cidIdPrefix = "-cid-";
                    string lcidIdPrefix = "-lcid-";
                    string sidIdPrefix = "-sid-";
                    string idSuffix = "\": ";
                    int prevArtKey3Dig = 000;
                    int currArtKey3Dig = 000;

                    bool newCatalog = false;

                    RegexMatcher rm = new RegexMatcher();
                    string updatedJson = "";
                    foreach(string s in objects) {
                        string akAtt = rm.MatchRegex(s, akRe);
                        string onAtt = rm.MatchRegex(s, onRe);
                        string vknAtt = rm.MatchRegex(s, vknRe);
                        string ctAtt = rm.MatchRegex(s, ctRe);
                        string cidAtt = rm.MatchRegex(s, cidRe);
                        string lcidAtt = rm.MatchRegex(s, lcidRe);
                        string sidAtt = rm.MatchRegex(s, sidRe);
                        id = "";
                        String[] aks = akAtt.Split(':');
                        String[] ons = onAtt.Split(':');
                        String[] vs = vknAtt.Split(':');
                        String[] cts = ctAtt.Split(':');
                        String[] cids = cidAtt.Split(':');
                        String[] lcids = lcidAtt.Split(':');
                        String[] sids = sidAtt.Split(':');
                        if(aks.Length > 1) { 
                            string artKey1 = aks[1].Replace(',', ' ');
                            artKey1 = artKey1.Replace('"', ' ');
                            artKey1 = artKey1.Replace('\\', ' ');
                            string artKey = artKey1.Trim();
                            string[] ArtKey3Dig1 = artKey.Split('.');
                            if(intAns == 1 || intAns == 2) {
                                currArtKey3Dig = int.Parse(ArtKey3Dig1[0]);

                                if (currArtKey3Dig != prevArtKey3Dig && prevArtKey3Dig != 000){
                                        newCatalog = true;
                                    }
                            }
                            id += akIdPrefix;
                            id += artKey;
                        }
                        if (ons.Length > 1){
                            string ordNum1 = ons[1].Replace(',', ' ');
                            ordNum1 = ordNum1.Replace('"', ' ');
                            ordNum1 = ordNum1.Replace('\\', ' ');
                            string ordNum = ordNum1.Trim();
                            id += onIdPrefix;
                            id += ordNum;
                        }
                        if (vs.Length > 1){
                            string vkn1 = vs[1].Replace(',', ' ');
                            vkn1 = vkn1.Replace('"', ' ');
                            vkn1 = vkn1.Replace('\\', ' ');
                            string vkn = vkn1.Trim();
                            id += vknIdPrefix;
                            id += vkn;
                        }
                        if (cts.Length > 1){
                            string ct1 = cts[1].Replace(',', ' ');
                            ct1 = ct1.Replace('"', ' ');
                            ct1 = ct1.Replace('\\', ' ');
                            string ct = ct1.Trim();
                            id += ctIdPrefix;
                            id += ct;
                        }
                        if (cids.Length > 1){
                            string cid1 = cids[1].Replace(',', ' ');
                            cid1 = cid1.Replace('"', ' ');
                            cid1 = cid1.Replace('\\', ' ');
                            string cid = cid1.Trim();
                            id += cidIdPrefix;
                            id += cid;
                        }
                        if (lcids.Length > 1){
                            string lcid1 = lcids[1].Replace(',', ' ');
                            lcid1 = lcid1.Replace('"', ' ');
                            lcid1 = lcid1.Replace('\\', ' ');
                            string lcid = lcid1.Trim();
                            id += lcidIdPrefix;
                            id += lcid;
                        }
                        if (sids.Length > 1){
                            string sid1 = sids[1].Replace(',', ' ');
                            sid1 = sid1.Replace('"', ' ');
                            sid1 = sid1.Replace('\\', ' ');
                            string sid = sid1.Trim();
                            id += sidIdPrefix;
                            id += sid;
                            id += idSuffix;
                            id += akAtt;
                        }
                        
                        if(akAtt != string.Empty) {
                            if(newCatalog == true)
                            {
                                updatedJson += Environment.NewLine + "}" + Environment.NewLine + "}";

                                if (intAns == 1)
                                {
                                    updatedJson += Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                                    updatedJson += "////BREAK BETWEEN CONTENT THAT SHOULD BE USED IN TOPAZ";
                                    updatedJson += Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                                }
                                else
                                {
                                    rep.ReplaceMany(directory + "-" + prevArtKey3Dig.ToString() + ".json", updatedJson);
                                    fileCnt += 1;
                                    updatedJson = "";
                                }
                                updatedJson += rep.getFileStart();
                            }
                            string newObject = s.Replace(akAtt, id);
                            if (newCatalog == true)
                            {
                                newObject = newObject.Substring(1);
                            }
                            updatedJson += newObject;
                            updatedJson += "}";
                        }
                        else
                        {
                            updatedJson += Environment.NewLine + "}" + Environment.NewLine + "}";
                            updatedJson += s;
                            
                        }

                        prevArtKey3Dig = currArtKey3Dig;
                        newCatalog = false;


                    }

                    if(intAns == 0 || intAns == 1)
                    {
                        rep.ReplaceMany(updatedFilePath, updatedJson);
                    }
                    else
                    {
                        rep.ReplaceMany(directory + "-" + prevArtKey3Dig.ToString() + ".json", updatedJson);
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
