using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonStuff
{
    class Combat
    {
        private Character Berserk;  // Deklaration of characters
        private Character Mage;
        private Character Healer;
        
        private Character Monster;
        
        private Dice dice;

        public Combat(Character Berserk, Character Mage, Character Healer,Character Monster, Dice dice)
        {
            this.Berserk = Berserk;
            this.Mage = Mage;
            this.Healer = Healer;
            this.Monster = Monster;
            this.dice = dice;
        }


        private void Draw()  // Stav zpasu
        {
            Console.Clear();
            Console.WriteLine("-------------- Arena -------------- \n");
            Console.WriteLine("Your Characters: \n");
            Console.WriteLine("{0} {1}", Berserk, Berserk.GraphicHealth());
            Console.WriteLine("{0} {1}", Mage, Mage.GraphicHealth());
            Console.WriteLine("{0} {1} \n", Healer, Healer.GraphicHealth());

            Console.WriteLine("Enemy Mobs: \n");
            Console.WriteLine("{0} {1} \n", Monster, Monster.GraphicHealth());

            Console.WriteLine("Logs: \n");
        }


        private void MessageWritte(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
        }

        
        public void Fight()
        {
            Console.WriteLine("Welcome to the Arena!");
            Console.WriteLine($"Today will compete {Berserk}, {Mage}, {Healer} vs {Monster}! \n");
            Console.WriteLine("Match can begine....");
            Console.ReadKey();

            while ((Berserk.Alive() || Mage.Alive() || Healer.Alive()) && Monster.Alive())
            {
                Berserk.Attak(Monster);
                Draw();
                MessageWritte(Berserk.ReturnLastMessage());
                MessageWritte(Monster.ReturnLastMessage());

                Mage.Attak(Monster);
                Draw();
                MessageWritte(Mage.ReturnLastMessage());
                MessageWritte(Monster.ReturnLastMessage());

                Healer.Attak(Monster);
                Draw();
                MessageWritte(Mage.ReturnLastMessage());
                MessageWritte(Monster.ReturnLastMessage());

                
                switch (dice.Throw())
                {
                    case 6:
                    case 5:
                        if (Berserk.Alive())
                        {
                            Monster.Attak(Berserk);
                            MessageWritte(Monster.ReturnLastMessage());
                        }
                        break;
                    case 4:
                    case 3:
                        if (Mage.Alive())
                        {
                            Monster.Attak(Mage);
                            MessageWritte(Monster.ReturnLastMessage());
                        }
                        break;
                    case 2:
                    case 1:
                        if (Healer.Alive())
                        {
                            Monster.Attak(Healer);
                            MessageWritte(Monster.ReturnLastMessage());
                        }
                        break;
                }
                Draw();
                Console.WriteLine();
            }
        }
    }

}