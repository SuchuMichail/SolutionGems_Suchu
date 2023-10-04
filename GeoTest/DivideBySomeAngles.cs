using GeoExercise1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTest
{
    public class DivideBySomeAngles
    {
        [Fact]
        public void TestEightAnglesDivideByFour()
        {
            var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);

            var lnr = gf.CreateLinearRing(new[]
            {
                new NetTopologySuite.Geometries.Coordinate(1,0),
                new NetTopologySuite.Geometries.Coordinate(0,1),
                new NetTopologySuite.Geometries.Coordinate(0,2),
                new NetTopologySuite.Geometries.Coordinate(1,3),
                new NetTopologySuite.Geometries.Coordinate(3,4),
                new NetTopologySuite.Geometries.Coordinate(4,3),
                new NetTopologySuite.Geometries.Coordinate(5,1),
                new NetTopologySuite.Geometries.Coordinate(2,0),
                new NetTopologySuite.Geometries.Coordinate(1,0)
            });

            GeometrySlicer gs = new GeometrySlicer();

            var rings = gs.SliceWithMaxCountAngles(lnr,4);
            
            Assert.True(rings.Count == 4);

            for(int i = 0; i < rings.Count; i++) {         
                Assert.True(rings[i].Count - 1 <= 4);
            }
        }
    }
}
