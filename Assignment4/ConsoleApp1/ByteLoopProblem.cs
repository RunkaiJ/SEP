int max = 500;
for (byte i = 0; i < 255; i++)
{
    if (i + 1 == 255)
    {
        Console.WriteLine("Out Of Range");
        break;
    }
    Console.WriteLine(i);
}
