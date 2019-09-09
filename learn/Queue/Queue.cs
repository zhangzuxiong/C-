using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Queue
{
    class Queue<T>
    {

        //数组的长度
        private int length;

        //保存数据的数组
        private T[] array;

        //数组的最大容量
        private int size;

        public Queue()
        {
            this.array = null;
        }

        public Queue(int size)
        {
            this.length = 0;
            this.array = new T[size];
            this.size = size;
        }


        public bool IsFull()
        {
            if (this.length==this.size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsEmpty()
        {
            if (this.length==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //入队
        public void Push(T data)
        {
            if (this.IsFull())
            {
                return;
            }
            this.array[this.length++] = data;
        }


        //出队
        public T Pop()
        {
            if (this.IsEmpty())
            {
                return default;
            }

            T res = this.array[0];
            for (int i = 0; i < this.length-1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
            this.length--;
            return res;
        }

        public void Top(out T result)
        {
            if (!this.IsEmpty())
            {
                result = this.array[0];
            }
            else
            {
                result = default;
            }
        }

        public void Show()
        {
            if (this.IsEmpty())
            {
                return;
            }

            for (int i = 0; i < this.length; i++)
            {
                Console.Write(this.array[i]+" ");
            }
            Console.WriteLine();
        }

        public int Length { get => length; set => length = value; }
        public T[] Array { get => array; set => array = value; }
        public int Size { get => size; set => size = value; }
    }


    public static class MyMath
    {
        #region
        //计算两个大数相减
        public static string Sub(string left,string right)
        {
            Stack<char> leftStack = new Stack<char>();
            Stack<char> rightStack = new Stack<char>();


            int len = left.Length > right.Length ? left.Length : right.Length;

            if (left.Length<len)
            {
                string temp = "";
                for (int i = 0; i < len-left.Length; i++)
                {
                    temp += "0";
                }
                    left = temp + left;
            }

            if (right.Length < len)
            {
                string temp = "";
                for (int i = 0; i < len - right.Length; i++)
                {
                    temp += "0";
                }
                right = temp + right;
            }
            

            string result = "";

            //左操作数小于右操作数
            if (left.CompareTo(right)==-1)
            {
                result = "-";
                string temp = left;
                left = right;
                right = temp;
            }


            //将左操作数和右操作数入栈
            for (int i = 0; i < left.Length; i++)
            {
                leftStack.Push(left[i]);
            }

            for (int i = 0; i < right.Length; i++)
            {
                rightStack.Push(right[i]);
            }

            //保存结果的栈
            Stack<int> res = new Stack<int>();

            int borrow = 0;//借位

            int CLeft;
            int CRight;
            int num = 0;

            for (int i = 0; i < left.Length; i++)
            {
                CLeft = Convert.ToInt32(leftStack.Pop().ToString());
                CRight = Convert.ToInt32(rightStack.Pop().ToString());
                //借位处理
                if (borrow==1)
                {
                    //如果借位为0
                    if (CLeft==0)
                    {
                        CLeft = 9;
                    }
                    else
                    {
                        CLeft -= borrow;
                    }
                }

                borrow = 0;
                if (CLeft < CRight)
                {
                    borrow = 1;
                }

                if (borrow==1)
                {
                    num = CLeft + 10 - CRight;
                }
                if (borrow==0)
                {
                    num = CLeft - CRight;
                }

                res.Push(num);


            }




            result += string.Join("", res).TrimStart('0');

            if (result.Length==0)
            {
                result = "0";
            }

            return result;
        }
        #endregion

        //计算两个大数相加
        public static string Add(string left,string right)
        {
            Stack<char> leftStack = new Stack<char>();
            Stack<char> rightStack = new Stack<char>();


            //将左操作数和右操作数入栈
            for (int i = 0; i < left.Length; i++)
            {
                leftStack.Push(left[i]);
            }

            for (int i = 0; i < right.Length; i++)
            {
                rightStack.Push(right[i]);
            }

            int carry = 0;//进位

            //保存结果的栈
            Stack<int> res = new Stack<int>();

            int len = left.Length < right.Length ? left.Length : right.Length;

            char CLeft;
            char CRight;

            //取出操作数的末尾做加法计算
            for (int i = 0; i < len; i++)
            {
                CLeft = leftStack.Pop();
                CRight = rightStack.Pop();

                int sum = Convert.ToInt32(CLeft.ToString()) + Convert.ToInt32(CRight.ToString()) + carry;

                carry = sum / 10;

                res.Push(sum % 10);
            }

            if (left.Length==right.Length)
            {
                if (carry==1)
                {
                    res.Push(carry);
                }
            }

            //如果左操作数大把多余的位入栈
            if (len<left.Length)
            {
                for (int i = 0; i < left.Length-len; i++)
                {
                    CLeft = leftStack.Pop();

                    int sum = Convert.ToInt32(CLeft.ToString()) + carry;

                    carry = sum / 10;

                    res.Push(sum % 10);
                }
                
            }

            //如果有操作数大，把多余的位入栈
            if (len<right.Length)
            {
                for (int i = 0; i < right.Length-len; i++)
                {
                    CRight = rightStack.Pop();

                    int sum = Convert.ToInt32(CRight.ToString()) + carry;

                    carry = sum / 10;

                    res.Push(sum % 10);
                }
            }

            return string.Join("",res);
        }

    }
}
