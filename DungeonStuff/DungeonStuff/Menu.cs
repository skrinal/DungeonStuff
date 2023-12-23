using System;
using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonStuff
{
    class Menu
    {
        public static int freshStart;
        public static int selectedOption = 0;
        public static ConsoleKeyInfo key;
        public static int returnNum = -1;

        public static string nameOfPlayer = "";

        public static string mainClass = "";

        static ConsoleColor mainColorTheme = ConsoleColor.DarkMagenta;


        public static void SlowTextOutput(string text, int delayMilliseconds)
        {
            SlowTextOutput(text, delayMilliseconds, Console.ForegroundColor);
        }

        public static void SlowTextOutput(string text, int delayMilliseconds, ConsoleColor color)
        {
            Console.ForegroundColor = color;

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMilliseconds);
            }

            Console.ResetColor();
        }

        public static void ColorConsoleOutput(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(text);

            Console.ResetColor();
        }

        public static void MenuFrame()
        {
            Console.ForegroundColor = mainColorTheme;
            Console.Write("  ");
            for (int i = 0; i < 116; i++)
            {
                Console.Write("_");
            }

            Console.WriteLine("");

            for (int i = 0; i < 27; i++)
            {

                Console.Write(" |");
                for (int j = 0; j < 116; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");

            }

            Console.Write(" |");
            for (int i = 0; i < 116; i++)
            {
                Console.Write("_");
            }
            Console.Write("|");

            Console.ResetColor();
            
        }

        public static int HandleSelection()
        {
            switch (selectedOption)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
            }
            return 0;
        }

        public static void MainMenu()
        {
           // OLD WAY
           /*
            if (freshStart == 0)
            {
                MenuFrame();
                Console.SetCursorPosition(44, 8);
                SlowTextOutput("Welcome to From the Beginning", 45, ConsoleColor.Magenta);
            }
            */

            Console.Clear();
            MenuFrame();
            returnNum = -1;


            //OLD WAY

            //Console.SetCursorPosition(51, 1);
            //ColorConsoleOutput(ConsoleColor.Magenta, "Welcome to From the Beginning");


            // DONT EVEN BOTHER TO TOUCH THIS
            Console.SetCursorPosition(0, 2);
            Console.ForegroundColor = mainColorTheme;
            Console.WriteLine(@"
 |
 |              ______                     _   _            ____             _             _             
 |             |  ____|                   | | | |          |  _ \           (_)           (_)            
 |             | |__ _ __ ___  _ __ ___   | |_| |__   ___  | |_) | ___  __ _ _ _ __  _ __  _ _ __   __ _ 
 |             |  __| '__/ _ \| '_ ` _ \  | __| '_ \ / _ \ |  _ < / _ \/ _` | | '_ \| '_ \| | '_ \ / _` |
 |             | |  | | | (_) | | | | | | | |_| | | |  __/ | |_) |  __/ (_| | | | | | | | | | | | | (_| |
 |             |_|  |_|  \___/|_| |_| |_|  \__|_| |_|\___| |____/ \___|\__, |_|_| |_|_| |_|_|_| |_|\__, |
 |                                                                      __/ |                       __/ |
 |                                                                     |___/                       |___/ 
 |   
 ");
            Console.ResetColor();
            // DONT EVEN BOTHER TO TOUCH THIS



            Console.SetCursorPosition(51, 15);
            Console.WriteLine($"  {(selectedOption == 0 ? ">" : " ")} Start");

            Console.SetCursorPosition(51, 17);
            Console.WriteLine($"  {(selectedOption == 1 ? ">" : " ")} About");

            Console.SetCursorPosition(49, 19);
            Console.WriteLine($"  {(selectedOption == 2 ? ">" : " ")} Settings");

            Console.SetCursorPosition(51, 21);
            Console.WriteLine($"  {(selectedOption == 3 ? ">" : " ")} Exit");


            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    selectedOption = (selectedOption - 1 + 4) % 4;
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    selectedOption = (selectedOption + 1) % 4;
                    break;

                case ConsoleKey.Enter:
                    returnNum = HandleSelection();
                    break;
            }
        }

        public static void StartMenu()
        {
            Console.Clear();
            MenuFrame();

            returnNum = -1;



            //Console.SetCursorPosition(44, 2);
            //ColorConsoleOutput(ConsoleColor.Magenta, "Choose a Difficulty"); // big / doh / doom / slant / small / standart / 



            Console.SetCursorPosition(0, 4);
            Console.ForegroundColor = mainColorTheme;
            Console.WriteLine(@"
 |                           _____    _    __    __   _                  _   _           
 |                          |  __ \  (_)  / _|  / _| (_)                | | | |          
 |                          | |  | |  _  | |_  | |_   _    ___   _   _  | | | |_   _   _ 
 |                          | |  | | | | |  _| |  _| | |  / __| | | | | | | | __| | | | |
 |                          | |__| | | | | |   | |   | | | (__  | |_| | | | | |_  | |_| |
 |                          |_____/  |_| |_|   |_|   |_|  \___|  \__,_| |_|  \__|  \__, |
 |                                                                                  __/ |
 |                                                                                 |___/ 
 ");
            Console.ResetColor();




            Console.SetCursorPosition(50, 15);
            Console.WriteLine($"  {(selectedOption == 0 ? ">" : " ")} Normal");

            Console.SetCursorPosition(51, 17);
            Console.WriteLine($"  {(selectedOption == 1 ? ">" : " ")} Hard");

            Console.SetCursorPosition(47, 19);
            ColorConsoleOutput(ConsoleColor.Red, $"  {(selectedOption == 2 ? ">" : " ")} I N F E R N O");

            Console.SetCursorPosition(47, 23);
            Console.WriteLine($"  {(selectedOption == 3 ? ">" : " ")} Back to Menu");


            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    selectedOption = (selectedOption - 1 + 4) % 4;
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    selectedOption = (selectedOption + 1) % 4;
                    break;

                case ConsoleKey.Enter:
                    returnNum = HandleSelection();
                    break;
            }

        }


        public static void MainClassMenu()
        {
            Console.Clear();
            MenuFrame();

            returnNum = -1;



            //Console.SetCursorPosition(44, 2);
            //ColorConsoleOutput(ConsoleColor.Magenta, "Choose a Difficulty"); // big / doh / doom / slant / small / standart / 



            Console.SetCursorPosition(0, 4);
            Console.ForegroundColor = mainColorTheme;
            Console.WriteLine(@"
 |                             __  __           _              _____   _                     
 |                            |  \/  |         (_)            / ____| | |                    
 |                            | \  / |   __ _   _   _ __     | |      | |   __ _   ___   ___ 
 |                            | |\/| |  / _` | | | | '_ \    | |      | |  / _` | / __| / __|
 |                            | |  | | | (_| | | | | | | |   | |____  | | | (_| | \__ \ \__ \
 |                            |_|  |_|  \__,_| |_| |_| |_|    \_____| |_|  \__,_| |___/ |___/ 
 ");
            Console.ResetColor();




            Console.SetCursorPosition(47, 15);
            ColorConsoleOutput(ConsoleColor.Red, $"  {(selectedOption == 0 ? ">" : " ")} Shadow Fury Berserk");

            Console.SetCursorPosition(50, 17);
            ColorConsoleOutput(ConsoleColor.DarkMagenta, $"  {(selectedOption == 1 ? ">" : " ")} Undead Mage");

            Console.SetCursorPosition(47, 19);
            ColorConsoleOutput(ConsoleColor.Yellow, $"  {(selectedOption == 2 ? ">" : " ")} Lunar Shadow Healer");



            Console.SetCursorPosition(47, 23);
            Console.WriteLine($"  {(selectedOption == 3 ? ">" : " ")} Back to Difficulty");


            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    selectedOption = (selectedOption - 1 + 4) % 4;
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    selectedOption = (selectedOption + 1) % 4;
                    break;

                case ConsoleKey.Enter:
                    returnNum = HandleSelection();
                    break;
            }
        }


        public static void YourNameMenu()
        {
            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                MenuFrame();

                Console.SetCursorPosition(0, 4);
                Console.ForegroundColor = mainColorTheme;
                Console.WriteLine(@"
 |                            __     __                   _   _                         
 |                            \ \   / /                  | \ | |                        
 |                             \ \_/ /___   _   _  _ __  |  \| |  __ _  _ __ ___    ___ 
 |                              \   // _ \ | | | || '__| | . ` | / _` || '_ ` _ \  / _ \
 |                               | || (_) || |_| || |    | |\  || (_| || | | | | ||  __/
 |                               |_| \___/  \__,_||_|    |_| \_| \__,_||_| |_| |_| \___|
 ");
                Console.ResetColor();

          
                Console.SetCursorPosition(57 - nameOfPlayer.Length / 2, 15);
                Console.WriteLine(nameOfPlayer);

                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                if (key.Key == ConsoleKey.Backspace && nameOfPlayer.Length > 0)
                {
                    nameOfPlayer = nameOfPlayer.Substring(0, nameOfPlayer.Length - 1);
                }
                else
                {
                    nameOfPlayer += key.KeyChar;
                } 
            }
        }

        public static void ExitMenu()
        {
            Console.Clear();
            MenuFrame();
            Console.SetCursorPosition(44, 12);
            Console.WriteLine("Exiting the game. Goodbye!");

            Console.SetCursorPosition(0, 15);
            Environment.Exit(0);

           
        }
    }
}
