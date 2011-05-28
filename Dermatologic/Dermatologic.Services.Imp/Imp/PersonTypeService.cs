using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class PersonTypeService : ServiceController<PersonType>, IPersonTypeService
    {
        public PersonTypeService()
        {
            Repository = RepositoryFactory.GetPersonTypeRepository();
        }
    }
}