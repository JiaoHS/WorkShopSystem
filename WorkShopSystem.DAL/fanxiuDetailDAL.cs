/**  版本信息模板在安装目录下，可自行修改。
* fanxiuDetail.cs
*
* 功 能： N/A
* 类 名： fanxiuDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/6/21 9:59:52   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using WorkShopSystem.Utility;

namespace WorkShopSystem.DAL
{
    /// <summary>
    /// 数据访问类:fanxiuDetail
    /// </summary>
    public partial class fanxiuDetailDAL
    {
        public fanxiuDetailDAL()
        { }
        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(WorkShopSystem.Model.fanxiuDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into fanxiuDetail(");
            strSql.Append("bengliao,fanpen,zhengxing,benzhu,liuchengpiaohao)");
            strSql.Append(" values (");
            strSql.Append("@bengliao,@fanpen,@zhengxing,@benzhu,@liuchengpiaohao)");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@bengliao", DbType.Decimal,8),
                    new SQLiteParameter("@fanpen", DbType.Decimal,8),
                    new SQLiteParameter("@zhengxing", DbType.Decimal,8),
                    new SQLiteParameter("@benzhu", DbType.String,2147483647),
            new SQLiteParameter("@liuchengpiaohao", DbType.String,2147483647)};
            parameters[0].Value = model.bengliao;
            parameters[1].Value = model.fanpen;
            parameters[2].Value = model.zhengxing;
            parameters[3].Value = model.benzhu;
            parameters[4].Value = model.liuchengpiaohao;
            int rows = SqliteHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WorkShopSystem.Model.fanxiuDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update fanxiuDetail set ");
            strSql.Append("bengliao=@bengliao,");
            strSql.Append("fanpen=@fanpen,");
            strSql.Append("zhengxing=@zhengxing,");
            strSql.Append("benzhu=@benzhu");
            strSql.Append(" where ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@bengliao", DbType.Decimal,8),
                    new SQLiteParameter("@fanpen", DbType.Decimal,8),
                    new SQLiteParameter("@zhengxing", DbType.Decimal,8),
                    new SQLiteParameter("@benzhu", DbType.String,2147483647)};
            parameters[0].Value = model.bengliao;
            parameters[1].Value = model.fanpen;
            parameters[2].Value = model.zhengxing;
            parameters[3].Value = model.benzhu;

            int rows = SqliteHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from fanxiuDetail ");
            strSql.Append(" where ");
            SQLiteParameter[] parameters = {
            };

            int rows = SqliteHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WorkShopSystem.Model.fanxiuDetail GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select bengliao,fanpen,zhengxing,benzhu from fanxiuDetail ");
            strSql.Append(" where ");
            SQLiteParameter[] parameters = {
            };

            WorkShopSystem.Model.fanxiuDetail model = new WorkShopSystem.Model.fanxiuDetail();
            DataTable dt = SqliteHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                return DataRowToModel(dt.Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WorkShopSystem.Model.fanxiuDetail DataRowToModel(DataRow row)
        {
            WorkShopSystem.Model.fanxiuDetail model = new WorkShopSystem.Model.fanxiuDetail();
            if (row != null)
            {
                if (row["bengliao"] != null && row["bengliao"].ToString() != "")
                {
                    model.bengliao = decimal.Parse(row["bengliao"].ToString());
                }
                if (row["fanpen"] != null && row["fanpen"].ToString() != "")
                {
                    model.fanpen = decimal.Parse(row["fanpen"].ToString());
                }
                if (row["zhengxing"] != null && row["zhengxing"].ToString() != "")
                {
                    model.zhengxing = decimal.Parse(row["zhengxing"].ToString());
                }
                if (row["benzhu"] != null)
                {
                    model.benzhu = row["benzhu"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select bengliao,fanpen,zhengxing,benzhu ");
            strSql.Append(" FROM fanxiuDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqliteHelper.ExecuteDataTable(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM fanxiuDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = SqliteHelper.ExecuteScalar(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from fanxiuDetail T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return SqliteHelper.ExecuteDataTable(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tblName", DbType.VarChar, 255),
					new SQLiteParameter("@fldName", DbType.VarChar, 255),
					new SQLiteParameter("@PageSize", DbType.Int32),
					new SQLiteParameter("@PageIndex", DbType.Int32),
					new SQLiteParameter("@IsReCount", DbType.bit),
					new SQLiteParameter("@OrderType", DbType.bit),
					new SQLiteParameter("@strWhere", DbType.VarChar,1000),
					};
			parameters[0].Value = "fanxiuDetail";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return SqliteHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

