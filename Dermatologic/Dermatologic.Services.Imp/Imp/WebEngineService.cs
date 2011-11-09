using System;

namespace Dermatologic.Services
{
    public class WebEngineService : IWebEngineService
    {
        public void Navigate(Page page)
        {
            var _context = System.Web.HttpContext.Current.Response;

            Attribute att = Attribute.GetCustomAttribute(
                page.GetType().GetField(page.ToString()), typeof(UrlPageAttribute));

            UrlPageAttribute urlAtt = null;

            if (att is UrlPageAttribute)
                urlAtt = att as UrlPageAttribute;

            if (urlAtt != null)
                _context.Redirect(urlAtt.Url, urlAtt.EndResponse);
        }

        public void Navigate(string page)
        {
            var _context = System.Web.HttpContext.Current.Response;
            _context.Redirect(page, false);
        }
    }
}