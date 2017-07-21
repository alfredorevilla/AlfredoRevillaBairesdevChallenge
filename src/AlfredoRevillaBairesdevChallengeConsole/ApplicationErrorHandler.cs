using System;
using System.Collections.Generic;
using System.Text;

namespace AlfredoRevillaBairesdevChallenge
{
    //  todo: logging!!!
    public class ApplicationErrorHandler : IApplicationErrorHandler
    {
        public void HandleError(Exception e)
        {
            ConsoleHelper.WriteRedLines("Un error de aplicación ha ocurrido.", "");
        }
    }
}