using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsonIdEditor
{
    class AttributeExtractor
    {

        public void ExtractAttribute(string s, string re, string attIdPrefix, JsonInfo jsonInfo, bool artKey = false)
        {

            jsonInfo.attText = jsonInfo.rm.MatchRegex(s, re);
            jsonInfo.atts = jsonInfo.attText.Split(':');
            if (jsonInfo.atts.Length > 1)
            {
                jsonInfo.att = jsonInfo.atts[1].Replace(',', ' ');
                jsonInfo.att = jsonInfo.att.Replace('"', ' ');
                jsonInfo.att = jsonInfo.att.Replace('\\', ' ');
                jsonInfo.att = jsonInfo.att.Trim();

                if (artKey == true) {
                    jsonInfo.akAtt = string.Copy(jsonInfo.att);
                    jsonInfo.ArtKey3Dig1 = jsonInfo.att.Split('.');

                    if (jsonInfo.intAns == 1 || jsonInfo.intAns == 2)
                    {
                        jsonInfo.currArtKey3Dig = int.Parse(jsonInfo.ArtKey3Dig1[0]);

                        if (jsonInfo.currArtKey3Dig != jsonInfo.prevArtKey3Dig && jsonInfo.prevArtKey3Dig != 000)
                        {
                            jsonInfo.newCatalog = true;
                        }
                    }
                }


            }
            else
            {
                jsonInfo.att = string.Copy(jsonInfo.attText);
            }

            jsonInfo.idCurr += attIdPrefix;
            jsonInfo.idCurr += jsonInfo.att;
        }
}
}
