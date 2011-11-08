using System;
using System.Linq;
using System.Web.Services;
using Dermatologic.Domain;
using Dermatologic.Services;
using Telerik.Web.UI;

namespace Dermatologica.Web
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class DataService : WebService
    {
        private readonly AbstractServiceFactory bussinessFactory = new ServiceFactory();

        private AbstractServiceFactory BussinessFactory
        {
            get { return bussinessFactory; }
        }

        public DataService()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private static Guid GetPersonTypeContext(RadComboBoxContext context)
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
                var example = new Person
                                  {
                                      PersonType = { Id = GetPersonTypeContext(context) }
                                  };
                var response = BussinessFactory.GetPersonService().GetPacients(example);
                var allResult = from c in response.Pacients
                                select new RadComboBoxItemData
                                {
                                    Text = c.CompleteName,
                                    Value = c.Id.ToString()
                                };
                result.Items = allResult.ToArray();
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
    }
}
    
