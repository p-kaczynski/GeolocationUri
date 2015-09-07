/* -----------------------------------------------------------------------------
 * Visitor.cs
 * -----------------------------------------------------------------------------
 *
 * Producer : com.parse2.aparse.Parser 2.5
 * Produced : Mon Sep 07 13:22:32 BST 2015
 *
 * -----------------------------------------------------------------------------
 */

namespace Geolocation.ABNF
{
    public interface Visitor
    {
        object Visit(Rule_geo_URI rule);
        object Visit(Rule_geo_scheme rule);
        object Visit(Rule_geo_path rule);
        object Visit(Rule_coordinates rule);
        object Visit(Rule_coord_a rule);
        object Visit(Rule_coord_b rule);
        object Visit(Rule_coord_c rule);
        object Visit(Rule_p rule);
        object Visit(Rule_crsp rule);
        object Visit(Rule_crslabel rule);
        object Visit(Rule_uncp rule);
        object Visit(Rule_uval rule);
        object Visit(Rule_parameter rule);
        object Visit(Rule_pname rule);
        object Visit(Rule_pvalue rule);
        object Visit(Rule_paramchar rule);
        object Visit(Rule_labeltext rule);
        object Visit(Rule_pnum rule);
        object Visit(Rule_num rule);
        object Visit(Rule_unreserved rule);
        object Visit(Rule_mark rule);
        object Visit(Rule_pct_encoded rule);
        object Visit(Rule_p_unreserved rule);
        object Visit(Rule_alphanum rule);
        object Visit(Rule_DIGIT rule);
        object Visit(Rule_HEXDIG rule);
        object Visit(Rule_ALPHA rule);

        object Visit(Terminal_StringValue value);
        object Visit(Terminal_NumericValue value);
    }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
