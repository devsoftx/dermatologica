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
using NHibernate.Linq;
using Configuration = NHibernate.Cfg.Configuration;
using FetchMode = ConfOrm.Mappers.FetchMode;

namespace Dermatologic.Data.Persistence
{
    public static class PersistenceManager
    {
        private static ISessionFactory factory;

        public static ISessionFactory SessionFactory
        {
            get { return factory; }
        }

        private static ISessionFactory Factory
        {
            get
            {
                if (factory == null)
                {
                    Configuration config = CreateConfiguration();
                    log4net.Config.XmlConfigurator.Configure();
                    factory = config.BuildSessionFactory();
                }

                return factory;
            }
        }

        public static ISession OpenSession()
        {
            return Factory.OpenSession();
        }

        private static Configuration CreateConfiguration()
        {
            var configure = new Configuration();
            configure.SessionFactoryName("Dermatologic");
            log4net.Config.XmlConfigurator.Configure();
            configure.Proxy(p => p.ProxyFactoryFactory<ProxyFactoryFactory>());
            configure.DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2005Dialect>();
                db.Driver<SqlClientDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
                db.LogSqlInConsole = true;
                db.HqlToSqlSubstitutions = "true 1, false 0, yes 'Y', no 'N'";
                db.LogFormatedSql = true;
                db.AutoCommentSql = true;
                db.PrepareCommands = true;
                
            });

