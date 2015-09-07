/* -----------------------------------------------------------------------------
 * XmlDisplayer.cs
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
    public class XmlDisplayer:Visitor
    {
        private bool terminal = true;

        public object Visit(Rule_geo_URI rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<geo-URI>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</geo-URI>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_geo_scheme rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<geo-scheme>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</geo-scheme>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_geo_path rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<geo-path>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</geo-path>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_coordinates rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<coordinates>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</coordinates>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_coord_a rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<coord-a>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</coord-a>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_coord_b rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<coord-b>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</coord-b>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_coord_c rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<coord-c>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</coord-c>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_p rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<p>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</p>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_crsp rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<crsp>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</crsp>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_crslabel rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<crslabel>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</crslabel>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_uncp rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<uncp>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</uncp>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_uval rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<uval>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</uval>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_parameter rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<parameter>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</parameter>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_pname rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<pname>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</pname>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_pvalue rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<pvalue>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</pvalue>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_paramchar rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<paramchar>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</paramchar>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_labeltext rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<labeltext>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</labeltext>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_pnum rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<pnum>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</pnum>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_num rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<num>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</num>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_unreserved rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<unreserved>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</unreserved>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_mark rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<mark>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</mark>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_pct_encoded rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<pct-encoded>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</pct-encoded>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_p_unreserved rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<p-unreserved>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</p-unreserved>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_alphanum rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<alphanum>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</alphanum>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_DIGIT rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<DIGIT>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</DIGIT>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_HEXDIG rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<HEXDIG>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</HEXDIG>");
            terminal = false;
            return null;
        }

        public object Visit(Rule_ALPHA rule)
        {
            if (!terminal) Console.WriteLine();
            Console.Write("<ALPHA>");
            terminal = false;
            VisitRules(rule.rules);
            if (!terminal) Console.WriteLine();
            Console.Write("</ALPHA>");
            terminal = false;
            return null;
        }

        public object Visit(Terminal_StringValue value)
        {
            Console.Write(value.spelling);
            terminal = true;
            return null;
        }

        public object Visit(Terminal_NumericValue value)
        {
            Console.Write(value.spelling);
            terminal = true;
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
