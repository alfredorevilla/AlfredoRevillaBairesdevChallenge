using System;

namespace AlfredoRevillaBairesdevChallenge
{
    internal class ConsoleHelper
    {
        public static void WriteLinesWithDifferentColorAndRollbackToOriginalOne(string[] lines, ConsoleColor color)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            foreach (var item in lines)
            {
                Console.WriteLine(item);
            }
            Console.ForegroundColor = originalColor;
        }

        public static void WriteRedLines(params string[] lines)
        {
            WriteLinesWithDifferentColorAndRollbackToOriginalOne(lines, ConsoleColor.Red);
        }

        public static void WriteYellowLines(params string[] lines)
        {
            WriteLinesWithDifferentColorAndRollbackToOriginalOne(lines, ConsoleColor.Yellow);
        }
    }
}