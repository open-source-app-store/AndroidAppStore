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

namespace Bonrix_App_Store.ClientStore
{
    public partial class StoreList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //if (Session["SubDomain"] == null)
                    if (Session["StoreUserName"] == null)
                    {
                        Response.Redirect("~/ClientStore/Home.aspx");
                    }
                    else
                    {
                        LoadStore(Session["SubDomain"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ClsLog.LogException(ex, "Error at Page Client Store StoreList-->OnLoad");
                Notification("Error at Page Client Store StoreList OnLoad", "error");
            }
        }

        protected void LoadStore(string subDomain)
        {
            try
            {
                // SHOW THE ENTIRE LIST OF THE FOLDER.
                string ApkPath = "";
                List<GridList> lstGridList = new List<GridList>();
                string Details_Directory = ConfigurationManager.AppSettings["Details_Directory"].ToString();
                string getDetails_Directory = System.IO.File.ReadAllText(Details_Directory + "details.txt");
                var details = JObject.Parse(getDetails_Directory);

                string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();
                StoreDirectory = StoreDirectory + "\\" + subDomain + "\\APP";

                string[] subdirectoryEntries = Directory.GetFiles(StoreDirectory, "*.apk");
                if (subdirectoryEntries.Length > 0)
                {
                    //For file name
                    ApkPath = ConfigurationManager.AppSettings["Store_Directory"].ToString() + "\\" + subDomain + "\\StoreAPK";
                    string[] ApkStoreDirectory = Directory.GetFiles(ApkPath);
                    if (ApkStoreDirectory.Length > 0)
                    {
                        DirectoryInfo dirInfoApk = new DirectoryInfo(ApkStoreDirectory[0]);
                        dwnldlink.Attributes["href"] = "/Raw_Details/Store/" + subDomain + "/StoreAPK/" + dirInfoApk.Name;
                    }
                    foreach (var directory in subdirectoryEntries)
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(directory);
                        GridList objGridList = new GridList();

                        if (System.IO.File.Exists(StoreDirectory + "\\" + dirInfo.Name.Substring(0, dirInfo.Name.Length - 3) + ".txt"))
                        {
                            //getDetails_Directory = System.IO.File.ReadAllText(StoreDirectory + "\\" + dirInfo.Name.Substring(0, dirInfo.Name.Length - 3) + "\\.txt");
                            details = JObject.Parse(System.IO.File.ReadAllText(StoreDirectory + "\\" + dirInfo.Name.Substring(0, dirInfo.Name.Length - 3) + ".txt"));
                            objGridList.Package = details["package"].ToString().Replace("\"", "").Trim();
                            objGridList.Version = details["version"].ToString().Replace("\"", "").Trim();
                            objGridList.Name = details["name"].ToString().Replace("\"", "").Trim();
                        }

                        objGridList.ApkName = dirInfo.Name.ToString();
                        objGridList.DateTime = dirInfo.CreationTime.ToShortDateString();
                        objGridList.ImageUrl = "../Images/android_logo.png";
                        lstGridList.Add(objGridList);
                    }
                }
                //BIND THE FILE LIST WITH THE REPEATER CONTROL.
                tableData.DataSource = lstGridList;
                tableData.DataBind();
            }
            catch (Exception ex)
            {
                ClsLog.LogException(ex, "Error at Page Client Store StoreList-->LoadStore");
                Notification("Error at Page Client Store StoreList", "error");
            }
        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (FileUpload1.HasFile)
        //        {
        //            try
        //            {
        //                string filename = Path.GetFileName(FileUpload1.FileName);
        //                string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();
        //                StoreDirectory = StoreDirectory + "\\" + Session["SubDomain"].ToString() + "\\APP";
        //                StoreDirectory = StoreDirectory + "\\" + filename;
        //                if (System.IO.File.Exists(StoreDirectory))
        //                {
        //                    Notification("File Already Exists", "error");
        //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "KeepOpen()", true);
        //                    return;
        //                }
        //                else
        //                {
        //                    FileUpload1.SaveAs(StoreDirectory);
        //                    LoadStore(Session["SubDomain"].ToString());
        //                    Notification("File Uploaded", "success");
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                ClsLog.LogException(ex, "Error at Page Client Store StoreList -->fileUpload");
        //            }
        //        }
        //        else
        //        {
        //            Notification("Select Image to Upload", "error");
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "KeepOpen()", true);
        //            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "Notification('" + message + "','" + iconn + "');", true);
        //            return;
        //        }
        //    }
        //    catch (Exception ex1)
        //    {
        //        Notification("Error OnUpload", "error");
        //        ClsLog.LogException(ex1, "Error at Page Client Store StoreList-->OnUpload");
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

                    btn = e.Item.FindControl("lnkDelete") as LinkButton;
                    if (btn != null)
                    {
                        btn.Click += OnDelete;
                        scriptMan.RegisterAsyncPostBackControl(btn);
                    }
                }
            }
            catch (Exception ex)
            {
                Notification("Error at  OnItemCreated", "danger");
                ClsLog.LogException(ex, "Error at Page StoreList-->OnItemCreated");
            }
        }
        protected void OnDelete(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                string lblApkName = (item.FindControl("lblApkName") as Label).Text.Trim();

                string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();
                StoreDirectory = StoreDirectory + "\\" + Session["SubDomain"].ToString() + "\\APP\\" + lblApkName;

                File.Delete(StoreDirectory);

                StoreDirectory = StoreDirectory + "\\" + Session["SubDomain"].ToString() + "\\APP\\" + lblApkName + ".txt";
                if (File.Exists(StoreDirectory))
                {
                   File.Delete(StoreDirectory);
                }

                Notification("Deleted Successfully", "success");
                LoadStore(Session["SubDomain"].ToString());

            }
            catch (Exception ex)
            {
                Notification("Error at OnDelete", "danger");
                ClsLog.LogException(ex, "Error at Page StoreList-->OnDelete");
            }
        }
        protected void Notification(string message, string iconn)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "Notification('" + message + "','" + iconn + "');", true);
            return;
        }
        //public class Friends
        //{
        //    public string ApkName { get; set; }
        //    public string DateTime { get; set; }
        //    public string ImageUrl { get; set; }
        //}
    }
}