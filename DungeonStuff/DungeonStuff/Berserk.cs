using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonStuff
{
    class Berserk : Character
    {
        private int rage;
        private int maxRage;
        private int rageAttack;
        private int rageDefense;
        
        public Berserk(string name, int health, int attack, int defense, Dice dice, int rage, int rageAttack/*, int rageDefense*/) : base(name, health, attack, defense, dice)
        {
            this.rage = rage;
            this.maxRage = rage;
            this.rageAttack = rageAttack;
            this.rageDefense = defense * 3;
        }
    }
}
