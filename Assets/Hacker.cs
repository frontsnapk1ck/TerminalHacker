using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game Config Data
    const string menuHiut = "You can type 'menu' to get back the the Main Menu.";
    string[] Level1Passwords = { "Books", "Quiet", "Borrow", "Card", "Fiction" };
    string[] Level2Passwords = { "Handcuffs", "Uniform", "Sergent", "Prison", "Illegal" };
    string[] Level3Passwords = { "Spaceship", "Rocketship", "Telescope", "Exploration", "Launchpad" };

    //Game state
    int level;
    string password;
    enum Screen {MainMenu, Password, Win}
    Screen curentScreen;
 
    
    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    // Updates once a frame
    void Update()
    {
        
    }
    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("To where would you like to hack?");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Press '1' to hack the 'Libary'");
        Terminal.WriteLine("Press '2' to hack the 'Police Staion'");
        Terminal.WriteLine("Press '3' to hack 'NASA'");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Remember, you can always type 'menu' to get back here!");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Enter your selection:");

    }
     
    void OnUserInput(string input)
    {
       
        if (input.ToLower() == "menu")  // To always go to back to main menu.
        {
            ShowMainMenu();
        }
        else if (curentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (curentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        RunEasterEggs(input);
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3"); // levels
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }  // end levels

        else
        {
            Terminal.WriteLine("Select a valid level");
        }
    }

    public void RunEasterEggs(string input)
    {
        if (input == "007")
        {
            Terminal.WriteLine("Hello Mr. Bond");
        }
        else if (input.ToLower() == "ksp")
        {
            Terminal.WriteLine("KSP is the greatest thing known to all of man kind!");
            Terminal.WriteLine("");
            Terminal.WriteLine("I hope that you play the best game ever");
        }
    }

    void AskForPassword()
    {
        curentScreen = Screen.Password;
        SetRandomPassword();
        Terminal.ClearScreen();
        Terminal.WriteLine("Enter your Password, hint: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, Level1Passwords.Length);
                password = Level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, Level2Passwords.Length);
                password = Level2Passwords[index2];
                break;
            case 3:
                int index3 = Random.Range(0, Level3Passwords.Length);
                password = Level3Passwords[index3];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input) // checks the password
    {
        if (input == password)
        {
            ShowWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void ShowWinScreen()
    {
        curentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();

    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a book..");
                Terminal.WriteLine(@"

                 __________
                /         //
               /         //
              /         //
             /_________//
            (_________(/
                ");
                Terminal.WriteLine(menuHiut);
                break;
            case 2:
                Terminal.WriteLine("They won't be coming for you now!");
                Terminal.WriteLine(@"
                ___________
               /           \
       _______/             \_____    
      /      |)/-\ |  | /- |-      \
     (    ___| \_/ |_ | \_ |= ___  |
    (____/   \_______________/   \_/
         \___/               \___/
            ");
                Terminal.WriteLine(menuHiut);
                break;
            case 3:
                Terminal.WriteLine(@"
                  ___
           Type  /   \    Reach for
         'menu' /     \   the sky!
        to get |       |
          back |       |  This will
       to the /|       |\ help...
        Main / |       | \
       Menu /  |       |  \
           /___|_______|___\
               /__\ /__\
");
                break;
            default:
                Debug.LogError("Invalid something or another...");
                break;
        }
        
    }
}