using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObjectLearn
{
    class MyClass
    {
    }

    

    public abstract class AbstractClass : IMyInterface
    {
        public int num;

        public int this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Fun() { }

        public abstract void Show();

    }

    //sealed:无法作为基类
    public sealed class AbstractClassImpl : AbstractClass
    {
        public override void Show()
        {
            Fun();
            Console.WriteLine(num);
        }

    }


    //static:静态类没有实例，静态类的所有成员必须全部静态，无法继承，无法派生,工具类
    public static class A
    {

    }

    //引用类型：引用存放在栈里面，数据存放在堆里面；值类型：存放在栈里面
    //结构体：自定义值类型，没有析构（值类型的内存由系统分配，因此不需要析构）
    //结构体类型无法显示的声明无参构造,构造函数必须为所有的字段初始化
    //结构体中的new没有开辟空间的含义，仅仅只是调用构造函数，结构体中的无参构造始终有效
    //结构体无法继承类或者结构体，但是可以实现接口

    public struct Vector3
    {
        public float x;

        public float y;

        public float z;


        public static Vector3 Zero
        {
            get
            {
                Vector3 zero = new Vector3(0, 0, 0);
                return zero;
            }

            set
            {
                Zero = value;
            }
        }

        public Vector3(float x,float y,float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        public float X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }
    }


    //枚举,内部只有一种成员：常量,值类型
    public enum Gender : uint//枚举类型约束
    {
        Male=0,     //0
        Female=1,   //1
        Other,      //2
    }


    //接口：不包含数据成员，方法成员不允许实现，只包含方法，属性，事件，索引，没有返回修饰符
    public interface IMyInterface
    {
        void Show();

        int Speed { get; set; }

        int this[int index] { get;set; }
    }

    public class MyInterfaceImpl : IMyInterface
    {
        public int this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Show()
        {
            Console.WriteLine("实现接口");
        }
    }
}
