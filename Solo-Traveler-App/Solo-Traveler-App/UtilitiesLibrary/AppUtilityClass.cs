using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Xsl;

namespace UtilitiesLibrary
{
    public class AppUtilityClass
    {
        private static byte[] seed = ASCIIEncoding.ASCII.GetBytes("cse44598");

        public static string Encrypt(string strToEnc)
        {
            if (String.IsNullOrEmpty(strToEnc))
            {
                throw new ArgumentNullException("The input cannot be empty or null!");
            }
            SymmetricAlgorithm saProvider = DES.Create();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, saProvider.CreateEncryptor(seed, seed), CryptoStreamMode.Write);
            StreamWriter sWriter = new StreamWriter(cStream);
            sWriter.Write(strToEnc);
            sWriter.Flush(); // Buffer flush is necessary when switching writing modes
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.GetBuffer(), 0, (int)mStream.Length);

        }

        public static string Decrypt(string strToDec)
        {

            if (String.IsNullOrEmpty(strToDec))
            {
                throw new ArgumentNullException("The string cannot be empty or null!");
            }
            SymmetricAlgorithm saProvider = DES.Create();
            MemoryStream memStream = new MemoryStream(Convert.FromBase64String(strToDec));
            CryptoStream cStream = new CryptoStream(memStream, saProvider.CreateDecryptor(seed, seed), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cStream);
            return reader.ReadLine();

        }

        public static bool ValidatePhoneNum(string number)
        {
            try
            {
                number = number.Trim();
                string subNum = number.Substring(0, 5);
                int num = 0;
                if (number.Length != 10)
                {
                    return false;
                }
                if (!int.TryParse(subNum, out num))
                {
                    return false;
                }
                subNum = number.Substring(5);
                if (!int.TryParse(subNum, out num))
                {
                    return false;
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        
        public static string XmlDocToString(XmlDocument xmlDoc)
        {
            var stringWriter = new StringWriter();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            var xmlTextWriter = XmlWriter.Create(stringWriter, settings);
            xmlDoc.WriteTo(xmlTextWriter);
            xmlTextWriter.Flush();
            return stringWriter.GetStringBuilder().ToString();
        }
        
    }
}