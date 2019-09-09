using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLearn
{


    //道具结构体
    public struct Prop
    {
        private int id;


        //名称
        private string name;


        //描述
        private string des;

        
        //增加血量
        private int lifeValue;


        //增加攻击
        private int attackValue;

        public Prop(int id,string name,string des,int lifeValue,int attackValue)
        {
            this.id = id;
            this.name = name;
            this.des = des;
            this.lifeValue = lifeValue;
            this.attackValue = attackValue;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Des { get => des; set => des = value; }
        public int LifeValue { get => lifeValue; set => lifeValue = value; }
        public int AttackValue { get => attackValue; set => attackValue = value; }
    }


    public enum Skill
    {
        Q,
        W,
    }



    /*

    //internal:在当前程序集可以访问，默认
    //public > internal > protected > private
    //静态：类的独一份，优先加载
    public class Prop
    {
        //无参构造
        public Prop()
        {

        }


        private const int iNum=999;
        private static int iNum2;


        //析构函数,用于清理非托管代码的资源，不能被调用
        ~Prop()
        {
            Console.WriteLine("析构函数");
        }

        public static int size;

        //静态构造函数，用于初始化当前类静态成员
        static Prop()
        {
            Console.WriteLine("静态构造");
            size = 10;
        }



        //常量只能通过类名访问，常量不占内存
        public const int COUNT = 10;

        public int propId;

        public bool isDel;

        private string name;

        //readonly:只读属性
        public readonly int propNum;

        public int getPropId()
        {
            return propId;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }

        //属性访问器  可以访问数据和修改数据 
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }

        //索引器,可以访问和修改多个字段，方法成员，访问的数据类型必须与申明时一致
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return propId;
                    case 1:
                        return propNum;

                    default:
                        //异常处理
                        throw new IndexOutOfRangeException("index");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        propId = value;
                        break;
                    case 1:
                        //propNum = value;
                        break;
                    default:
                        //异常处理
                        throw new IndexOutOfRangeException("index");
                }
            }
        }


        //自动属性访问器
        //编译器会自定生成小写同名字段，有只读没有只写
        public string PropDesc {  get; set; }
        public static int INum2 { get => iNum2; set => iNum2 = value; }

        public static int INum => iNum;
    }

    */

}
