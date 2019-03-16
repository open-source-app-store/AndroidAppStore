using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Bonrix_App_Store.Class;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Configuration;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Bonrix_App_Store.Services
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetApp_List()
        {

            try
            {
                string jsonresponse = "";
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<ClsAppList> LstClsAppList = new List<ClsAppList>();
                GetClsAppList objGetClsAppList = new GetClsAppList();

                string DomainName = HttpContext.Current.Request.Url.Host;
                //string DomainName = "myappstore.co.in";
                string MainDomain= ConfigurationManager.AppSettings["MainDomain"].ToString();
                string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();

                if (DomainName == MainDomain)
                {
                    if (System.IO.Directory.Exists(StoreDirectory))
                    {
                       // StoreDirectory = StoreDirectory + "\\" + DomainName + "\\APP";
                        string[] subdirectoryEntries = Directory.GetDirectories(StoreDirectory);

                        if (subdirectoryEntries.Length > 0)
                        {
                            foreach (var directory in subdirectoryEntries)
                            {
                                DirectoryInfo dirInfo = new DirectoryInfo(directory + "\\StoreAPK");
                                
                                if (System.IO.Directory.Exists(dirInfo.ToString()))
                                {
                                    string[] innerSubdirectoryEntries = Directory.GetFiles(dirInfo.ToString(), "*.apk");

                                    if (innerSubdirectoryEntries.Length > 0)
                                    {
                                        foreach (var innerDirectory in innerSubdirectoryEntries)
                                        {
                                            ClsAppList objClsAppList = new ClsAppList();
                                            DirectoryInfo innerDirInfo = new DirectoryInfo(innerDirectory);

                                            objClsAppList.ApkName = innerDirInfo.Name.ToString();
                                            int StringPosition = innerDirectory.IndexOf("Raw_Details");
                                            string path = innerDirectory.Substring(StringPosition, innerDirectory.Length - StringPosition);

                                            if (System.IO.File.Exists(directory + "\\StoreAPK" + "\\" + innerDirInfo.Name.Substring(0, innerDirInfo.Name.Length - 4) + ".txt"))
                                            {
                                                //getDetails_Directory = System.IO.File.ReadAllText(StoreDirectory + "\\" + dirInfo.Name.Substring(0, dirInfo.Name.Length - 4) + "\\.txt");
                                                var details = JObject.Parse(System.IO.File.ReadAllText(directory + "\\StoreAPK" + "\\" + innerDirInfo.Name.Substring(0, innerDirInfo.Name.Length - 4) + ".txt"));
                                                objClsAppList.Name = details["name"].ToString().Replace("\"", "").Trim();
                                                objClsAppList.Package = details["package"].ToString().Replace("\"", "").Trim();
                                                objClsAppList.Version = details["version"].ToString().Replace("\"", "").Trim();
                                            }
                                            objClsAppList.DateTime = innerDirInfo.CreationTime.ToShortDateString();
                                            objClsAppList.ImageUrl = "/Images/android_logo.jpg";
                                            objClsAppList.ApkPath = path.Replace("Raw_Details", "").Replace(@"\", "/");
                                            LstClsAppList.Add(objClsAppList);
                                        }
                                        
                                    }
                                    

                                   
                                }
                                
                            }
                            objGetClsAppList.Data = LstClsAppList;
                            objGetClsAppList.Status = "True";
                            objGetClsAppList.Message = "Total Store: " + subdirectoryEntries.Length.ToString();
                        }
                        else
                        {
                            objGetClsAppList.Status = "False";
                            objGetClsAppList.Message = "No Store Created.";
                        }
                    }
                    else
                    {
                        objGetClsAppList.Status = "False";
                        objGetClsAppList.Message = "Store Not Available.";
                    }
                }
                else
                {
                    //Getlist of SubDomain APK
                    DomainName = DomainName.Replace("." + MainDomain.ToString(), "");
                    if (System.IO.Directory.Exists(StoreDirectory + "\\" + DomainName))
                    {
                        StoreDirectory = StoreDirectory + "\\" + DomainName + "\\APP";
                        string[] subdirectoryEntries = Directory.GetFiles(StoreDirectory, "*.apk");

                        if (subdirectoryEntries.Length > 0)
                        {
                            foreach (var directory in subdirectoryEntries)
                            {
                                DirectoryInfo dirInfo = new DirectoryInfo(directory);
                                ClsAppList objClsAppList = new ClsAppList();

                                if (System.IO.File.Exists(StoreDirectory + "\\" + dirInfo.Name.Substring(0, dirInfo.Name.Length - 4) + ".txt"))
                                {
                                    //getDetails_Directory = System.IO.File.ReadAllText(StoreDirectory + "\\" + dirInfo.Name.Substring(0, dirInfo.Name.Length - 4) + "\\.txt");
                                    var details = JObject.Parse(System.IO.File.ReadAllText(StoreDirectory + "\\" + dirInfo.Name.Substring(0, dirInfo.Name.Length - 4) + ".txt"));
                                    objClsAppList.Name = details["name"].ToString().Replace("\"", "").Trim();
                                    objClsAppList.Package = details["package"].ToString().Replace("\"", "").Trim();
                                    objClsAppList.Version = details["version"].ToString().Replace("\"", "").Trim();
                                }
                                int StringPosition = directory.IndexOf("Raw_Details");
                                string path = directory.Substring(StringPosition, directory.Length - StringPosition);

                                objClsAppList.ApkName = dirInfo.Name.ToString();
                                objClsAppList.DateTime = dirInfo.CreationTime.ToShortDateString();
                                objClsAppList.ImageUrl = "../Images/android_logo.jpg";
                                objClsAppList.ApkPath = path.Replace("Raw_Details", "").Replace(@"\", "/");
                                LstClsAppList.Add(objClsAppList);
                            }
                            objGetClsAppList.Data = LstClsAppList;
                            objGetClsAppList.Status = "True";
                            objGetClsAppList.Message = "Total APK: " + subdirectoryEntries.Length.ToString();
                        }
                        else
                        {
                            objGetClsAppList.Status = "False";
                            objGetClsAppList.Message = "No APK Uploaded.";
                        }
                    }
                    else
                    {
                        objGetClsAppList.Status = "False";
                        objGetClsAppList.Message = "Store Not Available.";
                    }
                }

                jsonresponse = js.Serialize(objGetClsAppList);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.AddHeader("content-length", jsonresponse.Length.ToString());
                Context.Response.Flush();
                Context.Response.Write(jsonresponse);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                ClsLog.LogException(ex, "Error at Page Service-->GetApp_List");
            }
        }
    }
}
