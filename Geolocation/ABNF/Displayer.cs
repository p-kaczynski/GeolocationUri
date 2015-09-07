/* -----------------------------------------------------------------------------
 * Displayer.cs
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
    public class Displayer:Visitor
    {

        public object Visit(Rule_geo_URI rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_geo_scheme rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_geo_path rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_coordinates rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_coord_a rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_coord_b rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_coord_c rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_p rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_crsp rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_crslabel rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_uncp rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_uval rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_parameter rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_pname rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_pvalue rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_paramchar rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_labeltext rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_pnum rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_num rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_unreserved rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_mark rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_pct_encoded rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_p_unreserved rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_alphanum rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_DIGIT rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_HEXDIG rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Rule_ALPHA rule)
        {
            return VisitRules(rule.rules);
        }

        public object Visit(Terminal_StringValue value)
        {
            Console.Write(value.spelling);
            return null;
        }

        public object Visit(Terminal_NumericValue value)
        {
            Console.Write(value.spelling);
            return null;
        }

        private object VisitRules(List<Rule> rules)
        {
            foreach (Rule rule in rules)
                rule.Accept(this);
            return null;
        }
    }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
