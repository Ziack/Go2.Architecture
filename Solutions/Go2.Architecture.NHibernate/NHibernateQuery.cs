namespace Go2.Architecture.NHibernate
{
    using System.Collections.Generic;

    using global::NHibernate;

    using Go2.Architecture.Domain.PersistenceSupport;

    public abstract class NHibernateQuery
    {
        protected virtual ISession Session
        {
            get
            {
                string factoryKey = SessionFactoryKeyHelper.GetKeyFrom(this);
                return NHibernateSession.CurrentFor(factoryKey);
            }
        }
    }
}