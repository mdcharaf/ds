namespace DS.Sorting
{
    public class BubbleSort
    {
        public static int[] Sort(int[] arr)
        {
            var isSorted = false;
            var lastUnsorted = arr.Length - 1;

            while (!isSorted)
            {
                for (int i = 0; i < lastUnsorted; i++)
                {
                    isSorted = true;
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        isSorted = false;
                    }
                }

                lastUnsorted--;
            }

            return arr;
        }
        
        static void Swap(int[] arr, int i, int j)
        {
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}