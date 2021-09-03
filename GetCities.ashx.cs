using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CacheDemo
{
    /// <summary>
    /// Summary description for GetCities
    /// </summary>
    public class GetCities : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            WebApi _apiObj = new WebApi();
          string stateCode=  context.Request.QueryString["statecode"];
           List<string> _cities= _apiObj.GetCityList(stateCode);
            StringBuilder cityBuilder = new StringBuilder();
           foreach(string city in _cities)
            {
                cityBuilder.Append(city).Append(",");

            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(cityBuilder.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}