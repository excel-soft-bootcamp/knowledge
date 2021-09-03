using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CacheDemo
{
    public partial class AjaxDemo : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {

                

                Cache.Insert("statecitylist",GetDictionaryData());
            }
        }

        Dictionary<string,List<string>> GetDictionaryData()
        {
            Dictionary<string, List<string>> _state_city_store = new Dictionary<string, List<string>>();
            _state_city_store.Add("KA", new List<string> { "BLR", "BEL", "MYS" });
            _state_city_store.Add("MH", new List<string> { "BOM", "Pune", "Nasik" });
            _state_city_store.Add("AP", new List<string> { "HYD", "VIJ", "CHI" });
            _state_city_store.Add("TN", new List<string> { "CHN", "Madurai", "HOS" });
            return _state_city_store;
        }
        protected void stateCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Delay(5000).Wait();
            string stateCode = this.stateCombo.Text;
        Dictionary<string,List<string>>  stateCityList = Cache.Get("satecitylist") as Dictionary<string, List<string>>;


            if (stateCityList == null)
            {
                stateCityList = GetDictionaryData();
                Cache.Insert("statecitylist", stateCityList);

            }

            List<string> cities = stateCityList[stateCode];
            this.cityCombo.DataSource = cities;
            this.cityCombo.DataBind();


        }
    }
}