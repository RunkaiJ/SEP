
namespace ConsoleApp1
{
    internal class LongestSequence
    {
        static void Main(string[] args)
        {
            int[] res1 = LongestSequenceHelper(new int[] { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 });
            foreach (int i in res1)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            int[] res2 = LongestSequenceHelper(new int[] { 1, 1, 1, 2, 3, 1, 3, 3 });
            foreach (int i in res2)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            int[] res3 = LongestSequenceHelper(new int[] { 4, 4, 4, 4 });
            foreach (int i in res3)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            int[] res4 = LongestSequenceHelper(new int[] { 0, 1, 1, 5, 2, 2, 6, 3, 3 });
            foreach (int i in res4)
            {
                Console.Write($"{i} ");
            }
        }

        static int[] LongestSequenceHelper(int[] seq)
        {
            if (seq.Length == 0)
            {
                return Array.Empty<int>();
            }
            int maxLen = 1;
            int ansLeft = 0;
            int ansRight = 0;
            int currentLeft = 0;

            for (int i = 1; i < seq.Length; i++)
            {
                if (seq[i] != seq[i - 1])
                {
                    currentLeft = i;
                }
                else
                {
                    int currentLen = i - currentLeft + 1;
                    if (currentLen > maxLen)
                    {
                        maxLen = currentLen;
                        ansLeft = currentLeft;
                        ansRight = i;
                    }
                }
            }

            int[] result = new int[maxLen];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = seq[ansLeft];
            }
            return result;
        }

    }



}
