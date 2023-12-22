using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonStuff
{
    class Mage : Character
    { 
        private int magicAttack;

        public Mage(string name, int health, int attack, int defense, int mana, Dice dice, int magicAttack) : base(name, health, attack, defense, mana, dice)
        {
            this.magicAttack = magicAttack;
        }
    }
}
