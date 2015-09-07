using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Geolocation.ABNF;

namespace Geolocation
{
    public class Geolocation
    {
        public const string HeaderName = "x-nt-geolocation";
        private const string RootRuleName = "geo-URI";

        internal readonly Dictionary<string, string> InternalParameters = new Dictionary<string, string>();

        public decimal Longitude { get; internal set; }
        public decimal Latitude { get; internal set; }
        public decimal? Altitude { get; internal set; }
        public string CoordinateReferenceSystemId { get; internal set; }
        public decimal? Uncertainty { get; internal set; }

        public IReadOnlyDictionary<string, string> Parameters
        {
            get { return InternalParameters; }
        }

        /// <summary>
        ///     Loads Geolocation header from provided <see cref="HttpRequestMessage" /> instance.
        /// </summary>
        /// <param name="request">The HTTP request</param>
        /// <returns>An object representing Geolocation header or null if not present</returns>
        public static Geolocation Load(HttpRequestMessage request)
        {
            IEnumerable<string> values;
            return request.Headers.TryGetValues(HeaderName, out values)
                ? Parse(values.FirstOrDefault())
                : null;
        }

        /// <summary>
        ///     Parses provided sequence of header bodies into Geolocation object
        /// </summary>
        /// <param name="value">Geolocation header value</param>
        /// <returns>An object representing Geolocation header</returns>
        public static Geolocation Parse(string value)
        {
            var geolocation = new Geolocation();

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Header value cannot be null or empty","value");

            var geo = Parser.Parse(RootRuleName, value);
            var visitor = new GeolocationVisitor(geolocation);
            geo.Accept(visitor);

            // if no exception was thrown, the geo should be filled with parsed data
            return geolocation;
        }

        public static bool TryParse(string value, out Geolocation location)
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