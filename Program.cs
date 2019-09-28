using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//mysql头文件,需要导入MySQL.Data.dll

namespace MysqlTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //MySQL报错是返回MySqlException异常
            string connStr = "server=127.0.0.1;port=3306;user=root;password=123456;database=c#test";
            MySqlConnection conn = new MySqlConnection(connStr);//连接MySQL服务器
            conn.Open();//打开通道，建立连接，可能出现异常
            string sql = "select * from user where id=@id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);//执行一条sql语句
            cmd.Parameters.AddWithValue("id", 1);//占位符，防止sql注入
            MySqlDataReader reader = cmd.ExecuteReader();//执行查询，返回查询的结果集
            while (reader.Read())
            {
                //根据数据库中的列名获取对应的数据
                Console.WriteLine("result:{0},{1},{2},{3}", reader.GetInt32("id"), reader.GetString("name"), reader.GetString("phone"), reader.GetInt32("age"));
            }
            conn.Close();

            conn.Open();
            sql = "select count(1) from user";
            //cmd = new MySqlCommand(sql, conn);
            Object result = cmd.ExecuteScalar();//执行查询，返回查询结果集中的第一行的第一列
            Console.WriteLine("result:{0}", result);
            conn.Close();


            conn.Open();
            sql = "insert into user(name,phone,age) values('zhangzuxiong','762637517','22')";
            cmd = new MySqlCommand(sql, conn);
            int res = cmd.ExecuteNonQuery();//执行插入、删除、更新语句，返回受影响的行数
            Console.WriteLine("result:{0}", res);

            conn.Close();
        }
    }
}
