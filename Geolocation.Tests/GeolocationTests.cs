using System.Collections.Generic;
using Should;
using Xunit;

namespace Geolocation.Tests
{
    public class GeolocationDataTests
    {
        [Theory]
        [MemberData("PositiveCases")]
        public void Geolocation_Parse_ParsesCorrectly(string input, decimal latitude, decimal longitude, decimal? altitude, string crs, decimal? uncertainty)
        {
            var geo = GeolocationUri.Parse(input);
            geo.Longitude.ShouldEqual(longitude);
            geo.Latitude.ShouldEqual(latitude);
            geo.Altitude.ShouldEqual(altitude);
            geo.CoordinateReferenceSystemId.ShouldEqual(crs);
            geo.Uncertainty.ShouldEqual(uncertainty);
            geo.Parameters.ShouldBeEmpty();
        }

        [Theory]
        [InlineData("geo:-48.198634,-16.371648,23.544;crs=wgs84;u=40;key=value", "key", "value")]
        [InlineData("geo:-48.198634,-16.371648,23.544;crs=wgs84;u=40;key", "key", null)]
        public void Geolocation_Parse_ParsesParameters(string input, string key, string value)
        {
            var geo = GeolocationUri.Parse(input);
            geo.Parameters.ContainsKey(key).ShouldBeTrue();
            geo.Parameters[key].ShouldEqual(value);
        }

        public static IEnumerable<object[]> PositiveCases
        {
            get
            {
                yield return new object[] { "geo:-48.198634,-16.371648,23.544;crs=abc;u=40", -48.198634m, -16.371648m, 23.544m, "abc", 40m };
                yield return new object[] { "geo:48.198634,-16.371648,23.544;crs=wgs84;u=40", 48.198634m, -16.371648m, 23.544m, "wgs84", 40m };
                yield return new object[] { "geo:-48.198634,16.371648,23.544;crs=wgs84;u=40", -48.198634m, 16.371648m, 23.544m, "wgs84", 40m };
                yield return new object[] { "geo:48.198634,16.371648,23.544;crs=wgs84;u=40", 48.198634m, 16.371648m, 23.544m, "wgs84", 40m };
                yield return new object[] { "geo:-48.198634,-16.371648,23.544;u=40", -48.198634m, -16.371648m, 23.544m, "wgs84", 40m };
                yield return new object[] { "geo:-48.198634,-16.371648,23.544;crs=wgs84", -48.198634m, -16.371648m, 23.544m, "wgs84", null };
                // reverse order of params violates the RFC5870 specs - possibly an error
                //yield return new object[] { "geo:-48.198634,-16.371648,23.544;u=40;crs=wgs84", -48.198634m, -16.371648m, 23.544m, "wgs84", 40m };
                yield return new object[] { "geo:-48.198634,-16.371648,23.544", -48.198634m, -16.371648m, 23.544m, "wgs84", null };

                yield return new object[] { "geo:-48.198634,-16.371648;crs=abc;u=40", -48.198634m, -16.371648m, null, "abc", 40m };
                yield return new object[] { "geo:48.198634,-16.371648;crs=wgs84;u=40", 48.198634m, -16.371648m, null, "wgs84", 40m };
                yield return new object[] { "geo:-48.198634,16.371648;crs=wgs84;u=40", -48.198634m, 16.371648m, null, "wgs84", 40m };
                yield return new object[] { "geo:48.198634,16.371648;crs=wgs84;u=40", 48.198634m, 16.371648m, null, "wgs84", 40m };
                yield return new object[] { "geo:-48.198634,-16.371648;u=40", -48.198634m, -16.371648m, null, "wgs84", 40m };
                yield return new object[] { "geo:-48.198634,-16.371648;crs=wgs84", -48.198634m, -16.371648m, null, "wgs84", null };
                // reverse order of params violates the RFC5870 specs - possibly an error
                //yield return new object[] { "geo:-48.198634,-16.371648;u=40;crs=wgs84", -48.198634m, -16.371648m, null, "wgs84", 40m };
                yield return new object[] { "geo:-48.198634,-16.371648", -48.198634m, -16.371648m, null, "wgs84", null };
            }
        }
    }
}
