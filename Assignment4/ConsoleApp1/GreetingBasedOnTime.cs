
TimeOnly currTime = TimeOnly.FromDateTime(DateTime.Now);

if (currTime >= TimeOnly.Parse("00:00") && currTime < TimeOnly.Parse("12:00"))
{
    Console.WriteLine("Good Morning");
}

if (currTime >= TimeOnly.Parse("12:00") && currTime < TimeOnly.Parse("17:00"))
{
    Console.WriteLine("Good Afternoon");
}

if (currTime >= TimeOnly.Parse("17:00") && currTime < TimeOnly.Parse("21:00"))
{
    Console.WriteLine("Good Evening");
}

if (currTime >= TimeOnly.Parse("21:00") && currTime <= TimeOnly.Parse("23:59"))
{
    Console.WriteLine("Good Night");
}

