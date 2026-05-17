using XBIOM.Algorithms.Tsp;

namespace XBIOM.Tests;

public class CityTests
{
    [Fact]
    public void GetDistanceFromPosition_ReturnsZeroForSamePosition()
    {
        City prague = new("Praha", 50.075538, 14.437800);

        double distance = prague.GetDistanceFromPosition(50.075538, 14.437800);

        Assert.Equal(0, distance, precision: 10);
    }

    [Fact]
    public void GetDistanceFromPosition_IsSymmetric()
    {
        City prague = new("Praha", 50.075538, 14.437800);
        City olomouc = new("Olomouc", 49.593778, 17.250879);

        double pragueToOlomouc = prague.GetDistanceFromPosition(olomouc.Latitude, olomouc.Longitude);
        double olomoucToPrague = olomouc.GetDistanceFromPosition(prague.Latitude, prague.Longitude);

        Assert.Equal(pragueToOlomouc, olomoucToPrague, precision: 10);
    }

    [Fact]
    public void GetDistanceFromPosition_ReturnsExpectedApproximateDistance()
    {
        City prague = new("Praha", 50.075538, 14.437800);
        City olomouc = new("Olomouc", 49.593778, 17.250879);

        double distance = prague.GetDistanceFromPosition(olomouc.Latitude, olomouc.Longitude);

        Assert.InRange(distance, 205, 215);
    }
}
