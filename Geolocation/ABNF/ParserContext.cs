/* -----------------------------------------------------------------------------
 * ParserContext.cs
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
    public class ParserContext
    {
        public readonly string text;
        public int index;

        private Stack<int> startStack = new Stack<int>();
        private Stack<string> callStack = new Stack<string>();
        private Stack<string> errorStack = new Stack<string>();
        private int level;
        private int errorIndex;

        private readonly bool traceOn;

        public ParserContext(string text, bool traceOn)
        {
            this.text = text;
            this.traceOn = traceOn;
            index = 0;
        }

        public void Push(string rulename)
        {
            Push(rulename, "");
        }

        public void Push(string rulename, string trace)
        {
            callStack.Push(rulename);
            startStack.Push(index);

            if (traceOn)
            {
                string sample = text.Substring(index, index + 10 > text.Length ? text.Length - index : 10);

                Regex regex = new Regex("[\\x00-\\x1F]");
                sample = regex.Replace(sample, " ");

                Console.WriteLine("-> " + ++level + ": " + rulename + "(" + (trace != null ? trace : "") + ")");
                Console.WriteLine(index + ": " + sample);
            }
        }

        public void Pop(string function, bool result)
        {
            int start = startStack.Pop();
            callStack.Pop();

            if (traceOn)
            {
                Console.WriteLine(
                    "<- " + level-- + 
                    ": " + function + 
                    "(" + (result ? "true" : "false") + 
                    ",s=" + start + 
                    ",l=" + (index - start) + 
                    ",e=" + errorIndex + ")");
            }

            if (!result)
            {
                if (index > errorIndex)
                {
                    errorIndex = index;
                    errorStack = new Stack<string>(callStack);
                }
                else if (index == errorIndex && errorStack.Count == 0)
                {
                    errorStack = new Stack<string>(callStack);
                }
            }
            else
            {
                if (index > errorIndex) errorIndex = 0;
            }
        }

        public Stack<string> GetErrorStack()
        {
            return errorStack;
        }

        public int GetErrorIndex()
        {
            return errorIndex;
        }
    }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
