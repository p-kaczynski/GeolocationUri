/* -----------------------------------------------------------------------------
 * Rule_coord_c.cs
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
    sealed public class Rule_coord_c:Rule
    {
        private Rule_coord_c(string spelling, List<Rule> rules) :
            base(spelling, rules)
        {
        }

        public override object Accept(Visitor visitor)
        {
            return visitor.Visit(this);
        }

        public static Rule_coord_c Parse(ParserContext context)
        {
            context.Push("coord-c");

            Rule rule;
            bool parsed = true;
            ParserAlternative b;
            int s0 = context.index;
            ParserAlternative a0 = new ParserAlternative(s0);

            List<ParserAlternative> as1 = new List<ParserAlternative>();
            parsed = false;
            {
                int s1 = context.index;
                ParserAlternative a1 = new ParserAlternative(s1);
                parsed = true;
                if (parsed)
                {
                    bool f1 = true;
                    int c1 = 0;
                    for (int i1 = 0; i1 < 1 && f1; i1++)
                    {
                        rule = Rule_num.Parse(context);
                        if ((f1 = rule != null))
                        {
                            a1.Add(rule, context.index);
                            c1++;
                        }
                    }
                    parsed = c1 == 1;
                }
                if (parsed)
                {
                    as1.Add(a1);
                }
                context.index = s1;
            }

            b = ParserAlternative.GetBest(as1);

            parsed = b != null;

            if (parsed)
            {
                a0.Add(b.rules, b.end);
                context.index = b.end;
            }

            rule = null;
            if (parsed)
            {
                rule = new Rule_coord_c(context.text.Substring(a0.start, a0.end - a0.start), a0.rules);
            }
            else
            {
                context.index = s0;
            }

            context.Pop("coord-c", parsed);

            return (Rule_coord_c)rule;
        }
    }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
