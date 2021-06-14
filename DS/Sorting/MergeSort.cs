namespace DS.Sorting
{
    public class MergeSort
    {
        public static void Sort(int[] arr)
        {
        }

        static void Sort(int[] arr, int start, int end)
        {
            if (start >= end) return;

            var mid = (start + end) / 2;
            
            Sort(arr, start, mid);
            Sort(arr, mid, end);
        }

        static void Merge(int[] arr, int start, int mid, int end)
        {
            
        }
    }
}