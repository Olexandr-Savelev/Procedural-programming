using static System.Console;

WriteLine("Hello");

List<string> todos = new List<string> { };

string choice;

do
{
    PrintMenu();
    UserChoiceHandler(out choice);
} while (choice != "E");

void UserChoiceHandler(out string choice)
{
    choice = ReadLine().ToUpper();

    switch (choice)
    {
        case "S":
            PrintAllTodos(todos);
            break;
        case "A":
            AddTodo(todos);
            break;
        case "R":
            RemoveTodo(todos);
            break;
        case "E":
            break;
        default:
            WriteLine("Incorrect input");
            break;
    }
}

void PrintMenu()
{
    WriteLine();
    WriteLine("What do you want to do?");
    WriteLine("[S]ee all TODOs");
    WriteLine("[A]dd a TODO");
    WriteLine("[R]emove a TODO");
    WriteLine("[E]xit");
}

void PrintAllTodos(List<string> todos)
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
    }
    foreach (var (value, i) in todos.Select((value, i) => (value, i)))
    {
        WriteLine($"{i + 1}. {value}");
    }
}

void AddTodo(List<string> todos)
{
    string description;
    do
    {
        WriteLine("Enter the TODO description");
        description = ReadLine();
    }
    while (!isDescriptionValid(description));

    todos.Add(description);
    WriteLine($"TODO successfully added: {description}");
}
bool isDescriptionValid(string description)
{
    if (string.IsNullOrEmpty(description))
    {
        WriteLine($"The description cannot be empty.");
        return false;
    }
    else if (todos.Contains(description))
    {
        WriteLine($"The description must be unique.");
        return false;
    }
    return true;
}
void RemoveTodo(List<string> todos)
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }

    int index;

    do
    {
        WriteLine("Select the index of the TODO you want to remove:");
        PrintAllTodos(todos);
    }
    while (!TryToReadIndex(out index));


    string description = todos[index];
    WriteLine($"TODO removed: {description}");
    todos.Remove(description);
}

void ShowNoTodosMessage()
{
    WriteLine("No TODOs have been added yet.");
}

bool TryToReadIndex(out int index)
{
    var userInput = ReadLine();
    if (userInput == "")
    {
        index = 0;
        WriteLine("Selected index cannot be empty.");
        return false;
    }

    bool isChoiceValid = int.TryParse(userInput, out index);
    index--;

    if (isChoiceValid && index >= 0 && index < todos.Count)
    {
        return true;
    }

    WriteLine("The given index is not valid.");
    return false;
}