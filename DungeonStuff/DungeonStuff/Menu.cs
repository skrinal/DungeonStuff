using System;

namespace DungeonStuff
{
    class Menu
    {
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

        public static void MainMenu()
        {
            // Basicly every text is slowly typed once you start the game
            MenuFrame();

            Console.SetCursorPosition(25, 3);
            SlowTextOutput("Welcome to From the Beginning", 45);

            Console.SetCursorPosition(33, 6);
            SlowTextOutput("1. Start", 45);

            Console.SetCursorPosition(33, 7);
            SlowTextOutput("2. About", 45);

            Console.SetCursorPosition(33, 8);
            SlowTextOutput("3.", 45);

            Console.SetCursorPosition(33, 10);
            SlowTextOutput("|       |", 0);

            Console.SetCursorPosition(37, 10); // Adjust the cursor position based on your layout

            bool ans = false;
            do {
                while (ans)
                {
                    // Basicly every text is slowly typed once you start the game
                    MenuFrame();

                    Console.SetCursorPosition(25, 3);
                    SlowTextOutput("Welcome to From the Beginning", 15);

                    Console.SetCursorPosition(33, 6);
                    SlowTextOutput("1. Start", 0);

                    Console.SetCursorPosition(33, 7);
                    SlowTextOutput("2. About", 0);

                    Console.SetCursorPosition(33, 8);
                    SlowTextOutput("3.", 0);

                    Console.SetCursorPosition(33, 10);
                    SlowTextOutput("|       |", 0);


                    Console.SetCursorPosition(37, 10); // Adjust the cursor position based on your layout
                    ans = false;
                }

                string userInputString = Console.ReadLine();
                int.TryParse(userInputString, out int userInput);

                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("You chose 1");

                        MenuFrame();

                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("You chose 2");

                        MenuFrame();

                        Console.ReadKey();
                        break;

                    default:
                        Console.Clear();

                        MenuFrame();

                        Console.SetCursorPosition(31, 4);
                        SlowTextOutput("Invalid input", 50);

                        Console.SetCursorPosition(33, 6);
                        SlowTextOutput("Try Again", 50);

                        Console.SetCursorPosition(32, 9);
                        SlowTextOutput("| Confirm |", 50);

                        Console.ReadKey();
                        Console.Clear();

                        ans = true; // retypes Menu but faster

                        break;
                }
            } while (ans);

        }
    }
}
