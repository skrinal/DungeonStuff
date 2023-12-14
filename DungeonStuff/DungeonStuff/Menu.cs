using System;
using System.Runtime.InteropServices;

namespace DungeonStuff
{
    class Menu
    {
        static int selectedOption = 0;
        public static void SlowTextOutput(string text, int delayMilliseconds)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMilliseconds);
            }
        }
        public static void MenuFrame()
        {
            Console.WriteLine("   ________________________________________________________________________");
            Console.WriteLine("  |                                                                        |");
            Console.WriteLine("  |                                                                        |");
            Console.WriteLine("  |                                                                        |");
            Console.WriteLine("  |                                                                        |");
            Console.WriteLine("  |                                                                        |");
            Console.WriteLine("  |                                                                        |");
            Console.WriteLine("  |                                                                        |");
            Console.WriteLine("  |                                                                        |");
            Console.WriteLine("  |                                                                        |");
            Console.WriteLine("  |                                                                        |");
            Console.WriteLine("  |                                                                        |");
            Console.WriteLine("  |________________________________________________________________________|");
        }

        static void HandleSelection()
        {

            Console.Clear();
            switch (selectedOption)
            {
                case 0:
                    Console.WriteLine("Starting the game...");
                    Console.ReadKey();
                    // Add your game logic here
                    break;

                case 1:
                    Console.WriteLine("Opening settings...");
                    // Add your settings logic here
                    break;

                case 2:
                    MenuFrame();
                    Console.SetCursorPosition(27, 6);
                    Console.WriteLine("Exiting the game. Goodbye!");
                    
                    Console.SetCursorPosition(0, 15);
                    Environment.Exit(0);
                    break;
            }
        }
            public static void MainMenu() {

            MenuFrame();
            Console.SetCursorPosition(25, 3);
            //SlowTextOutput("Welcome to From the Beginning", 45); // slow text output of game name so It's cool

            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                MenuFrame();

                Console.SetCursorPosition(25, 3);
                Console.WriteLine("Welcome to From the Beginning");


                Console.SetCursorPosition(32, 6);
                Console.WriteLine($"  {(selectedOption == 0 ? ">" : " ")} Start");

                Console.SetCursorPosition(32, 7);
                Console.WriteLine($"  {(selectedOption == 1 ? ">" : " ")} About");

                Console.SetCursorPosition(32, 8);
                Console.WriteLine($"  {(selectedOption == 2 ? ">" : " ")} Settings");


                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        selectedOption = (selectedOption - 1 + 3) % 3;
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        selectedOption = (selectedOption + 1) % 3;
                        break;

                    case ConsoleKey.Enter:
                        HandleSelection();
                        break;
                }
            } while (key.Key != ConsoleKey.Escape);

        }

        public static void StartMenu()
        {
            MenuFrame();
        }
    }
}
