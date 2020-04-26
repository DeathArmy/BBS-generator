using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BlumBlumShub
{
    public class FipsTests
    {
        public FipsTests()
        {

        }

        public void SingleBitsTest(string series)
        {
            int zeroCount = 0;
            int oneCount = 0;
            for (int i = 0; i < series.Length; i++)
            {
                if (series[i] == '1') oneCount++;
                else zeroCount++;
            }
            System.Console.WriteLine("Test pojedynczych bitow:");
            System.Console.WriteLine("0: " + zeroCount + "\n1: " + oneCount);

            int halfSizeOfSize = series.Length / 2;
            double minCount = halfSizeOfSize - (halfSizeOfSize * 0.0275);
            double maxCount = halfSizeOfSize + (halfSizeOfSize * 0.0275);
            System.Console.WriteLine("Przedzial: " + minCount + "-" + maxCount);

            if (zeroCount >= minCount && zeroCount <= maxCount) System.Console.WriteLine("Wynik testu pozytywny!\n");
            else System.Console.WriteLine("Wynik testu negatywny!\n");
        }

        public void SeriesTest(string series)
        {
            char charMemory = series[0];
            int seriesCount = 1;
            int[] seriesCountTest = new int[1];
            for (int i = 1; i < series.Length; i++)
            {
                if (series[i] == charMemory) seriesCount++;
                else
                {
                    charMemory = series[i];
                    if (seriesCountTest.Length <= seriesCount) Array.Resize(ref seriesCountTest, seriesCount);
                    else seriesCountTest[seriesCount] += 1;
                    seriesCount = 1;
                }
            }
            int tempCounter = 0;
            System.Console.WriteLine("Test serii: ");
            for (int i = 1; i < seriesCountTest.Length; i++)
            {
                if (i < 6) System.Console.WriteLine("Dlugosc serii: " + i + " - " + seriesCountTest[i]);
                else tempCounter += seriesCountTest[i];
            }
            System.Console.WriteLine("Dlugosc serii: 6+ - " + tempCounter);
        }

        public void LongSeriesTest(string series)
        {
            char charMemory = series[0];
            int seriesCount = 1;
            int[] seriesCountTest = new int[1];
            for (int i = 1; i < series.Length; i++)
            {
                if (series[i] == charMemory) seriesCount++;
                else
                {
                    charMemory = series[i];
                    if (seriesCountTest.Length <= seriesCount) Array.Resize(ref seriesCountTest, seriesCount);
                    else seriesCountTest[seriesCount] += 1;
                    seriesCount = 1;
                }
            }
            System.Console.WriteLine("Test dlugiej serii: ");
            if (seriesCountTest.Length < 26) System.Console.WriteLine("Nieznaleziono serii o dlugosci rownej lub dluzszej niz 26!\n");
            else System.Console.WriteLine("Wykryto sierie o dlugosci rownej lub dluzszej niz 26!\n");
        }

        public void PokerTest(string series)
        {
            string[] splitedSegments = (from Match m in Regex.Matches(series, @"\d{1,4}")
                                        select m.Value).ToArray();
            Dictionary<string, int> sumOfSegments = new Dictionary<string, int>();

            sumOfSegments.Add("0000", 0);
            sumOfSegments.Add("0001", 0);
            sumOfSegments.Add("0010", 0);
            sumOfSegments.Add("0011", 0);
            sumOfSegments.Add("0100", 0);
            sumOfSegments.Add("0101", 0);
            sumOfSegments.Add("0110", 0);
            sumOfSegments.Add("0111", 0);
            sumOfSegments.Add("1000", 0);
            sumOfSegments.Add("1001", 0);
            sumOfSegments.Add("1010", 0);
            sumOfSegments.Add("1011", 0);
            sumOfSegments.Add("1100", 0);
            sumOfSegments.Add("1101", 0);
            sumOfSegments.Add("1110", 0);
            sumOfSegments.Add("1111", 0);

            for (int i = 0; i < splitedSegments.Length; i++)
            {
                sumOfSegments[splitedSegments[i]] += 1;
            }
            System.Console.WriteLine("Test pokerowy:");
            double x = 0;
            foreach(var iterator in sumOfSegments)
            {
                x += iterator.Value * iterator.Value;
            }
            x = x * 0.0032;
            x -= 5000;
            System.Console.WriteLine("x= " + x);
            if (x > 2.16 && x < 46.17) System.Console.WriteLine("Wynik testu pozytywny!\n");
            else System.Console.WriteLine("Wynik testu negatywny!\n");
        }
    }
}
