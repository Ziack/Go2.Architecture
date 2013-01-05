namespace Go2.Architecture.NHibernate.NHibernateValidator
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using global::NHibernate.Event;

    using Go2.Architecture.Domain.DomainModel;

    [Serializable]
    internal class DataAnnotationsEventListener : IPreUpdateEventListener, IPreInsertEventListener
    {
        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            if (@event.Entity is ValidatableObject)
            {
                var entity = @event.Entity;
                Validator.ValidateObject(entity, new ValidationContext(entity, null, null), true);
            }
            return false;
        }

        public bool OnPreInsert(PreInsertEvent @event)
        {
            if (@event.Entity is ValidatableObject)
            {
                var entity = @event.Entity;
                Validator.ValidateObject(entity, new ValidationContext(entity, null, null), true);
            }
            return false;
        }
    }
}
