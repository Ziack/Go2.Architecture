namespace Tests.Go2.Architecture.NHibernate
{
    using NUnit.Framework;

    using global::Go2.Architecture.Domain.PersistenceSupport;
    using global::Go2.Architecture.NHibernate;
    using global::Go2.Architecture.Testing.NUnit;

    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void CanCastConcreteLinqRepositoryToInterfaceILinqRepository()
        {
            LinqRepository<MyEntity> concreteRepository = new LinqRepository<MyEntity>();
            ILinqRepository<MyEntity> castRepository = concreteRepository as ILinqRepository<MyEntity>;
            castRepository.ShouldNotBeNull();
        }
    }

    public class MyEntity
    {
        private string Name { get; set; }
    }
}