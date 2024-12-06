
List<string> toDoList = new List<string>();
while (true)
{
    Console.WriteLine("Current List:");
    if (toDoList.Count == 0)
    {
        Console.WriteLine("Empty");
    }
    else
    {
        foreach (String toDo in toDoList)
        {
            Console.WriteLine("* " + toDo);
        }
    }
    Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
    string? input = Console.ReadLine();
    if (input == null || !(input[0] != '+' || input[0] != '-'))
    {
        Console.WriteLine("Please enter a valid input.");
        continue;
    }
    if (input.Equals("--"))
    {
        toDoList.Clear();
        continue;
    }
    else if (input[0] == '-')
    {
        string toDo = input.Substring(2);
        toDoList.Remove(toDo);
    }
    else
    {
        string toDo = input.Substring(2);
        toDoList.Add(toDo);
    }
}