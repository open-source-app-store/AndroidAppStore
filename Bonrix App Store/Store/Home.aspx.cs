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

namespace Bonrix_App_Store.Store
{
    public partial class Home : System.Web.UI.Page
    {
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
                Notification("Error at Page Store Home", "OnLoad");
            }
        }
        protected void LoadCards()
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

                if (System.IO.File.Exists(Details_Directory + "\\StoreApk.apk"))
                {
                    dwnldlink.Attributes["href"] = "http://" + domain.Substring(1).ToString() + "/Raw_Details/Store/StoreApk.apk";
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
                    j = j + 1;
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
                   
                    if (i == 3)
                    {
                        j = 0;
                    }
                    i = i + 1;
                }

            }
            catch (Exception ex)
            {
                ClsLog.LogException(ex, "Error at Page Store Home-->LoadCards");
                Notification("Error at Page Store Home", "LoadCards");
            }
        }
        protected void Notification(string message, string iconn)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "Notification('" + message + "','" + iconn + "');", true);
            return;
        }
    }
}