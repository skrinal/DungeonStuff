using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonStuff
{
    class Map
    {

        string[,] myMap;

        //
        int playerRow;
        int playerCol;
        //

        private int positionOfMapRow = 40;
        private int positionOfMapColums = 5;


        public Map(int rows, int columns)
        {
            myMap = new string[rows, columns];

            FillMapEdges(myMap, rows, columns);


            /////////
            playerRow = rows / 2 ;
            playerCol = columns / 2 - 1;
            myMap[playerRow, playerCol] = "X"; // "P" represents the player
            ///////
        }

        public void FillMapEdges(string[,] array, int rows , int columns)
        {
            for (int i = 0; i < columns; i++)
            {
                //array[0, i] = "_";  -  povodne bez medzer v rohu
                array[0, i] = i == 0 || i == columns - 1 ? " " : "_";  //trosku odpisane nebudem klamat
                array[rows - 1, i] = "_";
                
            }


            for (int x = 1; x < rows; x++)
            {
                array[x, 0] = "|";
                
                array[x, columns - 1] = "|";
            }

            for(int i = 1; i < rows - 1; i++)
            {
                for (int j = 1; j < columns - 1; j++)
                {
                    array[i, j] = " ";
                }
            }
        }

        public void DisplayMap()
        {
            //////////
            Console.Clear(); // Clear the console to redraw the map
            Console.BackgroundColor = ConsoleColor.Black; // Set default background color
            ///////////


            for (int i = 0; i < myMap.GetLength(0); i++)
            {
                Console.SetCursorPosition(positionOfMapRow, i + positionOfMapColums); // center

                for (int j = 0; j < myMap.GetLength(1); j++)
                {
                    Console.Write(myMap[i, j]);
                }
                Console.WriteLine();
            }


            ActuallyMap();

        }


        public void ActuallyMap()
        {
            // Boss + Campfire
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(50, 6 + i);
                Console.Write("|");

                if (i < 2)
                {
                    Console.SetCursorPosition(55, 8 + i);
                    Console.Write("|");
                }

                if (i < 4)
                {
                    Console.SetCursorPosition(51 + i, 8);
                    Console.Write("_");
                }
                
            }


            // S1
            for (int i = 0; i < 10; i++)
            {
                if (i == 0) // gate - remove later
                {
                    Console.SetCursorPosition(49, 12);
                    Console.Write("G");
                }

                if (i < 1)
                {
                    Console.SetCursorPosition(54, 12 - i);
                    Console.Write("|");
                }

                if (i < 2)
                {
                    Console.SetCursorPosition(42 + i, 14);
                    Console.Write("_");

                    Console.SetCursorPosition(42, 15 + i);
                    Console.Write("|");
                }
                
                if (i < 3)
                {
                    Console.SetCursorPosition(41 + i, 10);
                    Console.Write("_");
                }
                
                if (i < 4)
                {
                    Console.SetCursorPosition(44, 11 + i);
                    Console.Write("|");

                    Console.SetCursorPosition(55 + i, 11);
                    Console.Write("_");
                }

                if (i == 4)
                    i+=3;
                Console.SetCursorPosition(44 + i, 12);
                Console.Write("_");
                  

            }
            for (int i = 0; i < 10; i++)
            {
                if (i < 6)
                {

                    Console.SetCursorPosition(59, 6 + i);
                    Console.Write("|");
                }
            }
            



            // S2
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    Console.SetCursorPosition(44, 22);
                    Console.Write("|");
                }

                if (i < 2)
                {
                    Console.SetCursorPosition(41 + i, 18);
                    Console.Write("_");
                    
                    if (i == 1)
                    {
                        Console.SetCursorPosition(43, 22);
                        Console.Write("_");
                        i++;
                        Console.SetCursorPosition(43 + i, 22);
                        Console.Write("_");
                        i--;
                    }
                    
                }

                if (i < 3)
                {
                    Console.SetCursorPosition(41 + i, 21);
                    Console.Write("_");

                    if (i == 2) 
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            Console.SetCursorPosition(42, 20 + j);
                            Console.Write("|");
                        }
                    }
                    
                }

            }

            // S3
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(72 + i, 12);
                Console.Write("_"); //S3a

                if (i == 1)
                {
                    
                }

                if (i < 2)
                {
                    Console.SetCursorPosition(73, 11 + i);
                    Console.Write("|"); //S3c
                }

                if (i < 3)
                {
                    Console.SetCursorPosition(76, 13 + i);
                    Console.Write("|"); //S3b

                    Console.SetCursorPosition(72 + i, 10);
                    Console.Write("_"); //S3d

                    Console.SetCursorPosition(75, 8 + i);
                    Console.Write("|"); //S3e
                }

            }


            // Spawn            
            Console.SetCursorPosition(55, 15);
            Console.Write("|");
            Console.SetCursorPosition(63, 15);
            Console.Write("|");

            for (int i = 0; i < 5; i++)
            {
                
                if (i < 4)
                {
                    Console.SetCursorPosition(58 + i, 13);
                    Console.Write("_");
                }

                if (i == 4)
                {
                    Console.SetCursorPosition(60, 13);
                    Console.Write("|");
                }
            }


            // CS 
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(63, 6 + i); 
                Console.Write("|"); //CS1
            }

            // m1
            for (int i = 0; i < 5; i++)
            {
                
                if (i < 2)
                {
                    Console.SetCursorPosition(49, 21 + i);
                    Console.Write("|");

                    Console.SetCursorPosition(52, 23 + i);
                    Console.Write("|");
                }

                

            }

            // m2
            for (int i = 0; i < 10; i++)
            {
                if (i < 1)
                {
                    Console.SetCursorPosition(46, 16);
                    Console.Write("|");
                }

                if (i < 2)
                {
                    Console.SetCursorPosition(48 + i, 14);
                    Console.Write("_");
                   
                    Console.SetCursorPosition(55, 19 + i);
                    Console.Write("|");

                }

                if (i < 3)
                {
                    Console.SetCursorPosition(47, 18 + i);
                    Console.Write("|");

                    Console.SetCursorPosition(51, 17 + i);
                    Console.Write("|");
                }

                if (i < 5)
                {
                    Console.SetCursorPosition(48 + i, 19);
                    Console.Write("_");
                    if (i == 3)
                    {
                        Console.SetCursorPosition(48 + i, 19);
                        Console.Write("|");
                    }

                    Console.SetCursorPosition(52 + i, 18);
                    Console.Write("_");
                }
            }

            // m3
            for (int i = 0; i < 10; i++)
            {
                if (i < 3)
                {
                    Console.SetCursorPosition(58, 21 + i);
                    Console.Write("|");

                }

            }

            // m4
            for (int i = 0; i < 5; i++)
            {
                if (i < 2)
                {
                    Console.SetCursorPosition(71, 16 + i);
                    Console.Write("|"); // m4f

                }

                if (i < 3)
                {
                    Console.SetCursorPosition(67, 16 + i);
                    Console.Write("|"); //m4d

                    Console.SetCursorPosition(68 + i, 16);
                    Console.Write("_"); // m4e

                    Console.SetCursorPosition(72 + i, 17);
                    Console.Write("_"); // m4g
                }

                if (i < 4)
                {
                    Console.SetCursorPosition(63 + i, 18);
                    Console.Write("_"); //m4c

                    Console.SetCursorPosition(58 + i, 17);
                    Console.Write("_"); //m4a

                }

                Console.SetCursorPosition(62, 18 + i);
                Console.Write("|"); // m4b
            }

            // m5
            for (int i = 0; i < 5; i++)
            {
                if (i < 2)
                {
                    Console.SetCursorPosition(72, 6 + i);
                    Console.Write("|"); // m5d
                }

                if (i < 3)
                {
                    Console.SetCursorPosition(64 + i, 10);
                    Console.Write("_"); // m5a

                    Console.SetCursorPosition(68 + i, 8);
                    Console.Write("_"); // m5c
                }

                if (i < 4)
                {
                    Console.SetCursorPosition(67, 8 + i);
                    Console.Write("|"); // m5b

                }
            }

            // MS6
            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(70 + i, 21);
                Console.Write("_"); // MS6a

                if (i < 4)
                {
                    Console.SetCursorPosition(72 + i, 20);
                    Console.Write("_"); // MS6b

                    Console.SetCursorPosition(66, 21 + i);
                    Console.Write("|"); // MS6d
                }

                if (i == 4)
                {
                    Console.SetCursorPosition(74, 21);
                    Console.Write("|"); // MS6c
                }
            } 

        }


        ////////////////////////
        public void MovePlayer(ConsoleKeyInfo key)
        {
            myMap[playerRow, playerCol] = " ";

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (playerRow > 1)
                        playerRow--;
                    break;
                case ConsoleKey.DownArrow:
                    if (playerRow < myMap.GetLength(0) - 2)
                        playerRow++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (playerCol > 1)
                        playerCol--;
                    break;
                case ConsoleKey.RightArrow:
                    if (playerCol < myMap.GetLength(1) - 2)
                        playerCol++;
                    break;
            }

            myMap[playerRow, playerCol] = "X";
            HighlightPlayerPosition();
        }

        private void HighlightPlayerPosition()
        {
            // Calculate the actual console position based on the player's position in the array
            int consoleRow = playerRow - Console.WindowTop;
            int consoleCol = playerCol - Console.WindowLeft;

            // Check if the calculated console position is within the console window bounds
            if (consoleRow >= 0 && consoleRow < Console.WindowHeight && consoleCol >= 0 && consoleCol < Console.WindowWidth)
            {
                Console.SetCursorPosition(consoleCol + positionOfMapRow, consoleRow + positionOfMapColums); //Fixed here
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write("P");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        //////////////////////
      
    
    }
}
