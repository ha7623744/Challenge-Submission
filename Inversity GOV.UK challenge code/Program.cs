static void Login()
{
    const string correctID = "GOV12345";   // Predefined correct ID

    Console.WriteLine("Welcome to the GOV.UK ID Login System");
    Console.WriteLine("-------------------------------------------");

    // Prompt the user to enter their name
    Console.Write("Please enter your name: ");
    string userName = Console.ReadLine() ?? "Unknown User";

    // Repeats process of entering ID until correct ID is entered
    while (true)
    {
        Console.Write("Please enter your government ID: ");
        string userInput = Console.ReadLine() ?? string.Empty;

        if (userInput == correctID)
        {
            Console.WriteLine($"Login successful! Welcome to GOV.UK {userName}");
            Search();  // Call the Search procedure
        }
        else
        {
            Console.WriteLine("Incorrect ID. Please try again.");
        }
    }
}

static void Logout(){
    Console.WriteLine("Do you want to log out? (yes/no)");
    string? input = Console.ReadLine();
    if (input != null && input.ToLower() == "yes")
    {
        Console.WriteLine("You have been logged out.");
        Environment.Exit(0);   // Exit the program
    }
    else if (input != null && input.ToLower() == "no")
    {
        Console.WriteLine("You are still logged in.");
        Search();  // Call the Search procedure
    }
    else
    {
        Console.WriteLine("Invalid input. Please try again.");
        Logout();  // Call the Logout procedure again
    }
}

static void Search()
{
    // Create a list to store search history
    List<string> searchHistory = new List<string>();
    // Start an infinite loop to keep searching until user types 'exit'
    while (true)
    {
        Console.WriteLine("Enter a search term (or type 'exit' to stop):");
        string? searchTerm = Console.ReadLine();
        if (searchTerm != null && searchTerm.ToLower() == "exit")
        {
            break;  // Exit the loop 
        }
        // If the search term is not null, add it to the search history
        if (searchTerm != null)
        {
            if (searchHistory.Contains(searchTerm))
            {
                // Display a message if the search term is already in the history
                Console.WriteLine($"You have already searched for {searchTerm}");
            }
            else
            {
                // Add the search term to the history if it's a new term
                searchHistory.Add(searchTerm);
                Console.WriteLine($"You searched for: {searchTerm}");
            }    
        }
    }

    // Display the search history
    Console.WriteLine("Search history:");
    foreach (var term in searchHistory)
    {
        Console.WriteLine(term);
    }

    Logout();  // Call the Logout procedure
}

//------------------- Main Program -------------------

Login();   // Call the Login procedure
