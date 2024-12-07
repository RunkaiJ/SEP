


namespace ConsoleApp1;

public class ReverseString
{
    static void Main(string[] args)
    {
        int[] numbers = GenerateNumbers(10);
        Reverse(numbers);
        PrintNumbers(numbers);
    }

    private static void PrintNumbers(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (i != numbers.Length - 1)
                Console.Write($"{numbers[i]}, ");
            else
                Console.WriteLine($"{numbers[i]}.");

        }
    }

    private static void Reverse(int[] numbers)
    {
        int left = 0;
        int right = numbers.Length - 1;
        while (left < right)
        {
            int temp = numbers[left];
            numbers[left] = numbers[right];
            numbers[right] = temp;
            left += 1;
            right -= 1;
        }
    }

    private static int[] GenerateNumbers(int length)
    {
        int[] res = new int[length];
        for (int i = 1; i <= length; i++)
        {
            res[i - 1] = i;
        }
        return res;
    }
}