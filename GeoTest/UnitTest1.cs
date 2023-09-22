using GeoExercise1;
using NetTopologySuite.Geometries;

namespace GeoTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestFourAngles()
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
            var geometries2 = gs.SliceOnEqualFigures(lnr);
            Assert.Equal(2, geometries.Length);
            Assert.True(geometries[0].Count < 5);
            Assert.True(geometries[1].Count < 5);
            Assert.Equal(lnr.Count + 3, geometries[0].Count + geometries[1].Count);

            Assert.Equal(2, geometries2.Length);
            Assert.True(geometries2[0].Count < 5);
            Assert.True(geometries2[1].Count < 5);
            Assert.Equal(lnr.Count + 3, geometries2[0].Count + geometries2[1].Count);


            Assert.True(EqualCoordinates(lnr, geometries[0], geometries[1]));
            Assert.True(EqualCoordinates(lnr, geometries2[0], geometries2[1]));
        }

        [Fact]
        public void TestFiveAngles()
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
            var geometries2 = gs.SliceOnEqualFigures(lnr);
            Assert.Equal(2, geometries.Length);
            Assert.True(geometries[0].Count < 6);
            Assert.True(geometries[1].Count < 6);
            Assert.Equal(lnr.Count + 3, geometries[0].Count + geometries[1].Count);

            Assert.Equal(2, geometries2.Length);
            Assert.True(geometries2[0].Count < 6);
            Assert.True(geometries2[1].Count < 6);
            Assert.Equal(lnr.Count + 3, geometries2[0].Count + geometries2[1].Count);

            Assert.True(EqualCoordinates(lnr, geometries[0], geometries[1]));
            Assert.True(EqualCoordinates(lnr, geometries2[0], geometries2[1]));
        }

        [Fact]
        public void TestSixAngles()
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
            var geometries2 = gs.SliceOnEqualFigures(lnr);

            Assert.Equal(2, geometries.Length);
            Assert.True(geometries[0].Count < 7);
            Assert.True(geometries[1].Count < 7);
            Assert.Equal(lnr.Count + 3, geometries[0].Count + geometries[1].Count);

            Assert.Equal(2, geometries2.Length);
            Assert.True(geometries2[0].Count < 7);
            Assert.True(geometries2[1].Count < 7);
            Assert.Equal(lnr.Count + 3, geometries2[0].Count + geometries2[1].Count);

            Assert.True(EqualCoordinates(lnr, geometries[0], geometries[1]));
            Assert.True(EqualCoordinates(lnr, geometries2[0], geometries2[1]));
        }



        public bool EqualCoordinates(LinearRing parent, LinearRing geometry1, LinearRing geometry2)
        {
            bool res = true;
            List<Coordinate> coordinates_parent = new List<Coordinate>(parent.Count - 1);
            List<Coordinate> coordinates_g1 = new List<Coordinate>(geometry1.Count - 1);
            List<Coordinate> coordinates_g2 = new List<Coordinate>(geometry2.Count - 1);


            for (int i = 0; i < parent.Count - 1; i++)
            {
                coordinates_parent.Add(parent[i]);
            }
            for (int i = 0; i < geometry1.Count - 1; i++)
            {
                coordinates_g1.Add(geometry1[i]);
            }
            for (int i = 0; i < geometry2.Count - 1; i++)
            {
                coordinates_g2.Add(geometry2[i]);
            }


            for (int i = 0; i < geometry1.Count - 1; i++) 
            {
                if (!coordinates_parent.Contains(coordinates_g1[i]))
                {
                    res = false;
                }
            }
            for (int i = 0; i < geometry2.Count - 1; i++)
            {
                if (!coordinates_parent.Contains(coordinates_g2[i]))
                {
                    res = false;
                }
            }

            for(int i = 0; i < parent.Count - 1; i++)
            {
                if (!coordinates_g1.Contains(coordinates_parent[i]) && 
                    !coordinates_g2.Contains(coordinates_parent[i])){
                    res = false;
                }
            }

            return res;
        }
    }
}