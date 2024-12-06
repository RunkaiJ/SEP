int[] original = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
int[] copy = new int[original.Length];
for (int i = 0; i < original.Length; i++)
{
    copy[i] = original[i];
}

for  (int i = 0; i < original.Length; i++)
{
    if (i < original.Length - 1)
        Console.Write(original[i] + ",");
    else 
        Console.WriteLine(original[i]);
}
for (int i = 0; i < copy.Length; i++)
{
    if (i < copy.Length - 1)
        Console.Write(original[i] + ",");
    else
        Console.WriteLine(original[i]);
}