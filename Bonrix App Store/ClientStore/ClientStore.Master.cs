using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bonrix_App_Store.Class;
namespace Bonrix_App_Store.ClientStore
{
    public partial class ClientStore : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["StoreUserName"] == null && Session["SubDomain"] == null)
                    {
                        Response.Redirect("~/ClientStore/Login.aspx", false);
                    }
                    else
                    {
                        if (Session["StoreUserName"] != null)
                        {
                            lnkStore.Visible = true;
                            liLogin.Visible = false;
                            liUser_Menu.Visible = true;

                            B2CNameRight.InnerText = " " + Session["StoreUserName"].ToString();
                            B2CNameLeft.InnerText = " " + Session["StoreUserName"].ToString();
                        }
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
                    //Response.Redirect("~/ClientStore/Login.aspx", false);
                }
            }
        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/ClientStore/Login.aspx",false);
            }
            catch (Exception ex)
            {
                ClsLog.LogException(ex, "Error at Page Client Store -->Login_Click");
                Notification("Error at Page Client Store ", "error");
            }
        }
        protected void Notification(string message, string iconn)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "Notification('" + message + "','" + iconn + "');", true);
            return;
        }
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            if (Session["StoreUserName"] == null)
            {
                Response.Redirect("~/ClientStore/Login.aspx");
            }
            else
            {
                Session.Remove("StoreUserName");            
                Response.Redirect("~/ClientStore/Home.aspx");
            }
        }
    }
}