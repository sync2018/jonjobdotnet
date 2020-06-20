using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JonJobBot.src.Helpers
{
    public static class TextFormattingHelper
    {
        /// <summary>
        /// Replaces the merge fields with the values in order
        /// </summary>
        /// <param name="text"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string ParseMergeFieldsValues(string text, string[] values)
        {
            int index = 0;
            while (text.IndexOf(Constants.MergeField) != -1)
            {
                if (index > values.Length)
                    return text;

                var regex = new Regex(Regex.Escape(Constants.MergeField));
                text = regex.Replace(text, values[index], 1);
                index++;
            }

            return text.ToString();
        }
    }
}
