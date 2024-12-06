
namespace ConsoleApp1
{
    internal class MostFrequentNumber
    {
        static void Main(string[] args)
        {
            MostFrequentHelper(new int[] { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 });
            MostFrequentHelper(new int[] { 7, 7, 7, 0, 2, 2, 2, 0, 10, 10, 10 });
        }
        
        static void MostFrequentHelper(int[] nums)
        {
            if (nums.Length == 0)
            {
                Console.WriteLine("The array is empty. No numbers to evaluate.");
                return;
            }
            Dictionary<int, int> map = new Dictionary<int, int>();
            int max = 0;
            foreach (int num in nums)
            {
                map[num] = map.GetValueOrDefault(num, 0) + 1;
                if (map[num] > max)
                {
                    max = map[num];
                }
            }
            List<int> answers = new List<int>();
            int leftMost = -1;
            foreach (KeyValuePair<int, int> pair in map)
            {
                if (pair.Value == max)
                {
                    answers.Add(pair.Key);
                }
            }
            foreach (int num in nums)
            {
                if (answers.Contains(num))
                {
                    leftMost = num;
                    break;
                }
            }
            if (answers.Count == 1)
            {
                Console.WriteLine($"The number {leftMost} is the most frequent (occurs {max} times)");
            }
            else
            {
                
                Console.Write($"The numbers {string.Join(",", answers)} have the same maximal frequency (each occurs {max} times). " +
                    $"The leftmost of them is {leftMost}");
                
            }



        }
    }

}
