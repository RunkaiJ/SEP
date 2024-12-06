using System.Text;

StringBuilder ans = new StringBuilder();
for (int i = 0; i < 101; i++)
{
    bool divibleBy3 = false;
    bool divibleBy5 = false;
    if (i % 3 == 0)
        divibleBy3 = true;
    if (i % 5 == 0)
        divibleBy5 = true;
    if (divibleBy3 && divibleBy5)
        ans.Append("/fizzbuzz/");
    else if (divibleBy3)
        ans.Append("/fizz/");
    else if (divibleBy5) 
        ans.Append("/buzz/");
    else
        ans.Append(i);
    if (i < 100)
        ans.Append(", ");

}
Console.WriteLine(ans);