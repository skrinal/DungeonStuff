using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonStuff
{
    class Berserk : Character
    {
        private int fury;
        private int maxfury;
        private int furyAttack;
        private int furyDefense;
        
        public Berserk(string name, int health, int attack, int defense, Dice dice, int fury, int furyAttack/*, int furyDefense*/) : base(name, health, attack, defense, dice)
        {
            this.fury = fury;
            this.maxfury = fury;
            this.furyAttack = furyAttack;
            this.furyDefense = defense * 3;
        }
    }
}
