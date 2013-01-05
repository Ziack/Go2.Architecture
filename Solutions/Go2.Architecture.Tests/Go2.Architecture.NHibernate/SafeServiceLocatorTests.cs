//namespace Tests.Go2.Architecture.Domain
//{
//    using System;

//    using Castle.MicroKernel.Registration;
//    using Castle.Windsor;

//    using CommonServiceLocator.WindsorAdapter;

//    using Microsoft.Practices.ServiceLocation;

//    using NUnit.Framework;

//    using global::Go2.Architecture.Domain;
//    using global::Go2.Architecture.Domain.CommonValidator;
//    using global::Go2.Architecture.NHibernate.NHibernateValidator.CommonValidatorAdapter;

//    [TestFixture]
//    public class SafeServiceLocatorTests
//    {
//        [Test]
//        public void CanReturnServiceIfInitializedAndRegistered() {
//            IWindsorContainer container = new WindsorContainer();
//            container.Register(
//                Component
//                    .For(typeof(IValidator))
//                    .ImplementedBy(typeof(Validator))
//                    .Named("validator"));
//            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));

//            var validatorService = SafeServiceLocator<IValidator>.GetService();

//            Assert.That(validatorService, Is.Not.Null);
//        }

//        [SetUp]
//        public void Setup() {
//            ServiceLocator.SetLocatorProvider(null);
//        }

//        [Test]
//        public void WillBeInformedIfServiceLocatorNotInitialized() {
//            var exceptionThrown = false;

//            try {
//                SafeServiceLocator<IValidator>.GetService();
//            }
//            catch (NullReferenceException e) {
//                exceptionThrown = true;
//                Assert.That(e.Message.Contains("ServiceLocator has not been initialized"));
//            }

//            Assert.That(exceptionThrown);
//        }

//        [Test]
//        public void WillBeInformedIfServiceNotRegistered() {
//            var exceptionThrown = false;

//            IWindsorContainer container = new WindsorContainer();
//            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));

//            try {
//                SafeServiceLocator<IValidator>.GetService();
//            }
//            catch (ActivationException e) {
//                exceptionThrown = true;
//                Assert.That(e.Message.Contains("IValidator could not be located"));
//            }

//            Assert.That(exceptionThrown);
//        }
//    }
//}