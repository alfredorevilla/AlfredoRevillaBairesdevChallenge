using System;
using System.Linq;

namespace AlfredoRevillaBairesdevChallenge
{
    public class Application
    {
        private int _maxPotentialContactsResult;
        private IApplicationErrorHandler errorHandler;
        private IResultHandler handler;
        private ILogic logic;
        private IContactRepository repository;

        public Application(IContactRepository repository, ILogic logic, IResultHandler resultHandler, IApplicationErrorHandler errorHandler, int maxPotentialContactsResult = 100)
        {
            this.repository = repository;
            this.logic = logic;
            this.handler = resultHandler;
            this.errorHandler = errorHandler;
            this._maxPotentialContactsResult = maxPotentialContactsResult;
        }

        public void Run()
        {
            try
            {
                handler.HandlePotentialCustomers(this.logic.GetPotentialCustomers(this.repository.GetCustomers()).Take(_maxPotentialContactsResult));
            }
            catch (Exception e)
            {
                this.errorHandler.HandleError(e);
            }
        }
    }
}