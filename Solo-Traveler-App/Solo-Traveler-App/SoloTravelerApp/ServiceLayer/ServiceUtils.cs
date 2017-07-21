using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;

namespace SoloTravelerApp.ServiceLayer
{
    public class ServiceUtils
    {
        /// <summary>
        /// Makes the get request on given url and returns the response
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        public static Stream MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                request.Timeout = 120000;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                return response.GetResponseStream();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// converts the XML doc to string
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        public static string XmlDocToString(XmlDocument xmlDoc)
        {
            var stringWriter = new StringWriter();
            var xmlTextWriter = XmlWriter.Create(stringWriter);
            xmlDoc.WriteTo(xmlTextWriter);
            xmlTextWriter.Flush();
            return stringWriter.GetStringBuilder().ToString();
        }

        /// <summary>
        /// converts a response stream into an XML document
        /// </summary>
        /// <param name="responseStream"></param>
        /// <returns></returns>
        public static XmlDocument RespStreamToXmlDoc(Stream responseStream)
        {
            if (responseStream == null) return null;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(responseStream);
            return xmlDoc;
        }

        public static XmlDocument RespStringToXmlDoc(string responseString)
        {
            if (responseString == null) return null;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(responseString);
            return xmlDoc;
        }

        /// <summary>
        /// converts a response stream into a string
        /// </summary>
        /// <param name="responseStream"></param>
        /// <returns></returns>
        public static string RespStreamToString(Stream responseStream)
        {
            if (responseStream == null) return null;
            var reader = new StreamReader(responseStream);

            return reader.ReadToEnd();
        }

        
        public static string WebString(string url)
        {
            Web2StringServiceReference.ServiceClient serv = new Web2StringServiceReference.ServiceClient();
            string response = serv.GetWebContent(url);
            return response;
        }
        /// <summary>
        /// creates the URL for geocode api
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        public static string CreateLatLongURL(string zipcode)
        {
            string APIkey = "e108181451453afac894a3993c941549edcc341";
            string requestUrl = "https://api.geocod.io/v1/geocode?q=" + zipcode + "&api_key=" + APIkey;
            return requestUrl;
        }

        /// <summary>
        /// retrieves the latitude longitude from the geocode response
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static string GetLongLat(string response)
        {
            if (response == null) return null;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Entity.GeoCodeResponse geoCodeRepObj = serializer.Deserialize<Entity.GeoCodeResponse>(response);
            string lat_long = geoCodeRepObj.results[0].location.lat + ",";
            lat_long += geoCodeRepObj.results[0].location.lng;


            return lat_long;
        }
    }
}