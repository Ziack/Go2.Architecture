namespace Go2.Architecture.RavenDb.Web.Mvc
{
    using System.Web.Mvc;

    using Raven.Client;

    using Go2.Architecture.Domain;

    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        public bool RollbackOnModelStateError { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            IDocumentSession session = SafeServiceLocator<IDocumentSession>.GetService();
        
            if (((filterContext.Exception != null) && filterContext.ExceptionHandled) ||
                this.ShouldRollback(filterContext))
            {
                return;
            }

            session.SaveChanges();
        }

        private bool ShouldRollback(ControllerContext filterContext)
        {
            return this.RollbackOnModelStateError && !filterContext.Controller.ViewData.ModelState.IsValid;
        }
    }
}