using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CacheDemo
{
    public class WebApi
    {
        Dictionary<string, List<string>> _state_city_store = new Dictionary<string, List<string>>();
        public WebApi()
        {
            _state_city_store.Add("KA", new List<string> { "BLR", "BEL", "MYS" });
            _state_city_store.Add("MH", new List<string> { "BOM", "Pune", "Nasik" });
            _state_city_store.Add("AP", new List<string> { "HYD", "VIJ", "CHI" });
            _state_city_store.Add("TN", new List<string> { "CHN", "Madurai", "HOS" });
            
        }
        public List<string> GetCityList(string state)
        {
             return _state_city_store[state];   
        }
    }
}