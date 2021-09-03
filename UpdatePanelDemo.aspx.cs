using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CacheDemo
{
    public partial class UpdatePanelDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void stateCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string statecode = this.stateCombo.Text;
            WebApi _webAPi = new WebApi();
          List<string> cities=  _webAPi.GetCityList(statecode);
            this.cityCombo.DataSource = cities;
            this.cityCombo.DataBind();
        }
    }
}