            configure.AddDeserializedMapping(GetMapping(), "Dermatologic.Data");
            return configure;
        }

        private static HbmMapping GetMapping()
        {
            var orm = new ObjectRelationalMapper();
            orm.Patterns.PoidStrategies.Add(new AssignedPoidPattern());
            var mapper = new Mapper(orm);
            var entities = new List<Type>();
            DomainDefinition(orm);
            RegisterPatterns(mapper, orm);
            Customize(mapper);
            entities.AddRange(GetEntities());
            return mapper.CompileMappingFor(entities);
        }

        private static void DomainDefinition(ObjectRelationalMapper orm)
        {
            orm.TablePerClass(GetEntities());
        }

        private static void RegisterPatterns(Mapper mapper, IDomainInspector domainInspector)
        {

        }

        private static void Customize(Mapper mapper)
        {
            CustomizeRelations(mapper);
            CustomizeTables(mapper);
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

            mapper.Class<Role>(cm =>
            {
                cm.Id(o => o.RoleId, im => im.Generator(Generators.Assigned));
                cm.Bag(
                    o => o.MenuRoles,
                    x =>
                    {
                        x.Key(k => k.Column("MenuId"));
                        x.Lazy(CollectionLazy.Lazy);
                    },
                    x => { });
                cm.Bag(
                    o => o.UsersInRoles,
                    x =>
                    {
                        x.Key(k => k.Column("UserId"));
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
                cm.ManyToOne(
                    x => x.Role,
                    m =>
                    {
                        m.Column("RoleId");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(true);
                    });
            });

            mapper.Class<Person>(cm =>
            {
                cm.Id(o => o.Id, im => im.Generator(Generators.Assigned));
                cm.ManyToOne(
                    x => x.PersonType,
                    m =>
                    {
                        m.Column("IdPersonType");
                        m.Fetch(FetchMode.Join);
                        m.Cascade(Cascade.All);
                    });
            });

            mapper.Class<PersonType>(cm =>
            {
                cm.Id(o => o.Id, im => im.Generator(Generators.Assigned));
                cm.Bag(
                    o => o.Persons,
                    x =>
                    {
                        x.Key(k => k.Column("Id"));
                        x.Lazy(CollectionLazy.Lazy);
                    },
                    x => { });
            });

            mapper.Class<Service>(cm =>
            {
                cm.Id(o => o.Id, im => im.Generator(Generators.Assigned));
                cm.ManyToOne(
                    x => x.CostCenter,
                    m =>
                    {
                        m.Column("IdCostCenter");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(true);
                    });
               
            });
            mapper.Class<Medication>(cm =>
            {
                cm.Id(o => o.Id, im => im.Generator(Generators.Assigned));
                cm.ManyToOne(
                    x => x.Patient,
                    m =>
                    {
                        m.Column("IdPatient");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(true);
                    });
                cm.ManyToOne(
                   x => x.Service,
                   m =>
                   {
                       m.Column("IdService");
                       m.Fetch(FetchMode.Join);
                       m.NotNullable(true);
                   });
                cm.Bag(
                    o => o.Sessions,
                    x =>
                    {
                        x.Key(k => k.Column("Id"));
                        x.Cascade(Cascade.All);
                        x.Table("Session");
                    },
                    x =>
                        {
                            x.ManyToMany(k => k.Column("Id"));
                            x.ManyToMany(g => g.Class(typeof(Session)));
                        });
            });

            mapper.Class<Session>(cm =>
            {
                cm.Id(o => o.Id, im => im.Generator(Generators.Assigned));
                cm.ManyToOne(
                    x => x.Medication,
                    m =>
                    {
                        m.Column("IdMedication");
                        m.Fetch(FetchMode.Join);
                        m.Cascade(Cascade.Persist | Cascade.Remove);
                    });
            });

            mapper.Class<Rate>(cm =>
            {
                cm.Id(o => o.Id, im => im.Generator(Generators.Assigned));
                cm.ManyToOne(
                    x => x.Service,
                    m =>
                    {
                        m.Column("IdService");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(true);  
                    });
                cm.ManyToOne(
                   x => x.Person,
                   m =>
                   {
                       m.Column("IdPerson");
                       m.Fetch(FetchMode.Join);
                       m.NotNullable(true);
                   });
            });

            mapper.Class<MedicalCare>(cm =>
            {
                cm.Id(o => o.Id, im => im.Generator(Generators.Assigned));
                cm.ManyToOne(
                    x => x.Session,
                    m =>
                    {
                        m.Column("IdSession");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(true);
                    });
                cm.ManyToOne(
                    x => x.Pacient,
                    m =>
                    {
                        m.Column("IdPatient");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(true);
                    });
                cm.ManyToOne(
                  x => x.Medical,
                  m =>
                  {
                      m.Column("IdMedical");
                      m.Fetch(FetchMode.Join);
                      m.NotNullable(true);
                  });
                cm.ManyToOne(
                x => x.Partner,
                m =>
                {
                    m.Column("IdPartner");
                    m.Fetch(FetchMode.Join);
                    m.NotNullable(false);
                });
                cm.ManyToOne(
                 x => x.Rate,
                 m =>
                 {
                     m.Column("IdRate");
                     m.Fetch(FetchMode.Join);
                     m.NotNullable(true);
                 });
                cm.ManyToOne(
                 x => x.CostCenter,
                 m =>
                 {
                     m.Column("IdCostCenterR");
                     m.Fetch(FetchMode.Join);
                     m.NotNullable(false);
                 });
            });

            mapper.Class<CashMovement>(cm =>
            {
                cm.Id(o => o.Id, im => im.Generator(Generators.Assigned));
                cm.ManyToOne(
                    x => x.Invoice,
                    m =>
                    {
                        m.Column("IdInvoice");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(true);
                        m.Cascade(Cascade.Persist | Cascade.Remove);
                    });
                cm.ManyToOne(
                    x => x.CostCenter,
                    m =>
                    {
                        m.Column("IdCostCenter");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(true);
                    });
               
            });

            mapper.Class<Invoice>(cm =>
            {
                cm.Id(o => o.Id, im => im.Generator(Generators.Assigned));
                cm.ManyToOne(
                    x => x.Patient,
                    m =>
                    {
                        m.Column("IdPatient");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(false);
                    });
                cm.ManyToOne(
                    x => x.Session,
                    m =>
                    {
                        m.Column("IdSession");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(false);
                    });
                cm.ManyToOne(
                    x => x.Personal,
                    m =>
                    {
                        m.Column("IdPersonal");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(false);
                    });
                cm.ManyToOne(
                   x => x.MedicalCare,
                   m =>
                   {
                       m.Column("IdMedicalCare");
                       m.Fetch(FetchMode.Join);
                       m.NotNullable(false);
                   });
                cm.ManyToOne(
                    x => x.CostCenter,
                    m =>
                    {
                        m.Column("IdCostCenter");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(true);
                    });
                cm.Bag(
                    o => o.CashMovements,
                    x =>
                    {
                        x.Key(k => k.Column("Id"));
                        x.Cascade(Cascade.All);
                        x.Table("CashMovement");
                    },
                    x =>
                    {
                        x.ManyToMany(k => k.Column("Id"));
                        x.ManyToMany(g => g.Class(typeof(CashMovement)));
                    });
            });
            mapper.Class<StaffInformation>(cm =>
            {
                cm.Id(o => o.Id, im => im.Generator(Generators.Assigned));
                cm.ManyToOne(
                    x => x.CostCenter,
                    m =>
                    {
                        m.Column("IdCostCenter");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(true);
                    });
                cm.ManyToOne(
                    x => x.EmployeeType,
                    m =>
                    {
                        m.Column("IdEmployeeType");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(true);
                    });
                cm.ManyToOne(
                   x => x.TypeContract,
                   m =>
                   {
                       m.Column("IdTypeContract");
                       m.Fetch(FetchMode.Join);
                       m.NotNullable(true);
                   });

            });

            mapper.Class<Appointment>(cm =>
            {
                cm.Id(o => o.Id, im => im.Generator(Generators.Assigned));
                cm.ManyToOne(
                    x => x.Office,
                    m =>
                        {
                            m.Column("IdOffice");
                            m.Fetch(FetchMode.Join);
                            m.NotNullable(false);
                        });
                cm.ManyToOne(
                    x => x.Medical,
                    m =>
                    {
                        m.Column("IdPerson");
                        m.Fetch(FetchMode.Join);
                        m.NotNullable(false);
                    });
            });

            mapper.Class<Office>(cm =>
            {
                cm.Id(o => o.Id, im => im.Generator(Generators.Assigned));
                cm.Bag(
                    o => o.Appointments,
                    x =>
                    {
                        x.Key(k => k.Column("Id"));
                        x.Lazy(CollectionLazy.Lazy);
                    },
                    x => { });
            });
        }

        private static void CustomizeTables(Mapper mapper)
        {
            mapper.Class<Role>(x => x.Table("[aspnet_Roles]"));
            mapper.Class<UsersInRoles>(x => x.Table("[aspnet_UsersInRoles]"));
            mapper.Class<Users>(x => x.Table("[aspnet_Users"));
            mapper.Class<Session>(x => x.Table("[Session]"));
            mapper.Class<Service>(x => x.Table("[Service]"));
            mapper.Class<ExchangeRate>(x => x.Table("[ExchangeRate]"));
        }

        private static void CustomizeColumns(Mapper mapper)
        {
            mapper.Class<Users>(
                cm =>
                {
                    cm.Id(x => x.UserId, m => m.Column("UserId"));
                    cm.Property(x => x.ApplicationId, m => m.Column("ApplicationId"));
                    cm.Property(x => x.UserName, m => m.Column("UserName"));
                    cm.Property(x => x.LoweredUserName, m => m.Column("LoweredUserName"));
                    cm.Property(x => x.IsAnonymous, m => m.Column("IsAnonymous"));
                    cm.Property(x => x.LastActivityDate, m => m.Column("LastActivityDate"));
                }
                );

            mapper.Class<Role>(
                cm =>
                {
                    cm.Id(x => x.RoleId, m => m.Column("RoleId"));
                    cm.Property(x => x.ApplicationId, m => m.Column("ApplicationId"));
                    cm.Property(x => x.RoleName, m => m.Column("RoleName"));
                    cm.Property(x => x.Description, m => m.Column("Description"));
                    cm.Property(x => x.LoweredRoleName, m => m.Column("LoweredRoleName"));
                }
                );
            mapper.Class<UsersInRoles>(
                cm =>
                {
                    cm.Property(x => x.RoleId, m => m.Column("RoleId"));
                    cm.Property(x => x.UserId, m => m.Column("UserId"));
                }
                );

            mapper.Class<Menu>(
                cm =>
                {
                    cm.Id(x => x.Id, m => m.Column("Id"));
                    cm.Property(x => x.ParentId, m => m.NotNullable(false));
                    cm.Property(x => x.ParentId, m => m.Column("ParentId"));
                    cm.Property(x => x.Url, m => m.NotNullable(false));
                    cm.Property(x => x.Url, m => m.Column("Url"));
                    cm.Property(x => x.Name, m => m.NotNullable(true));
                    cm.Property(x => x.Name, m => m.Column("[Name]"));
                    cm.Property(x => x.Description, m => m.Column("Description"));
                    cm.Property(x => x.Orden, m => m.Column("[Order]"));
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
                    cm.Property(x => x.FirstName, m => m.Column("FirstName"));
                    cm.Property(x => x.LastNameP, m => m.Column("LastNameP"));
                    cm.Property(x => x.LastNameM, m => m.Column("LastNameM"));
                    cm.Property(x => x.DocumentType, m => m.Column("DocumentType"));
                    cm.Property(x => x.DocumentNumber, m => m.Column("DocumentNumber"));
                    cm.Property(x => x.Picture, m => m.Column("Picture"));
                    cm.Property(x => x.DateBirthDay, m => m.Column("DateBirthday"));
                    cm.Property(x => x.Phone, m => m.Column("Phone"));
                    cm.Property(x => x.CellPhone, m => m.Column("CellPhone"));
                    cm.Property(x => x.Email, m => m.Column("Email"));
                    cm.Property(x => x.EmergencyPhone, m => m.Column("EmergencyPhone"));
                    cm.Property(x => x.Address, m => m.Column("Address"));
                    cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                    cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                    cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                    cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                    cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
                    cm.Property(x => x.EmergencyPerson, m => m.Column("EmergencyPerson"));
                    cm.Property(x => x.Code, m => m.Column("Code"));
                }
                );

            mapper.Class<PersonType>(
                cm =>
                {
                    cm.Id(x => x.Id, m => m.Column("Id"));
                    cm.Property(x => x.Name, m => m.Column("[Name]"));
                    cm.Property(x => x.Description, m => m.Column("Description"));
                    cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                    cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                    cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                    cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                    cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
                }
                );

            mapper.Class<Ubigeo>(
                cm =>
                {
                    cm.Id(x => x.Id, m => m.Column("Id"));
                    cm.Property(x => x.Dpto, m => m.Column("ub_CodDpto"));
                    cm.Property(x => x.Prov, m => m.Column("ub_CodProv"));
                    cm.Property(x => x.Dist, m => m.Column("ub_CodDist"));
                    cm.Property(x => x.Name, m => m.Column("ub_Nombre"));
                    cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                    cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                    cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                    cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                    cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
                }
                );

            mapper.Class<Medication>(
                cm =>
                {
                    cm.Id(x => x.Id, m => m.Column("Id"));
                    cm.Property(x => x.Description, m => m.Column("Description"));
                    cm.Property(x => x.Currency, m => m.Column("Currency"));
                    cm.Property(x => x.Price, m => m.Column("Price"));
                    cm.Property(x => x.DiscountT, m => m.Column("DiscountT"));
                    cm.Property(x => x.NumberSessions, m => m.Column("NumberSessions"));
                    cm.Property(x => x.IsCompleted, m => m.Column("IsCompleted"));
                    cm.Property(x => x.Unpaid, m => m.Column("Unpaid"));
                    cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                    cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                    cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                    cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                    cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
                }
                );

            mapper.Class<MedicalCare>(
                cm =>
                {
                    cm.Id(x => x.Id, m => m.Column("Id"));
                    cm.Property(x => x.Description, m => m.Column("Description"));
                    cm.Property(x => x.DateAttention, m => m.Column("DateAttention"));
                    cm.Property(x => x.IsPaid, m => m.Column("IsReplacement"));
                    cm.Property(x => x.IsPaid, m => m.Column("IsPaid"));
                    cm.Property(x => x.IsPaidPartner, m => m.Column("IsPaidPartner"));
                    cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                    cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                    cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                    cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                    cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
                }
                );

            mapper.Class<Rate>(
                cm =>
                {
                    cm.Id(x => x.Id, m => m.Column("Id"));
                    cm.Property(x => x.Currency, m => m.Column("Currency"));
                    cm.Property(x => x.UnitCost, m => m.Column("UnitCost"));
                    cm.Property(x => x.UnitCostPartner, m => m.Column("UnitCostPartner"));
                    cm.Property(x => x.Observation, m => m.Column("Observation"));
                    cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                    cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                    cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                    cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                    cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
                    cm.Property(x => x.CurrencyPartner, m => m.Column("CurrencyPartner"));
                }
                );

            mapper.Class<Session>(
                cm =>
                {
                    cm.Id(x => x.Id, m => m.Column("Id"));
                    cm.Property(x => x.Currency, m => m.Column("Currency"));
                    cm.Property(x => x.RowId, m => m.Column("[RowId]"));
                    cm.Property(x => x.Price, m => m.Column("Price"));
                    cm.Property(x => x.Account, m => m.Column("Account"));
                    cm.Property(x => x.Residue, m => m.Column("Residue"));
                    cm.Property(x => x.Description, m => m.Column("Description"));
                    cm.Property(x => x.IsCompleted, m => m.Column("IsCompleted"));
                    cm.Property(x => x.IsPaid, m => m.Column("IsPaid"));
                    cm.Property(x => x.Unpaid, m => m.Column("Unpaid"));
                    cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                    cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                    cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                    cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                    cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
                }
                );

            mapper.Class<Service>(
                cm =>
                {
                    cm.Id(x => x.Id, m => m.Column("Id"));
                    cm.Property(x => x.Name, m => m.Column("[Name]"));
                    cm.Property(x => x.Description, m => m.Column("Description"));
                    cm.Property(x => x.Price, m => m.Column("Price"));
                    cm.Property(x => x.Currency, m => m.Column("Currency"));
                    cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                    cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                    cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                    cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                    cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
                }
                );

            mapper.Class<Supply>(
                cm =>
                {
                    cm.Id(x => x.Id, m => m.Column("Id"));
                    cm.Property(x => x.Name, m => m.Column("[Name]"));
                    cm.Property(x => x.Description, m => m.Column("Description"));
                    cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                    cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                    cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                    cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                    cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
                }
                );

            mapper.Class<ExchangeRate>(
               cm =>
               {
                   cm.Id(x => x.Id, m => m.Column("Id"));
                   cm.Property(x => x.DateRate, m => m.Column("DateRate"));
                   cm.Property(x => x.Currency, m => m.Column("Currency"));
                   cm.Property(x => x.Buy, m => m.Column("Buy"));
                   cm.Property(x => x.Sale, m => m.Column("Sale"));
                   cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                   cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                   cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                   cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                   cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
               }
               );

            mapper.Class<Account>(
               cm =>
               {
                   cm.Id(x => x.Id, m => m.Column("Id"));
                   cm.Property(x => x.Name, m => m.Column("[Name]"));
                   cm.Property(x => x.Description, m => m.Column("Description"));
                   cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                   cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                   cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                   cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                   cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
               }
               );

            mapper.Class<CostCenter>(
               cm =>
               {
                   cm.Id(x => x.Id, m => m.Column("Id"));
                   cm.Property(x => x.Name, m => m.Column("[Name]"));
                   cm.Property(x => x.Description, m => m.Column("Description"));
                   cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                   cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                   cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                   cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                   cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
               }
               );
            mapper.Class<Invoice>(
               cm =>
               {
                   cm.Id(x => x.Id, m => m.Column("Id"));
                   cm.Property(x => x.Name, m => m.Column("[Name]"));
                   cm.Property(x => x.Description, m => m.Column("Description"));
                   cm.Property(x => x.DatePayment, m => m.Column("DatePayment"));
                   cm.Property(x => x.MPayment, m => m.Column("MPayment"));
                   cm.Property(x => x.InvoiceType, m => m.Column("InvoiceType"));
                   cm.Property(x => x.NInvoice, m => m.Column("NInvoice"));
                   cm.Property(x => x.Amount, m => m.Column("Amount"));
                   cm.Property(x => x.Currency, m => m.Column("Currency"));
                   cm.Property(x => x.ExchangeRate, m => m.Column("ExchangeRate"));
                   cm.Property(x => x.Movement, m => m.Column("Movement"));
                   cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                   cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                   cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                   cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                   cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
               }
               );
           
              mapper.Class<CashMovement>(
               cm =>
               {
                   cm.Id(x => x.Id, m => m.Column("Id"));
                   cm.Property(x => x.MPayment, m => m.Column("MPayment"));
                   cm.Property(x => x.Date, m => m.Column("[Date]"));
                   cm.Property(x => x.EmissionAmount, m => m.Column("EmissionAmount"));
                   cm.Property(x => x.Amount, m => m.Column("Amount"));
                   cm.Property(x => x.Factor, m => m.Column("[Factor]"));
                   cm.Property(x => x.Currency, m => m.Column("[Currency]"));
                   cm.Property(x => x.ExchangeRate, m => m.Column("ExchangeRate"));
                   cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                   cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                   cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                   cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                   cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
               }
               );

            mapper.Class<StaffInformation>(
               cm =>
               {
                   cm.Id(x => x.Id, m => m.Column("Id"));
                   cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                   cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                   cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                   cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                   cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
               }
               );

            mapper.Class<PatientInformation>(
               cm =>
               {
                   cm.Id(x => x.Id, m => m.Column("Id"));
                   cm.Property(x => x.HaveHerpesLabial, m => m.Column("HaveHerpesLabial"));
                   cm.Property(x => x.DateHerpesLabial, m => m.Column("DateHerpesLabial"));
                   cm.Property(x => x.IsUseMarcapaso, m => m.Column("IsUseMarcapaso"));
                   cm.Property(x => x.DateUseMarcapaso, m => m.Column("DateUseMarcapaso"));
                   cm.Property(x => x.HaveVerrugas, m => m.Column("HaveVerrugas"));
                   cm.Property(x => x.DateVerrugas, m => m.Column("DateVerrugas"));
                   cm.Property(x => x.HaveHepatitisB, m => m.Column("HaveHepatitisB"));
                   cm.Property(x => x.HaveDiabetes, m => m.Column("HaveDiabetes"));
                   cm.Property(x => x.DateDiabetes, m => m.Column("DateDiabetes"));
                   cm.Property(x => x.HaveDermatitisAtopica, m => m.Column("HaveDermatitisAtopica"));
                   cm.Property(x => x.DateDermatitisAtopica, m => m.Column("DateDermatitisAtopica"));
                   cm.Property(x => x.HaveHipotiroidismo, m => m.Column("HaveHipotiroidismo"));
                   cm.Property(x => x.DateHipotiroidismo, m => m.Column("DateHipotiroidismo"));
                   cm.Property(x => x.CommentsAntecedentesEnfermedades, m => m.Column("CommentsAntecedentesEnfermedades"));
                   cm.Property(x => x.HaveWarfarina, m => m.Column("HaveWarfarina"));
                   cm.Property(x => x.HaveAntibioticosAcne, m => m.Column("HaveAntibioticosAcne"));
                   cm.Property(x => x.HaveRoaccuatan, m => m.Column("HaveRoaccuatan"));
                   cm.Property(x => x.HaveIsotretinoina, m => m.Column("HaveIsotretinoina"));
                   cm.Property(x => x.HaveVitaminas, m => m.Column("HaveVitaminas"));
                   cm.Property(x => x.HaveAspirinas, m => m.Column("HaveAspirinas"));
                   cm.Property(x => x.CommentsMedicacionHabitual, m => m.Column("CommentsMedicacionHabitual"));
                   cm.Property(x => x.HaveAlergiaAnestesicosHabituales, m => m.Column("HaveAlergiaAnestesicosHabituales"));
                   cm.Property(x => x.HaveAlergiaAspirinas, m => m.Column("HaveAlergiaAspirinas"));
                   cm.Property(x => x.HaveAlergiaCorticoides, m => m.Column("HaveAlergiaCorticoides"));
                   cm.Property(x => x.HaveAlergiaAsma, m => m.Column("HaveAlergiaAsma"));
                   cm.Property(x => x.HaveAlergiaRinitis, m => m.Column("HaveAlergiaRinitis"));
                   cm.Property(x => x.CommentsAntecedentesAlergias, m => m.Column("CommentsAntecedentesAlergias"));
                   cm.Property(x => x.HaveLifting, m => m.Column("HaveLifting"));
                   cm.Property(x => x.HaveRellenos, m => m.Column("HaveRellenos"));
                   cm.Property(x => x.HaveBotox, m => m.Column("HaveBotox"));
                   cm.Property(x => x.HaveLaser, m => m.Column("HaveLaser"));
                   cm.Property(x => x.CommentsTratamientosCirugiasActAnt, m => m.Column("CommentsTratamientosCirugiasActAnt"));
                   cm.Property(x => x.IsFumador, m => m.Column("IsFumador"));
                   cm.Property(x => x.IsHabitoBronceadoSoloVer, m => m.Column("IsHabitoBronceadoSoloVer"));
                   cm.Property(x => x.IsHabitoBronceadoTodoAno, m => m.Column("IsHabitoBronceadoTodoAno"));
                   cm.Property(x => x.IsHabitoEvitoBroncearme, m => m.Column("IsHabitoEvitoBroncearme"));
                   cm.Property(x => x.HaveCicatricesQueloides, m => m.Column("HaveCicatricesQueloides"));
                   cm.Property(x => x.AreaCicatricesQueloides, m => m.Column("AreaCicatricesQueloides"));
                   cm.Property(x => x.IsDepilacion, m => m.Column("IsDepilacion"));
                   cm.Property(x => x.AreaDepilacion, m => m.Column("AreaDepilacion"));
                   cm.Property(x => x.MetodoDepilacion, m => m.Column("MetodoDepilacion"));
                   cm.Property(x => x.IsEmbarazada, m => m.Column("IsEmbarazada"));
                   cm.Property(x => x.DateLastRegla, m => m.Column("DateLastRegla"));
                   cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                   cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                   cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                   cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                   cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
               }
               );

            mapper.Class<Appointment>(
                cm =>
                {
                    cm.Id(x => x.Id, m => m.Column("Id"));
                    cm.Property(x => x.Subject, m => m.Column("Subject"));
                    cm.Property(x => x.StartDate, m => m.Column("StartDate"));
                    cm.Property(x => x.EndDate, m => m.Column("EndDate"));
                    cm.Property(x => x.RecurrenceRule, m => m.Column("RecurrenceRule"));
                    cm.Property(x => x.RecurrenceParentID, m => m.Column("RecurrenceParentID"));
                    cm.Property(x => x.Patient, m => m.Column("Patient"));
                    cm.Property(x => x.Description, m => m.Column("Description"));
                    cm.Property(x => x.NotifyEach, m => m.Column("NotifyEach"));
                    cm.Property(x => x.Frecuence, m => m.Column("Frecuence"));
                    cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                    cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                    cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                    cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                    cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
                }
                );

            mapper.Class<Office>(
                cm =>
                {
                    cm.Id(x => x.Id, m => m.Column("Id"));
                    cm.Property(x => x.Name, m => m.Column("Name"));
                    cm.Property(x => x.Description, m => m.Column("Description"));
                    cm.Property(x => x.ColorId, m => m.Column("ColorId"));
                    cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                    cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                    cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                    cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                    cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
                }
                );
            mapper.Class<EmployeeType>(
               cm =>
               {
                   cm.Id(x => x.Id, m => m.Column("Id"));
                   cm.Property(x => x.Name, m => m.Column("Name"));
                   cm.Property(x => x.Description, m => m.Column("Description"));
                   cm.Property(x => x.IsActive, m => m.Column("IsActive"));
                   cm.Property(x => x.CreationDate, m => m.Column("CreationDate"));
                   cm.Property(x => x.LastModified, m => m.Column("LastModified"));
                   cm.Property(x => x.CreatedBy, m => m.Column("CreatedBy"));
                   cm.Property(x => x.ModifiedBy, m => m.Column("ModifiedBy"));
               }
               );
            mapper.Class<TypeContract>(
               cm =>
               {
                   cm.Id(x => x.Id, m => m.Column("Id"));
                   cm.Property(x => x.Name, m => m.Column("Name"));
                   cm.Property(x => x.Description, m => m.Column("Description"));
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

        public static IQueryable<T> Linq<T>(this ISession session)
        {
            return session.Query<T>();
        }
    }

}