
int increment = 1;
for (int i = 1; i <= 4; i++)
{
    for (int j = 0; j < 25; j += increment)
    {
        
        if (j != 24)
        {
            Console.Write(j + ",");
        }
        else
        {
            Console.WriteLine(j);
        }
    }
    increment++;
}
