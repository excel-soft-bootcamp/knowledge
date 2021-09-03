using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CacheDemo
{
    public partial class DataCache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cityCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           string cityCode= this.cityCombo.SelectedValue;
            string value= this.Cache[cityCode] as string;
            if (string.IsNullOrEmpty(value))
            {
                value = cityCode + " Description";
                Cache.Insert(cityCode,value);
                this.output.Text = value + " From DataBase";

            }
            else
            {
                this.output.Text = value + " From Cache";
            }
        }
    }
}