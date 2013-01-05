namespace Go2.Architecture.NHibernate.FluentNHibernate
{
    using System;

    using global::FluentNHibernate.Automapping;

    public interface IAutoPersistenceModelGenerator
    {
        AutoPersistenceModel Generate();
    }
}