using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLearn
{
    class Hero
    {
        //姓名
        private string name;

        //生命值
        private int lifeValue;

        //防御
        private int defense;

        //攻击力
        private int attackValue;

        //道具
        private List<Prop> props;


        public Hero() { }

        public Hero(string name, int lifeValue,int attackValue)
        {
            this.name = name;
            this.lifeValue = lifeValue;
            this.attackValue = attackValue;
            this.props = new List<Prop>();
        }

        public Hero(string name, int lifeValue, int defense, int attackValue)
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

        public void Attacked(Monster monster)
        {
            this.lifeValue -= monster.AttackValue;
            if (this.lifeValue<0)
            {
                this.lifeValue = 0;
            }
        }

        //添加道具
        public void addProp(Prop prop)
        {
            this.props.Add(prop);
            this.lifeValue += prop.LifeValue;
            this.attackValue += prop.AttackValue;
        }

        //移除道具
        public void removeProp(Prop prop)
        {
            this.props.Remove(prop);
            this.lifeValue -= prop.LifeValue;
            this.attackValue -= prop.AttackValue;
        }


        //技能Q:回血 1 点
        public void SkillQ()
        {
            this.lifeValue += 1;
        }

        //技能W:造成 3 点伤害
        public void SkillW()
        {

        }

    }
}
