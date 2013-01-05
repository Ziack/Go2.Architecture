namespace Go2.Architecture.Specifications
{
    using System;

    using Machine.Specifications;

    using global::Go2.Architecture.Testing.NUnit.NHibernate;

    public class AssemblyContext : IAssemblyContext
    {
        public void OnAssemblyStart()
        {
            RepositoryTestsHelper.InitializeNHibernateSession();
        }

        public void OnAssemblyComplete()
        {
            RepositoryTestsHelper.Shutdown();
        }
    }
}