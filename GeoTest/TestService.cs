using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTest
{
    public class TestService
    {
        public static bool NoExtraCoordinates(LinearRing parent, LinearRing geometry1, LinearRing geometry2)
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

            return res;
        }

        public static bool AllPointsUsed(LinearRing parent, LinearRing geometry1, LinearRing geometry2)
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


            for (int i = 0; i < parent.Count - 1; i++)
            {
                if (!coordinates_g1.Contains(coordinates_parent[i]) &&
                    !coordinates_g2.Contains(coordinates_parent[i]))
                {
                    res = false;
                }
            }

            return res;
        }
    }
}
