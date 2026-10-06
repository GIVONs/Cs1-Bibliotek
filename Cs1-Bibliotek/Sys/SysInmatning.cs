using System;
using System.Collections.Generic;
using System.Text;

namespace Cs1_Bibliotek.Sys
{
    public class SysInmatning
    {
        public static bool StringKontroll(string input)
        {
            while (true)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Fel inmatning, vänligen skriv bara text");
                    continue;
                }
            }

        }
    }
}
