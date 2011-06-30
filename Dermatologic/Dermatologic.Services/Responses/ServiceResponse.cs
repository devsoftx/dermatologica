using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class ServiceResponse: ResponseBase<Service>
    {
        public IList<Service> Services { set; get; }
    }

  }
