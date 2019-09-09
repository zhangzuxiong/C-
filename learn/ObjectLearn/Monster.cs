using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLearn
{
    class Monster
    {

        //姓名
        private string name;

        //生命值
        private int lifeValue;

        //防御
        private int defense;

        //攻击力
        private int attackValue;

        public Monster(string name,int lifeValue)
        {
            this.name = name;
            this.lifeValue = lifeValue;
            this.attackValue = 4;
        }

        public Monster(string name, int lifeValue, int defense, int attackValue)
        {
            this.name = name;
            this.lifeValue = lifeValue;
            this.defense = defense;
            this.attackValue = attackValue;
        }

        public string Name { get => name; set => name = value; }
        public int LifeValue { get => lifeValue; set => lifeValue = value; }
        public int Defense { get => defense; set => defense = value; }
        public int AttackValue { get => attackValue; set => attackValue = value; }

        public int Attacked(Hero hero)
        {
            Random random = new Random();
            int num = random.Next(1, 4)%hero.AttackValue;
            this.lifeValue -= num;
            if (this.lifeValue<0)
            {
                this.lifeValue = 0;
            }

            return num;
        }
    }
}
