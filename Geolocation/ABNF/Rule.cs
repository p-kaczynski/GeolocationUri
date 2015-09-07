/* -----------------------------------------------------------------------------
 * Rule.cs
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
    public abstract class Rule
    {
        public readonly string spelling;
        public readonly List<Rule> rules;

        protected Rule(string spelling, List<Rule> rules)
        {
            this.spelling = spelling;
            this.rules = rules;
        }

        public override string ToString()
        {
            return spelling;
        }

        public override bool Equals(object rule)
        {
            return rule is Rule && spelling.Equals(((Rule)rule).spelling);
        }

        public override int GetHashCode()
        {
            return spelling.GetHashCode();
        }

        public int CompareTo(Rule rule)
        {
            return spelling.CompareTo(rule.spelling);
        }

        public abstract object Accept(Visitor visitor);
    }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
