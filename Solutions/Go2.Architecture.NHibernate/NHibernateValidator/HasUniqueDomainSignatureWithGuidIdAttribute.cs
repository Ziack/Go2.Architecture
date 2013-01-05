using Go2.Architecture.Domain.DesignByContract;

namespace Go2.Architecture.NHibernate.NHibernateValidator
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Go2.Architecture.Domain;
    using Go2.Architecture.Domain.DomainModel;
    using Go2.Architecture.Domain.PersistenceSupport;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class HasUniqueDomainSignatureWithGuidIdAttribute : ValidationAttribute
    {
        public HasUniqueDomainSignatureWithGuidIdAttribute()
            : base("Provided values matched an existing, duplicate entity")
        {
        }

        public override bool IsValid(object value)
        {
            var entityToValidate = value as IEntityWithTypedId<Guid>;
            Check.Require(
                entityToValidate != null,
                "This validator must be used at the class level of an IDomainWithTypedId<Guid>. The type you provided was " + value.GetType());

            var duplicateChecker = SafeServiceLocator<IEntityDuplicateChecker>.GetService();
            return !duplicateChecker.DoesDuplicateExistWithTypedIdOf(entityToValidate);
        }
    }
}