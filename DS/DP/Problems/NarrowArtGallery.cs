using System;

namespace DS.DP.Problems
{
    public class NarrowArtGallery
    {
        private static long GetOptimalRoomsValues(int n, int k, int[,] gallery)
        {
            var totalValues = 0;
            for (int i = 0; i < n; i++)
            {
                totalValues += gallery[i, 0] + gallery[i, 0];
            }

            var minClosedRoomsValues = CountClosedRoomsMinVal(k, n - 1);

            return totalValues - minClosedRoomsValues;
        }

        private static long CountClosedRoomsMinVal(int k, int n)
        {
            return 0;
        }


        public static void Main2(string[] args)
        {
            var nk = Console.ReadLine().Split(' ');
            var n = int.Parse(nk[0]);
            var k = int.Parse(nk[1]);

            var gallery = new int[n + 1 ,2];

            for (int i = 0; i < n + 1; i++)
            {
                var v = Console.ReadLine().Split(' ');
                var v1 = int.Parse(v[0]);
                var v2 = int.Parse(v[1]);
                
                gallery[i, 0] = v1;
                gallery[i, 1] = v2;
            }

            var result = GetOptimalRoomsValues(n, k, gallery);
            
            Console.WriteLine(result);
        }
    }
}