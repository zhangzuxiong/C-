using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




//委托
public delegate void MyDelegate(int x);

namespace ObjectLearn
{

    

    class Program 
    {
        static void GameStart()
        {
            long a = 1234567890123456789;


            Prop[] props =
            {
                new Prop(1,"","增加血量",4,0),
                new Prop(2,"","增加攻击",0,1),
                new Prop(3,"","增加血量及攻击",2,1)
            };


            Hero hero = new Hero("吕布", 35,3);
            Monster monster = new Monster("貂蝉", 20);

            hero.addProp(props[0]);
            hero.addProp(props[1]);


            int count = 1;
            int attackValue = 0;
            while (hero.LifeValue>0&&monster.LifeValue>0)
            {
                attackValue = monster.Attacked(hero);
                Console.WriteLine("\n\n-------------------------\n第{0}回合:",count);
                Console.WriteLine("{0} 攻击 {1} 造成 {2} 点伤害",hero.Name,monster.Name,attackValue);
                Console.WriteLine("{0} 的血量剩余 {1}", monster.Name, monster.LifeValue);
                if (monster.LifeValue == 0)
                {
                    Console.WriteLine("怪物 {0} 已经阵亡",monster.Name);
                    break;
                }

                hero.Attacked(monster);
                Console.WriteLine("{0} 攻击 {1} 造成 {2} 点伤害",monster.Name,hero.Name,monster.AttackValue);
                Console.WriteLine("{0} 的血量剩余 {1}", hero.Name, hero.LifeValue);
                if (hero.LifeValue==0)
                {
                    Console.WriteLine("defeat");
                    break;
                }
                Console.WriteLine("第{0}回合结束", count);

                Console.ReadKey();

                count++;
            }
        }


        //位运算
        static void TestOperator()
        {
            //&:同为1才为1，其他为0
            //|:有1为1，其他为0
            //^:相反为1
            //~:取反    求相反数是取反加1

            //
            Console.WriteLine(2 ^ 11);

        }


        static void Main(string[] args)
        {


            //枚举的使用
            Gender gender = Gender.Female;
            Console.WriteLine(gender);

            switch (gender)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    break;
                case Gender.Other:
                    break;
                default:
                    break;
            }

            //Console.WriteLine(Prop.INum);
            //Prop.INum2 = 9999;
            //Console.WriteLine(Prop.INum2);


            //uint i = 10;
            //Console.WriteLine(i);
            //i -= 11;
            //Console.WriteLine(i);

            //TestOperator();


            GameStart();



            //TestStudent();


            //不安全代码
            //unsafe
            //{
            //    int a = 10;
            //    int* p = &a;
            //    Console.WriteLine(*p);
            //}

            //Prop prop = new Prop();
            //Console.WriteLine("对象创建之后"+Prop.size);
            //Console.WriteLine(prop.propId);
            //Console.WriteLine(prop.isDel);
            //Console.WriteLine(prop.Name);
            //prop.setName("zhang");
            //prop.Name = "li";
            //Console.WriteLine(prop[1]);
            //Console.WriteLine(prop.Name);

        }

        static void TestStudent()
        {
            Student stu1 = new Student(101,21,"li");
            Student stu2 = new Student(102,22,"zhao");
            Student stu3 = new Student(103,23,"qian");
            Student stu4 = new Student(104,24,"sun");
            Student stu5 = new Student(105,25,"zhang");


            List<Student> list = new List<Student> { };
            list.Add(stu5);
            list.Add(stu2);
            list.Add(stu1);
            list.Add(stu4);
            list.Add(stu3);

            
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();

            list.Sort();
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
