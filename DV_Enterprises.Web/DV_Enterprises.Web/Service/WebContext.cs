using System;
using System.Web;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Service
{
    [Pluggable("Default")]
    public class WebContext : IWebContext
    {
        public int ProductId
        {
            get
            {
                var result = 0;
                if (GetQueryStringValue("ProductId") != null)
                {
                    result = Convert.ToInt32(GetQueryStringValue("ProductId"));
                }
                return result;
            }
        }

        public int GreenhouseId
        {
            get
            {
                var result = 0;
                if (GetQueryStringValue("GreenhouseId") != null)
                {
                    result = Convert.ToInt32(GetQueryStringValue("GreenhouseId"));
                }
                return result;
            }
        }

        public int GreenhouseIdSession
        {
            get
            {
                var result = 0;
                if (GetFromSession("GreenhouseId") != null)
                {
                    result = Convert.ToInt32(GetFromSession("GreenhouseId"));
                }
                return result;
            }
            set
            {
                if (GetFromSession("GreenhouseId") != null)
                {
                    UpdateInSession("GreenhouseId", value);
                }
                else
                {
                    SetInSession("GreenhouseId", value);
                }
            }
        }

        public void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }

        public bool ContainsInSession(string key)
        {
            return HttpContext.Current.Session != null && HttpContext.Current.Session[key] != null;
        }

        public void RemoveFromSession(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        private static string GetQueryStringValue(string key)
        {
            return HttpContext.Current.Request.QueryString.Get(key);
        }

        private static void SetInSession(string key, object value)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null) return;
            HttpContext.Current.Session[key] = value;
        }

        private static object GetFromSession(string key)
        {
            return HttpContext.Current == null || HttpContext.Current.Session == null
                       ? null
                       : HttpContext.Current.Session[key];
        }

        private static void UpdateInSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
    }
}