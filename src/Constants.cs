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
        }

        public static class BotResponse
        {
            public const string Greet = "Hello <<mergefield>> I healot people.";
            public const string Yawa = "Baaang Yawa man diay ka <<mergefield>>";
        }
    }
}
