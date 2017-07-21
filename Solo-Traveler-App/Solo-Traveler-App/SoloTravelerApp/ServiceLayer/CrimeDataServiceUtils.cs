using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SoloTravelerApp.ServiceLayer
{
    /// <summary>
    /// This class contains the utility methods related to the Crime Data Service
    /// </summary>
    public class CrimeDataServiceUtils
    {
        /// <summary>
        /// this method extracts the provided crimedata in the XML format and returns it in XML format
        /// </summary>
        /// <param name="crimeList"></param>
        /// <param name="xmlDoc"></param>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public static XmlDocument GetCrimeDataDoc(List<string> crimeList, XmlDocument xmlDoc, int zipCode)
        {
            XmlDocument xmlCrimeDataDoc = new XmlDocument();
            XmlNode rootNode = xmlCrimeDataDoc.CreateElement("CrimeData");
            XmlAttribute attribute = xmlCrimeDataDoc.CreateAttribute("zip");
            attribute.Value = zipCode.ToString();
            rootNode.Attributes.Append(attribute);
            xmlCrimeDataDoc.AppendChild(rootNode);

            foreach (string crime in crimeList)
            {
                XmlNodeList nodeList = xmlDoc.GetElementsByTagName(crime);
                if (nodeList.Count == 0) { return null; }
                string val = nodeList[0].InnerText;
                XmlNode crimeNode = xmlCrimeDataDoc.CreateElement(crime);
                crimeNode.InnerText = val;
                rootNode.AppendChild(crimeNode);
            }

            return xmlCrimeDataDoc;
        }

        /// <summary>
        /// this method has the list of crimedata to be extracted
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCrimeList()
        {
            List<string> crimeList = new List<string>();
            crimeList.Add("ViolentCrime");
            crimeList.Add("MurderAndManslaughter");
            crimeList.Add("ForcibleRape");
            crimeList.Add("Robbery");
            crimeList.Add("AggravatedAssault");
            crimeList.Add("PropertyCrime");
            crimeList.Add("Burglary");
            crimeList.Add("LarcenyTheft");
            crimeList.Add("MotorVehicleTheft");
            crimeList.Add("Arson");
            return crimeList;

        }

        /// <summary>
        /// this method creates the request URL for the geodataservice crime data service
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public static string CreateCrimeDataReqURL(int zipCode)
        {
            string requestUrl = "https://azure.geodataservice.net/GeoDataService.svc/" +
                "GetUSDemographics?includecrimedata=true&zipcode=" +
                                    zipCode;
            return requestUrl;
        }
    }
}