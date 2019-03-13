using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bonrix_App_Store.Class;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace Bonrix_App_Store.Admin
{
    public partial class Login : System.Web.UI.Page
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

                string Details_Directory1 = ConfigurationManager.AppSettings["Details_Directory"].ToString();
                Details_Directory = ConfigurationManager.AppSettings["Details_Directory"].ToString();
               // Details_Directory = Server.MapPath( Details_Directory);
                getDetails_Directory = System.IO.File.ReadAllText(Details_Directory + "details.txt");
                var details = JObject.Parse(getDetails_Directory);

                username = details["username"].ToString().Replace("\"", "").Trim();
                password = details["password"].ToString().Replace("\"", "").Trim();

                if (txtuser_name.Text.ToString() == username && txtpassword.Text.ToString() == password)
                {
                    Session["StoreUserName"] = username;
                    Response.Redirect("~/Admin/Home.aspx",false);
                }
                else
                {
                    lblWarning.Text = "Invlaid Credentials.";
                }
            }
            catch (Exception ex)
            {
                ClsLog.LogException(ex, "Error at Page Login-->OnLogin");
            }
        }
    }
}