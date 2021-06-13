namespace DS.CodeSignal.IvPrep.DPBasic
{
    public class MapDecodingProblem
    {
        public static int MapDecoding(string message)
        {
            if (string.IsNullOrEmpty(message)) return 1;
            
            var dp = new int[message.Length + 1];
            dp[0] = 1;
            dp[1] = message[0] == '0' ? 0 : 1;

            for (var i = 2; i <= message.Length; i++)
            {
                var oneDigit = int.Parse(message.Substring(i - 1, 1));
                var twoDigits = int.Parse(message.Substring(i - 2, 2));

                if (oneDigit >= 1)
                {
                    dp[i] += dp[i - 1];
                }

                if (twoDigits >= 10 && twoDigits <= 26)
                {
                    dp[i] += dp[i - 2];
                }
            }

            return dp[message.Length];
        }
    }
}