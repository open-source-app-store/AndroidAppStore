using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bonrix_App_Store.Class;
using System.Configuration;
using System.IO;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Bonrix_App_Store.Store
{
    public partial class Home : System.Web.UI.Page
    {
        string subDomain = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //string DomainName = "www.myappstore.co.in";
                    string DomainName = HttpContext.Current.Request.Url.Host;
                    string MainDomain = ConfigurationManager.AppSettings["MainDomain"].ToString();
                    DomainName = DomainName.Replace("www.", "");
                    if (DomainName != MainDomain)
                    {
                        string Details_Directory = ConfigurationManager.AppSettings["Details_Directory"].ToString();
                        string getDetails_Directory = System.IO.File.ReadAllText(Details_Directory + "details.txt");
                        var details = JObject.Parse(getDetails_Directory);

                        string domain = details["domain"].ToString().Replace("\"", "").Trim();
                        DomainName = DomainName.Replace("." + MainDomain.ToString(), "");
                        //DomainName = DomainName.Replace("www.", "");
                        Response.Redirect("http://" + DomainName + domain + "/ClientStore/Home.aspx", false);
                    }
                    else
                    {
                        LoadCards();

                    }
                }

            }
            catch (Exception ex)
            {
                ClsLog.LogException(ex, "Error at Page Store Home-->OnLoad");
                Notification("Error at Page Store Home OnLoad", "error");
            }
        }
        protected void LoadCards()
        {
            try
            {
                int i = 0;
                int j = 0;
                string[] subdirectoryEntries = null;
                string Details_Directory = ConfigurationManager.AppSettings["Details_Directory"].ToString();
                string getDetails_Directory = System.IO.File.ReadAllText(Details_Directory + "details.txt");
                var details = JObject.Parse(getDetails_Directory);

                string domain = details["domain"].ToString().Replace("\"", "").Trim();
                string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();

                if (System.IO.File.Exists(Details_Directory + "\\myappstore.apk"))
                {
                    dwnldlink.Attributes["href"] = "http://" + domain.Substring(1).ToString() + "/Raw_Details/myappstore.apk";
                }

                if (Session["SearchValue"] != null)//For Search
                {
                    int k = 0;
                    DirectoryInfo FolderSearch = new DirectoryInfo(StoreDirectory);
                    FileSystemInfo[] lstFolderSearch = FolderSearch.GetFileSystemInfos("*" + Session["SearchValue"].ToString() + "*");

                    subdirectoryEntries = new string[lstFolderSearch.Length];
                    
                    foreach (FileSystemInfo foundFile in lstFolderSearch)
                    {
                        subdirectoryEntries[k] = foundFile.FullName;                      
                        k = k + 1;
                    }
                }
                else
                {
                    subdirectoryEntries = Directory.GetDirectories(StoreDirectory);
                }               
               
                foreach (var directory in subdirectoryEntries)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(directory);

                    HtmlGenericControl createDivMain = new HtmlGenericControl("div");
                    createDivMain.ID = "createDivMain" + i;
                    createDivMain.Attributes.Add("runat", "server");
                    createDivMain.Attributes.Add("class", "col-xl-4 col-md-6 col-12");

                    HtmlGenericControl createInfoBox = new HtmlGenericControl("div");
                    createInfoBox.ID = "createInfoBox" + i;
                    createInfoBox.Attributes.Add("runat", "server");

                    if (j == 0)
                    {
                        createInfoBox.Attributes.Add("class", "info-box bg-b-green");
                    }
                    else if (j == 1)
                    {
                        createInfoBox.Attributes.Add("class", "info-box bg-b-yellow");
                    }
                    else if (j == 2)
                    {
                        createInfoBox.Attributes.Add("class", "info-box bg-b-blue");
                    }
                    else if (j == 3)
                    {
                        createInfoBox.Attributes.Add("class", "info-box bg-b-pink");
                    }

                    if (j == 3)
                    {
                        j = 0;
                    }
                    else
                    {
                        j = j + 1;
                    }

                    string RowSpan = "";
                    RowSpan = "<span class=\"info-box-icon push-bottom\" ><i class=\"material-icons\" Style=\"margin: 18px 10px 10px 10px\">android</i></span>";
                    createInfoBox.InnerHtml = RowSpan;
                    RowSpan = "";
                    string[] subdirectoryEntriesApp = Directory.GetFiles(directory + "\\APP", "*.apk");

                    HtmlGenericControl createInfoBoxContent = new HtmlGenericControl("div");
                    createInfoBoxContent.ID = "createInfoBoxContent" + i;
                    createInfoBoxContent.Attributes.Add("runat", "server");
                    createInfoBoxContent.Attributes.Add("class", "info-box-content");

                    RowSpan = "<span class=\"info-box-number\">" + dirInfo.Name.ToString() + "</span>";
                    RowSpan += "<span class=\"info-box-text\">" + dirInfo.CreationTime.ToShortDateString() + "</span>";
                    RowSpan += "<span class=\"info-box-number\">" + subdirectoryEntriesApp.Length.ToString() + " APPS" + "</span>";
                    RowSpan += "<span class=\"info-box-text\"><a href=\"http://" + dirInfo.Name + domain + "/ClientStore/Home.aspx\">Goto App Store</a></span>";
                    createInfoBoxContent.InnerHtml = RowSpan;


                    createInfoBox.Controls.Add(createInfoBoxContent);
                    createDivMain.Controls.Add(createInfoBox);
                    DynamicDiv.Controls.Add(createDivMain);                  
                    i = i + 1;
                }
                if (Session["SearchValue"] != null)
                {
                    Session["SearchValue"] = null;//For Search                  
                }
            }
            catch (Exception ex)
            {
                ClsLog.LogException(ex, "Error at Page Store Home-->LoadCards");
                Notification("Error at Page Store Home", "error");
            }
        }

        protected void SearchCards()
        {
            try
            {
                int i = 0;
                int j = 0;
                string Details_Directory = ConfigurationManager.AppSettings["Details_Directory"].ToString();
                string getDetails_Directory = System.IO.File.ReadAllText(Details_Directory + "details.txt");
                var details = JObject.Parse(getDetails_Directory);

                string domain = details["domain"].ToString().Replace("\"", "").Trim();

                string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();
                string[] subdirectoryEntries = Directory.GetDirectories(StoreDirectory);

                if (System.IO.File.Exists(Details_Directory + "\\myappstore.apk"))
                {
                    dwnldlink.Attributes["href"] = "http://" + domain.Substring(1).ToString() + "/Raw_Details/myappstore.apk";
                }


                string directory = StoreDirectory + "\\" + Session["SearchValue"];
                DirectoryInfo dirInfo = new DirectoryInfo(directory);
                if (dirInfo.Exists)
                {
                    HtmlGenericControl createDivMain = new HtmlGenericControl("div");
                    createDivMain.ID = "createDivMain" + i;
                    createDivMain.Attributes.Add("runat", "server");
                    createDivMain.Attributes.Add("class", "col-xl-4 col-md-6 col-12");

                    HtmlGenericControl createInfoBox = new HtmlGenericControl("div");
                    createInfoBox.ID = "createInfoBox" + i;
                    createInfoBox.Attributes.Add("runat", "server");

                    if (j == 0)
                    {
                        createInfoBox.Attributes.Add("class", "info-box bg-b-green");
                    }

                    string RowSpan = "";
                    RowSpan = "<span class=\"info-box-icon push-bottom\" ><i class=\"material-icons\" Style=\"margin: 18px 10px 10px 10px\">android</i></span>";
                    createInfoBox.InnerHtml = RowSpan;

                    RowSpan = "";

                    string[] subdirectoryEntriesApp = Directory.GetFiles(directory + "\\APP", "*.apk");

                    HtmlGenericControl createInfoBoxContent = new HtmlGenericControl("div");
                    createInfoBoxContent.ID = "createInfoBoxContent" + i;
                    createInfoBoxContent.Attributes.Add("runat", "server");
                    createInfoBoxContent.Attributes.Add("class", "info-box-content");

                    RowSpan = "<span class=\"info-box-number\">" + dirInfo.Name.ToString() + "</span>";
                    RowSpan += "<span class=\"info-box-text\">" + dirInfo.CreationTime.ToShortDateString() + "</span>";
                    RowSpan += "<span class=\"info-box-number\">" + subdirectoryEntriesApp.Length.ToString() + " APPS" + "</span>";
                    RowSpan += "<span class=\"info-box-text\"><a href=\"http://" + dirInfo.Name + domain + "/ClientStore/Home.aspx\">Goto App Store</a></span>";
                    createInfoBoxContent.InnerHtml = RowSpan;


                    createInfoBox.Controls.Add(createInfoBoxContent);
                    createDivMain.Controls.Add(createInfoBox);
                    DynamicDiv.Controls.Add(createDivMain);
                }
                else
                {
                    Notification("Store Not Available", "error");
                }

                Session["SearchValue"] = null;
            }
            catch (Exception ex)
            {
                ClsLog.LogException(ex, "Error at Page Store Home-->SearchCards");
                Notification("Error at Page Store Home", "error");
            }
        }


        protected void lnkShareMain_Click(object sender, EventArgs e)
        {
            try
            {
                string ApkPath = "";
                string linkcopy = "";
                string name = "";
                string version = "";

                string Details_Directory = ConfigurationManager.AppSettings["Details_Directory"].ToString();
                string getDetails_Directory = System.IO.File.ReadAllText(Details_Directory + "details.txt");
                var details = JObject.Parse(getDetails_Directory);

                string domain = details["domain"].ToString().Replace("\"", "").Trim();
                domain = domain.Substring(1, domain.Length - 1);

                ApkPath = Details_Directory;

                string[] subdirectoryEntries = Directory.GetFiles(ApkPath, "*.apk");
                if (subdirectoryEntries.Length > 0)
                {

                    DirectoryInfo dirInfoApk = new DirectoryInfo(subdirectoryEntries[0]);
                    linkcopy = "http://" + domain + "/Raw_Details/" + dirInfoApk.Name;
                    if (System.IO.File.Exists(ApkPath + dirInfoApk.Name.Substring(0, dirInfoApk.Name.Length - 4) + ".txt"))
                    {
                        //getDetails_Directory = System.IO.File.ReadAllText(StoreDirectory + "\\" + dirInfo.Name.Substring(0, dirInfo.Name.Length - 4) + "\\.txt");
                        details = JObject.Parse(System.IO.File.ReadAllText(ApkPath + "\\" + dirInfoApk.Name.Substring(0, dirInfoApk.Name.Length - 4) + ".txt"));
                        version = details["version"].ToString().Replace("\"", "").Trim();
                        name = details["name"].ToString().Replace("\"", "").Trim();
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "onShare('" + name + "','" + linkcopy + "','" + version + "','myAppStore');", true);
                }
            }
            catch (Exception ex)
            {
                Notification("Error at OnShareMain", "error");
                ClsLog.LogException(ex, "Error at Page Store Home-->OnShareMain");
            }
        }

        protected void lnkSendSmsMain_Click(object sender, EventArgs e)
        {
            try
            {
                string ApkPath = "";
                string linkcopy = "";

                string Details_Directory = ConfigurationManager.AppSettings["Details_Directory"].ToString();
                string getDetails_Directory = System.IO.File.ReadAllText(Details_Directory + "details.txt");
                var details = JObject.Parse(getDetails_Directory);

                string domain = details["domain"].ToString().Replace("\"", "").Trim();
                domain = domain.Substring(1, domain.Length - 1);

                ApkPath = Details_Directory;

                string[] subdirectoryEntries = Directory.GetFiles(ApkPath, "*.apk");
                if (subdirectoryEntries.Length > 0)
                {

                    DirectoryInfo dirInfoApk = new DirectoryInfo(subdirectoryEntries[0]);
                    linkcopy = "http://" + domain + "/Raw_Details/" + dirInfoApk.Name;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "onSendSms('" + linkcopy + "');", true);
                }
            }
            catch (Exception ex)
            {
                Notification("Error at OnSendSmsMain", "error");
                ClsLog.LogException(ex, "Error at Page Store Home-->OnSendSmsMain");
            }
        }
        protected void btnSendSms_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMobile.Text == "")
                {
                    Notification("Enter Mobile Number", "error");
                    return;
                }
                string Details_Directory = ConfigurationManager.AppSettings["Details_Directory"].ToString();
                string getDetails_Directory = System.IO.File.ReadAllText(Details_Directory + "details.txt");
                var details = JObject.Parse(getDetails_Directory);

                string smsUrl = details["smsurl"].ToString().Replace("\"", "").Trim();

                smsUrl = smsUrl.Replace("<mobileno>", txtMobile.Text);
                smsUrl = smsUrl.Replace("<message>", hiddenText.Value.ToString());
                string response = SendRequest(smsUrl);
                if (response.Contains("success"))
                {
                    Notification("Sms Sent Successfully", "success");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Msg", "onSendSms('');", true);

                }
                else
                {
                    Notification("Error in Sending Sms", "error");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Msg", "onSendSms('');", true);
                }
            }
            catch (Exception ex)
            {
                Notification("Error at SendSms", "error");
                ClsLog.LogException(ex, "Error at Page Store Home-->btnSendSms");
            }
        }
        public string SendRequest(string url)
        {
            try
            {
                HttpWebRequest request = ((HttpWebRequest)(WebRequest.Create(url)));
                request.Method = "GET";
                request.Timeout = 30000;
                request.PreAuthenticate = true;
                request.KeepAlive = false;
                //webreq.ContentType = "application/x-www-form-urlencoded";
                request.ContentType = "application/json;charset=UTF-8";
                request.Credentials = CredentialCache.DefaultCredentials;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resst = response.GetResponseStream();
                StreamReader sr = new StreamReader(resst);
                string strresponse = sr.ReadToEnd();
                sr.Close();
                response.Close();
                resst.Close();

                return strresponse;
            }
            catch (Exception ex)
            {
                ClsLog.LogException(ex, "Error at Page Store Home-->SendRequest");
                return ex.ToString();
            }
        }
        protected void Notification(string message, string iconn)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "Notification('" + message + "','" + iconn + "');", true);
            return;
        }
    }
    //protected void LoadCards()
    //{
    //    try
    //    {
    //        int i = 0;
    //        int j = 0;

    //        string Details_Directory = ConfigurationManager.AppSettings["Details_Directory"].ToString();
    //        string getDetails_Directory = System.IO.File.ReadAllText(Details_Directory + "details.txt");
    //        var details = JObject.Parse(getDetails_Directory);

    //        string domain = details["domain"].ToString().Replace("\"", "").Trim();
    //        string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();

    //        if (System.IO.File.Exists(Details_Directory + "\\myappstore.apk"))
    //        {
    //            dwnldlink.Attributes["href"] = "http://" + domain.Substring(1).ToString() + "/Raw_Details/myappstore.apk";
    //        }

    //        if (Session["SearchValue"] != null) //For Search
    //        {
    //            StoreDirectory = StoreDirectory + "\\" + Session["SearchValue"];
    //            DirectoryInfo dirInfo = new DirectoryInfo(StoreDirectory);

    //            if (!dirInfo.Exists)
    //            {
    //                Session["SearchValue"] = null;
    //                Notification("Store Not Available", "error");
    //                return;
    //            }
    //        }

    //        string[] subdirectoryEntries = Directory.GetDirectories(StoreDirectory);

    //        foreach (var directory in subdirectoryEntries)
    //        {
    //            string SwapDirectory = directory;
    //            if (Session["SearchValue"] != null)
    //            {
    //                SwapDirectory = SwapDirectory.Replace(@"\APP", ""); //For Search
    //            }
    //            DirectoryInfo dirInfo = new DirectoryInfo(SwapDirectory);

    //            HtmlGenericControl createDivMain = new HtmlGenericControl("div");
    //            createDivMain.ID = "createDivMain" + i;
    //            createDivMain.Attributes.Add("runat", "server");
    //            createDivMain.Attributes.Add("class", "col-xl-4 col-md-6 col-12");

    //            HtmlGenericControl createInfoBox = new HtmlGenericControl("div");
    //            createInfoBox.ID = "createInfoBox" + i;
    //            createInfoBox.Attributes.Add("runat", "server");

    //            if (j == 0)
    //            {
    //                createInfoBox.Attributes.Add("class", "info-box bg-b-green");
    //            }
    //            else if (j == 1)
    //            {
    //                createInfoBox.Attributes.Add("class", "info-box bg-b-yellow");
    //            }
    //            else if (j == 2)
    //            {
    //                createInfoBox.Attributes.Add("class", "info-box bg-b-blue");
    //            }
    //            else if (j == 3)
    //            {
    //                createInfoBox.Attributes.Add("class", "info-box bg-b-pink");
    //            }

    //            if (j == 3)
    //            {
    //                j = 0;
    //            }
    //            else
    //            {
    //                j = j + 1;
    //            }

    //            string RowSpan = "";
    //            RowSpan = "<span class=\"info-box-icon push-bottom\" ><i class=\"material-icons\" Style=\"margin: 18px 10px 10px 10px\">android</i></span>";
    //            createInfoBox.InnerHtml = RowSpan;

    //            RowSpan = "";

    //            string[] subdirectoryEntriesApp = Directory.GetFiles(SwapDirectory + "\\APP", "*.apk");

    //            HtmlGenericControl createInfoBoxContent = new HtmlGenericControl("div");
    //            createInfoBoxContent.ID = "createInfoBoxContent" + i;
    //            createInfoBoxContent.Attributes.Add("runat", "server");
    //            createInfoBoxContent.Attributes.Add("class", "info-box-content");

    //            RowSpan = "<span class=\"info-box-number\">" + dirInfo.Name.ToString() + "</span>";
    //            RowSpan += "<span class=\"info-box-text\">" + dirInfo.CreationTime.ToShortDateString() + "</span>";
    //            RowSpan += "<span class=\"info-box-number\">" + subdirectoryEntriesApp.Length.ToString() + " APPS" + "</span>";
    //            RowSpan += "<span class=\"info-box-text\"><a href=\"http://" + dirInfo.Name + domain + "/ClientStore/Home.aspx\">Goto App Store</a></span>";
    //            createInfoBoxContent.InnerHtml = RowSpan;


    //            createInfoBox.Controls.Add(createInfoBoxContent);
    //            createDivMain.Controls.Add(createInfoBox);
    //            DynamicDiv.Controls.Add(createDivMain);

    //            if (Session["SearchValue"] != null)
    //            {
    //                Session["SearchValue"] = null;//For Search
    //                break;
    //            }
    //            //if (j == 3)
    //            //{
    //            //    j = 0;
    //            //}
    //            //if (j != 0)
    //            //{
    //            //    j = j + 1;
    //            //}
    //            i = i + 1;

    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        ClsLog.LogException(ex, "Error at Page Store Home-->LoadCards");
    //        Notification("Error at Page Store Home", "error");
    //    }
    //}
}