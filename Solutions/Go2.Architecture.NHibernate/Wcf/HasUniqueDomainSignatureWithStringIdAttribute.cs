using Go2.Architecture.Domain.DesignByContract;
using System;
using System.ComponentModel.DataAnnotations;
using Go2.Architecture.Domain;
using Go2.Architecture.Domain.DomainModel;
using Go2.Architecture.Domain.PersistenceSupport;

namespace Go2.Architecture.NHibernate.Wcf
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class HasUniqueDomainSignatureWithStringIdAttribute : ValidationAttribute
    {
        public HasUniqueDomainSignatureWithStringIdAttribute()
            : base("Provided values matched an existing, duplicate entity")
        {
        }

        public override bool IsValid(object value)
        {
            var entityToValidate = value as IEntityWithTypedId<string>;
            Check.Require(
                entityToValidate != null,
                "This validator must be used at the class level of an IDomainWithTypedId<string>. The type you provided was " + value.GetType());

            var duplicateChecker = SafeServiceLocator<IEntityDuplicateChecker>.GetService();
            return !duplicateChecker.DoesDuplicateExistWithTypedIdOf(entityToValidate);
        }
    }
}