using System;
using System.Runtime.Serialization;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    [DataContract]
    public class UsersService : ServiceController<Users>, IUsersService
    {
         public UsersService()
         {
             Repository = RepositoryFactory.GetUsersRepository();
         }

        
    }
}