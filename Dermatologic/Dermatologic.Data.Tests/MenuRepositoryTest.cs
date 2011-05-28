using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dermatologic.Data.Persistence;
using Dermatologic.Domain;
using NHibernate;
using NUnit.Framework;

namespace Dermatologic.Data.Tests
{
    
    [TestFixture]
    public class MenuRepositoryTest : NhibernateTest
    {
        [Test]
        public void Must_Be_Saved_Test()
        {
            using (var session = PersistenceManager.OpenSession())
            {
                ITransaction transaction = session.BeginTransaction();
                var menu = new Menu
                {
                    Id = Guid.NewGuid(),
                    Name = "Administracion",
                    IsActive = true,
                    LastModified = DateTime.Now,
                    CreationDate = DateTime.Now,
                    CreatedBy = Guid.NewGuid(),
                    ModifiedBy = Guid.NewGuid()
                };
                session.Save(menu);
                transaction.Commit();
            }
        }
    }
}
