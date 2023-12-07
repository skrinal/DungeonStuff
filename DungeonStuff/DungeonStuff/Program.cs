using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.MainMenu();
            
            
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
            Console.ReadKey();


        }

    }

}