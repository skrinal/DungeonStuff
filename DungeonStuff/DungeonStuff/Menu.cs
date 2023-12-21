using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DungeonStuff
{
    class Menu
    {
        public static int freshStart;
        public static int selectedOption = 0;
        public static ConsoleKeyInfo key;
        public static int returnNum = -1;

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
            Console.ForegroundColor = ConsoleColor.Magenta;
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
           // UNCOMMENT when done with game
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


            Console.SetCursorPosition(44, 8);
            ColorConsoleOutput(ConsoleColor.Magenta, "Welcome to From the Beginning");

            Console.SetCursorPosition(51, 13);
            Console.WriteLine($"  {(selectedOption == 0 ? ">" : " ")} Start");

            Console.SetCursorPosition(51, 15);
            Console.WriteLine($"  {(selectedOption == 1 ? ">" : " ")} About");

            Console.SetCursorPosition(49, 17);
            Console.WriteLine($"  {(selectedOption == 2 ? ">" : " ")} Settings");

            Console.SetCursorPosition(51, 19);
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

            Console.SetCursorPosition(44, 8);
            ColorConsoleOutput(ConsoleColor.Magenta, "Welcome to From the Beginning");


            Console.SetCursorPosition(51, 13);
            Console.WriteLine($"  {(selectedOption == 0 ? ">" : " ")} Easy");

            Console.SetCursorPosition(51, 15);
            Console.WriteLine($"  {(selectedOption == 1 ? ">" : " ")} Hard");

            Console.SetCursorPosition(47, 17);
            ColorConsoleOutput(ConsoleColor.Red, $"  {(selectedOption == 2 ? ">" : " ")} I N F E R N O");

            Console.SetCursorPosition(47, 21);
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
