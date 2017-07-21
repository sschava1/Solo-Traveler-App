using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Xml;

namespace SoloTravelerApp.ServiceLayer
{
    public class ServiceCall
    {
        /// <summary>
        /// this method implements the Crime data service endpoint
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public static string GetCrimeData(int zipCode)
        {
            try
            {
                string latLongReqURL = ServiceUtils.CreateLatLongURL(zipCode.ToString());
                Stream responseStream = ServiceUtils.MakeRequest(latLongReqURL);
                String respString = ServiceUtils.RespStreamToString(responseStream);
                string lat_long = ServiceUtils.GetLongLat(respString);
                if (lat_long == null) return "Invalid zipcode";

                StringBuilder crimeData = new StringBuilder();
                List<string> crimeList = CrimeDataServiceUtils.GetCrimeList();

                string requestUrl = CrimeDataServiceUtils.CreateCrimeDataReqURL(zipCode);
                string responseString = ServiceUtils.WebString(requestUrl);
                XmlDocument xmlDoc = ServiceUtils.RespStringToXmlDoc(responseString);
                XmlDocument xmlCrimeDataDoc = null;
                if (xmlDoc != null)
                {
                    xmlCrimeDataDoc = CrimeDataServiceUtils.GetCrimeDataDoc(crimeList, xmlDoc, zipCode);

                }
                if (xmlCrimeDataDoc != null)
                {
                    return ServiceUtils.XmlDocToString(xmlCrimeDataDoc);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            
            return "Invalid ZipCode";

        }

        /// <summary>
        /// this method handles the event of click on Store Search service retrieve button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static string GetNearestStoreData(string inputZip, string type)
        {

            Weather_NearestStore_ServiceRef.OmniWSDLServiceInterfaceClient nearestStoreRef = new Weather_NearestStore_ServiceRef.OmniWSDLServiceInterfaceClient();
            

            int inputVal;

            if (inputZip.Equals("") || type.Equals(""))
            {
                return "Please provide valid input";
            }

            if (!int.TryParse(inputZip, out inputVal))
            {
                return "Invalid ZipCode";
            }

            string xml = nearestStoreRef.FindNearestStore(inputZip, type);
            
            return xml;


        }

        public static string GetWeatherData(string zipcode, DateTime date)
        {
            Weather_NearestStore_ServiceRef.OmniWSDLServiceInterfaceClient servClient = new Weather_NearestStore_ServiceRef.OmniWSDLServiceInterfaceClient();
            string response = servClient.GetFutureWeatherData(zipcode, date);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Entity.WeatherDataResponse weathDatResp = serializer.Deserialize<Entity.WeatherDataResponse>(response);
            string htmlResp = ConvertWeatherRespToHTML(weathDatResp);

            return htmlResp;
        }

        private static string ConvertWeatherRespToHTML(Entity.WeatherDataResponse weathDatResp)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);

            htmlWriter.RenderBeginTag(HtmlTextWriterTag.H1);
            htmlWriter.Write("Weather Forecast");
            htmlWriter.RenderEndTag();
            htmlWriter.AddAttribute(HtmlTextWriterAttribute.Border, "1");
            htmlWriter.AddAttribute(HtmlTextWriterAttribute.Align, "center");
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Table);
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Tbody);

            foreach (Entity.WeatherDataResponseDatum data in weathDatResp.daily.data)
            {
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Tr);

                htmlWriter.AddAttribute(HtmlTextWriterAttribute.Rowspan, "6");
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
                htmlWriter.Write(FromUnixTime(data.time));
                htmlWriter.RenderEndTag();
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
                htmlWriter.Write("Summary");
                htmlWriter.RenderEndTag();
                htmlWriter.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
                htmlWriter.Write(data.summary);
                htmlWriter.RenderEndTag();

                htmlWriter.RenderEndTag();

                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Tr);
                
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
                htmlWriter.Write("Temperature");
                htmlWriter.RenderEndTag();
                htmlWriter.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
                htmlWriter.Write(((data.temperatureMin + data.temperatureMax)/2));
                htmlWriter.RenderEndTag();

                htmlWriter.RenderEndTag();

                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Tr);

                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
                htmlWriter.Write("Humidity");
                htmlWriter.RenderEndTag();
                htmlWriter.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
                htmlWriter.Write(data.humidity);
                htmlWriter.RenderEndTag();

                htmlWriter.RenderEndTag();

                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Tr);

                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
                htmlWriter.Write("Windspeed");
                htmlWriter.RenderEndTag();
                htmlWriter.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
                htmlWriter.Write(data.windSpeed);
                htmlWriter.RenderEndTag();

                htmlWriter.RenderEndTag();

                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Tr);

                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
                htmlWriter.Write("Visibility");
                htmlWriter.RenderEndTag();
                htmlWriter.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
                htmlWriter.Write(data.visibility);
                htmlWriter.RenderEndTag();

                htmlWriter.RenderEndTag();

                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Tr);

                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
                htmlWriter.Write("UV Index");
                htmlWriter.RenderEndTag();
                htmlWriter.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
                htmlWriter.Write(data.uvIndex);
                htmlWriter.RenderEndTag();

                htmlWriter.RenderEndTag();
                
            }

            htmlWriter.RenderEndTag();
            htmlWriter.RenderEndTag();
            return htmlWriter.InnerWriter.ToString();
        }

        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }
    }
}