using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ConfOrm;
using ConfOrm.Mappers;
using ConfOrm.NH;
using ConfOrm.Patterns;
using Dermatologic.Domain;
using NHibernate;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Cfg.Loquacious;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NUnit.Framework;
using Configuration = NHibernate.Cfg.Configuration;
using FetchMode = ConfOrm.Mappers.FetchMode;

namespace Dermatologic.Data.Tests
{
    public class NhibernateTest
    {
        public ISession Session { set; get; }

        private ISessionFactory Factory { set; get; }

        [SetUp]
        public void SetUp()
        {
            var configure = new Configuration();
            configure.SessionFactoryName("Dermatologic");

            configure.Proxy(p => p.ProxyFactoryFactory<ProxyFactoryFactory>());
            configure.DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2005Dialect>();
                db.Driver<SqlClientDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
                db.LogSqlInConsole = true;
                db.HqlToSqlSubstitutions = "true 1, false 0, yes 'Y', no 'N'";
            });

            configure.AddDeserializedMapping(GetMapping(), "Dermatologic_ConfORM");
            Factory = configure.BuildSessionFactory();
            Session = Factory.OpenSession();
        }

        private static HbmMapping GetMapping()
        {
            var orm = new ObjectRelationalMapper();
            orm.Patterns.PoidStrategies.Add(new AssignedPoidPattern());
            var mapper = new Mapper(orm);
            var entities = new List<Type>();
            DomainDefinition(orm);
            Customize(mapper);
            entities.AddRange(GetEntities());
            return mapper.CompileMappingFor(entities);
        }

        private static void DomainDefinition(ObjectRelationalMapper orm)
        {
            orm.TablePerClass(GetEntities());
        }

        private static void Customize(Mapper mapper)
        {
            CustomizeRelations(mapper);
            CustomizeColumns(mapper);
        }

        private static void CustomizeRelations(Mapper mapper)
        {
            mapper.Class<Menu>(cm =>
            {
                cm.Id(o => o.Id, im => im.Generator(Generators.Assigned));
                cm.Bag(
                    o => o.MenuRoles,
                    x =>
                    {
                        x.Key(k => k.Column("MenuId"));
                        x.Lazy(CollectionLazy.Lazy);
                    },
                    x => { });
            });

            mapper.Class<MenuRole>(cm =>
            {
                cm.Id(o => o.Id, im => im.Generator(Generators.Assigned));
                cm.ManyToOne(
                    x => x.Menu,
                    m =>
                    {
                        m.Column("MenuId");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(true);
                    });
            });
        }

        private static void CustomizeColumns(Mapper mapper)
        {
            mapper.Class<Menu>(
                cm =>
                {
                    cm.Id(x => x.Id, m => m.Column("Id"));
                    cm.Property(x => x.ParentId, m => m.NotNullable(false));
                    cm.Property(x => x.Id, m => m.NotNullable(true));
                    cm.Property(x => x.Url, m => m.NotNullable(false));
                    cm.Property(x => x.Name, m => m.NotNullable(true));
                    cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                    cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                    cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                    cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                    cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
                }
                );

            mapper.Class<MenuRole>(
                cm =>
                {
                    cm.Id(x => x.Id, m => m.Column("Id"));
                    cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                    cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                    cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                    cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                    cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
                });

            mapper.Class<Person>(
                cm =>
                {
                    cm.Id(x => x.Id, m => m.Column("Id"));
                    cm.Property(x => x.FirstName, m => m.NotNullable(false));
                    cm.Property(x => x.FirstName, m => m.Column("FirstName"));
                    cm.Property(x => x.LastNameP, m => m.NotNullable(false));
                    cm.Property(x => x.LastNameP, m => m.Column("LastName"));
                    cm.Property(x => x.DocumentType, m => m.NotNullable(false));
                    cm.Property(x => x.DocumentType, m => m.Column("DocumentType"));
                    cm.Property(x => x.DocumentNumber, m => m.NotNullable(false));
                    cm.Property(x => x.DocumentNumber, m => m.Column("DocumentNumber"));
                    cm.Property(x => x.DateBirthDay, m => m.NotNullable(false));
                    cm.Property(x => x.DateBirthDay, m => m.Column("DateBirthday"));
                    cm.Property(x => x.Phone, m => m.NotNullable(false));
                    cm.Property(x => x.Phone, m => m.Column("Phone"));
                    cm.Property(x => x.CellPhone, m => m.NotNullable(false));
                    cm.Property(x => x.CellPhone, m => m.Column("CellPhone"));
                    cm.Property(x => x.EmergencyPhone, m => m.NotNullable(true));
                    cm.Property(x => x.EmergencyPhone, m => m.Column("CellPhone"));
                    cm.Property(x => x.Address, m => m.NotNullable(true));
                    cm.Property(x => x.Address, m => m.Column("Address"));
                    cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                    cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                    cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                    cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                    cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
                }
                );
        }

        private static IEnumerable<Type> GetEntities()
        {
            return typeof(Person).Assembly.GetTypes().Where(t => t.Namespace == typeof(Person).Namespace);
        }

        [TearDown]
        public void Dispose()
        {
            Session.Dispose();
            Session = null;
        }
    }
}
