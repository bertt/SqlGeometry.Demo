using System;
using Microsoft.SqlServer.Types;

namespace SqlIntersect
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Demo of union using SqlGeometry");
            SqlGeometrySample();
            Console.ReadLine();
        }

        private static void SqlGeometrySample()
        {
            // first polygon
            const string polygon1 = "POLYGON((1 1,5 1,5 5,1 5,1 1),(2 2, 3 2, 3 3, 2 3,2 2))";
            // second polygon with small difference
            const string polygon2 = "POLYGON((0 1,5 1,5 5,1 5,0 1),(2 2, 3 2, 3 3, 2 3,2 2))";
            Console.WriteLine(@"First geometry: {0}", polygon1);
            Console.WriteLine(@"Second geometry: {0}", polygon1);
            var firstGeometry = SqlGeometry.Parse(polygon1);
            var secondGeometry = SqlGeometry.Parse(polygon2);
            // do union
            var resultUnionGeometry = firstGeometry.STUnion(secondGeometry);
            // do intersect
            var resultIntersectGeometry = firstGeometry.STIntersection(secondGeometry);

            var wktResultUnion = resultUnionGeometry.STAsText();
            var wktResultIntersect = resultIntersectGeometry.STAsText();

            // show result as wkt
            Console.WriteLine(@"Union result: {0}", new string(wktResultUnion.Value));
            Console.WriteLine(@"Intersect result: {0}", new string(wktResultIntersect.Value));

        }
    }
}
