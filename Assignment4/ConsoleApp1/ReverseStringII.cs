
using System.Text;


namespace ConsoleApp1
{
    internal class ReverseStringII
    {
        static void Main(string[] args)
        {
            Console.WriteLine(reverse("C# is not C++, and PHP is not Delphi!"));
            Console.WriteLine(reverse("The quick brown fox jumps over the lazy dog /Yes! Really!!!/."));
        }

        static string reverse(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }

            HashSet<char> separators = new HashSet<char>()
    {
        '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' '
    };

            List<string> words = new List<string>();
            List<string> delimiters = new List<string>();
            StringBuilder currWord = new StringBuilder();
            StringBuilder currDelimiter = new StringBuilder();

            foreach (char c in s)
            {
                if (separators.Contains(c))
                {
                    if (currWord.Length > 0)
                    {
                        words.Add(currWord.ToString());
                        currWord.Clear();
                    }
                    currDelimiter.Append(c);
                }
                else
                {
                    if (currDelimiter.Length > 0)
                    {
                        delimiters.Add(currDelimiter.ToString());
                        currDelimiter.Clear();
                    }
                    currWord.Append(c);
                }
            }

            if (currDelimiter.Length > 0)
            {
                delimiters.Add(currDelimiter.ToString());
            }

            words.Reverse();

            StringBuilder result = new StringBuilder();
            int delimiterIndex = 0;

           
            for (int i = 0; i < words.Count; i++)
            {
                result.Append(words[i]);
                if (delimiterIndex < delimiters.Count)
                {
                    result.Append(delimiters[delimiterIndex]);
                    delimiterIndex++;
                }
            }

            while (delimiterIndex < delimiters.Count)
            {
                result.Append(delimiters[delimiterIndex]);
                delimiterIndex++;
            }

            return result.ToString();
        }


    }
}
