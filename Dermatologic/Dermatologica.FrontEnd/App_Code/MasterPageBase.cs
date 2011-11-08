using System.Web.UI;
using Dermatologic.Services;

namespace Dermatologica.Web
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