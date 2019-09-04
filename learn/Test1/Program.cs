using System;
using System.Collections.Generic;//容器
using System.Linq;//mysql
using System.Text;//文本
using System.Threading.Tasks;//线程


//程序集除了是.exe 还可以是.dll
namespace Test
{
    class Program
    {
        //程序开始入口
        static void Main(string[] args)
        {


            RandomNum();


            MultiplicationTable();

            NarcissisticNumber();

            PrimeNumber();


            //PalindromeNumber();

            //Test1();

            //RandomNum();

            //ValueTest();

            //ValueChange();
        }



        /// <summary>
        /// 文档注释,用户注释一个方法
        /// 
        /// </summary>
        public static void ValueTest()
        {
            //代码折叠，开始
            #region
            //局部变量必须初始化
            int a = 100;
            Console.WriteLine(a);

            string path = "D:\\test";
            Console.WriteLine(path);

            //定义一个常量,常量不占内存,一旦复制无法在修改
            const double PI = 3.1415926;

            //代码折叠,结束
            #endregion

        }



        /// <summary>
        /// 数据类型强制转换
        /// </summary>
        public static void ValueChange()
        {
            int a = 100;
            string str = "200";

            //int 转 string
            //str = a.ToString();

            //string 转 int
            //int.TryParse(str,out a);
            //a = int.Parse(str);
            a = Convert.ToInt32(str);//可以将string转化为int、double、char等


            Console.WriteLine(a);
            Console.WriteLine(str);

            double d = 3.1415926;
            str = d.ToString();

            Console.WriteLine(str);
            Console.WriteLine(Convert.ToDouble(str));

            float f = (float)d;//double 转 float 是四舍五入保留6位有效小数
            Console.WriteLine(f);

            Console.WriteLine((int)f);//double\float转int直接抹掉小数点后面的数
        }

        //输入输出
        public static void Test1()
        {
            //变量    分配了4个字节的内存，里面存数值100
            int a = 100;

            Console.WriteLine(typeof(int));
            Console.WriteLine(typeof(Int32));
            Console.WriteLine(typeof(Int16));
            Console.WriteLine(typeof(Int64));

            Console.WriteLine(sizeof(int));
            Console.WriteLine(sizeof(Int32));
            Console.WriteLine(sizeof(Int16));
            Console.WriteLine(sizeof(Int64));

            string str = Console.ReadLine();//控制台输入string类型
            Console.Write(str);//输出不换行
            Console.WriteLine();

            int i = Console.Read();//读取控制台输入的第一个字符，返回ASCII值
            Console.WriteLine("ASCII {0} 对应的字符为 {1}", i, (char)i);//将ASCII转为字符


            Console.WriteLine("Hello World!");//换行输出

            Console.ReadKey();//等待用户输入，可以锁住控制台面板
        }


        //随机数排序
        public static void RandomNum()
        {
            Random random = new Random();

            const int LEN = 10;

            int[] arr = new int[LEN];

            for(int i = 0;i < LEN; i++)
            {
                arr[i] = random.Next(1, 11);
            }

            Console.WriteLine("排序之前:"+string.Join(" ", arr));


            for(int i = 0; i < arr.Length-1; i++)
            {
                for(int j = 0; j < arr.Length - i-1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }

            Console.WriteLine("\n排序之后:"+string.Join(" ", arr));

        }

        //交换两个数的值
        public static void Swap(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }


        //回文数
        public static void PalindromeNumber()
        {
            Console.WriteLine("\n回文数:");
            int count = 0;
            for(int num = 0; num < 10000; num++)
            {
                string str = num.ToString();
                for (int i = 0, j = str.Length - 1; i <= j; i++, j--)
                {
                    if (str[i] != str[j])
                    {
                        break;
                    }

                    if (i==j||(i+1==j))
                    {
                        Console.Write(num + "\t");

                        count++;
                        if (count % 10 == 0)
                        {
                            Console.WriteLine("\n");
                        }
                    }
                }
                
            }
        }

        //质数
        public static void PrimeNumber()
        {
            Console.WriteLine("\n\n100以内的质数:");
            for(int num = 2; num <= 100; num++)
            {
                for(int i = 2; i < num; i++)
                {
                    if ((num%i)==0)
                    {
                        break;
                    }

                    if (i+1 == num)
                    {
                        Console.Write(num+" ");
                    }
                }
            }

            Console.WriteLine();
        }


        //水仙花数
        public static void NarcissisticNumber()
        {
            Console.WriteLine("\n\n100-1000的水仙花数:");
            string str = null;
            int sum = 0;
            for (int num = 100; num <= 1000; num++)
            {
                sum = 0;
                str = num.ToString();
                for (int i = 0; i < str.Length; i++)
                {
                    sum += (int)Math.Pow(Convert.ToInt32(str[i].ToString()), 3);
                }

                if (sum == num)
                {
                    Console.Write(num + "\t");
                }
            }
            Console.WriteLine();
        }

        //九九乘法表
        public static void MultiplicationTable()
        {
            Console.WriteLine("\n\n九九乘法表:");
            for(int i = 1; i <= 9; i++)
            {
                for(int j = 1; j <= i;j++)
                {
                    Console.Write(j + "*" + i + "=" + i * j + "\t");
                }
                Console.WriteLine();
            }
        }

    }
}
