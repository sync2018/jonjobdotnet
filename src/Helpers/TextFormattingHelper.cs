using System;
using System.Collections.Generic;
using System.Text;

namespace JonJobBot.src.Helpers
{
    public static class TextFormattingHelper
    {
        public static string ParseMergeFields(string text, string[] values)
        {
            int index = 0;
            var parsedMessage = new StringBuilder(text);
            while (parsedMessage.ToString().IndexOf(Constants.MergeField) != -1)
            {
                if (index > values.Length)
                    return parsedMessage.ToString();

                parsedMessage.Replace(Constants.MergeField, values[index]);
                index++;
            }

            return parsedMessage.ToString();
        }
    }
}
