/* -----------------------------------------------------------------------------
 * Terminal_StringValue.cs
 * -----------------------------------------------------------------------------
 *
 * Producer : com.parse2.aparse.Parser 2.5
 * Produced : Mon Sep 07 13:22:32 BST 2015
 *
 * -----------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;

namespace Geolocation.ABNF
{
    public class Terminal_StringValue:Rule
    {
        private Terminal_StringValue(string spelling, List<Rule> rules) :
            base(spelling, rules)
        {
        }

        public static Terminal_StringValue Parse(
            ParserContext context, 
            string regex)
        {
            context.Push("StringValue", regex);

            bool parsed = true;

            Terminal_StringValue stringValue = null;
            try
            {
                string value = context.text.Substring(context.index, regex.Length);

                if ((parsed = value.ToLower().Equals(regex.ToLower())))
                {
                    context.index += regex.Length;
                    stringValue = new Terminal_StringValue(value, null);
                }
            }
            catch (ArgumentOutOfRangeException) {parsed = false;}

            context.Pop("StringValue", parsed);

            return stringValue;
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
