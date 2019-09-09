using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLearn
{

    class Student: IComparable<Student>
    {
        private int id;

        private int age;

        private string name;

        private const  string SCHOOLE_NAME = "五道口技术学院";


        public Student()
        {

        }


        public Student(int id,int age,string name)
        {
            this.id = id;
            this.age = age;
            this.name = name;
        }

        //属性访问器
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }




        //索引器
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return id;

                    case 1:
                        return age;

                    default:
                        throw new IndexOutOfRangeException("index");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        id = value;
                        break;

                    case 1:
                        age = value;
                        break;

                    default:
                        throw new IndexOutOfRangeException("index");
                }
            }
        }

        //public string this[int index]
        //{
        //    get
        //    {
        //        switch (index)
        //        {
        //            case 0:
        //                return name;
        //            case 1:
        //                return SCHOOLE_NAME;
        //                break;
        //            default:
        //                throw new IndexOutOfRangeException("index");
        //        }
        //    }
        //    set
        //    {
        //        switch (index)
        //        {
        //            case 0:
        //                name = value;
        //                break;

        //            default:
        //                throw new IndexOutOfRangeException("index");
        //        }
        //    }
        //}


        public string ToString()
        {
            //Console.WriteLine("学号:{0},姓名：{1},年龄:{2}", id, name, age);
            return string.Format("学号:{0},姓名：{1},年龄:{2},学校:{3}", id, name, age,SCHOOLE_NAME);
        }

        public int CompareTo(Student other)
        {
            return this.id - other.id;
            //return this.name.CompareTo(other.name);
        }

    }
}
