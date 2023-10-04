using GeoExercise1;
using NetTopologySuite.Geometries;

namespace GeoTest
{
    public class DivideOneByTwo
    {
        [Fact]
        public void TestFourAnglesDivideByTwo()
        {
            var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);

            var lnr = gf.CreateLinearRing(new[]
            {
                new NetTopologySuite.Geometries.Coordinate(55,55),
                new NetTopologySuite.Geometries.Coordinate(55,56),
                new NetTopologySuite.Geometries.Coordinate(56,56),
                new NetTopologySuite.Geometries.Coordinate(56,55),
                new NetTopologySuite.Geometries.Coordinate(55,55)
            });

            GeometrySlicer gs = new GeometrySlicer();

            var geometries = gs.SliceOnTriangleAndOther(lnr);
            var geometries2 = gs.SliceOnSameAmountAnglesFigures(lnr);
            Assert.Equal(2, geometries.Length);
            Assert.True(geometries[0].Count < 5);
            Assert.True(geometries[1].Count < 5);
            Assert.Equal(lnr.Count + 3, geometries[0].Count + geometries[1].Count);

            Assert.Equal(2, geometries2.Length);
            Assert.True(geometries2[0].Count - 1 == 3);
            Assert.True(geometries2[1].Count - 1 == 3);
            Assert.Equal(lnr.Count + 3, geometries2[0].Count + geometries2[1].Count);


            Assert.True(TestService.NoExtraCoordinates(lnr, geometries[0], geometries[1]));
            Assert.True(TestService.AllPointsUsed(lnr, geometries[0], geometries[1]));
            Assert.True(TestService.NoExtraCoordinates(lnr, geometries2[0], geometries2[1]));
            Assert.True(TestService.AllPointsUsed(lnr, geometries2[0], geometries2[1]));
        }

        [Fact]
        public void TestFiveAnglesDivideByTwo()
        {
            var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);

            var lnr = gf.CreateLinearRing(new[]
            {
                new NetTopologySuite.Geometries.Coordinate(1,0),
                new NetTopologySuite.Geometries.Coordinate(0,1),
                new NetTopologySuite.Geometries.Coordinate(2,2),
                new NetTopologySuite.Geometries.Coordinate(4,1),
                new NetTopologySuite.Geometries.Coordinate(3,0),
                new NetTopologySuite.Geometries.Coordinate(1,0)
            });

            GeometrySlicer gs = new GeometrySlicer();

            var geometries = gs.SliceOnTriangleAndOther(lnr);
            var geometries2 = gs.SliceOnSameAmountAnglesFigures(lnr);
            Assert.Equal(2, geometries.Length);
            Assert.True(geometries[0].Count < 6);
            Assert.True(geometries[1].Count < 6);
            Assert.Equal(lnr.Count + 3, geometries[0].Count + geometries[1].Count);

            Assert.Equal(2, geometries2.Length);
            Assert.True(geometries2[0].Count - 1 == 3);
            Assert.True(geometries2[1].Count - 1 == 4);
            Assert.Equal(lnr.Count + 3, geometries2[0].Count + geometries2[1].Count);

            Assert.True(TestService.NoExtraCoordinates(lnr, geometries[0], geometries[1]));
            Assert.True(TestService.AllPointsUsed(lnr, geometries[0], geometries[1]));
            Assert.True(TestService.NoExtraCoordinates(lnr, geometries2[0], geometries2[1]));
            Assert.True(TestService.AllPointsUsed(lnr, geometries2[0], geometries2[1]));
        }

        [Fact]
        public void TestSixAnglesDivideByTwo()
        {
            var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);

            var lnr = gf.CreateLinearRing(new[]
            {
                new NetTopologySuite.Geometries.Coordinate(1,0),
                new NetTopologySuite.Geometries.Coordinate(0,1),
                new NetTopologySuite.Geometries.Coordinate(1,2),
                new NetTopologySuite.Geometries.Coordinate(2,2),
                new NetTopologySuite.Geometries.Coordinate(3,1),
                new NetTopologySuite.Geometries.Coordinate(2,0),
                new NetTopologySuite.Geometries.Coordinate(1,0)
            }) ;

            GeometrySlicer gs = new GeometrySlicer();

            var geometries = gs.SliceOnTriangleAndOther(lnr);
            var geometries2 = gs.SliceOnSameAmountAnglesFigures(lnr);

            Assert.Equal(2, geometries.Length);
            Assert.True(geometries[0].Count < 7);
            Assert.True(geometries[1].Count < 7);
            Assert.Equal(lnr.Count + 3, geometries[0].Count + geometries[1].Count);

            Assert.Equal(2, geometries2.Length);
            Assert.True(geometries2[0].Count - 1 == 4);
            Assert.True(geometries2[1].Count - 1 == 4);
            Assert.Equal(lnr.Count + 3, geometries2[0].Count + geometries2[1].Count);

            Assert.True(TestService.NoExtraCoordinates(lnr, geometries[0], geometries[1]));
            Assert.True(TestService.AllPointsUsed(lnr, geometries[0], geometries[1]));
            Assert.True(TestService.NoExtraCoordinates(lnr, geometries2[0], geometries2[1]));
            Assert.True(TestService.AllPointsUsed(lnr, geometries2[0], geometries2[1]));
        }

    }
}