using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonStuff
{
    class Dice
    {
        private Random random;
        private int countofwalls;

        public Dice()
        {
            countofwalls = 6;
            random = new Random();
        }

        public Dice(int countofwalls)
        {
            this.countofwalls = countofwalls;
            random = new Random();
        }

        public int ReturnCountOfWalls()
        {
            return countofwalls;
        }

        public int Throw()
        {
            return random.Next(1, countofwalls + 1);
        }

        public override string ToString()
        {
            return String.Format("Kostka s {0} stěnami", countofwalls);
        }

    }
}
