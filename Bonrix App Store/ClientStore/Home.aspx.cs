using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Bonrix_App_Store.Class;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Net;

namespace Bonrix_App_Store.ClientStore
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

                    //string DomainName = "bonrix.myappstore.co.in";
                    //ClsLog.Url_Log("Request", "Url --> " + HttpContext.Current.Request.Url.ToString());
                    string DomainName = HttpContext.Current.Request.Url.Host;
                    //ClsLog.Url_Log("Request ", "DomainName--> " + DomainName);                    
                    if (DomainName.Contains("."))
                    {
                        string[] spltDomain = DomainName.Split('.');
                        subDomain = spltDomain[0].ToString();
                        Session["SubDomain"] = subDomain;
                        //ClsLog.Url_Log("Request", "Sub Domain Name--> " + subDomain);
                        divTitle.InnerText = subDomain.ToUpper() + " APP STORE";
                        LoadStore(subDomain);
                    }
                }
            }
            catch (Exception ex)
            {
                ClsLog.LogException(ex, "Error at Page Client Store Home-->OnLoad");
                Notification("Error at Page Client Store Home OnLoad", "error");
            }
        }

        protected void LoadStore(string subDomain)
        {
            try
            {
                List<GridList> friendsList = new List<GridList>();
                string Details_Directory = ConfigurationManager.AppSettings["Details_Directory"].ToString();
                string getDetails_Directory = System.IO.File.ReadAllText(Details_Directory + "details.txt");
                var details = JObject.Parse(getDetails_Directory);

                string domain = details["domain"].ToString().Replace("\"", "").Trim();

                // SHOW THE ENTIRE LIST OF THE FOLDER.
                string ApkPath = "";

                string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();
                StoreDirectory = StoreDirectory + "\\" + subDomain + "\\APP";
                ApkPath = ConfigurationManager.AppSettings["Store_Directory"].ToString() + "\\" + subDomain + "\\StoreAPK";


                //For file name
                string[] ApkStoreDirectory = Directory.GetFiles(ApkPath, "*.apk");
                if (ApkStoreDirectory.Length > 0)
                {
                    DirectoryInfo dirInfoApk = new DirectoryInfo(ApkStoreDirectory[0]);
                    dwnldlink.Attributes["href"] = "http://" + subDomain + domain + "/Raw_Details/Store/" + subDomain + "/StoreAPK/" + dirInfoApk.Name;
                    dwnldlink.Attributes["title"] = "Download " + subDomain.ToUpper() + " Store Client Apk";
                }

                string[] subdirectoryEntries = Directory.GetFiles(StoreDirectory, "*.apk");
                if (subdirectoryEntries.Length > 0)
                {
                    foreach (var directory in subdirectoryEntries)
                    {

                        DirectoryInfo dirInfo = new DirectoryInfo(directory);
                        GridList objGrid = new GridList();

                        if (System.IO.File.Exists(StoreDirectory + "\\" + dirInfo.Name.Substring(0, dirInfo.Name.Length - 4) + ".txt"))
                        {
                            //getDetails_Directory = System.IO.File.ReadAllText(StoreDirectory + "\\" + dirInfo.Name.Substring(0, dirInfo.Name.Length - 4) + "\\.txt");
                            details = JObject.Parse(System.IO.File.ReadAllText(StoreDirectory + "\\" + dirInfo.Name.Substring(0, dirInfo.Name.Length - 4) + ".txt"));
                            objGrid.Package = details["package"].ToString().Replace("\"", "").Trim();
                            objGrid.Version = details["version"].ToString().Replace("\"", "").Trim();
                            objGrid.Name = details["name"].ToString().Replace("\"", "").Trim();
                        }

                        objGrid.ApkName = dirInfo.Name.ToString();
                        objGrid.DateTime = dirInfo.CreationTime.ToShortDateString() + " " + dirInfo.CreationTime.ToLongTimeString();
                        objGrid.ImageUrl = "../Images/android_logo.png";
                        objGrid.DownloadUrl = "http://" + subDomain + domain + "/Raw_Details/Store/" + subDomain + "/APP/" + dirInfo.Name.ToString();
                        objGrid.CopyUrl = "http://" + subDomain + domain + "/Raw_Details/Store/" + subDomain + "/APP/" + dirInfo.Name.ToString();
                        friendsList.Add(objGrid);
                    }
                }
                //else
                //{
                //    Notification("APK Not Uploaded", "error");
                //}                
                //BIND THE FILE LIST WITH THE REPEATER CONTROL.
                tableData.DataSource = friendsList;
                tableData.DataBind();
            }
            catch (Exception ex)
            {
                ClsLog.LogException(ex, "Error at Page Client Store Home-->LoadStore");
                Notification("Error at Page Client Store Home LoadStore", "error");
            }
        }

        protected void Notification(string message, string iconn)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "Notification('" + message + "','" + iconn + "');", true);
            return;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        string PackagePath = "";
                        string username = "";
                        string password = "";
                        string getDetails_Directory = "";
                        string filename = Path.GetFileName(FileUpload1.FileName);
                        string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();
                        string filePath = StoreDirectory;

                        StoreDirectory = StoreDirectory + "\\" + Session["SubDomain"].ToString() + "\\APP";
                        PackagePath = StoreDirectory;

                        StoreDirectory = StoreDirectory + "\\" + filename;
                        Session["filepath"] = StoreDirectory;

                        if (System.IO.File.Exists(filePath + "\\" + Session["SubDomain"].ToString() + "\\password.txt"))
                        {
                            if (Session["StoreUserName"] == null && Session["StorePassword"] == null)
                            {
                                Notification("Login to upload APK.", "error");
                                return;
                            }

                            getDetails_Directory = System.IO.File.ReadAllText(filePath + "\\" + Session["SubDomain"].ToString() + "\\password.txt");
                            var details = JObject.Parse(getDetails_Directory);

                            username = details["username"].ToString().Replace("\"", "").Trim();
                            password = details["password"].ToString().Replace("\"", "").Trim();

                            if (Session["StoreUserName"].ToString() != username && Session["StorePassword"].ToString() != password)
                            {
                                Notification("Invalid Credential, Login Again..", "error");
                                return;
                            }
                            //divUserName.Visible = true;
                            //divPassword.Visible = true;
                            //divSubmit1.Visible = true;
                            //divSubmit.Visible = false;
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "KeepOpen()", true);
                            //return;
                        }

                        //if (System.IO.File.Exists(StoreDirectory))
                        //{
                        //    Notification("File Already Exists", "error");
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "KeepOpen()", true);
                        //    return;
                        //}
                        //else
                        //{

                        FileUpload1.SaveAs(StoreDirectory);
                        //Write Package file
                        System.IO.File.Delete(PackagePath + "\\" + filename.Substring(0, filename.Length - 4) + ".txt");
                        StreamWriter sw = new StreamWriter(PackagePath + "\\" + filename.Substring(0, filename.Length - 4) + ".txt", true);
                        sw.Write("{\"name\":\"" + txtName.Text.ToString().Trim() + "\",\"package\":\"" + txtPackageName.Text.ToString().Trim() + "\",\"version\":\"" + txtVersion.Text.ToString().Trim() + "\"}");
                        sw.Close();

                        LoadStore(Session["SubDomain"].ToString());
                        Notification("File Uploaded", "success");
                        Session["filepath"] = null;
                        //}

                    }
                    catch (Exception ex)
                    {
                        ClsLog.LogException(ex, "Error at Page Client Store Home -->fileUpload");
                    }
                }
                else
                {
                    Notification("Select Image to Upload", "error");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "KeepOpen()", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "Notification('" + message + "','" + iconn + "');", true);
                    return;
                }
            }
            catch (Exception ex1)
            {
                Notification("Error OnUpload", "error");
                ClsLog.LogException(ex1, "Error at Page Client Store Home-->OnUpload");
            }
        }

        protected void OnEdit(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            try
            {
                //Check for password file of store          
                string filePath = "";
                txtEditName.Text = "";
                txtEditPackage.Text = "";
                txtEditVersion.Text = "";

                filePath = ConfigurationManager.AppSettings["Store_Directory"].ToString();
                if (System.IO.File.Exists(filePath + "\\" + Session["SubDomain"].ToString() + "\\password.txt"))
                {
                    if (Session["StoreUserName"] == null)
                    {
                        Notification("Login to Edit APP.", "error");
                        return;
                    }
                }

                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Msg", "ShowModal('" + (item.FindControl("lblApkName") as Label).Text.Trim() +
                                                                                "','" + (item.FindControl("hiddenName") as HiddenField).Value.Trim() +
                                                                                "','" + (item.FindControl("hiddenPackage") as HiddenField).Value.Trim() +
                                                                                "','" + (item.FindControl("hiddenVersion") as HiddenField).Value.Trim() + "');", true);
            }
            catch (Exception ex)
            {
                Notification("Error at OnEdit", "error");
                ClsLog.LogException(ex, "Error at Client Store Home-->OnEdit");
            }
            //this.ToggleElements(item, true);
        }
        protected void btnEditSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string ApkPath = "";
                ApkPath = ConfigurationManager.AppSettings["Store_Directory"].ToString() + "\\" + Session["SubDomain"] + "\\APP\\" + hiddenEditApkName.Value.Substring(0, hiddenEditApkName.Value.Length - 4).ToString() + ".txt";
                System.IO.File.Delete(ApkPath);
                StreamWriter sw = new StreamWriter(ApkPath, true);
                sw.Write("{\"name\":\"" + txtEditName.Text.ToString().Trim() + "\",\"package\":\"" + txtEditPackage.Text.ToString().Trim() + "\",\"version\":\"" + txtEditVersion.Text.ToString().Trim() + "\"}");
                sw.Close();
                LoadStore(Session["SubDomain"].ToString());
                Notification("Updated Successfully", "success");

            }
            catch (Exception ex)
            {
                Notification("Error at btnEditSubmit_Click", "error");
                ClsLog.LogException(ex, "Error at Client Store Home-->btnEditSubmit_Click");
            }
        }

        //protected void btnSubmit1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //if (FileUpload1.HasFile)
        //        if (Session["filepath"] != null)
        //        {
        //            try
        //            {
        //                string getDetails_Directory = "";
        //                string username = "";
        //                string password = "";

        //                string filename = Path.GetFileName(Session["filepath"].ToString());
        //                string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();

        //                getDetails_Directory = System.IO.File.ReadAllText(StoreDirectory + "\\" + Session["SubDomain"].ToString() + "\\password.txt");
        //                var details = JObject.Parse(getDetails_Directory);

        //                username = details["username"].ToString().Replace("\"", "").Trim();
        //                password = details["password"].ToString().Replace("\"", "").Trim();


        //                StoreDirectory = StoreDirectory + "\\" + Session["SubDomain"].ToString() + "\\APP";
        //                StoreDirectory = StoreDirectory + "\\" + filename;
        //                if (txtUserName.Text == "" && txtPassWord.Text == "")
        //                {
        //                    Notification("Please enter username and password.", "error");
        //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "KeepOpen()", true);
        //                    return;
        //                }

        //                if (txtUserName.Text == "")
        //                {
        //                    Notification("Please enter username.", "error");
        //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "KeepOpen()", true);
        //                    return;
        //                }

        //                if (txtPassWord.Text == "")
        //                {
        //                    Notification("Please enter password.", "error");
        //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "KeepOpen()", true);
        //                    return;
        //                }

        //                if (txtUserName.Text.ToString() == username && txtPassWord.Text.ToString() == password)
        //                {
        //                    if (System.IO.File.Exists(StoreDirectory))
        //                    {
        //                        divUserName.Visible = false;
        //                        divPassword.Visible = false;
        //                        divSubmit1.Visible = false;
        //                        divSubmit.Visible = true;
        //                        Notification("File Already Exists", "error");
        //                        ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "KeepOpen()", true);
        //                        return;
        //                    }
        //                    else
        //                    {
        //                        FileUpload1.SaveAs(StoreDirectory);
        //                        LoadStore(Session["SubDomain"].ToString());
        //                        divUserName.Visible = false;
        //                        divPassword.Visible = false;
        //                        divSubmit1.Visible = false;
        //                        divSubmit.Visible = true;
        //                        txtUserName.Text = "";
        //                        txtPassWord.Text = "";
        //                        Session["filepath"] = null;
        //                        Notification("File Uploaded", "success");
        //                        return;
        //                    }
        //                }
        //                else
        //                {
        //                    Notification("Invlaid Credentials", "error");
        //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "KeepOpen()", true);
        //                    return;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                ClsLog.LogException(ex, "Error at Page Client Store Home -->fileUpload1");
        //            }
        //        }
        //        else
        //        {
        //            Notification("Select Image to Upload", "error");
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "KeepOpen()", true);
        //        }
        //    }
        //    catch (Exception ex1)
        //    {
        //        Notification("Error OnUpload", "error");
        //        ClsLog.LogException(ex1, "Error at Page Client Store Home-->OnUpload1");
        //    }
        //}


        protected void tableData_ItemCreated(Object Sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    ScriptManager scriptMan = ScriptManager.GetCurrent(this);
                    LinkButton btn = e.Item.FindControl("lnkEdit") as LinkButton;
                    if (btn != null)
                    {
                        btn.Click += OnEdit;
                        scriptMan.RegisterAsyncPostBackControl(btn);
                    }

                    btn = e.Item.FindControl("lnkCopy") as LinkButton;
                    if (btn != null)
                    {
                        btn.Click += OnCopy;
                        scriptMan.RegisterAsyncPostBackControl(btn);
                    }

                    btn = e.Item.FindControl("lnkShare") as LinkButton;
                    if (btn != null)
                    {
                        btn.Click += OnShare;
                        scriptMan.RegisterAsyncPostBackControl(btn);
                    }

                    btn = e.Item.FindControl("lnkSendSms") as LinkButton;
                    if (btn != null)
                    {
                        btn.Click += OnSendSms;
                        scriptMan.RegisterAsyncPostBackControl(btn);
                    }
                }
            }
            catch (Exception ex)
            {
                Notification("Error at  ClientStore Home OnItemCreated", "error");
                ClsLog.LogException(ex, "Error at Page ClientStore Home-->OnItemCreated");
            }
        }

        protected void OnCopy(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                string linkcopy = (item.FindControl("lnkdownload") as HtmlAnchor).HRef.ToString();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Msg", "onCopy('" + linkcopy + "');", true);
            }
            catch (Exception ex)
            {
                Notification("Error at OnCopy", "error");
                ClsLog.LogException(ex, "Error at Page Client Store Home-->OnDelete");
            }
        }

        protected void OnShare(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                string linkcopy = (item.FindControl("lnkdownload") as HtmlAnchor).HRef.ToString();
                string name = (item.FindControl("lblName") as Label).Text.Trim();
                string version = (item.FindControl("lblAPKVersion") as Label).Text.Trim();
                version = version.Replace("Version:", "");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Msg", "onShare('" + name + "','" + linkcopy + "','" + version + "','" + Session["SubDomain"].ToString().ToUpper() + "');", true);
            }
            catch (Exception ex)
            {
                Notification("Error at OnShare", "error");
                ClsLog.LogException(ex, "Error at Page Client Store Home-->OnShare");
            }
        }
        protected void OnSendSms(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                string linkcopy = (item.FindControl("lnkdownload") as HtmlAnchor).HRef.ToString();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Msg", "onSendSms('" + linkcopy + "');", true);
            }
            catch (Exception ex)
            {
                Notification("Error at OnSendSms", "error");
                ClsLog.LogException(ex, "Error at Page Client Store Home-->OnSendSms");
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
                Notification("Error at btnSendSms", "error");
                ClsLog.LogException(ex, "Error at Page Client Store Home-->btnSendSms");
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
                ClsLog.LogException(ex, "Error at Page Client Store Home-->SendRequest");
                return ex.ToString();
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
                subDomain = Session["SubDomain"].ToString();

                ApkPath = ConfigurationManager.AppSettings["Store_Directory"].ToString() + "\\" + subDomain + "\\StoreAPK";

                string[] subdirectoryEntries = Directory.GetFiles(ApkPath, "*.apk");
                if (subdirectoryEntries.Length > 0)
                {

                    DirectoryInfo dirInfoApk = new DirectoryInfo(subdirectoryEntries[0]);
                    linkcopy = "http://" + subDomain + domain + "/Raw_Details/Store/" + subDomain + "/StoreAPK/" + dirInfoApk.Name;

                    if (System.IO.File.Exists(ApkPath + "\\" + dirInfoApk.Name.Substring(0, dirInfoApk.Name.Length - 4) + ".txt"))
                    {
                        //getDetails_Directory = System.IO.File.ReadAllText(StoreDirectory + "\\" + dirInfo.Name.Substring(0, dirInfo.Name.Length - 4) + "\\.txt");
                        details = JObject.Parse(System.IO.File.ReadAllText(ApkPath + "\\" + dirInfoApk.Name.Substring(0, dirInfoApk.Name.Length - 4) + ".txt"));
                        version = details["version"].ToString().Replace("\"", "").Trim();
                        name = details["name"].ToString().Replace("\"", "").Trim();
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "onShare('" + name + "','" + linkcopy + "','" + version + "','" + Session["SubDomain"].ToString().ToUpper() + "');", true);
                }
            }
            catch (Exception ex)
            {
                Notification("Error at OnShareMain", "error");
                ClsLog.LogException(ex, "Error at Page Client Store Home-->OnShareMain");
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
                subDomain = Session["SubDomain"].ToString();

                ApkPath = ConfigurationManager.AppSettings["Store_Directory"].ToString() + "\\" + subDomain + "\\StoreAPK";

                string[] subdirectoryEntries = Directory.GetFiles(ApkPath, "*.apk");
                if (subdirectoryEntries.Length > 0)
                {

                    DirectoryInfo dirInfoApk = new DirectoryInfo(subdirectoryEntries[0]);
                    linkcopy = "http://" + subDomain + domain + "/Raw_Details/Store/" + subDomain + "/StoreAPK/" + dirInfoApk.Name;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "onSendSms('" + linkcopy + "');", true);
                }
            }
            catch (Exception ex)
            {
                Notification("Error at OnSendSmsMain", "error");
                ClsLog.LogException(ex, "Error at Page Client Store Home-->OnSendSmsMain");
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //Check for password file of store          
                string filePath = "";
                filePath = ConfigurationManager.AppSettings["Store_Directory"].ToString();
                if (System.IO.File.Exists(filePath + "\\" + Session["SubDomain"].ToString() + "\\password.txt"))
                {
                    if (Session["StoreUserName"] == null)
                    {
                        Notification("Login to Upload APP.", "error");
                        return;
                    }
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "ShowPanelAdd();", true);

            }
            catch(Exception ex)
            {
                Notification("Error at OnUpload", "error");
                ClsLog.LogException(ex, "Error at Page Client Store Home-->btnUpload");
            }

        }
    }
}