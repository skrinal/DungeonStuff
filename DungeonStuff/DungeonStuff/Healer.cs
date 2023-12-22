using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonStuff
{
    class Healer : Character
    {
        private int healing;
        private int massHealing;
        public Healer(string name, int health, int attack, int defense, Dice dice, int mana) : base(name, health, attack, defense, mana, dice)
        {
            
        }
    }
}
