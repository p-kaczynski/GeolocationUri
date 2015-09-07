/* -----------------------------------------------------------------------------
 * ParserException.cs
 * -----------------------------------------------------------------------------
 *
 * Producer : com.parse2.aparse.Parser 2.5
 * Produced : Mon Sep 07 13:22:32 BST 2015
 *
 * -----------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Geolocation.ABNF
{
    public class ParserException:Exception
    {
        private string reason;
        private string text60;
        private int index60;
        private Stack<string> ruleStack;

        private ParserException cause;

        static private readonly string newline = Environment.NewLine;

        public ParserException(
            string reason,
            string text,
            int index,
            Stack<string> ruleStack) : base(reason)
        {
            this.reason = reason;
            this.ruleStack = ruleStack;

            int start = (index < 30) ? 0 : index - 30;
            int end = (text.Length < index + 30) ? text.Length : index + 30;
            text60 = text.Substring(start, end - start);
            index60 = (index < 30) ? index : 30;

            Regex regex = new Regex("[\\x00-\\x1F]");
            text60 = regex.Replace(text60, " ");
        }

        public string GetReason()
        {
            return reason;
        }

        public string GetSubstring()
        {
            return text60;
        }

        public int GetSubstringIndex()
        {
            return index60;
        }

        public Stack<string> GetRuleStack()
        {
            return ruleStack;
        }

        public override string Message
        {
            get
            {
                string marker = "                              ";

                StringBuilder buffer = new StringBuilder();
                buffer.Append(reason + newline);
                buffer.Append(text60 + newline);
                buffer.Append(marker.Substring(0, index60) + "^" + newline);

                if (ruleStack.Count > 0)
                {
                    buffer.Append("rule stack:");

                    foreach (string rule in ruleStack)
                        buffer.Append(newline + "  " + rule);
                }

                ParserException secondaryError = GetCause();
                if (secondaryError != null)
                {
                    buffer.Append("possible cause: " + secondaryError.reason + newline);
                    buffer.Append(secondaryError.text60 + newline);
                    buffer.Append(marker.Substring(0, secondaryError.index60) + "^" + newline);

                    if (secondaryError.ruleStack.Count > 0)
                    {
                        buffer.Append("rule stack:");

                        foreach (string rule in secondaryError.ruleStack)
                            buffer.Append(newline + "  " + rule);
                    }
                }

                return buffer.ToString();
            }
        }

        public void SetCause(ParserException cause)
        {
            this.cause = cause;
        }

        ParserException GetCause()
        {
            return cause;
        }
    }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
