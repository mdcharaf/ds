namespace DS.LeetCode.Problems
{
    public class AddTwoNumbersProblem
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var head = new ListNode();
            var l3 = head;
            var carry = 0;

            while (l1 != null || l2 != null)
            {
                var l1Val = l1?.val ?? 0;
                var l2Val = l2?.val ?? 0;

                var sum = l1Val + l2Val + carry;
                var lsd = sum % 10;
                carry = sum / 10;

                l3.next = new ListNode(lsd);

                l1 = l1?.next;
                l2 = l2?.next;
                l3 = l3.next;
            }

            if (carry > 0)
            {
                l3.next = new ListNode(carry);
            }

            return head.next;
        }
    }
}