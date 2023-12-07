﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonStuff
{
    class Character
    {
        private string name;
        private int health;
        private int maxHealth;
        private int attack;
        private int defense;
        //private string characterClass;
        private Dice dice;

        public Character(string name, int health, int attack, int defense, /*string characterClass,*/ Dice dice)
        {
            this.name = name;
            this.health = health;
            this.maxHealth = health;
            this.attack = attack;
            this.defense = defense;
            //this.characterClass = characterClass;
            this.dice = dice;
        }

        public bool Alive()
        {
            return (health > 0);
        }

        
        public string GraphicHealth()
        {
            string s = "[";
            int overall = 20;
            double count = Math.Round(((double)health / maxHealth) * overall); // Math calculation so health is estetic

            if ((count == 0) && (Alive()))
            {
                count = 1;
            }

            for (int i = 0; i < count; i++)
            {
                s += "#";
            }
            s = s.PadRight(overall + 1);
            s += "]";
            
            return s;
        }

        public void Attak (Character enemy)
        {
            int hit = attack + dice.Throw();
            SetMessage(String.Format($"{name} attacks with a {hit} hp hit "));
            enemy.Defense(hit);
        }

        public void Defense (int hit)
        {
            int injury = hit - (defense + dice.Throw());  // injury = (dmg) - (defense + dice)
            if ( injury > 0)
            {
                health -= injury; 
                message = String.Format($"{name} suffered damage {injury} hp ");
                if ( health <= 0)
                {
                    health = 0;
                    message += "and died";
                }
            }
            else
            {
                message = String.Format($"{name} repelled the attack");
            }
            SetMessage(message);
        }

        private string message;
        private void SetMessage(string message)
        {
            this.message = message;
        }


        public override string ToString()
        {
            return name;
        }

        public string ReturnLastMessage()
        {
            return message;
        }
    }

}
