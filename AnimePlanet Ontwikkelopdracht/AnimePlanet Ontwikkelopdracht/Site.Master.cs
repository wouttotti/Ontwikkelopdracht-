using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimePlanet_Ontwikkelopdracht
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Inlognaam.Visible = false;
            if(!IsPostBack)
            {
                if(Request.Cookies["Gebruikersnaam"] != null && Request.Cookies["Wachtwoord"] != null)
                {
                    Session["Email"] = Request.Cookies["Gebruikersnaam"].Value;
                }
            }

            if(Session["EMAIL"] != null)
            {
                Inlognaam.Text = Session["EMAIL"].ToString(); ;
                Inlognaam.Visible = true;
                loginLink.HRef = "~/Uitlog";
                loginLink.InnerText = "Uitloggen";
                registerLink.Visible = false;
                LijstenLink.Visible = true;
                GebruikerLink.Visible = true;
                ZoekenLink.Visible = true;
            }
            else
            {
                Inlognaam.Visible = false;
                loginLink.HRef = "~/Login";
                loginLink.InnerText = "Inloggen";
                registerLink.Visible = true;
                LijstenLink.Visible = false;
                GebruikerLink.Visible = false;
                ZoekenLink.Visible = false;
            }
        }
    }
}