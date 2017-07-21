using System;

namespace AlfredoRevillaBairesdevChallenge
{
    public interface IApplicationErrorHandler
    {
        void HandleError(Exception e);
    }
}