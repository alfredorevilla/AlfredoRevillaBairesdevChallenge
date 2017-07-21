using System;
using System.Collections.Generic;
using System.Text;

namespace AlfredoRevillaBairesdevChallenge
{
    internal class ApplicationErrorHandler : IApplicationErrorHandler
    {
        public void HandleError(Exception e)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("An application error has ocurred.");
            Console.WriteLine();
            Console.ForegroundColor = color;
        }
    }
}