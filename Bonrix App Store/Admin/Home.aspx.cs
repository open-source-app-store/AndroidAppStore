using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bonrix_App_Store.Class;
using System.Configuration;
using System.IO;
using System.Collections;
using Newtonsoft.Json.Linq;
namespace Bonrix_App_Store.Admin
{
    public partial class Home : System.Web.UI.Page
    {
        public class Store
        {
            public string FolderName { get; set; }
            public string DateTime { get; set; }
            public string ImageUrl { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    loadData();
                }
                catch (Exception ex)
                {
                    ClsLog.LogException(ex, "Error at Page Home-->Page_Load");
                    Notification("Error at Page Home", "error");
                }
            }

        }
        protected void loadData()
        {
            try
            {
                // SHOW THE ENTIRE LIST OF THE FOLDER.
                List<Store> objStoreList = new List<Store>();
                string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();
                string[] subdirectoryEntries = Directory.GetDirectories(StoreDirectory);
                if (subdirectoryEntries.Length > 0)
                {

                    foreach (var directory in subdirectoryEntries)
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(directory);
                        Store objStore = new Store();
                        objStore.FolderName = dirInfo.Name.ToString();
                        objStore.DateTime = dirInfo.CreationTime.ToShortDateString();
                        objStore.ImageUrl = "../Images/android_logo.png";
                        objStoreList.Add(objStore);
                        //foreach (var friend in friendz)
                        //{
                        //    friendsList.Add(
                        //        new Friends { ID = friend.id, Name = friend.name }
                        //    );

                        //}

                        //var data = new List<KeyValuePair<string, string>>()
                        //{            
                        //    new KeyValuePair<string, string>( "folder_name",  dirInfo.Name.ToString()),
                        //     new KeyValuePair<string, string>( "date_time",  dirInfo.CreationTime.ToShortDateString())
                        //};

                        // Notice I've created a DirectoryInfo variable.


                        // And likewise a name variable for storing the name.
                        // If this is not added, only the first directory will
                        // be captured in the loop; the rest won't.

                        //string name = dirInfo.Name;


                        //resultList2.Add(data);

                        // Finally we add the directory name to our defined List.
                        //subdirectoryEntries.Add(name);
                    }
                }
                //BIND THE FILE LIST WITH THE REPEATER CONTROL.
                tableData.DataSource = objStoreList;
                tableData.DataBind();
            }
            catch (Exception ex)
            {
                ClsLog.LogException(ex, "Error at Page Home-->loadData");
                Notification("Error at Page Home LoadData", "error");
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string path = "";
            try
            {
                if (txtStoreName.Text == "")
                {
                    Notification("Please Enter Store Name", "error");
                    return;
                }

                if (txtStoreName.Text.Contains(" "))
                {
                    txtStoreName.Text = txtStoreName.Text.Replace(" ", "").ToString();
                }

                if (chkActive.Checked)
                {
                    if (txtpassword.Text == "")
                    {
                        Notification("Please Enter Store Password", "error");
                        return;
                    }
                }

                string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();
                DirectoryInfo objDirectoryInfo = new DirectoryInfo(StoreDirectory);
                if (!objDirectoryInfo.Exists)
                {
                    Directory.CreateDirectory(StoreDirectory);
                }

                StoreDirectory = StoreDirectory + "\\" + txtStoreName.Text.ToString().Trim();
                path = StoreDirectory;

                //Check if store name exists
                objDirectoryInfo = new DirectoryInfo(path);
                if (objDirectoryInfo.Exists)
                {
                    Notification("Store Name Already Exists", "error");
                    return;
                }
                else
                {
                    Directory.CreateDirectory(StoreDirectory);
                }


                //objDirectoryInfo = new DirectoryInfo(StoreDirectory);
                //if (!objDirectoryInfo.Exists)
                //{
                //    Directory.CreateDirectory(StoreDirectory);
                //}

                StoreDirectory = path + "\\APP";
                objDirectoryInfo = new DirectoryInfo(StoreDirectory);
                if (!objDirectoryInfo.Exists)
                {
                    Directory.CreateDirectory(StoreDirectory);
                }

                StoreDirectory = path + "\\StoreAPK";
                objDirectoryInfo = new DirectoryInfo(StoreDirectory);
                if (!objDirectoryInfo.Exists)
                {
                    Directory.CreateDirectory(StoreDirectory);
                }

                if (chkActive.Checked)
                {
                    path = path + "\\password.txt";
                    StreamWriter sw = new StreamWriter(path, true);
                    sw.Write("{\"username\":\"" + txtStoreName.Text.ToString().Trim() + "\",\"password\":\"" + txtpassword.Text.ToString().Trim() + "\"}");
                    sw.Close();
                }
                loadData();
                Notification("Store Created Successfully", "success");
            }
            catch (Exception ex)
            {
                ClsLog.LogException(ex, "Error at Page Home-->Submit");
                Notification("Error at Page Home", "error");
            }
        }
        protected void Notification(string message, string iconn)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "Notification('" + message + "','" + iconn + "');", true);
            return;
        }
        protected void OnUpload(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            try
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Msg", "ShowModal('" + (item.FindControl("lblFolderName") as Label).Text.Trim() + "');", true);
            }
            catch (Exception ex)
            {
                Notification("Error at OnUpload", "error");
                ClsLog.LogException(ex, "Error at Admin Home-->OnUpload");
            }
            //this.ToggleElements(item, true);
        }
        protected void OnEdit(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            try
            {
                string getDetails_Directory = "";
                string name = "";
                string package = "";
                string version = "";
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                string lblFolderName = (item.FindControl("lblFolderName") as Label).Text.Trim();
                string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();
                string filePath = StoreDirectory;

                txtName.Text = "";
                txtPackageName.Text = "";
                txtVersion.Text = "";
                if (System.IO.File.Exists(filePath + "\\" + lblFolderName + "\\" + "StoreAPK\\" + lblFolderName + ".txt"))
                {
                    if (Session["StoreUserName"] == null && Session["StorePassword"] == null)
                    {
                        Notification("Login to upload APK.", "error");
                        return;
                    }
                    getDetails_Directory = System.IO.File.ReadAllText(filePath + "\\" + lblFolderName + "\\" + "StoreAPK\\" + lblFolderName + ".txt");
                    var details = JObject.Parse(getDetails_Directory);

                    name = details["name"].ToString().Replace("\"", "").Trim();
                    package = details["package"].ToString().Replace("\"", "").Trim();
                    version = details["version"].ToString().Replace("\"", "").Trim();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Msg", "EditValue('" + lblFolderName + "','" + name + "','" + package + "','" + version + "');", true);

                }
                else
                {
                    string aa=filePath + "\\" + lblFolderName + "\\" + "StoreAPK\\" + lblFolderName + ".txt";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Msg", "EditValue('" + lblFolderName + "','" + name + "','" + package + "','" + version + "');", true);
                }


            }
            catch (Exception ex)
            {
                Notification("Error at OnEdit", "error");
                ClsLog.LogException(ex, "Error at Admin Home-->OnEdit");
            }
            //this.ToggleElements(item, true);
        }
        protected void tableData_ItemCreated(Object Sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    ScriptManager scriptMan = ScriptManager.GetCurrent(this);
                    LinkButton btn = e.Item.FindControl("lnkUpload") as LinkButton;
                    if (btn != null)
                    {
                        btn.Click += OnUpload;
                        scriptMan.RegisterAsyncPostBackControl(btn);
                    }

                    btn = e.Item.FindControl("lnkEdit") as LinkButton;
                    if (btn != null)
                    {
                        btn.Click += OnEdit;
                        scriptMan.RegisterAsyncPostBackControl(btn);
                    }

                    btn = e.Item.FindControl("lnkDeleteAPK") as LinkButton;
                    if (btn != null)
                    {
                        btn.Click += OnDeleteAPK;
                        scriptMan.RegisterAsyncPostBackControl(btn);
                    }

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
                Notification("Error at  Admin Home OnItemCreated", "error");
                ClsLog.LogException(ex, "Error at Page Admin Home-->OnItemCreated");
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        string PackagePath = "";
                        //string username = "";
                        //string password = "";
                        //string getDetails_Directory = "";
                        string filename = Path.GetFileName(FileUpload1.FileName);
                        string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();
                        string filePath = StoreDirectory;

                        StoreDirectory = StoreDirectory + "\\" + hiddenFolderName.Value.ToString() + "\\StoreAPK";
                        PackagePath = StoreDirectory;

                        StoreDirectory = StoreDirectory + "\\" + filename;
                        //Session["filepath"] = StoreDirectory;

                        //if (System.IO.File.Exists(filePath + "\\" + hiddenFolderName.Value.ToString() + "\\password.txt"))
                        //{
                        //    if (Session["StoreUserName"] == null && Session["StorePassword"] == null)
                        //    {
                        //        Notification("Login to upload APK.", "error");
                        //        return;
                        //    }

                        //    getDetails_Directory = System.IO.File.ReadAllText(filePath + "\\" + Session["SubDomain"].ToString() + "\\password.txt");
                        //    var details = JObject.Parse(getDetails_Directory);

                        //    username = details["username"].ToString().Replace("\"", "").Trim();
                        //    password = details["password"].ToString().Replace("\"", "").Trim();

                        //    if (Session["StoreUserName"].ToString() != username && Session["StorePassword"].ToString() != password)
                        //    {
                        //        Notification("Invalid Credential, Login Again..", "error");
                        //        return;
                        //    }                          
                        //}

                        //if (System.IO.File.Exists(StoreDirectory))
                        //{
                        //    Notification("File Already Exists", "error");
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "KeepOpen()", true);
                        //    return;
                        //}
                        //else
                        //{

                        FileUpload1.SaveAs(StoreDirectory);
                        loadData();
                        Notification("File Uploaded", "success");
                        //Session["filepath"] = null;
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
                ClsLog.LogException(ex1, "Error at Page Admin Home-->btnUpload");
            }
        }
        protected void OnDelete(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                string lblFolderName = (item.FindControl("lblFolderName") as Label).Text.Trim();

                string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();
                StoreDirectory = StoreDirectory + "\\" + lblFolderName;

                Directory.Delete(StoreDirectory, true);
                loadData();
                Notification("Deleted Successfully", "success");
            }
            catch (Exception ex)
            {
                Notification("Error at OnDelete", "danger");
                ClsLog.LogException(ex, "Error at Page Admin Home-->OnDelete");
            }
        }
        protected void OnDeleteAPK(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                string lblFolderName = (item.FindControl("lblFolderName") as Label).Text.Trim();

                string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();
                StoreDirectory = StoreDirectory + "\\" + lblFolderName + "\\StoreAPK";

                string[] subdirectoryEntries = Directory.GetFiles(StoreDirectory);
                if (subdirectoryEntries.Length > 0)
                {
                    foreach (var directory in subdirectoryEntries)
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(directory);
                        File.Delete(dirInfo.ToString());
                    }
                    //Directory.Delete(StoreDirectory, true);
                    loadData();
                    Notification("Deleted Successfully", "success");
                }
                else
                {
                    Notification("No Store Apk Uploaded.", "danger");
                }
            }
            catch (Exception ex)
            {
                Notification("Error at OnDelete", "danger");
                ClsLog.LogException(ex, "Error at Page Admin Home-->OnDelete");
            }
        }
        protected void btnEditSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string lblFolderName = hiddenFolderName.Value.ToString();
                string StoreDirectory = ConfigurationManager.AppSettings["Store_Directory"].ToString();
                StoreDirectory = StoreDirectory + "\\" + hiddenFolderName.Value.ToString() + "\\StoreAPK";
                StoreDirectory = StoreDirectory + "\\" + lblFolderName + ".txt";
                if (System.IO.File.Exists(StoreDirectory))
                {
                    System.IO.File.Delete(StoreDirectory);
                }
                //Write Package file
                StreamWriter sw = new StreamWriter(StoreDirectory, true);
                sw.Write("{\"name\":\"" + txtName.Text.ToString().Trim() + "\",\"package\":\"" + txtPackageName.Text.ToString().Trim() + "\",\"version\":\"" + txtVersion.Text.ToString().Trim() + "\"}");
                sw.Close();
                Notification("Updated Successfully", "success");
            }
            catch (Exception ex)
            {
                Notification("Error at OnDelete APK", "danger");
                ClsLog.LogException(ex, "Error at Page Admin Home-->OnDelete APK");
            }
        }
    }
}