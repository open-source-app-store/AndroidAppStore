using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bonrix_App_Store.Class;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace Bonrix_App_Store.ClientStore
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWarning.Text = "";

        }
        protected void OnLogin(object sender, EventArgs e)
        {
            string Details_Directory = "";
            string getDetails_Directory = "";
            string username = "";
            string password = "";

            try
            {
                if (txtuser_name.Text == "" && txtpassword.Text == "")
                {
                    lblWarning.Text = "Please enter username and password.";
                    return;
                }

                if (txtuser_name.Text == "")
                {
                    lblWarning.Text = "Please enter username.";
                    return;
                }

                if (txtpassword.Text == "")
                {
                    lblWarning.Text = "Please enter password.";
                    return;
                }
                Details_Directory = ConfigurationManager.AppSettings["Store_Directory"].ToString();
                Details_Directory = Details_Directory + "\\" + Session["SubDomain"] + "\\password.txt";
                //string[] subdirectoryEntries = System.IO.Directory.GetFiles(Details_Directory);
                if (System.IO.File.Exists(Details_Directory))
                {
                    getDetails_Directory = System.IO.File.ReadAllText(Details_Directory);
                    var details = JObject.Parse(getDetails_Directory);

                    username = details["username"].ToString().Replace("\"", "").Trim();
                    password = details["password"].ToString().Replace("\"", "").Trim();

                    if (txtuser_name.Text.ToString() == username && txtpassword.Text.ToString() == password)
                    {
                        Session["StoreUserName"] = username;
                        Session["StorePassword"] = password;
                        ////if (Response.IsClientConnected)
                        ////{
                        ////    // If still connected, redirect
                        ////    // to another page. 
                        ////    Response.Redirect("~/ClientStore/Home.aspx", false);
                        ////}
                        ////else
                        ////{
                        ////    // If the browser is not connected
                        ////    // stop all response processing.
                        ////    Response.End();
                        ////}
                        Response.Redirect("~/ClientStore/Home.aspx", false);

                    }
                    else
                    {
                        lblWarning.Text = "Invlaid Credentials.";
                    }
                }
                else
                {
                    lblWarning.Text = "Password Not Created, So Contact Your Administrator.";

                }
            }
            catch (Exception ex)
            {
                if( ex.Message.Contains("Could not find a part of the path"))
                {
                    lblWarning.Text = "Password Not Created, So Contact Your Administrator.";
                }
                ClsLog.LogException(ex, "Error at Page ClientStore Login-->OnLogin");
            }
        }
    }
}