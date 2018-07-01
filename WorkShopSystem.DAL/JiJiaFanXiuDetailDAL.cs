/**  版本信息模板在安装目录下，可自行修改。
* JiJiaFanXiuDetail.cs
*
* 功 能： N/A
* 类 名： JiJiaFanXiuDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/6/22 11:15:19   N/A    初版
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
	/// 数据访问类:JiJiaFanXiuDetail
	/// </summary>
	public partial class JiJiaFanXiuDetailDAL
	{
		public JiJiaFanXiuDetailDAL()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WorkShopSystem.Model.JiJiaFanXiuDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into JiJiaFanXiuDetail(");
			strSql.Append("jinqikoukepeng,falanmianhuashang,pensha,kefanxipin,kefanfamei,xiaoshakongkefanxiu,beizhu,liuchengpiaobianhao,louqi)");
			strSql.Append(" values (");
			strSql.Append("@jinqikoukepeng,@falanmianhuashang,@pensha,@kefanxipin,@kefanfamei,@xiaoshakongkefanxiu,@beizhu,@liuchengpiaobianhao,@louqi)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@jinqikoukepeng", DbType.Decimal,8),
					new SQLiteParameter("@falanmianhuashang", DbType.Decimal,8),
					new SQLiteParameter("@pensha", DbType.Decimal,8),
					new SQLiteParameter("@kefanxipin", DbType.Decimal,8),
					new SQLiteParameter("@kefanfamei", DbType.Decimal,8),
					new SQLiteParameter("@xiaoshakongkefanxiu", DbType.Decimal,8),
					new SQLiteParameter("@beizhu", DbType.String,2147483647),
					new SQLiteParameter("@liuchengpiaobianhao", DbType.String,2147483647),
					new SQLiteParameter("@louqi", DbType.Decimal,8)};
			parameters[0].Value = model.jinqikoukepeng;
			parameters[1].Value = model.falanmianhuashang;
			parameters[2].Value = model.pensha;
			parameters[3].Value = model.kefanxipin;
			parameters[4].Value = model.kefanfamei;
			parameters[5].Value = model.xiaoshakongkefanxiu;
			parameters[6].Value = model.beizhu;
			parameters[7].Value = model.liuchengpiaobianhao;
			parameters[8].Value = model.louqi;

			int rows=SqliteHelper.ExecuteNonQuery(strSql.ToString(),parameters);
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
		public bool Update(WorkShopSystem.Model.JiJiaFanXiuDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update JiJiaFanXiuDetail set ");
			strSql.Append("jinqikoukepeng=@jinqikoukepeng,");
			strSql.Append("falanmianhuashang=@falanmianhuashang,");
			strSql.Append("pensha=@pensha,");
			strSql.Append("kefanxipin=@kefanxipin,");
			strSql.Append("kefanfamei=@kefanfamei,");
			strSql.Append("xiaoshakongkefanxiu=@xiaoshakongkefanxiu,");
			strSql.Append("beizhu=@beizhu,");
			strSql.Append("liuchengpiaobianhao=@liuchengpiaobianhao,");
			strSql.Append("louqi=@louqi");
			strSql.Append(" where ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@jinqikoukepeng", DbType.Decimal,8),
					new SQLiteParameter("@falanmianhuashang", DbType.Decimal,8),
					new SQLiteParameter("@pensha", DbType.Decimal,8),
					new SQLiteParameter("@kefanxipin", DbType.Decimal,8),
					new SQLiteParameter("@kefanfamei", DbType.Decimal,8),
					new SQLiteParameter("@xiaoshakongkefanxiu", DbType.Decimal,8),
					new SQLiteParameter("@beizhu", DbType.String,2147483647),
					new SQLiteParameter("@liuchengpiaobianhao", DbType.String,2147483647),
					new SQLiteParameter("@louqi", DbType.Decimal,8)};
			parameters[0].Value = model.jinqikoukepeng;
			parameters[1].Value = model.falanmianhuashang;
			parameters[2].Value = model.pensha;
			parameters[3].Value = model.kefanxipin;
			parameters[4].Value = model.kefanfamei;
			parameters[5].Value = model.xiaoshakongkefanxiu;
			parameters[6].Value = model.beizhu;
			parameters[7].Value = model.liuchengpiaobianhao;
			parameters[8].Value = model.louqi;

			int rows=SqliteHelper.ExecuteNonQuery(strSql.ToString(),parameters);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from JiJiaFanXiuDetail ");
			strSql.Append(" where ");
			SQLiteParameter[] parameters = {
			};

			int rows=SqliteHelper.ExecuteNonQuery(strSql.ToString(),parameters);
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
		public WorkShopSystem.Model.JiJiaFanXiuDetail GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select jinqikoukepeng,falanmianhuashang,pensha,kefanxipin,kefanfamei,xiaoshakongkefanxiu,beizhu,liuchengpiaobianhao,louqi from JiJiaFanXiuDetail ");
			strSql.Append(" where ");
			SQLiteParameter[] parameters = {
			};

			WorkShopSystem.Model.JiJiaFanXiuDetail model=new WorkShopSystem.Model.JiJiaFanXiuDetail();
			DataTable dt=SqliteHelper.ExecuteDataTable(strSql.ToString(),parameters);
			if(dt.Rows.Count>0)
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
		public WorkShopSystem.Model.JiJiaFanXiuDetail DataRowToModel(DataRow row)
		{
			WorkShopSystem.Model.JiJiaFanXiuDetail model=new WorkShopSystem.Model.JiJiaFanXiuDetail();
			if (row != null)
			{
				if(row["jinqikoukepeng"]!=null && row["jinqikoukepeng"].ToString()!="")
				{
					model.jinqikoukepeng=decimal.Parse(row["jinqikoukepeng"].ToString());
				}
				if(row["falanmianhuashang"]!=null && row["falanmianhuashang"].ToString()!="")
				{
					model.falanmianhuashang=decimal.Parse(row["falanmianhuashang"].ToString());
				}
				if(row["pensha"]!=null && row["pensha"].ToString()!="")
				{
					model.pensha=decimal.Parse(row["pensha"].ToString());
				}
				if(row["kefanxipin"]!=null && row["kefanxipin"].ToString()!="")
				{
					model.kefanxipin=decimal.Parse(row["kefanxipin"].ToString());
				}
				if(row["kefanfamei"]!=null && row["kefanfamei"].ToString()!="")
				{
					model.kefanfamei=decimal.Parse(row["kefanfamei"].ToString());
				}
				if(row["xiaoshakongkefanxiu"]!=null && row["xiaoshakongkefanxiu"].ToString()!="")
				{
					model.xiaoshakongkefanxiu=decimal.Parse(row["xiaoshakongkefanxiu"].ToString());
				}
				if(row["beizhu"]!=null)
				{
					model.beizhu=row["beizhu"].ToString();
				}
				if(row["liuchengpiaobianhao"]!=null)
				{
					model.liuchengpiaobianhao=row["liuchengpiaobianhao"].ToString();
				}
				if(row["louqi"]!=null && row["louqi"].ToString()!="")
				{
					model.louqi=decimal.Parse(row["louqi"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select jinqikoukepeng,falanmianhuashang,pensha,kefanxipin,kefanfamei,xiaoshakongkefanxiu,beizhu,liuchengpiaobianhao,louqi ");
			strSql.Append(" FROM JiJiaFanXiuDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return SqliteHelper.ExecuteDataTable(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM JiJiaFanXiuDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj =SqliteHelper.ExecuteScalar(strSql.ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from JiJiaFanXiuDetail T ");
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
			parameters[0].Value = "JiJiaFanXiuDetail";
			parameters[1].Value = "";
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

