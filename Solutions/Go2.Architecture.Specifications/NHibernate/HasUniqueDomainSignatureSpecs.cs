﻿//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

using Go2.Architecture.Domain.DesignByContract;
using Go2.Architecture.NHibernate.Wcf;

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local


namespace Go2.Architecture.Specifications.NHibernate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using global::Go2.Architecture.Domain;
    using global::Go2.Architecture.Domain.PersistenceSupport;
    using global::Go2.Architecture.NHibernate;
    using global::Go2.Architecture.NHibernate.NHibernateValidator;

    using Machine.Specifications;

    using global::Go2.Architecture.Testing.NUnit.NHibernate;

    public class has_unique_domain_signature_specs
    {
        public abstract class specification_for_has_unique_domain_signature_validator
        {
            protected static IEntityDuplicateChecker entityDuplicateChecker;

            Establish context = () =>
            {
                entityDuplicateChecker = new EntityDuplicateChecker();
                entityDuplicateChecker.AddToServiceLocator();
            };

            Cleanup after = ServiceLocatorHelper.Reset;
        }

        [Subject(typeof(HasUniqueDomainSignatureAttribute))]
        public class when_validating_an_entity_and_a_duplicate_exists : specification_for_has_unique_domain_signature_validator
        {
            static Contractor duplicateContractor;
            static bool result;

            Establish context = () =>
            {
                var contractor = new Contractor() { Name = "codai" };
                NHibernateSession.Current.Save(contractor);
                RepositoryTestsHelper.FlushSessionAndEvict(contractor);
                duplicateContractor = new Contractor() { Name = "codai" };
            };

            Because of = () =>
            {
                result = duplicateContractor.IsValid();
            };

            It should_say_the_entity_is_invalid = () => result.ShouldBeFalse();
        }

        [Subject(typeof(HasUniqueDomainSignatureWithGuidIdAttribute))]
        public class when_validating_an_entity_with_a_guid_id_and_a_duplicate_exists : specification_for_has_unique_domain_signature_validator
        {
            static ObjectWithGuidId duplicateObjectWithGuidId;
            static bool result;

            Establish context = () =>
            {
                var objectWithGuidId = new ObjectWithGuidId { Name = "codai" };
                NHibernateSession.Current.Save(objectWithGuidId);
                RepositoryTestsHelper.FlushSessionAndEvict(objectWithGuidId);
                duplicateObjectWithGuidId = new ObjectWithGuidId { Name = "codai" };
            };

            Because of = () => result = duplicateObjectWithGuidId.IsValid();

            It should_say_the_entity_is_invalid = () => result.ShouldBeFalse();
        }

        [Subject(typeof(HasUniqueDomainSignatureWithStringIdAttribute))]
        public class when_validating_an_entity_with_a_string_id_and_a_duplicate_exists : specification_for_has_unique_domain_signature_validator
        {
            static User duplicateUser;
            static bool result;

            Establish context = () =>
            {
                var user = new User("user1", "123-12-1234");
                NHibernateSession.Current.Save(user);
                RepositoryTestsHelper.FlushSessionAndEvict(user);
                duplicateUser = new User("user2", "123-12-1234");
            };

            Because of = () => result = duplicateUser.IsValid();

            It should_say_the_entity_is_invalid = () => result.ShouldBeFalse();
        }

        [Subject(typeof(HasUniqueDomainSignatureAttribute))]
        public class when_validating_an_entity_and_the_entity_is_unique : specification_for_has_unique_domain_signature_validator
        {
            static Contractor contractor;
            static bool result;

            Establish context = () =>
            {
                contractor = new Contractor { Name = "the name" };
            };

            Because of = () => result = contractor.IsValid();

            It should_say_the_entity_is_valid = () => result.ShouldBeTrue();
        }

        [Subject(typeof(HasUniqueDomainSignatureAttribute))]
        public class when_validating_an_entity_with_the_wrong_validator_type : specification_for_has_unique_domain_signature_validator
        {
            static ObjectWithStringIdAndValidatorForIntId entity;
            static Exception result;

            Establish context = () =>
            {
                Check.UseAssertions = false;
                entity = new ObjectWithStringIdAndValidatorForIntId { Name = "whatever" };
            };

            Because of = () => result = Catch.Exception(() => entity.IsValid());

            It should_throw_a_precondition_exception = () => result.ShouldBeOfType(typeof(PreconditionException));
        }

        [Subject(typeof(HasUniqueDomainSignatureAttribute))]
        public class when_validating_a_unique_entity_that_has_another_entity_as_part_of_domain_signature : specification_for_has_unique_domain_signature_validator
        {
            static Song song;
            static bool result;

            private Establish context = () =>
            {
                var tigerlillies = new Band() { BandName = "The Tiger Lillies", DateFormed = DateTime.Now };
                NHibernateSession.Current.Save(tigerlillies);
                RepositoryTestsHelper.FlushSessionAndEvict(tigerlillies);
                song = new Song() { Performer = tigerlillies, SongTitle = "Souvenirs" };
            };

            Because of = () => result = song.IsValid();

            It should_say_the_entity_is_valid = () => result.ShouldBeTrue();
        }

        [Subject(typeof(HasUniqueDomainSignatureAttribute))]
        public class when_validating_a_unique_entity_that_has_a_null_value_domain_signature_property : specification_for_has_unique_domain_signature_validator
        {
            static Song song;
            static bool result;

            private Establish context = () =>
            {
                song = new Song() { SongTitle = "Souvenirs" };
            };

            Because of = () => result = song.IsValid();

            It should_say_the_entity_is_valid = () => result.ShouldBeTrue();
        }


        [Subject(typeof(HasUniqueDomainSignatureAttribute))]
        public class when_validating_a_duplicate_entity_that_has_another_entity_as_part_of_domain_signature : specification_for_has_unique_domain_signature_validator
        {
            static Song duplicateSong;
            static bool result;

            private Establish context = () =>
            {
                var tragicRoundabout = new Band() { BandName = "Tragic Roundabout", DateFormed = DateTime.Now };
                NHibernateSession.Current.Save(tragicRoundabout);
                var song = new Song() { Performer = tragicRoundabout, SongTitle = "Prince Geek" };
                NHibernateSession.Current.Save(song);
                duplicateSong = new Song() { Performer = tragicRoundabout, SongTitle = "Prince Geek" };
            };

            Because of = () => result = duplicateSong.IsValid();

            It should_say_the_entity_is_invalid = () => result.ShouldBeFalse();
        }

        [Subject(typeof(HasUniqueDomainSignatureAttribute))]
        public class when_validating_a_duplicate_entity_that_has_a_null_value_domain_signature_property : specification_for_has_unique_domain_signature_validator
        {
            static Song duplicateSong;
            static bool result;

            private Establish context = () =>
            {
                var song = new Song() { SongTitle = "Souvenirs" };
                NHibernateSession.Current.Save(song);
                duplicateSong = new Song() { SongTitle = "Souvenirs" };
            };

            Because of = () => result = duplicateSong.IsValid();

            It should_say_the_entity_is_invalid = () => result.ShouldBeFalse();
        }

        [Subject(typeof(HasUniqueDomainSignatureAttribute))]
        public class when_validating_a_duplicate_entity_that_has_a_value_object_domain_signature_property : specification_for_has_unique_domain_signature_validator
        {
            static Customer duplicateCustomer;
            static bool result;

            private Establish context = () =>
            {
                var address = new Address() { PostCode = "N15MO", StreetAddress = "98 Baker Street" };
                var customer = new Customer() { Name = "Sherlock Holmes", Address = address };
                NHibernateSession.Current.Save(customer);
                duplicateCustomer = new Customer() { Name = "Sherlock Holmes", Address = address};
            };

            Because of = () => result = duplicateCustomer.IsValid();

            It should_say_the_entity_is_invalid = () => result.ShouldBeFalse();
        }

        [Subject(typeof(HasUniqueDomainSignatureAttribute))]
        public class When_validating_duplicate_entity_that_has_null_value_for_property_of_unique_entity_type : specification_for_has_unique_domain_signature_validator
        {
            static Album newAlbum;
            static ICollection<ValidationResult> result;

            private Establish context = () =>
            {
                var post = new Album() { Title = "Atom Heart Mother" };
                NHibernateSession.Current.Save(post);
                newAlbum = new Album() { Title = "Atom Heart Mother" };
            };

            Because of = () => result = newAlbum.ValidationResults();

            It should_say_the_entity_is_invalid = () => result.Any(x => x.ErrorMessage.Contains("Album"));

            It should_should_not_say_that_null_child_unique_entity_is_invalid = () => result.Any(x => x.ErrorMessage.Contains("Band")).ShouldBeFalse();
        }

        [Subject(typeof(HasUniqueDomainSignatureAttribute))]
        public class when_validating_a_duplicate_entity_with_a_specified_error_message : specification_for_has_unique_domain_signature_validator
        {
            static Band duplicate;
            static ICollection<ValidationResult> result;

            private Establish context = () =>
            {
                var tigerlillies = new Band() { BandName = "King Prawn", DateFormed = DateTime.Now };
                NHibernateSession.Current.Save(tigerlillies);
                RepositoryTestsHelper.FlushSessionAndEvict(tigerlillies);
                duplicate = new Band() { BandName = "King Prawn", DateFormed = DateTime.Now };
            };

            Because of = () => result = duplicate.ValidationResults();

            It should_return_the_specified_message_as_validation_result = () => result.Any(x => x.ErrorMessage == "Band already exists").ShouldBeTrue();
        }

        [Subject(typeof(HasUniqueDomainSignatureAttribute))]
        public class when_validating_a_duplicate_entity_with_no_error_message_specified : specification_for_has_unique_domain_signature_validator
        {
            static Contractor duplicate;
            static ICollection<ValidationResult> result;

            private Establish context = () =>
            {
                var seif = new Contractor() { Name = "Seif Attar"};
                NHibernateSession.Current.Save(seif);
                RepositoryTestsHelper.FlushSessionAndEvict(seif);
                duplicate = new Contractor() { Name = "Seif Attar"};
            };

            Because of = () => result = duplicate.ValidationResults();

            It should_return_the_default_duplicate_error = () => result.Any(x => x.ErrorMessage == "Provided values matched an existing, duplicate entity").ShouldBeTrue();
        }
    }
}