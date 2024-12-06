namespace ConsoleApp1;

public class FindPrimeNumbers
{
    public static void Main(string[] args)
    {
        int[] primeNums = FindPrimesInRange(0, 100);
        foreach (int prime in  primeNums)
        {
            Console.WriteLine(prime);
        }
    }

    static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> ret = new List<int>();
        for (int i = startNum; i < endNum; i++)
        {
            if (IsPrime(i))
            {
                ret.Add(i);
            }
        }
        return ret.ToArray();

    }

    static bool IsPrime(int num) 
    {
        if (num <= 1)
        {
            return false;
        }
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}