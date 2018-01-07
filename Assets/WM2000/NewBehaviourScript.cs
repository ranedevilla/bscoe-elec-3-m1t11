using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    // Use this for initialization
    String level;
    int pass;
    int ctr = 0;
    bool check = false;
    String[] easy = { "SWORD" , "KNIFE", "ROPE", "GUNS", "STICK"};
    String[] medium = { "DAGGER", "OUTFIT", "GAS MASK", "GAS BOMB", "JAMMER" };
    String[] hard = { "BY FOOT", "HELICOPTER", "CAR", "TUNNEL", "STAY IN HOUSE" };
    String[] choices = new String[3];
    System.Random rdm = new System.Random();
    enum Screen { MainMenu, Password, Win };
    Screen CurrentScreen = Screen.MainMenu;

	void Start () {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        CurrentScreen = Screen.MainMenu;
        Terminal.WriteLine("#M1T11");
        Terminal.WriteLine("");
        Terminal.WriteLine("HOW TO GET AWAY WITH MURDER");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 TO SELECT YOUR WEAPON");
        Terminal.WriteLine("Press 2 TO SELECT YOUR SPECIAL ITEM");
        Terminal.WriteLine("Press 3 TO SELECT YOUR ESCAPE ROUTE");
        Terminal.WriteLine("");
        Terminal.WriteLine("Loss? Type MENU to return here");
        Terminal.WriteLine("");
    }
	
    void OnUserInput(string input)
    {
        if (input.Equals("menu", StringComparison.OrdinalIgnoreCase))
        {
            Terminal.ClearScreen();
            ShowMainMenu();
        }
        else if (input == "Rane" || input == "Claire")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Welcome, " + input + "!");
            Terminal.WriteLine("");
            Terminal.WriteLine("HOW TO GET AWAY WITH MURDER");
            Terminal.WriteLine("");
            Terminal.WriteLine("Press 1 TO SELECT A WEAPON");
            Terminal.WriteLine("Press 2 TO SELECT A SPECIAL DEVICE");
            Terminal.WriteLine("Press 3 TO SELECT AN ESCAPE ROUTE");
            Terminal.WriteLine("");
            Terminal.WriteLine("Loss? Type MENU to return here");
            Terminal.WriteLine("");
        }
        else if (CurrentScreen == Screen.MainMenu)
        {
            StartPassword(input);
        }
        else if(CurrentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void StartPassword(string game_mode)
    {
        Terminal.ClearScreen();
        CurrentScreen = Screen.Password;
        if (game_mode == "1")
        {
            level = "1";
            Terminal.WriteLine("Guess your weapon");
            Terminal.WriteLine("");
            pass = rdm.Next(0, 6);
            Terminal.WriteLine("Hint: " + easy[pass].Anagram());
            Terminal.WriteLine("");
        }
        else if (game_mode == "2")
        {
            level = "2";
            Terminal.WriteLine("Guess your special device");
            Terminal.WriteLine("");
            pass = rdm.Next(0, 6);
            Terminal.WriteLine("Hint: " + medium[pass].Anagram());
            Terminal.WriteLine("");
        }
        else if (game_mode == "3")
        {
            level = "3";
            Terminal.WriteLine("Guess your escape route");
            Terminal.WriteLine("");
            pass = rdm.Next(0, 6);
            Terminal.WriteLine("Hint: " + hard[pass].Anagram());
            Terminal.WriteLine("");
        }
    }

    void CheckPassword(string password)
    {
        if (ctr >= 3)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("You got caught by the guards and they killed you. Start all over again");
            Terminal.WriteLine("");
            Terminal.WriteLine("Type MENU to go back to Main Menu");
        }
        else if (level == "1")
        {
            if(password.Equals(easy[pass], StringComparison.OrdinalIgnoreCase))
            {
                ctr = 0;
                choices[0] = easy[pass];
                level = "2";
                StartPassword("2");
            }
            else
            {
                Terminal.WriteLine("Try Again");
                Terminal.WriteLine("");
                ctr++;
            }
        }
        else if (level == "2")
        {
            if (password.Equals(medium[pass], StringComparison.OrdinalIgnoreCase))
            {
                ctr = 0;
                choices[1] = medium[pass];
                level = "3";
                StartPassword("3");
            }
            else
            {
                Terminal.WriteLine("Try Again");
                Terminal.WriteLine("");
                ctr++;
            }
        }
        else if (level == "3")
        {
            if (password.Equals(hard[pass], StringComparison.OrdinalIgnoreCase))
            {
                ctr = 0;
                choices[2] = hard[pass];
                CurrentScreen = Screen.Win;
                Winner();
            }
            else
            {
                Terminal.WriteLine("Try Again");
                Terminal.WriteLine("");
                ctr++;
            }
        }
        
    }

    void Winner()
    {
        for (int x = 0; x<3; x++)
        {
            if (choices[x] != null)
            {
                check = false;
            }
            else
            {
                check = true;
                break;
            }
        }

        if (check == true)
        {
            ctr = 0;
            Array.Clear(choices, 0, 3);
            Terminal.ClearScreen();
            Terminal.WriteLine("You did not make it through");
            Terminal.WriteLine("And got yourself killed.");
            Terminal.WriteLine("You forgot something to bring with you.");
            Terminal.WriteLine("");
            Terminal.WriteLine("Type MENU to start all over again.");
        }
        else
        {
            ctr = 0;
            Array.Clear(choices, 0, 3);
            Terminal.ClearScreen();
            Terminal.WriteLine("Congrats!");
            Terminal.WriteLine("You get away with murder!");
            Terminal.WriteLine("");
            Terminal.WriteLine("Type MENU to start all over again.");
        }
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
