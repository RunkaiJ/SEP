using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

internal class ExtractPalindromes
{
    static void Main(string[] args)
    {
        string[] palindromes = extract("Hi,exe? ABBA! Hog fully a string: ExE. Bob");
        foreach (string palindrome in palindromes)
        {
            if (palindrome == palindromes[palindromes.Length - 1])
            {
                Console.Write($"{palindrome}");
            }
            else
            {
                Console.Write($"{palindrome}, ");
            }
        }
    }

    static string[] extract(string s)
    {
      
        HashSet<string> uniquePalindromes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        char[] separators = { '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };
        string[] words = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (IsPalindrome(word))
            {
                uniquePalindromes.Add(word);
            }
        }

        return uniquePalindromes.OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ToArray();
    }

    static bool IsPalindrome(string word)
    {
        if (string.IsNullOrEmpty(word) || word.Length == 1)
        {
            return true;
        }

        int left = 0;
        int right = word.Length - 1;

        while (left < right)
        {
            if (char.ToLower(word[left]) != char.ToLower(word[right]))
            {
                return false;
            }
            left++;
            right--;
        }

        return true;
    }
}
