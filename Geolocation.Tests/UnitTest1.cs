using Xunit;

namespace Geolocation.Tests
{
    public class GeolocationTests
    {
        [Theory]
        [InlineData()]
        public void Geolocation_Parse_ParsesCorrectly(string input, decimal longitude, decimal latitude, decimal? altitude, string crs, decimal uncertainty)
        {
        }
    }
}
