using System;
using System.Collections.Generic;//容器
using System.Linq;//mysql
using System.Text;//文本
using System.Threading.Tasks;//线程


//五子棋、字符串切割
namespace learn
{
    class Program
    {
        //函数入口
        static void Main(string[] args)
        {

            ASCIIToString();

            ArrayTest();


            Split();

            CheckerBoard();
        }


        //ASCII和string数组的转换
        static void ASCIIToString()
        {
            int a = Console.Read();
            Console.WriteLine(a);
            byte[] arrByte = System.Text.Encoding.ASCII.GetBytes("128".ToString());//将一个字符串的每一个字符转为ASCII码，保存到一个byte数组
            Console.WriteLine(arrByte[1]);

            byte[] bs = { 49, 48 };
            string str = System.Text.Encoding.ASCII.GetString(bs);//将一个ASCII码数组转换为string数组
            Console.WriteLine(str);

            Console.WriteLine(String.Join('-', bs));
            Console.WriteLine(string.Join('-', bs));

            List<int> list = new List<int> { };

        }

        //棋盘
        static void CheckerBoard()
        {
            int[,] arr = new int[16, 16];
            Random random = new Random();
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    arr[i, j] = random.Next(0, 3);
                }
            }

            //打印棋盘
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write(arr[i, j]+"     ");
                }
                Console.WriteLine("\n");
            }


            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    
                    int flag = arr[i, j];//当前位置的棋的颜色1,2
                    if (flag!=0)
                    {
                        
                        int len = 5;
                        int x = i;
                        int y = j;
                        //判断右斜连
                        while ((x>=0&&x< arr.GetLength(0)) &&(y>=0&&y< arr.GetLength(1)))
                        {
                            if (arr[x,y]==flag)
                            {
                                len--;
                                if (len==0)
                                {
                                    Console.WriteLine("[{0},{1}]={2}开始右斜连", i, j, arr[i, j]);
                                    break;
                                }
                                x++;
                                y++;
                            }
                            else
                            {
                                break;
                            }
                            
                        }

                        len = 5;
                        x = i;
                        y = j;
                        //判断左斜连
                        while ((x >= 0 && x < arr.GetLength(0)) && (y >= 0 && y < arr.GetLength(1)))
                        {
                            if (arr[x, y] == flag)
                            {
                                len--;
                                if (len == 0)
                                {
                                    Console.WriteLine("[{0},{1}]={2}开始左斜连", i, j, arr[i, j]);
                                    break;
                                }
                                x++;
                                y--;
                            }
                            else
                            {
                                break;
                            }
                        }

                        len = 5;
                        x = i;
                        y = j;
                        //判断竖连
                        while ((x >= 0 && x < arr.GetLength(0)) && (y >= 0 && y < arr.GetLength(1)))
                        {
                            if (arr[x, y] == flag)
                            {
                                len--;
                                if (len == 0)
                                {
                                    Console.WriteLine("[{0},{1}]={2}开始竖连", i, j, arr[i, j]);
                                    break;
                                }
                                x++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        len = 5;
                        x = i;
                        y = j;
                        //判断横连
                        while ((x >= 0 && x < arr.GetLength(0)) && (y >= 0 && y < arr.GetLength(1)))
                        {
                            if (arr[x, y] == flag)
                            {
                                len--;
                                if (len == 0)
                                {
                                    Console.WriteLine("[{0},{1}]={2}开始横连", i, j, arr[i, j]);
                                    break;
                                }
                                y++;
                            }
                            else
                            {
                                break;
                            }
                        }

                    }
                    

                }
            }

        }


        //字符串分割
        static void Split()
        {
            string str = "你好，窗口，，帮助";
            char c = '，';


            int num = 1;

            //确定要切割成string类型数组的长度
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i]==c)
                {
                    //过滤空字符串
                    if (str[i+1]!=c)
                    {
                        num++;
                    }
                    //num++;  
                }
            }

            //Console.WriteLine(num);

            string[] ss = new string[num];
            string s = "";
            int len = 0;
            int pre = 0;//记录前一个分割符的位置
            for (int i = 0;  i< str.Length; i++)
            {
                if (str[i]==c)
                {
                    //如果遇到了分隔符，将前一个分隔符到当前位置之间的字符串截取出来保存到字符串数组中
                    s = str.Substring(pre, i - pre);
                    if (s.Length!=0)
                    {
                        ss[len++] = s;
                    }
                    //ss[len++] = s;
                    pre = i + 1;
                }

                //如果到末尾，将前一个分隔符到末尾的字串保存到字符串数组中
                if (i==str.Length-1)
                {
                    s = str.Substring(pre, i - pre+1);
                    ss[len++] = s;
                }
            }


            //遍历分割之后的字符串数组
            foreach (var item in ss)
            {
                Console.Write(item + '\n');
            }
            Console.WriteLine();


        }


        //随机生成一个不重复的二维数组，
        static void ArrayTest()
        {
            int[,] arr = new int[4, 4];
            Random random = new Random();
            int[] mark = new int[16];
            int num = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    num = random.Next(1, 17);
                    if (mark[num-1]==0)
                    {
                        arr[i, j] = num;
                        mark[num - 1] = 1;
                    }
                    else
                    {
                        j--;
                    }
                }
            }

            foreach (var item in arr)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }

    }
}
