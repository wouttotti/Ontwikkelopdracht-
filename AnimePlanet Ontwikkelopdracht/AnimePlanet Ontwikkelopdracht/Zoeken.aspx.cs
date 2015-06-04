using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AnimePlanet_Ontwikkelopdracht
{
    public partial class Zoeken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindGridview_mouse_over_detailedData();
            }
        }
        public void bindGridview_mouse_over_detailedData()
        {
            // Created a new datatable
            DataTable dt = new DataTable();

            // Added columns to thedatatable
            dt.Columns.Add("item_id", typeof(string));
            dt.Columns.Add("titel", typeof(string));
            dt.Columns.Add("score", typeof(string));
            dt.Columns.Add("PictureUrl", typeof(string));
            dt.Columns.Add("Jaar", typeof(string));

            dt.Rows.Add("4", "Pandora Hearts", "4.1", @"C:\Users\Wout\Documents\GitHub\Ontwikkelopdracht-\AnimePlanet Ontwikkelopdracht\AnimePlanet Ontwikkelopdracht\Images\pandora_hearts.jpg", "2009");
            gv_MouseOverData.DataSource = dt;
            gv_MouseOverData.DataBind();
        }
    }
}