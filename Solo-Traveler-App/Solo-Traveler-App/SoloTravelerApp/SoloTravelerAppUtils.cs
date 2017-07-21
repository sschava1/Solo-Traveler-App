using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Xsl;

namespace SoloTravelerApp
{
    public class SoloTravelerAppUtils
    {
        
        public static string GetXmlFormattedResponse(string xml)
        {

            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.LoadXml(xml);

                string output = UtilitiesLibrary.AppUtilityClass.XmlDocToString(xmlDoc);

                return String.Format("<pre>{0}</pre>", HttpUtility.HtmlEncode(output));
            }
            catch (Exception e)
            {
                return xml;
            }

        }
        
        public static string ConvertXMLToHTML(string xmlStr,bool isFile, string XslRelativePath)
        {
            try
            {
                XmlDocument crimeDataXml = new XmlDocument();
                string path = HttpRuntime.AppDomainAppPath;
                if (isFile)
                {
                    crimeDataXml.Load(path+xmlStr);
                }
                else
                {
                    crimeDataXml.LoadXml(xmlStr);
                }

                StringWriter htmlStringWriter = new StringWriter();

                XslCompiledTransform xslTrans = new XslCompiledTransform();
                xslTrans.Load(path+ XslRelativePath);
                xslTrans.Transform(crimeDataXml.CreateNavigator(), new XsltArgumentList(), htmlStringWriter);

                return htmlStringWriter.ToString();
            }
            catch (Exception ex)
            {
                return "failure";
            }
        }
    }
}