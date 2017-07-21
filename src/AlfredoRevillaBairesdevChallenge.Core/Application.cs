using System;

namespace AlfredoRevillaBairesdevChallenge
{
    public class Application
    {
        private IApplicationErrorHandler errorHandler;
        private IResultHandler handler;
        private ILogic logic;
        private IContactRepository repository;

        public Application(IContactRepository repository, ILogic logic, IResultHandler resultHandler, IApplicationErrorHandler errorHandler)
        {
            this.repository = repository;
            this.logic = logic;
            this.handler = resultHandler;
            this.errorHandler = errorHandler;
        }

        public void Run()
        {
            try
            {
                handler.HandlePotentialCustomers(this.logic.GetPotentialCustomers(this.repository.GetCustomers()));
            }
            catch (Exception e)
            {
                this.errorHandler.HandleError(e);
            }
        }
    }
}