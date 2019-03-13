using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bonrix_App_Store.Class;

namespace Bonrix_App_Store.Admin
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["StoreUserName"] == null)
                    {
                        Response.Redirect("~/Admin/Login.aspx", false);
                    }
                    else
                    {
                        B2CNameRight.InnerText = " " + Session["StoreUserName"].ToString();
                        B2CNameLeft.InnerText = " " + Session["StoreUserName"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    ClsLog.LogException(ex, "Error at Page Master-->Page_Load");
                }
            }
            else
            {
                if (Session["StoreUserName"] == null)
                {
                    Response.Redirect("~/Admin/Login.aspx", false);
                }
            }
        }
        protected void OnLogout(object sender, EventArgs e)
        {
            //Fetch the Cookie using its Key.            
            if (Session["StoreUserName"] == null)
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
                Session.Remove("StoreUserName");                
                Response.Redirect("~/Admin/Login.aspx");
            }
        }

    }
}