using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WorkShopSystem.Utility;

namespace WorkShopSystem.DAL
{
	/// <summary>
	/// 数据访问类:FanXiuDetail
	/// </summary>
	public partial class FanXiuDetailDAL
	{
		public FanXiuDetailDAL()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WorkShopSystem.Model.FanXiuDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FanXiuDetail(");
			strSql.Append("time,bengliao,fanpen,zhengxing,beizhu,jinqikoukepeng,falanmianhuashang,pensha,kefanxipin,kefanfamei,xiaoshakongkefanxiu,louqi,liuchengpiaobianhao)");
			strSql.Append(" values (");
			strSql.Append("@time,@bengliao,@fanpen,@zhengxing,@beizhu,@jinqikoukepeng,@falanmianhuashang,@pensha,@kefanxipin,@kefanfamei,@xiaoshakongkefanxiu,@louqi,@liuchengpiaobianhao)");
			SqlParameter[] parameters = {
					new SqlParameter("@time", SqlDbType.DateTime),
					new SqlParameter("@bengliao", SqlDbType.Decimal,17),
					new SqlParameter("@fanpen", SqlDbType.Decimal,17),
					new SqlParameter("@zhengxing", SqlDbType.Decimal,17),
					new SqlParameter("@beizhu", SqlDbType.NVarChar,50),
					new SqlParameter("@jinqikoukepeng", SqlDbType.Decimal,17),
					new SqlParameter("@falanmianhuashang", SqlDbType.Decimal,17),
					new SqlParameter("@pensha", SqlDbType.Decimal,17),
					new SqlParameter("@kefanxipin", SqlDbType.Decimal,17),
					new SqlParameter("@kefanfamei", SqlDbType.Decimal,17),
					new SqlParameter("@xiaoshakongkefanxiu", SqlDbType.Decimal,17),
					new SqlParameter("@louqi", SqlDbType.Decimal,17),
					new SqlParameter("@liuchengpiaobianhao", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.time;
			parameters[1].Value = model.bengliao;
			parameters[2].Value = model.fanpen;
			parameters[3].Value = model.zhengxing;
			parameters[4].Value = model.beizhu;
			parameters[5].Value = model.jinqikoukepeng;
			parameters[6].Value = model.falanmianhuashang;
			parameters[7].Value = model.pensha;
			parameters[8].Value = model.kefanxipin;
			parameters[9].Value = model.kefanfamei;
			parameters[10].Value = model.xiaoshakongkefanxiu;
			parameters[11].Value = model.louqi;
			parameters[12].Value = model.liuchengpiaobianhao;

			int rows=SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters);
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
		public bool Update(WorkShopSystem.Model.FanXiuDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FanXiuDetail set ");
			strSql.Append("time=@time,");
			strSql.Append("bengliao=@bengliao,");
			strSql.Append("fanpen=@fanpen,");
			strSql.Append("zhengxing=@zhengxing,");
			strSql.Append("beizhu=@beizhu,");
			strSql.Append("jinqikoukepeng=@jinqikoukepeng,");
			strSql.Append("falanmianhuashang=@falanmianhuashang,");
			strSql.Append("pensha=@pensha,");
			strSql.Append("kefanxipin=@kefanxipin,");
			strSql.Append("kefanfamei=@kefanfamei,");
			strSql.Append("xiaoshakongkefanxiu=@xiaoshakongkefanxiu,");
			strSql.Append("louqi=@louqi,");
			strSql.Append("liuchengpiaobianhao=@liuchengpiaobianhao");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@time", SqlDbType.DateTime),
					new SqlParameter("@bengliao", SqlDbType.Decimal,17),
					new SqlParameter("@fanpen", SqlDbType.Decimal,17),
					new SqlParameter("@zhengxing", SqlDbType.Decimal,17),
					new SqlParameter("@beizhu", SqlDbType.NVarChar,50),
					new SqlParameter("@jinqikoukepeng", SqlDbType.Decimal,17),
					new SqlParameter("@falanmianhuashang", SqlDbType.Decimal,17),
					new SqlParameter("@pensha", SqlDbType.Decimal,17),
					new SqlParameter("@kefanxipin", SqlDbType.Decimal,17),
					new SqlParameter("@kefanfamei", SqlDbType.Decimal,17),
					new SqlParameter("@xiaoshakongkefanxiu", SqlDbType.Decimal,17),
					new SqlParameter("@louqi", SqlDbType.Decimal,17),
					new SqlParameter("@liuchengpiaobianhao", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.time;
			parameters[1].Value = model.bengliao;
			parameters[2].Value = model.fanpen;
			parameters[3].Value = model.zhengxing;
			parameters[4].Value = model.beizhu;
			parameters[5].Value = model.jinqikoukepeng;
			parameters[6].Value = model.falanmianhuashang;
			parameters[7].Value = model.pensha;
			parameters[8].Value = model.kefanxipin;
			parameters[9].Value = model.kefanfamei;
			parameters[10].Value = model.xiaoshakongkefanxiu;
			parameters[11].Value = model.louqi;
			parameters[12].Value = model.liuchengpiaobianhao;

			int rows=SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters);
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
			strSql.Append("delete from FanXiuDetail ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			int rows=SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters);
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
		public WorkShopSystem.Model.FanXiuDetail GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 time,bengliao,fanpen,zhengxing,beizhu,jinqikoukepeng,falanmianhuashang,pensha,kefanxipin,kefanfamei,xiaoshakongkefanxiu,louqi,liuchengpiaobianhao from FanXiuDetail ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			WorkShopSystem.Model.FanXiuDetail model=new WorkShopSystem.Model.FanXiuDetail();
			DataTable dt=SqlHelper.ExecuteDataTable(strSql.ToString(),parameters);
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
		public WorkShopSystem.Model.FanXiuDetail DataRowToModel(DataRow row)
		{
			WorkShopSystem.Model.FanXiuDetail model=new WorkShopSystem.Model.FanXiuDetail();
			if (row != null)
			{
				if(row["time"]!=null && row["time"].ToString()!="")
				{
					model.time=DateTime.Parse(row["time"].ToString());
				}
				if(row["bengliao"]!=null && row["bengliao"].ToString()!="")
				{
					model.bengliao=decimal.Parse(row["bengliao"].ToString());
				}
				if(row["fanpen"]!=null && row["fanpen"].ToString()!="")
				{
					model.fanpen=decimal.Parse(row["fanpen"].ToString());
				}
				if(row["zhengxing"]!=null && row["zhengxing"].ToString()!="")
				{
					model.zhengxing=decimal.Parse(row["zhengxing"].ToString());
				}
				if(row["beizhu"]!=null)
				{
					model.beizhu=row["beizhu"].ToString();
				}
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
				if(row["louqi"]!=null && row["louqi"].ToString()!="")
				{
					model.louqi=decimal.Parse(row["louqi"].ToString());
				}
				if(row["liuchengpiaobianhao"]!=null)
				{
					model.liuchengpiaobianhao=row["liuchengpiaobianhao"].ToString();
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
			strSql.Append("select time,bengliao,fanpen,zhengxing,beizhu,jinqikoukepeng,falanmianhuashang,pensha,kefanxipin,kefanfamei,xiaoshakongkefanxiu,louqi,liuchengpiaobianhao ");
			strSql.Append(" FROM FanXiuDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return SqlHelper.ExecuteDataTable(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataTable GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" time,bengliao,fanpen,zhengxing,beizhu,jinqikoukepeng,falanmianhuashang,pensha,kefanxipin,kefanfamei,xiaoshakongkefanxiu,louqi,liuchengpiaobianhao ");
			strSql.Append(" FROM FanXiuDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.ExecuteDataTable(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		//public int GetRecordCount(string strWhere)
		//{
		//	StringBuilder strSql=new StringBuilder();
		//	strSql.Append("select count(1) FROM FanXiuDetail ");
		//	if(strWhere.Trim()!="")
		//	{
		//		strSql.Append(" where "+strWhere);
		//	}
		//	object obj = DbHelperSQL.GetSingle(strSql.ToString());
		//	if (obj == null)
		//	{
		//		return 0;
		//	}
		//	else
		//	{
		//		return Convert.ToInt32(obj);
		//	}
		//}
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
			strSql.Append(")AS Row, T.*  from FanXiuDetail T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return SqlHelper.ExecuteDataTable(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataTable GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "FanXiuDetail";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return SqlHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

