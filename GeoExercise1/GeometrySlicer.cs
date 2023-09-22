using NetTopologySuite.Geometries;

namespace GeoExercise1
{
    public class GeometrySlicer
    {
        public GeometrySlicer()
        {
            NetTopologySuite.NtsGeometryServices.Instance = new NetTopologySuite.NtsGeometryServices(
            // default CoordinateSequenceFactory
            NetTopologySuite.Geometries.Implementation.CoordinateArraySequenceFactory.Instance,
            // default precision model
            new NetTopologySuite.Geometries.PrecisionModel(1000d),
            // default SRID
            4326,
            /********************************************************************
             * Note: the following arguments are only valid for NTS >= v2.2
             ********************************************************************/
            // Geometry overlay operation function set to use (Legacy or NG)
            NetTopologySuite.Geometries.GeometryOverlay.NG,
            // Coordinate equality comparer to use (CoordinateEqualityComparer or PerOrdinateEqualityComparer)
            new NetTopologySuite.Geometries.CoordinateEqualityComparer());
        }
        public LinearRing[] SliceOnTriangleAndOther(LinearRing ring)
        { 
            /*Coordinate[] coordinates = new Coordinate[ring.Count-1];
            for(int i = 0; i < ring.Count - 1; i++)
            {
                coordinates[i] = ring.GetCoordinateN(i);
            }*/

            Coordinate[] coor_first = new Coordinate[4];
            coor_first[0] = ring[0];
            coor_first[1] = ring[1];
            coor_first[2] = ring[2];
            coor_first[3] = ring[0];

            Coordinate[] coor_second = new Coordinate[ring.Count-1];
            for (int i=2; i < ring.Count-1; i++){
                coor_second[i - 2] = ring[i];
            }
            coor_second[ring.Count - 3] = ring[0];
            coor_second[ring.Count - 2] = ring[2];


            var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);

            var lnr1 = gf.CreateLinearRing(coor_first);
            var lnr2 = gf.CreateLinearRing(coor_second);

            return new LinearRing[2] { lnr1, lnr2 };
        }

        public LinearRing[] SliceOnEqualFigures(LinearRing ring)
        {
            Coordinate[] coor_first = new Coordinate[(ring.Count - 1) / 2 + 2];
            Coordinate[] coor_second;
            if ( (ring.Count-1) % 2 == 0 ) 
            {
                coor_second = new Coordinate[(ring.Count-1)/2 + 2];
            }
            else
            {
                coor_second = new Coordinate[(ring.Count-1)/2 + 3];
            }

            for(int i=0; i < (ring.Count-1)/2 + 1; i++)
            {
                coor_first[i] = ring[i];
            }
            coor_first[coor_first.Length - 1] = ring[0];

            for (int i = (ring.Count - 1) / 2; i < ring.Count; i++)
            {
                coor_second[i - ((ring.Count - 1) / 2)] = ring[i];
            }
            coor_second[coor_second.Length - 1] = ring[(ring.Count-1)/2];


            var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);

            var lnr1 = gf.CreateLinearRing(coor_first);
            var lnr2 = gf.CreateLinearRing(coor_second);

            return new LinearRing[2] { lnr1, lnr2 };
        }
    }
}