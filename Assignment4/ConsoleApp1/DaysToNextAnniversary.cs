DateOnly birthday = DateOnly.Parse("04/24/1998");
DateOnly today = DateOnly.FromDateTime(DateTime.Now);
int yearsPassed = today.Year - birthday.Year;

if (today < birthday.AddYears(yearsPassed)){
    yearsPassed -= 1;
}

Console.WriteLine($"A person who was born in 04/24/1998 is {yearsPassed} years old");

int daysPassed = today.DayNumber - birthday.DayNumber;
int daysToNextAnniversary = 10000 - (daysPassed % 10000);
Console.WriteLine($"Days to Next Anniversary is: {daysToNextAnniversary}");

