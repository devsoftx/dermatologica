using System;
using System.Web.Services;
using Telerik.Web.UI;

namespace ASP.App_Code
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class DataService : System.Web.Services.WebService
    {
        public DataService()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private static Guid GetContractCycleIDContext(RadComboBoxContext context)
        {
            if (string.IsNullOrEmpty(context["PersonType"].ToString()))
                return Guid.Empty;
            return new Guid((string)context["PersonType"]);

        }

        [WebMethod(EnableSession = false)]
        public RadComboBoxData LoadPersons(RadComboBoxContext context)
        {
            var result = new RadComboBoxData();
            try
            {

            }
            catch (Exception)
            {

            }

            return result;
        }
    }
}