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
        public static int dificulty;
        //public static bool restartStartMenu = true;

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


            Console.CursorVisible = false;
            ///* UNCOMMENT
          
            bool Restart = true;
            bool restartStartMenu = true;
            bool restartMainClassMenu = true;

            do {
                Menu.selectedOption = 0; 
                do {
                    Menu.returnNum = -1;
                    Menu.MainMenu();
                    Menu.freshStart++;
                    restartStartMenu = true; // fix : "Back to Menu"
                    
                    if (Menu.returnNum >= 0 && Menu.returnNum <= 3) {
                        break;
                    }
                     

                } while (Menu.key.Key != ConsoleKey.Escape);

                if (Menu.key.Key == ConsoleKey.Escape) {
                    Menu.ExitMenu();
                    Restart = false; // Dead end
                }
                else
                { // if enter and Menu.returnNum == 0 - 3
                    switch (Menu.returnNum) {
                        case 0:  // Start
                            do 
                            { 
                                Menu.StartMenu();

                                switch (Menu.returnNum)
                                {
                                    case 0: // Normal
                                        Menu.selectedOption = 0;
                                        Restart = true;
                                        restartStartMenu = false;
                                        restartMainClassMenu = true; // fix : "Back to Difficulty"
                                        
                                        do
                                        {
                                            Menu.MainClassMenu();
                                            switch (Menu.returnNum)
                                            {
                                                case 0: // Shadowfury Berserk
                                                    Restart = false;
                                                    restartStartMenu = false;
                                                    restartMainClassMenu = false;

                                                    Menu.mainClass = "Berserk"; // class set as Bers

                                                    break;

                                                case 1: // Undead Mage
                                                    Restart = false;
                                                    restartStartMenu = false;
                                                    restartMainClassMenu = false;

                                                    Menu.mainClass = "Mage"; // class set as Mage

                                                    break;

                                                case 2: // Lunar Shadow Healer
                                                    Restart = false;
                                                    restartStartMenu = false;
                                                    restartMainClassMenu = false;
                                                    
                                                    Menu.mainClass = "Healer"; // class set as Healer

                                                    break;

                                                case 3: // Back to Difficulty
                                                    Restart = false;
                                                    restartStartMenu = true;
                                                    restartMainClassMenu = false;
                                                    Menu.selectedOption = 0; // if "Back to Difficulty" so we are at first option in menu
                                                    //Menu.returnNum = -1;
                                                    break;
                                            }
                                        }while (Menu.key.Key != ConsoleKey.Escape && restartMainClassMenu);;
                                        break;

                                    case 1: // Hard
                                        Restart = false;
                                        restartStartMenu = false;
                                        restartMainClassMenu = true; 
                                        


                                        Console.WriteLine("Hard");
                                        Console.ReadKey();
                                        break;

                                    case 2: // I N F E R N O
                                        Restart = false;
                                        restartStartMenu = false;
                                        restartMainClassMenu = true;



                                        Console.WriteLine("I N F E R N O");
                                        Console.ReadKey();
                                        break;

                                    case 3: // Back to menu
                                        Restart = true;
                                        restartStartMenu = false;
                                        Menu.selectedOption = 0; // if "Back to Menu" so we are at first option in menu
                                        Menu.returnNum = -1;
                                        break;
                                }
                            } while (Menu.key.Key != ConsoleKey.Escape && restartStartMenu);


                            if (Menu.returnNum >= 0 && Menu.returnNum <= 3) {
                                break;
                            }


                            //Console.ReadKey();
                            break;

                        case 1: // About
                            Console.WriteLine("About");
                            Console.ReadKey();

                            /* explanation of letters on map 
                            - B = boss
                            - ? = treasure 

                            etc.
                            */
                            break;


                        case 2: // Settings
                            Console.WriteLine("Settings");
                            Console.ReadKey();

                            // Main color ?
                            // Fast output

                            break;


                        case 3: // Exit
                            Menu.ExitMenu(); 
                            Restart = false; // Dead end
                            break;
                    }
                }

            } while (Restart);
  

            Menu.YourNameMenu();
            
            Console.ReadKey();




            Dice dice = new Dice(10);

            Berserk Berserk = new Berserk("Berserk", 120, 15, 30, dice, 50, 100);

            Mage Mage = new Mage("Mage", 80, 30, 20, 100, dice, 70);

            Healer Healer = new Healer("Healer", 130, 10, 40, dice, 250);

            //Console.WriteLine("Berserk: {0}", Berserk.GraphicHealth()); // test GrafickyZivot();
            //Console.WriteLine("Mage: {0}", Mage.GraphicHealth());
            //Console.WriteLine("Healer: {0}", Healer.GraphicHealth());

            Character Monster = new Character("Amirdrassil", 200, 40, 20, dice);  // Nova Super
                                                                                  // Enemy.Attak(Berserk);

            //Console.WriteLine(Enemy.ReturnLastMessage());
            //Console.WriteLine(Berserk.ReturnLastMessage());
            //Console.WriteLine("Boss health bar: {0}", Enemy.GraphicHealth());
            Combat combat = new Combat(Berserk, Mage, Healer, Monster, dice);

           

            

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


            
        }
    }
}
