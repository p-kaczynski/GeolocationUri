using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Geolocation.ABNF;

namespace Geolocation
{
    /// <summary>
    /// Contains data from RFC5870 compliant URI
    /// </summary>
    public sealed class GeolocationUri
    {
        private const string RootRuleName = "geo-URI";
        private const string Wgs84CoordinateSystemId = "wgs84";
        private const string Schema = "geo";

        /// <summary>
        /// Gets the longitude value of the location
        /// </summary>
        public decimal Longitude { get; internal set; }

        /// <summary>
        /// Gets the latitude value of the location
        /// </summary>
        public decimal Latitude { get; internal set; }

        /// <summary>
        /// (Optional) Gets the altitude of the location
        /// </summary>
        public decimal? Altitude { get; internal set; }

        /// <summary>
        /// Gets the coordinate reference system identificator
        /// </summary>
        public string CoordinateReferenceSystemId
        {
            get { return _coordinateReferenceSystemId ?? Wgs84CoordinateSystemId; }
            internal set { _coordinateReferenceSystemId = value; }
        }
        
        /// <summary>
        /// Gets the uncertainty of the location
        /// </summary>
        public decimal? Uncertainty { get; internal set; }

                public IReadOnlyDictionary<string, string> Parameters
        {
            get { return InternalParameters; }
        }

        internal readonly Dictionary<string, string> InternalParameters = new Dictionary<string, string>();
        private string _coordinateReferenceSystemId;

        /// <summary>
        /// Returns this instance of <see cref="GeolocationUri"/> in an URI format compliant with RFC5870
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Schema);
            sb.Append(':');
            sb.Append(Latitude.ToString(CultureInfo.InvariantCulture));
            sb.Append(',');
            sb.Append(Longitude.ToString(CultureInfo.InvariantCulture));

            if (Altitude.HasValue)
            {
                sb.Append(',');
                sb.Append(Altitude.Value.ToString(CultureInfo.InvariantCulture));
            }

            sb.Append(';');
            sb.Append(CoordinateReferenceSystemId);

            if (Uncertainty.HasValue)
            {
                sb.Append(';');
                sb.Append(Uncertainty.Value);
            }
            foreach (var kvp in Parameters)
            {
                sb.Append(';');
                sb.Append(kvp.Key);
                if (kvp.Value == null) continue;

                sb.Append('=');
                sb.Append(kvp.Value);
            }

            return sb.ToString();
        }

        /// <summary>
        ///     Parses provided string into an instance of the <see cref="GeolocationUri"/>
        /// </summary>
        /// <param name="value">Geolocation header value</param>
        /// <returns>An object representing Geolocation header</returns>
        public static GeolocationUri Parse(string value)
        {
            var geolocation = new GeolocationUri();

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Header value cannot be null or empty", "value");

            var geo = Parser.Parse(RootRuleName, value);
            var visitor = new GeolocationVisitor(geolocation);
            geo.Accept(visitor);

            // if no exception was thrown, the geo should be filled with parsed data
            return geolocation;
        }

        /// <summary>
        ///     Safely parses provided string into an instance of the <see cref="GeolocationUri"/>
        /// </summary>
        /// <param name="value">Geolocation header value</param>
        /// <param name="location">Geolocation variable</param>
        /// <returns>An object representing Geolocation header</returns>
        public static bool TryParse(string value, out GeolocationUri location)
        {
            try
            {
                location = Parse(value);
                return true;
            }
            catch
            {
                location = null;
                return false;
            }
        }
    }   
}