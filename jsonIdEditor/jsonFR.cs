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
            JsonInfo jsonInfo = new JsonInfo();
            
            try
            {
                if (jsonInfo.file.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("Do you want to split the file by the first 3 digits of the Article Key?" + Environment.NewLine + 
                        "Enter y for yes or n for no");
                    jsonInfo.strAns = Console.ReadLine();

                    jsonInfo.intAns = 0;

                    if (jsonInfo.strAns == "y" || jsonInfo.strAns == "Y" || jsonInfo.strAns == "Yes" || jsonInfo.strAns == "YES" || jsonInfo.strAns == "yes")
                    {
                        jsonInfo.intAns = 1;
                        Console.WriteLine("Do you want all of the Catalogs in 1 file or separate files?" + Environment.NewLine +
                        "Enter 1 for 1 file or s for seperate");
                        jsonInfo.strAns2 = Console.ReadLine();
                        if (jsonInfo.strAns2.Trim() != "1")
                        {
                            jsonInfo.intAns = 2;
                        }


                    }

                    jsonInfo.fullFilePath = jsonInfo.file.FileName;
                    jsonInfo.reader = new StreamReader(jsonInfo.fullFilePath);
                    jsonInfo.orgJsonTxt = jsonInfo.reader.ReadToEnd();
                    jsonInfo.dirFn = jsonInfo.fullFilePath.Split('.');
                    jsonInfo.directory = jsonInfo.dirFn[0];
                    jsonInfo.updatedFilePath = jsonInfo.directory + " (Updated)" + ".json";
                    jsonInfo.orgJsonObjects = jsonInfo.orgJsonTxt.Split('}');

                    string updatedJson = "";

                    foreach(string s in jsonInfo.orgJsonObjects) {
                        string akAtt = jsonInfo.rm.MatchRegex(s, jsonInfo.akRe);
                        string onAtt = jsonInfo.rm.MatchRegex(s, jsonInfo.onRe);
                        string vknAtt = jsonInfo.rm.MatchRegex(s, jsonInfo.vknRe);
                        string ctAtt = jsonInfo.rm.MatchRegex(s, jsonInfo.ctRe);
                        string cidAtt = jsonInfo.rm.MatchRegex(s, jsonInfo.cidRe);
                        string lcidAtt = jsonInfo.rm.MatchRegex(s, jsonInfo.lcidRe);
                        string sidAtt = jsonInfo.rm.MatchRegex(s, jsonInfo.sidRe);
                        jsonInfo.id = "";
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
                            if(jsonInfo.intAns == 1 || jsonInfo.intAns == 2) {
                                jsonInfo.currArtKey3Dig = int.Parse(ArtKey3Dig1[0]);

                                if (jsonInfo.currArtKey3Dig != jsonInfo.prevArtKey3Dig && jsonInfo.prevArtKey3Dig != 000){
                                        jsonInfo.newCatalog = true;
                                    }
                            }
                            jsonInfo.id += jsonInfo.akIdPrefix;
                            jsonInfo.id += artKey;
                        }
                        if (ons.Length > 1){
                            string ordNum1 = ons[1].Replace(',', ' ');
                            ordNum1 = ordNum1.Replace('"', ' ');
                            ordNum1 = ordNum1.Replace('\\', ' ');
                            string ordNum = ordNum1.Trim();
                            jsonInfo.id += jsonInfo.onIdPrefix;
                            jsonInfo.id += ordNum;
                        }
                        if (vs.Length > 1){
                            string vkn1 = vs[1].Replace(',', ' ');
                            vkn1 = vkn1.Replace('"', ' ');
                            vkn1 = vkn1.Replace('\\', ' ');
                            string vkn = vkn1.Trim();
                            jsonInfo.id += jsonInfo.vknIdPrefix;
                            jsonInfo.id += vkn;
                        }
                        if (cts.Length > 1){
                            string ct1 = cts[1].Replace(',', ' ');
                            ct1 = ct1.Replace('"', ' ');
                            ct1 = ct1.Replace('\\', ' ');
                            string ct = ct1.Trim();
                            jsonInfo.id += jsonInfo.ctIdPrefix;
                            jsonInfo.id += ct;
                        }
                        if (cids.Length > 1){
                            string cid1 = cids[1].Replace(',', ' ');
                            cid1 = cid1.Replace('"', ' ');
                            cid1 = cid1.Replace('\\', ' ');
                            string cid = cid1.Trim();
                            jsonInfo.id += jsonInfo.cidIdPrefix;
                            jsonInfo.id += cid;
                        }
                        if (lcids.Length > 1){
                            string lcid1 = lcids[1].Replace(',', ' ');
                            lcid1 = lcid1.Replace('"', ' ');
                            lcid1 = lcid1.Replace('\\', ' ');
                            string lcid = lcid1.Trim();
                            jsonInfo.id += jsonInfo.lcidIdPrefix;
                            jsonInfo.id += lcid;
                        }
                        if (sids.Length > 1){
                            string sid1 = sids[1].Replace(',', ' ');
                            sid1 = sid1.Replace('"', ' ');
                            sid1 = sid1.Replace('\\', ' ');
                            string sid = sid1.Trim();
                            jsonInfo.id += jsonInfo.sidIdPrefix;
                            jsonInfo.id += sid;
                            jsonInfo.id += jsonInfo.idSuffix;
                            jsonInfo.id += akAtt;
                        }
                        
                        if(akAtt != string.Empty) {
                            if(jsonInfo.newCatalog == true)
                            {
                                updatedJson += Environment.NewLine + "}" + Environment.NewLine + "}";

                                if (jsonInfo.intAns == 1)
                                {
                                    updatedJson += Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                                    updatedJson += "////BREAK BETWEEN CONTENT THAT SHOULD BE USED IN TOPAZ";
                                    updatedJson += Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                                }
                                else
                                {
                                    jsonInfo.rep.ReplaceMany(jsonInfo.directory + "-" + jsonInfo.prevArtKey3Dig.ToString() + ".json", updatedJson);
                                    jsonInfo.fileCnt += 1;
                                    updatedJson = "";
                                }
                                updatedJson += jsonInfo.rep.getFileStart();
                            }
                            string newObject = s.Replace(akAtt, jsonInfo.id);
                            if (jsonInfo.newCatalog == true)
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

                        jsonInfo.prevArtKey3Dig = jsonInfo.currArtKey3Dig;
                        jsonInfo.newCatalog = false;


                    }

                    if(jsonInfo.intAns == 0 || jsonInfo.intAns == 1)
                    {
                        jsonInfo.rep.ReplaceMany(jsonInfo.updatedFilePath, updatedJson);
                    }
                    else
                    {
                        jsonInfo.rep.ReplaceMany(jsonInfo.directory + "-" + jsonInfo.prevArtKey3Dig.ToString() + ".json", updatedJson);
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
