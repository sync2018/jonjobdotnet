using System;
using System.Collections.Generic;
using System.Text;

namespace JonJobBot.src
{
    public static class Constants
    {
        public const string InvalidCommandMessage = "Ganahan kog utin. Ikaw?";
        public const string MergeField = "<<mergefield>>";


        public static class BotCommands
        {
            public const string Greet = "hello";
            public const string Yawa = "yawa";
            public const string MakeAngubHappy = "make angub happy";
        }

        public static class BotResponse
        {
            public const string Greet = "Hello <<mergefield>> I healot people.";
            public const string Yawa = "Baaang <<mergefield>> man diay ka <<mergefield>>";
        }

        public static class InternetLinks
        {

        }

        public static class Insults
        {
            public const string Yawa = "yawa";
            public const string Faggot = "faggot";
            public const string Simp = "simp";
            public const string Bugo = "bugo";

            public static IList<string> GetAll()
            {
                return new List<string>
                {
                    Yawa, Faggot, Simp, Bugo
                };
            }
        }
    }
}
