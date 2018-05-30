using System;
using System.Collections.Generic;
using System.Globalization;
using Geolocation.ABNF;

namespace Geolocation
{
    public class GeolocationVisitor : Visitor
    {
        private readonly GeolocationUri _location;

        public GeolocationVisitor(GeolocationUri location)
        {
            _location = location;
        }

        private void VisitRules(IEnumerable<Rule> rules)
        {
            foreach (var rule in rules)
                rule.Accept(this);
        }

        #region Implementation of Visitor

        public object Visit(Rule_geo_URI rule)
        {
            VisitRules(rule.rules);
            return null;
        }

        public object Visit(Rule_geo_scheme rule)
        {
            VisitRules(rule.rules);
            return null;
        }

        public object Visit(Rule_geo_path rule)
        {
            VisitRules(rule.rules);
            return null;
        }

        public object Visit(Rule_coordinates rule)
        {
            VisitRules(rule.rules);
            return null;
        }

        public object Visit(Rule_coord_a rule)
        {
            _location.Latitude = decimal.Parse(rule.spelling, CultureInfo.InvariantCulture);
            return false;
        }

        public object Visit(Rule_coord_b rule)
        {
            _location.Longitude = decimal.Parse(rule.spelling, CultureInfo.InvariantCulture);
            return false;
        }

        public object Visit(Rule_coord_c rule)
        {
            _location.Altitude = decimal.Parse(rule.spelling, CultureInfo.InvariantCulture);
            return false;
        }

        public object Visit(Rule_p rule)
        {
            VisitRules(rule.rules);
            return null;
        }

        public object Visit(Rule_crsp rule)
        {
            VisitRules(rule.rules);
            return null;
        }

        public object Visit(Rule_crslabel rule)
        {
            _location.CoordinateReferenceSystemId = rule.spelling;
            return false;
        }

        public object Visit(Rule_uncp rule)
        {
            VisitRules(rule.rules);
            return null;
        }

        public object Visit(Rule_uval rule)
        {
            _location.Uncertainty = decimal.Parse(rule.spelling);
            return false;
        }

        private string _paramName;
        private string _paramValue;

        public object Visit(Rule_parameter rule)
        {
            // Reset the helper fields
            _paramName = null;
            _paramValue = null;

            // Visit rules - should set the paramName and possibly paramValue
            VisitRules(rule.rules);

            // Sanity check
            if (_paramName == null)
                throw new FormatException("The parameters name cannot be null");
            
            // Add custom param
            _location.InternalParameters.Add(_paramName, _paramValue);

            // Don't visit further, child rules were already visited
            return false;
        }

        public object Visit(Rule_pname rule)
        {
            _paramName = rule.spelling;
            return false;
        }

        public object Visit(Rule_pvalue rule)
        {
            _paramValue = rule.spelling;
            return false;
        }

        public object Visit(Rule_paramchar rule)
        {
            /* WON'T BE VISITED */
            return true;
        }

        public object Visit(Rule_labeltext rule)
        {
            /* WON'T BE VISITED */
            return true;
        }

        public object Visit(Rule_pnum rule)
        {
            /* WON'T BE VISITED */
            return true;
        }

        public object Visit(Rule_num rule)
        {
            /* WON'T BE VISITED */
            return true;
        }

        public object Visit(Rule_unreserved rule)
        {
            /* WON'T BE VISITED */
            return true;
        }

        public object Visit(Rule_mark rule)
        {
            /* WON'T BE VISITED */
            return true;
        }

        public object Visit(Rule_pct_encoded rule)
        {
            /* WON'T BE VISITED */
            return true;
        }

        public object Visit(Rule_p_unreserved rule)
        {
            /* WON'T BE VISITED */
            return true;
        }

        public object Visit(Rule_alphanum rule)
        {
            /* WON'T BE VISITED */
            return true;
        }

        public object Visit(Rule_DIGIT rule)
        {
            /* WON'T BE VISITED */
            return true;
        }

        public object Visit(Rule_HEXDIG rule)
        {
            /* WON'T BE VISITED */
            return true;
        }

        public object Visit(Rule_ALPHA rule)
        {
            /* WON'T BE VISITED */
            return true;
        }

        public object Visit(Terminal_StringValue value)
        {
            /* WON'T BE VISITED */
            return true;
        }

        public object Visit(Terminal_NumericValue value)
        {
            /* WON'T BE VISITED */
            return true;
        }

        #endregion
    }
}