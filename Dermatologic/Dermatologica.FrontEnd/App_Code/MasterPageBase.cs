using System.Web.UI;
using Dermatologic.Services;

namespace ASP.App_Code
{
    public class MasterPageBase : MasterPage
    {
        private readonly AbstractServiceFactory bussinessFactory = new ServiceFactory();

        protected AbstractServiceFactory BussinessFactory
        {
            get { return bussinessFactory; }
        }   
    }
}