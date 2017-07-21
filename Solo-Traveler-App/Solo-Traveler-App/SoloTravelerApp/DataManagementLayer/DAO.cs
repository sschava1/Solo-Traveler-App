using System;
using System.Web;
using System.Xml;
using SoloTravelerApp.Entity;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace SoloTravelerApp.DataManagementLayer
{
    public class DAO
    {
        public static bool AddUser(User user)
        {
            try
            {
                if (!CheckForUserFile())
                {
                    return false;
                }
                XmlDocument userDoc = new XmlDocument();
                string path = HttpRuntime.AppDomainAppPath + "/App_Data/Users.xml";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/Users.xml";
                userDoc.Load(path);
                XmlNode parentElement = userDoc.DocumentElement;

                XmlElement childElement = userDoc.CreateElement("User");
                XmlElement baseElement = childElement;
                parentElement.AppendChild(childElement);
                parentElement = childElement;

                childElement = userDoc.CreateElement("Name");
                parentElement.AppendChild(childElement);
                parentElement = childElement;

                childElement = userDoc.CreateElement("First");
                childElement.InnerText = user.Firstname;
                parentElement.AppendChild(childElement);
                childElement = userDoc.CreateElement("Last");
                childElement.InnerText = user.Lastname;
                parentElement.AppendChild(childElement);

                parentElement = baseElement;
                childElement = userDoc.CreateElement("Credential");
                parentElement.AppendChild(childElement);
                parentElement = childElement;

                childElement = userDoc.CreateElement("Id");
                childElement.InnerText = user.Id; 
                parentElement.AppendChild(childElement);
                childElement = userDoc.CreateElement("Password");
                string pwd = user.Pwd;
                childElement.InnerText = pwd;
                parentElement.AppendChild(childElement);

                parentElement = baseElement;
                childElement = userDoc.CreateElement("Contact");
                parentElement.AppendChild(childElement);
                parentElement = childElement;

                childElement = userDoc.CreateElement("Email");
                childElement.InnerText = user.Email;
                parentElement.AppendChild(childElement);
                childElement = userDoc.CreateElement("Phone");
                childElement.InnerText = user.Phone;
                parentElement.AppendChild(childElement);
                
                userDoc.Save(path);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public static bool DeleteUser(string username)
        {
            try
            {
                if (!CheckForUserFile())
                {
                    return false;
                }
                string path = HttpRuntime.AppDomainAppPath + "/App_Data/Users.xml";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/Users.xml";
                XDocument userDoc = XDocument.Load(path);
                userDoc.Root.Descendants("User").Where(x => (string)x.Element("Credential").Element("Id") == username).Remove();
                userDoc.Save(path);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public static bool UpdateUser(string username, string element, string value)
        {

            try
            {
                if (!CheckForUserFile())
                {
                    return false;
                }
                string path = HttpRuntime.AppDomainAppPath + "/App_Data/Users.xml";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/Users.xml";
                XDocument userDoc = XDocument.Load(path);
                XElement userToUpdate =  userDoc.Root.Descendants("User").Single(x => (string)x.Element("Credential").Element("Id") == username);
                userToUpdate.Descendants(element).First().Value = value;
                userDoc.Save(path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string ReadUserDetail(string username, string element)
        {
            try
            {
                if (!CheckForUserFile())
                {
                    return "Not Found";
                }
                string path = HttpRuntime.AppDomainAppPath + "/App_Data/Users.xml";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/Users.xml";
                XDocument userDoc = XDocument.Load(path);
                XElement userToRead = userDoc.Root.Descendants("User").Single(x => (string)x.Element("Credential").Element("Id") == username);
                string value = userToRead.Descendants(element).First().Value;
                return value;
            }
            catch (Exception ex)
            {
                return "Not Found";
            }
        }

        public static bool CheckForUser(string username)
        {
            try
            {
                if (!CheckForUserFile())
                {
                    return false;
                }
                string path = HttpRuntime.AppDomainAppPath + "/App_Data/Users.xml";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/Users.xml";
                XDocument userDoc = XDocument.Load(path);
                XElement userToUpdate = userDoc.Root.Descendants("User").Single(x => (string)x.Element("Credential").Element("Id") == username);
                if(userToUpdate != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool AddStaff(Entity.StaffMember staffMember)
        {
            try
            {
                if (!CheckForStaffFile())
                {
                    return false;
                }
                XmlDocument staffDoc = new XmlDocument();
                string path = HttpRuntime.AppDomainAppPath + "/App_Data/Staff.xml";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/Staff.xml";
                staffDoc.Load(path);
                XmlNode parentElement = staffDoc.DocumentElement;

                XmlElement childElement = staffDoc.CreateElement("Member");
                XmlElement baseElement = childElement;
                parentElement.AppendChild(childElement);
                parentElement = childElement;

                childElement = staffDoc.CreateElement("Name");
                parentElement.AppendChild(childElement);
                parentElement = childElement;

                childElement = staffDoc.CreateElement("First");
                childElement.InnerText = staffMember.Firstname;
                parentElement.AppendChild(childElement);
                childElement = staffDoc.CreateElement("Last");
                childElement.InnerText = staffMember.Lastname;
                parentElement.AppendChild(childElement);

                parentElement = baseElement;
                childElement = staffDoc.CreateElement("Credential");
                parentElement.AppendChild(childElement);
                parentElement = childElement;

                childElement = staffDoc.CreateElement("Id");
                childElement.InnerText = staffMember.Id;
                parentElement.AppendChild(childElement);
                childElement = staffDoc.CreateElement("Password");
                string pwd = staffMember.Pwd;
                childElement.InnerText = pwd;
                parentElement.AppendChild(childElement);

                parentElement = baseElement;
                childElement = staffDoc.CreateElement("Contact");
                parentElement.AppendChild(childElement);
                parentElement = childElement;

                childElement = staffDoc.CreateElement("Email");
                childElement.InnerText = staffMember.Email;
                parentElement.AppendChild(childElement);
                childElement = staffDoc.CreateElement("Phone");
                childElement.InnerText = staffMember.Phone;
                parentElement.AppendChild(childElement);

                parentElement = baseElement;
                childElement = staffDoc.CreateElement("Role");
                childElement.InnerText = staffMember.Role;
                parentElement.AppendChild(childElement);

                staffDoc.Save(path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeleteStaff(string id)
        {
            try
            {
                if (!CheckForStaffFile())
                {
                    return false;
                }
                string path = HttpRuntime.AppDomainAppPath + "/App_Data/Staff.xml";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/Staff.xml";
                XDocument staffDoc = XDocument.Load(path);
                staffDoc.Root.Descendants("Member").Where(x => (string)x.Element("Credential").Element("Id") == id).Remove();
                staffDoc.Save(path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool UpdateStaff(string id, string element, string value)
        {
            try
            {
                if (!CheckForStaffFile())
                {
                    return false;
                }
                string path = HttpRuntime.AppDomainAppPath + "/App_Data/Staff.xml";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/Staff.xml";
                XDocument staffDoc = XDocument.Load(path);
                XElement staffToUpdate = staffDoc.Root.Descendants("Member").Single(x => (string)x.Element("Credential").Element("Id") == id);
                staffToUpdate.Descendants(element).First().Value = value;
                staffDoc.Save(path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string ReadStaffDetail(string id, string element)
        {
            try
            {
                if (!CheckForStaffFile())
                {
                    return "Not Found";
                }
                string path = HttpRuntime.AppDomainAppPath + "/App_Data/Staff.xml";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/Staff.xml";
                XDocument staffDoc = XDocument.Load(path);
                XElement staffToRead = staffDoc.Root.Descendants("Member").Single(x => (string)x.Element("Credential").Element("Id") == id);
                string value = staffToRead.Descendants(element).First().Value;
                return value;
            }
            catch (Exception ex)
            {
                return "Not Found";
            }
        }

        public static bool CheckForStaff(string id)
        {
            try
            {
                if (!CheckForStaffFile())
                {
                    return false;
                }
                string path = HttpRuntime.AppDomainAppPath + "/App_Data/Staff.xml";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/Staff.xml";
                XDocument staffDoc = XDocument.Load(path);
                XElement staffToUpdate = staffDoc.Root.Descendants("Member").Single(x => (string)x.Element("Credential").Element("Id") == id);
                if (staffToUpdate != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool PromoteUser(string id, string role)
        {
            try
            {
                bool success = true;
                success = CheckForUserFile();
                string path = HttpRuntime.AppDomainAppPath + "/App_Data/";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/";
                XDocument userDoc = XDocument.Load(path + "Users.xml");
                XElement userElement = userDoc.Root.Descendants("User").Single(x => (string)x.Element("Credential").Element("Id") == id);
                StaffMember member = new StaffMember();
                member.Firstname = userElement.Element("Name").Element("First").Value;
                member.Lastname = userElement.Element("Name").Element("Last").Value;
                member.Id = userElement.Element("Credential").Element("Id").Value;
                member.Pwd = userElement.Element("Credential").Element("Password").Value;
                member.Email = userElement.Element("Contact").Element("Email").Value;
                member.Phone = userElement.Element("Contact").Element("Phone").Value;
                member.Role = role;
                success = AddStaff(member);
                userElement.Remove();
                userDoc.Save(path + "Users.xml");
                return success;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DemoteStaff(string id)
        {
            try
            {
                bool success = true;
                success = CheckForStaffFile();
                string path = HttpRuntime.AppDomainAppPath + "/App_Data/";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/";
                XDocument staffDoc = XDocument.Load(path + "Staff.xml");
                XElement staffElement = staffDoc.Root.Descendants("Member").Single(x => (string)x.Element("Credential").Element("Id") == id);
                User user = new User();
                user.Firstname = staffElement.Element("Name").Element("First").Value;
                user.Lastname = staffElement.Element("Name").Element("Last").Value;
                user.Id = staffElement.Element("Credential").Element("Id").Value;
                user.Pwd = staffElement.Element("Credential").Element("Password").Value;
                user.Email = staffElement.Element("Contact").Element("Email").Value;
                user.Phone = staffElement.Element("Contact").Element("Phone").Value;
                success = AddUser(user);
                staffElement.Remove();
                staffDoc.Save(path + "Staff.xml");
                return success;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool CheckForUserFile()
        {
            try
            {

                string path = HttpRuntime.AppDomainAppPath + "/App_Data/Users.xml";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/Staff.xml";

                if (!File.Exists(path))
                {
                    XDocument xmlFile = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"));
                    xmlFile.Add(new XElement("Users"));
                    xmlFile.Save(path);
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static bool CheckForStaffFile()
        {
            try
            {

                string path = HttpRuntime.AppDomainAppPath + "/App_Data/Staff.xml";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/Staff.xml";

                if (!File.Exists(path))
                {
                    XDocument xmlFile = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"));
                    xmlFile.Add(new XElement("Staff"));
                    xmlFile.Save(path);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static int GetStaffCount(string role)
        {
            try
            {
                if (!CheckForStaffFile())
                {
                    return 1;
                }
                string path = HttpRuntime.AppDomainAppPath + "/App_Data/Staff.xml";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/Staff.xml";
                XDocument staffDoc = XDocument.Load(path);
                IEnumerable<XElement> elemntList = staffDoc.Root.Descendants("Member").Where(x => (string)x.Element("Role") == role);
                int count = 0;
                foreach(XElement xElm in elemntList)
                {
                    count++;
                }
                return count;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public static List<string> GetIdsByRole(string role)
        {
            List<string> idList = new List<string>();
            try
            {
                if (!CheckForStaffFile())
                {
                    return idList;
                }
                string path = HttpRuntime.AppDomainAppPath + "/App_Data/Staff.xml";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/Staff.xml";
                XDocument staffDoc = XDocument.Load(path);
                IEnumerable<XElement> elemntList = staffDoc.Root.Descendants("Member").Where(x => (string)x.Element("Role") == role);
                foreach (XElement xElm in elemntList)
                {
                    string id = (string)xElm.Element("Credential").Element("Id");
                    idList.Add(id);
                }
                return idList;
            }
            catch (Exception ex)
            {
                return idList;
            }
        }

        public static List<string> GetAllUserIds()
        {
            List<string> idList = new List<string>();
            try
            {
                if (!CheckForStaffFile())
                {
                    return idList;
                }
                string path = HttpRuntime.AppDomainAppPath + "/App_Data/Users.xml";
                //string path = "C:/Users/Shirish/Documents/visual studio 2017/Projects/Assignment_5/SoloTravelerApp/DataManagementLayer/Database/Staff.xml";
                XDocument staffDoc = XDocument.Load(path);
                IEnumerable<XElement> elemntList = staffDoc.Root.Descendants("User").Where(x => (string)x.Element("Credential").Element("Id") != "");
                foreach (XElement xElm in elemntList)
                {
                    idList.Add((string)xElm.Element("Credential").Element("Id"));
                }
                return idList;
            }
            catch (Exception ex)
            {
                return idList;
            }
        }
    }
}
