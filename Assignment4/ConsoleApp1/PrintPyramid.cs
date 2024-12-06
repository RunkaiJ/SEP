int maxIteration = 5;
for (int i = 0; i < maxIteration; i++)
{
    // print space
    int maxSpace = maxIteration - i;
    for (int k = 0; k < maxSpace; k++)
    {
        Console.Write(" ");
    }
    // print stars
    for (int j = 0; j < 2 * i + 1; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}