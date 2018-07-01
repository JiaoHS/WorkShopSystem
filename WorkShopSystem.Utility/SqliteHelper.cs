using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SQLite;

namespace WorkShopSystem.Utility
{
    public static class SqliteHelper
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["sqlite"].ConnectionString;// @"Data Source=C:\Users\Steve\Documents\Visual Studio 2010\Projects\Itcast.Net.Food\Itcast.Net.Food.UI\bin\Debug\foodDB.db;Version=3;";

        //执行增删改的方法

        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] pms)
        {
            using (SQLiteConnection con = new SQLiteConnection(connStr))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int GetMaxID(string v1, string v2)
        {
            throw new NotImplementedException();
        }


        //执行返回单个值的方法
        public static object ExecuteScalar(string sql, params SQLiteParameter[] pms)
        {
            using (SQLiteConnection con = new SQLiteConnection(connStr))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        //执行返回reader的方法
        public static SQLiteDataReader ExecuteReader(string sql, params SQLiteParameter[] pms)
        {
            SQLiteConnection con = new SQLiteConnection(connStr);
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }

        //执行返回一个DataTable的方法
        public static DataTable ExecuteDataTable(string sql, params SQLiteParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, connStr))
            {
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
            return dt;
        }


        //初始化连接对象
        public static void InitialConnection()
        {
            _con = new SQLiteConnection(connStr);
            if (_con.State == ConnectionState.Closed)
            {
                _con.Open();
            }
            //在当前的_con连接对象上创建一个“事务对象”
            //只有当连接对象Open()以后，才能创建事务对象
            _transaction = _con.BeginTransaction();

            //创建一个command对象，设置该command对象使用_con连接对象
            _cmd = new SQLiteCommand(_con);
            //执行设置command对象执行sql语句的时候使用_transaction事务。
            _cmd.Transaction = _transaction;
        }

        //提交，释放连接
        public static void CommitAndCloseConnection()
        {
            if (_transaction != null)
            {
                //提交事务
                _transaction.Commit();
            }
            if (_con != null)
            {
                //关闭连接，释放资源
                _con.Close();
                _con.Dispose();
            }

            if (_cmd != null)
            {
                _cmd.Dispose();
            }
        }

        //回滚，释放连接
        public static void RollbackAndCloseConnection()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
            if (_con != null)
            {
                _con.Close();
                _con.Dispose();
            }

            if (_cmd != null)
            {
                _cmd.Dispose();
            }
        }
        //执行带事务的Sql语句
        public static void ExecuteSql(string sql, SQLiteParameter[] pms)
        {
            if (_cmd != null && _con != null)
            {
                _cmd.CommandText = sql;
                if (pms != null)
                {
                    _cmd.Parameters.AddRange(pms);
                }

                //执行sql
                _cmd.ExecuteNonQuery();
            }
            else
            {
                throw new Exception("Command对象或Connection对象为null。");
            }
        }

        //事务中使用的连接对象
        private static SQLiteConnection _con = null;

        //事务中使用的命令对象
        private static SQLiteCommand _cmd = null;
        //事务对象
        private static SQLiteTransaction _transaction = null;


        public static bool Exists(string p, SQLiteParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        /// List集合转DataTable  
        /// </summary>  
        /// <typeparam name="T">实体类型</typeparam>  
        /// <param name="list">传入集合</param>  
        /// <param name="isStoreDB">是否存入数据库DateTime字段，date时间范围没事，取出展示不用设置TRUE</param>  
        /// <returns>返回datatable结果</returns>  
        //public static DataTable ListToTable<T>(List<T> list, bool isStoreDB = true)
        //{
        //    Type tp = typeof(T);
        //    PropertyInfo[] proInfos = tp.GetProperties();
        //    DataTable dt = new DataTable();
        //    foreach (var item in proInfos)
        //    {
        //        dt.Columns.Add(item.Name, item.PropertyType); //添加列明及对应类型  
        //    }
        //    foreach (var item in list)
        //    {
        //        DataRow dr = dt.NewRow();
        //        foreach (var proInfo in proInfos)
        //        {
        //            object obj = proInfo.GetValue(item);
        //            if (obj == null)
        //            {
        //                continue;
        //            }
        //            //if (obj != null)  
        //            // {  
        //            if (isStoreDB && proInfo.PropertyType == typeof(DateTime) && Convert.ToDateTime(obj) < Convert.ToDateTime("1753-01-01"))
        //            {
        //                continue;
        //            }
        //            // dr[proInfo.Name] = proInfo.GetValue(item);  
        //            dr[proInfo.Name] = obj;
        //            // }  
        //        }
        //        dt.Rows.Add(dr);
        //    }
        //    return dt;
        //}

        /// <summary>  
        /// DataTable转化为List集合  
        /// </summary>  
        /// <typeparam name="T">实体对象</typeparam>  
        /// <param name="dt">datatable表</param>  
        /// <param name="isStoreDB">是否存入数据库datetime字段，date字段没事，取出不用判断</param>  
        /// <returns>返回list集合</returns>  
        //public static List<T> TableToList<T>(DataTable dt, bool isStoreDB = true)
        //{
        //    List<T> list = new List<T>();
        //    Type type = typeof(T);
        //    //List<string> listColums = new List<string>();  
        //    PropertyInfo[] pArray = type.GetProperties(); //集合属性数组  
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        T entity = Activator.CreateInstance<T>(); //新建对象实例   
        //        foreach (PropertyInfo p in pArray)
        //        {
        //            if (!dt.Columns.Contains(p.Name) || row[p.Name] == null || row[p.Name] == DBNull.Value)
        //            {
        //                continue;  //DataTable列中不存在集合属性或者字段内容为空则，跳出循环，进行下个循环     
        //            }
        //            if (isStoreDB && p.PropertyType == typeof(DateTime) && Convert.ToDateTime(row[p.Name]) < Convert.ToDateTime("1753-01-01"))
        //            {
        //                continue;
        //            }
        //            try
        //            {
        //                var obj = Convert.ChangeType(row[p.Name], p.PropertyType);//类型强转，将table字段类型转为集合字段类型    
        //                p.SetValue(entity, obj, null);
        //            }
        //            catch (Exception)
        //            {
        //                // throw;  
        //            }             
        //        }
        //        list.Add(entity);
        //    }
        //    return list;
        //}
    }
}
