using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//数组、ref、out关键字、多维数组、交错数组
namespace ArrayLearn
{
    class Program
    {
        static void Main(string[] args)
        {



            ArrayTest1();

            //ArrayTest();


        }


        //随机生成不重复的一个一维数组
        public static void ArrayTest1()
        {

            string str = "1,2,3,4,5";
            string[] strs = str.Split(',');
            Console.WriteLine("切割:"+strs.Length);
            for (int i=0;i<strs.Length;i++)
            {
                Console.Write(strs[i] + " ");
            }
            Console.WriteLine();
            char[] cs = str.ToCharArray();//将字符串转化为字符数组
            str.ToArray();


            const int LEN = 20;
            Random random = new Random();
            int[] arr = new int[LEN];
            //如果没有初始化，数组默认的内容为0
            int[] mark = new int[LEN];
            Console.WriteLine(string.Join(" ", mark));
            //for(int i = 0; i < LEN; i++)
            //{
            //    mark[i] = 0;
            //}
            int num = 0;
            for(int i = 0; i < LEN; i++)
            {
                num = random.Next(1, 21);
                if (mark[num - 1] == 0)
                {
                    arr[i] = num;
                    mark[num - 1]++;
                }
                else
                {
                    i--;
                }
            }


            Array.Sort(arr);

            int[] brr = new int[4];

            //数组的复制,复制arr的前3个数复制到brr的前3个
            Array.Copy(arr,brr,3);


            Console.WriteLine(string.Join(" ", arr));

            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", mark));
        }

        //数组
        public static void ArrayTest()
        {
            string[] arrayName = new string[5] {"1","2","3","4","5"};
            foreach(string str in arrayName)
            {
                Console.Write(str + " ");
            }

            //二维数组
            int[,] arr = new int[4, 5] {
                {1,2,3,4,5 },
                {1,2,3,4,5 },
                {1,2,3,4,5 },
                {1,2,3,4,5 }
            };
            //arr.GetLength(0)获取当前多维数组的第一个维度，0代表一维，1代表二维，2代表三维
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = 1;
                }
            }

            Console.WriteLine();

            foreach(int i in arr)
            {
                Console.Write(i + " ");
            }

            int rank = arr.Rank;//获取数组的秩（维度

            Console.WriteLine();

            //交错数组
            int[][] arr1 = new int[3][]{
                new int[3] { 1, 2, 3 },
                new int[4] { 1, 2, 3, 4 },
                new int[5] { 1, 2, 3, 4, 5 }
            };
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr1[i].Length; j++)
                {
                    Console.Write(arr1[i][j]);
                }
            }
            Console.WriteLine();
            foreach(int[] item in arr1)
            {
                foreach(var i in item)
                {
                    Console.Write(i);
                }
            }

        }


        #region

        //形参数组  在形参之前加params关键字，且必须放在形参的最后一个
        public static void Fun2(params int[] nums)
        {

        }

        //可选参数,参数列表初始化
        //ref和out不能用
        //引用类型的形参初始化只能给null
        public static void Fun3(int x=1,string str="zhang")
        {

        }


        //var 语法速记 类型推断，不是数据类型,只适用于局部变量，必须进行初始化，语法推断，根据初始化推断数据类型
        //一旦编译器推断出变量的数据类型，就无法在修改变量的数据类型
        public static void VarTest()
        {
            var a = 100;
            //a = 3.1415926;//错误
            a = 200;
            Console.WriteLine(a);
        }

        //交换两个数的值
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }


        //out 关键字必须在函数内部对参数进行初始化，ref和out不能构成重载，输出传参
        public static void Fun(out int a,out int b)
        {
            a = 100;
            b = 200;
        }

        #endregion
    }
}
