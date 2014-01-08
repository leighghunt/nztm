using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        //            int main( int argc, char *argv[] ) {
        double e, n, lt, ln, e1, n1;
        while (true)
        {
            System.Console.WriteLine("Enter NZTM easting, northing: ");

            string line = System.Console.ReadLine();
            string[] coordinates = line.Split(' ');
            if (coordinates.Count() != 2) break;
            if (!double.TryParse(coordinates[0], out e)) break;
            if (!double.TryParse(coordinates[1], out n)) break;

            nztm nztm = new nztm();
            nztm.nztm_geod(n, e, out lt, out ln);
            nztm.geod_nztm(lt, ln, out n1, out e1);
            System.Console.WriteLine(string.Format("Input NZTM e,n:  {0,12:F03} {1,12:F03}", e, n));
            System.Console.WriteLine(string.Format("Output Lat/Long: {0,12:F06} {1,12:F06}", lt * nztm.rad2deg, ln * nztm.rad2deg));
            System.Console.WriteLine(string.Format("Output NZTM e,n: {0,12:F03} {1,12:F03}", e1, n1));
            System.Console.WriteLine(string.Format("Difference:      {0,12:F03} {1,12:F03}", e1 - e, n1 - n));
        }
        System.Console.ReadKey();
        
        return;
    }

}
