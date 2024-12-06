
Console.WriteLine("Enter an array of n integers (space separated on a single line):");
string? input = Console.ReadLine();
string[] numsInStr = input.Split(' ');
int[] nums = new int[numsInStr.Length];
for (int i = 0; i < numsInStr.Length; i++)
{
    nums[i] = int.Parse(numsInStr[i]);
}
int[] rotated = new int[nums.Length];
Console.WriteLine("Rotated by: ");
input = Console.ReadLine();
int rotatedBy = int.Parse(input);
for  (int i = 1; i <= rotatedBy; i++)
{
    for (int j = 0; j < nums.Length; j++)
    {
        int rotatedIndex = (i + j) % nums.Length;
        rotated[rotatedIndex] += nums[j];
    }
}
foreach (int i in rotated)
{
    Console.Write($"{i} ");
}
