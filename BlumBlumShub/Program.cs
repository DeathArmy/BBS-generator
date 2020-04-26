using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BlumBlumShub
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger p = 30000000091;
            BigInteger q = 40000000003;
            BBS generatorBBS = new BBS(p, q);
            FipsTests fips = new FipsTests();
            string series = string.Empty;

            System.Console.WriteLine("p= " + p + "\nq= " + q);
            System.Console.Write("Wprowadz dlugosc ciagu do wygenerowania: ");
            int SeriesSize = Convert.ToInt32(System.Console.ReadLine());
            series = generatorBBS.GetSeries(SeriesSize);
            System.Console.WriteLine("Ciag: \n" + series);
            fips.SingleBitsTest(series);
            fips.SeriesTest(series);
            fips.LongSeriesTest(series);
            fips.PokerTest(series);

            System.Console.ReadKey();
        }
    }
}
