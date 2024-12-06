while (true)
{
    Console.Write("Guess a number between 1 and 3: ");
    string? input = Console.ReadLine();
    int num = string.IsNullOrEmpty(input) ? -1 : int.Parse(input);
    if (num < 1 || num > 3)
    {
        Console.WriteLine("Bad Input, Please try again.");
    }
    int ans = new Random().Next(3) + 1;
    
    if (num == ans)
    {
        Console.WriteLine("You got it!");
        break;
    }
    if (num < ans)
    {
        Console.WriteLine("Too small, please try again.");
    }
    else
    {
        Console.WriteLine("Too big, please try again.");
 
    }
}