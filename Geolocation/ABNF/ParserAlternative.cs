/* -----------------------------------------------------------------------------
 * ParserAlternative.cs
 * -----------------------------------------------------------------------------
 *
 * Producer : com.parse2.aparse.Parser 2.5
 * Produced : Mon Sep 07 13:22:32 BST 2015
 *
 * -----------------------------------------------------------------------------
 */

using System.Collections.Generic;

namespace Geolocation.ABNF
{
    public class ParserAlternative
    {
        public List<Rule> rules;
        public int start;
        public int end;

        public ParserAlternative(int start)
        {
            rules = new List<Rule>();
            this.start = start;
            end = start;
        }

        public void Add(Rule rule, int end)
        {
            rules.Add(rule);
            this.end = end;
        }

        public void Add(List<Rule> rules, int end)
        {
            this.rules.AddRange(rules);
            this.end = end;
        }

        static public ParserAlternative GetBest(List<ParserAlternative> alternatives)
        {
            ParserAlternative best = null;

            foreach (ParserAlternative alternative in alternatives)
            {
                if (best == null || alternative.end > best.end)
                    best = alternative;
            }

            return best;
        }
    }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
