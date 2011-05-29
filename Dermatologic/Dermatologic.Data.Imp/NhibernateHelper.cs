using System;
using System.Linq;
using System.Web;
using NHibernate;

namespace Dermatologic.Data.Persistence
{
    public static class NhibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";

        private static ISession OpenSession()
        {
            return PersistenceManager.OpenSession();
        }

        public static ISession GetCurrentSession()
        {
            var context = HttpContext.Current;
            var currentSession = (ISession)context.Items[CurrentSessionKey];
            if (currentSession == null)
            {
                currentSession = OpenSession();
                context.Items[CurrentSessionKey] = currentSession;
            }
            currentSession.FlushMode = FlushMode.Commit;
            return currentSession;
        }

        public static void CloseSession()
        {
            ISession currentSession = null;
            var context = HttpContext.Current;
            if (context == null)
            {
                return;

            }
            currentSession = (ISession)context.Items[CurrentSessionKey];
            if (currentSession == null)
            {
                return;
            }
            currentSession.Close();
            context.Items.Remove(CurrentSessionKey);
        }

        public static void CloseSessionFactory()
        {
            PersistenceManager.SessionFactory.Close();
        }

        public static void BeginTransaction()
        {
            try
            {
                if(!GetCurrentSession().Transaction.IsActive)
                {
                    GetCurrentSession().BeginTransaction();
                }
            }
            catch (Exception ex)
            {
                throw new HibernateException("No se puede inicializar transacción " + ex.Message);
            }
        }

        public static void EndTransaction()
        {
            try
            {
                GetCurrentSession().Transaction.Commit();
            }
            catch (Exception ex)
            {
                throw new HibernateException("No se pudo finalizar transacción" + ex.Message);
            }
        }

        public static void RollBackTransaction()
        {
            try
            {
                GetCurrentSession().Transaction.Rollback();
            }
            catch (Exception ex)
            {
                throw new HibernateException("No se pudo finalizar transacción" + ex.Message);
            }
        }

        public static IQueryable<T> Linq<T>()
        {
            return GetCurrentSession().Linq<T>();
        }

    }
}
