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


        ///////////////////
    }
}
