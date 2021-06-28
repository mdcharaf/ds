using System.Collections.Generic;

namespace DS._LeetCode.Graphs
{
    public class WordLadderProblem
    {
        public static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var set = new HashSet<string>(wordList);
            if (!set.Contains(endWord)) return 0;
            set.Remove(beginWord);

            var queue = new Queue<string>();
            queue.Enqueue(beginWord);
            var level = 0;

            while (queue.Count > 0)
            {
                var levelSize = queue.Count;
                level++;

                for (int i = 0; i < levelSize; i++)
                {
                    var word = queue.Dequeue();
                    
                    if (word == endWord)
                    {
                        return level;
                    }
                    
                    var neighbors = GetNeighbors(word);

                    foreach (var neighbor in neighbors)
                    {
                        // To Ensure that the neighbor indeed exists in the set.
                        if (set.Contains(neighbor))
                        {
                            queue.Enqueue(neighbor);
                            
                            // Remove word from set to ensure an acyclic graph
                            set.Remove(neighbor);
                        }
                    }
                }
            }

            return 0;
        }

        private static IList<string> GetNeighbors(string word)
        {
            var wordChars = word.ToCharArray();
            var result = new List<string>();

            for (int i = 0; i < wordChars.Length; i++)
            {
                var originalChar = wordChars[i];

                for (var character = 'a'; character <= 'z'; character++)
                {
                    if (character == originalChar) continue;

                    wordChars[i] = character;
                    
                    result.Add(new string(wordChars));
                }

                wordChars[i] = originalChar;
            }

            return result;
        }
    }
}