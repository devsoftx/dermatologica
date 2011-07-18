using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class EmployeeTypeService : ServiceController<EmployeeType>,IEmployeeTypeService
    {
        public EmployeeTypeService()
        {
             Repository=RepositoryFactory.GetEmployeeTypeRepository();
        }

      
        
    }
}
