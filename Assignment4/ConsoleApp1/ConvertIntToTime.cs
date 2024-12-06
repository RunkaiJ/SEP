Console.Write("Input: ");
string? input = Console.ReadLine();
ulong centuries = string.IsNullOrEmpty(input) ? 0 : ulong.Parse(input);
ulong years = (ulong)centuries * 100;
ulong days = (ulong)(years * 365.24);
ulong hours = days * 60;
ulong minutes = hours * 60;
ulong  seconds = minutes * 60;
ulong milliseconds = seconds * 1000;
ulong microseconds = milliseconds * 1000;
ulong nanoseconds = milliseconds * 1000;

Console.WriteLine($"{centuries} century = {years} years = {days} days = {hours} hours = 52594560 minutes" +
    $" = {seconds} seconds = {milliseconds} milliseconds = {microseconds}  microseconds" +
    $" = {microseconds} nanoseconds");