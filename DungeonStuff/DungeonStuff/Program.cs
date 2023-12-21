using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonStuff
{
    class Program
    {
        /* CHATGPT - Console fullscrean
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        private const int SW_SHOWMAXIMIZED = 3;
        */
        static void Main()
        {
            /* Get the handle of the console window
            IntPtr consoleHandle = GetConsoleWindow();

            // If the console window handle is obtained successfully
            if (consoleHandle != IntPtr.Zero)
            {
                // Maximize the console window
                ShowWindow(consoleHandle, SW_SHOWMAXIMIZED);
            }
        */ //CHATGPT


            /* UNCOMMENT
            Console.CursorVisible = false;
            bool Restart = true;

            do {
                do {
                    Menu.MainMenu();
                    Menu.freshStart++;

                    if (Menu.returnNum >= 0 && Menu.returnNum <= 4) {
                        break;
                    }

                } while (Menu.key.Key != ConsoleKey.Escape);

                if (Menu.key.Key == ConsoleKey.Escape) {
                    Menu.ExitMenu();
                    Restart = false; // Exit the outer loop if Escape is pressed
                }
                else {
                    switch (Menu.returnNum) {
                        case 0:
                            do {

                                Menu.StartMenu();
                                
                                if (Menu.returnNum == 3)
                                {
                                    Restart = true;
                                    break;
                                }
                            } while (Menu.key.Key != ConsoleKey.Escape);

                            

                            if (Menu.returnNum >= 0 && Menu.returnNum <= 4) {
                                break;
                            }

                            Console.ReadKey();
                            break;
                        case 1:
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.ReadKey();
                            break;
                        case 3:
                            Menu.ExitMenu(); // Exit
                            Restart = false; // Exit the outer loop
                            break;
                    }
                }

            } while (Restart);

            /* here
            do {
                Menu.MainMenu();
                Menu.freshStart++;

                if (Menu.returnNum >= 0 && Menu.returnNum <= 4)
                {
                    break;
                }

            } while (Menu.key.Key != ConsoleKey.Escape);

           
            if (Menu.key.Key == ConsoleKey.Escape)
            {
                Menu.ExitMenu();
            }
           
            switch (Menu.returnNum)
            {
                case 0:
                    do
                    {
                        Menu.StartMenu();
                    } while (Menu.key.Key != ConsoleKey.Escape);

                    if (Menu.returnNum >= 0 && Menu.returnNum <= 4)
                    {
                        break;
                    }

                    Console.ReadKey();
                    break;
                case 1:
                    
                    Console.ReadKey();
                    break;
                case 2:
                    
                    Console.ReadKey();
                    break;
                case 3:
                    Menu.ExitMenu(); // Exit
                    break;

            }

            */



            Dice dice = new Dice(10);
            Character Berserk = new Character("Berserk", 120, 15, 30, dice);

            Character Mage = new Character("Mage", 80, 30, 20, dice);

            Character Healer = new Character("Healer", 130, 10, 40, dice);

            //Console.WriteLine("Berserk: {0}", Berserk.GraphicHealth()); // test GrafickyZivot();
            //Console.WriteLine("Mage: {0}", Mage.GraphicHealth());
            //Console.WriteLine("Healer: {0}", Healer.GraphicHealth());

            Character Monster = new Character("Amirdrassil", 200, 40, 20, dice);  // Nova Super
                                                                                  // Enemy.Attak(Berserk);

            //Console.WriteLine(Enemy.ReturnLastMessage());
            //Console.WriteLine(Berserk.ReturnLastMessage());
            //Console.WriteLine("Boss health bar: {0}", Enemy.GraphicHealth());

            Combat combat = new Combat(Berserk, Mage, Healer, Monster, dice);

            //combat.Fight();
            //Console.ReadKey();


            



            ///////////////
            Console.CursorVisible = false; // Hide the cursor for better 

            Map dungeonMap = new Map(20, 40);

            ConsoleKeyInfo key;

            do
            {
                dungeonMap.DisplayMap();

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                    break;

                dungeonMap.MovePlayer(key);

            } while (true);

            Console.CursorVisible = true; // Show the cursor again before exiting
            //////////////////////////






            Console.Clear();
            Console.WriteLine("jeba");
            Console.ReadKey();
        }
    }
}
