/* -----------------------------------------------------------------------------
 * Terminal_NumericValue.cs
 * -----------------------------------------------------------------------------
 *
 * Producer : com.parse2.aparse.Parser 2.5
 * Produced : Mon Sep 07 13:22:32 BST 2015
 *
 * -----------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Geolocation.ABNF
{
    public class Terminal_NumericValue:Rule
    {
        private Terminal_NumericValue(string spelling, List<Rule> rules) :
            base(spelling, rules)
        {
        }

        public static Terminal_NumericValue Parse(
            ParserContext context, 
            string spelling, 
            string regex, 
            int length)
        {
            context.Push("NumericValue", spelling + "," + regex);

            bool parsed = true;

            Terminal_NumericValue numericValue = null;
            try
            {
                string value = context.text.Substring(context.index, length);

                if ((parsed = Regex.IsMatch(value, regex)))
                {
                    context.index += length;
                    numericValue = new Terminal_NumericValue(value, null);
                }
            }
            catch (ArgumentOutOfRangeException) {parsed = false;}

            context.Pop("NumericValue", parsed);

            return numericValue;
        }

        public override object Accept(Visitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
