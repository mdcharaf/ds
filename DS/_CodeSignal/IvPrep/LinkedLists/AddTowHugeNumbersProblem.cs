namespace DS.CodeSignal.IvPrep.LinkedLists
{
    public class AddTowHugeNumbersProblem
    {
        ListNode<int> AddTwoHugeNumbers(ListNode<int> a, ListNode<int> b)
        {
            var l1 = Reverse(a);
            var l2 = Reverse(b);
            var head = new ListNode<int>();
            var l3 = head;

            int carry = 0;
            while (l1 != null || l2 != null)
            {
                var val1 = l1?.value ?? 0;
                var val2 = l2?.value ?? 0;

                var sum = val1 + val2 + carry;
                var lsd = sum % 10000;
                carry = sum / 10000;

                l3.next = new ListNode<int> {value = lsd};

                l1 = l1?.next;
                l2 = l2?.next;
                l3 = l3.next;
            }

            if (carry > 0)
            {
                l3.next = new ListNode<int>() {value = carry};
            }

            var result = Reverse(head.next);
            return result;
        }

        ListNode<int> Reverse(ListNode<int> head)
        {
            ListNode<int> prev = null;
            var current = head;

            while (current != null)
            {
                var next = current.next;

                current.next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }
    }
}