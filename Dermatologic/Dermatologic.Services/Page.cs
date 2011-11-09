using System;

namespace Dermatologic.Services
{
    public enum Page
    {
        [UrlPage(Url = "~/Derma/Admin/ListUsers.aspx")]
        ListUsers,

        [UrlPage(Url = "~/Account/ChangePasswordSuccess.aspx")]
        ChangePasswordSuccess,

        [UrlPage(Url = "~/Derma/Admin/Staff.aspx")]
        Staff,

        [UrlPage(Url = "~/Derma/Admin/ListRates.aspx")]
        ListRates,
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class UrlPageAttribute : Attribute
    {
        public string Url { get; set; }
        public bool EndResponse { get; set; }

        public UrlPageAttribute()
        {

        }

        public UrlPageAttribute(string url)
        {
            this.Url = url;
            this.EndResponse = false;
        }

        public UrlPageAttribute(string url, bool endResponse)
        {
            this.Url = url;
            this.EndResponse = endResponse;
        }
        
    }
}