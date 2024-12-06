
namespace ConsoleApp1
{
    internal class ReverseString
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string to reverse: ");
            string? input = Console.ReadLine();
            string reversed = helper1(input);
            Console.WriteLine(reversed);
            helper2(input);

        }

        static string helper1(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "";
            }
            char[] inputArray = input.ToCharArray();
            int left = 0;
            int right = inputArray.Length - 1;
            while (left < right)
            {
                char temp = inputArray[left];
                inputArray[left] = inputArray[right];
                inputArray[right] = temp;
                left += 1;
                right -= 1;
            }
            return string.Join("", inputArray);
        }
        
        static void helper2(string input)
        {
            for (int i = input.Length - 1; i >= 0; i--)
            {
                Console.Write(input[i]);
            }
        }
    }
}
