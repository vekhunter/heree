class Program
{
    static void Main()
    {
        QuestManager questManager = new QuestManager();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine($"You have {questManager.GetScore()} points.");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine() ?? "";
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(questManager);
                    break;
                case "2":
                    questManager.ListGoals();
                    break;
                case "3":
                    Console.Write("What is the filename for the goal file? ");
                    questManager.SaveGoals(Console.ReadLine() ?? "goals.txt");
                    break;
                case "4":
                    Console.Write("What is the filename for the goal file? ");
                    questManager.LoadGoals(Console.ReadLine() ?? "goals.txt");
                    break;
                case "5":
                    questManager.RecordEvent();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Please choose a valid menu option.");
                    break;
            }
        }
    }

    static void CreateGoal(QuestManager questManager)
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string type = Console.ReadLine() ?? "";
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? "";
        Console.Write("What is the amount of points associated with this goal? ");

        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid number of points.");
            return;
        }

        switch (type)
        {
            case "1":
                questManager.AddGoal(new SimpleGoal(name, description, points));
                break;
            case "2":
                questManager.AddGoal(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    Console.WriteLine("Invalid target count.");
                    return;
                }
                Console.Write("What is the bonus for accomplishing it that many times? ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid bonus amount.");
                    return;
                }
                questManager.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }
}
