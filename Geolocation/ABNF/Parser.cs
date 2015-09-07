/* -----------------------------------------------------------------------------
 * Parser.cs
 * -----------------------------------------------------------------------------
 *
 * Producer : com.parse2.aparse.Parser 2.5
 * Produced : Mon Sep 07 13:22:32 BST 2015
 *
 * -----------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Geolocation.ABNF
{
    public class Parser
    {
        private Parser() {}

        static public Rule Parse(string rulename, string text)
        {
            return Parse(rulename, text, false);
        }

        static public Rule Parse(string rulename, StreamReader input)
        {
            return Parse(rulename, input, false);
        }

        static public Rule Parse(string rulename, FileStream file)
        {
            return Parse(rulename, file, false);
        }

        static private Rule Parse(string rulename, string text, bool trace)
        {
            if (rulename == null)
                throw new ArgumentNullException("null rulename");
            if (text == null)
                throw new ArgumentException("null string");

            ParserContext context = new ParserContext(text, trace);

            Rule rule = null;
            if (rulename.ToLower().Equals("geo-URI".ToLower())) rule = Rule_geo_URI.Parse(context);
            else if (rulename.ToLower().Equals("geo-scheme".ToLower())) rule = Rule_geo_scheme.Parse(context);
            else if (rulename.ToLower().Equals("geo-path".ToLower())) rule = Rule_geo_path.Parse(context);
            else if (rulename.ToLower().Equals("coordinates".ToLower())) rule = Rule_coordinates.Parse(context);
            else if (rulename.ToLower().Equals("coord-a".ToLower())) rule = Rule_coord_a.Parse(context);
            else if (rulename.ToLower().Equals("coord-b".ToLower())) rule = Rule_coord_b.Parse(context);
            else if (rulename.ToLower().Equals("coord-c".ToLower())) rule = Rule_coord_c.Parse(context);
            else if (rulename.ToLower().Equals("p".ToLower())) rule = Rule_p.Parse(context);
            else if (rulename.ToLower().Equals("crsp".ToLower())) rule = Rule_crsp.Parse(context);
            else if (rulename.ToLower().Equals("crslabel".ToLower())) rule = Rule_crslabel.Parse(context);
            else if (rulename.ToLower().Equals("uncp".ToLower())) rule = Rule_uncp.Parse(context);
            else if (rulename.ToLower().Equals("uval".ToLower())) rule = Rule_uval.Parse(context);
            else if (rulename.ToLower().Equals("parameter".ToLower())) rule = Rule_parameter.Parse(context);
            else if (rulename.ToLower().Equals("pname".ToLower())) rule = Rule_pname.Parse(context);
            else if (rulename.ToLower().Equals("pvalue".ToLower())) rule = Rule_pvalue.Parse(context);
            else if (rulename.ToLower().Equals("paramchar".ToLower())) rule = Rule_paramchar.Parse(context);
            else if (rulename.ToLower().Equals("labeltext".ToLower())) rule = Rule_labeltext.Parse(context);
            else if (rulename.ToLower().Equals("pnum".ToLower())) rule = Rule_pnum.Parse(context);
            else if (rulename.ToLower().Equals("num".ToLower())) rule = Rule_num.Parse(context);
            else if (rulename.ToLower().Equals("unreserved".ToLower())) rule = Rule_unreserved.Parse(context);
            else if (rulename.ToLower().Equals("mark".ToLower())) rule = Rule_mark.Parse(context);
            else if (rulename.ToLower().Equals("pct-encoded".ToLower())) rule = Rule_pct_encoded.Parse(context);
            else if (rulename.ToLower().Equals("p-unreserved".ToLower())) rule = Rule_p_unreserved.Parse(context);
            else if (rulename.ToLower().Equals("alphanum".ToLower())) rule = Rule_alphanum.Parse(context);
            else if (rulename.ToLower().Equals("DIGIT".ToLower())) rule = Rule_DIGIT.Parse(context);
            else if (rulename.ToLower().Equals("HEXDIG".ToLower())) rule = Rule_HEXDIG.Parse(context);
            else if (rulename.ToLower().Equals("ALPHA".ToLower())) rule = Rule_ALPHA.Parse(context);
            else throw new ArgumentException("unknown rule");

            if (rule == null)
            {
                throw new ParserException(
                    "rule \"" + context.GetErrorStack().Peek() + "\" failed",
                    context.text,
                    context.GetErrorIndex(),
                    context.GetErrorStack());
            }

            if (context.text.Length > context.index)
            {
                ParserException primaryError = 
                    new ParserException(
                        "extra data found",
                        context.text,
                        context.index,
                        new Stack<string>());

                if (context.GetErrorIndex() > context.index)
                {
                    ParserException secondaryError = 
                        new ParserException(
                            "rule \"" + context.GetErrorStack().Peek() + "\" failed",
                            context.text,
                            context.GetErrorIndex(),
                            context.GetErrorStack());

                    primaryError.SetCause(secondaryError);
                }

                throw primaryError;
            }

            return rule;
        }

        static private Rule Parse(string rulename, StreamReader input, bool trace)
        {
            if (rulename == null)
                throw new ArgumentNullException("null rulename");
            if (input == null)
                throw new ArgumentNullException("null input stream");

            int ch = 0;
            StringBuilder output = new StringBuilder();
            while ((ch = input.Read()) != -1)
                output.Append((char)ch);

            return Parse(rulename, output.ToString(), trace);
        }

        static private Rule Parse(string rulename, FileStream file, bool trace)
        {
            if (rulename == null)
                throw new ArgumentNullException("null rulename");
            if (file == null)
                throw new ArgumentNullException("null file");

            StreamReader input = new StreamReader(file);
            int ch = 0;
            StringBuilder output = new StringBuilder();
            while ((ch = input.Read()) != -1)
                output.Append((char)ch);

            input.Close();

            return Parse(rulename, output.ToString(), trace);
        }
    }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
