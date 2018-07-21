using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WorkShopSystem.Utility;

namespace WorkShopSystem.DAL
{
	/// <summary>
	/// 数据访问类:YaZhuQueXianDetail
	/// </summary>
	public partial class YaZhuQueXianDetailDAL
	{
		public YaZhuQueXianDetailDAL()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WorkShopSystem.Model.YaZhuQueXianDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YaZhuQueXianDetail(");
			strSql.Append("time,gaodiya,lamo,nianmo,kaweichaocha,liewen,guilie,lengliao,youwufahei,duanzhen,qipi,jushang,yadianshang,chongshang,bengqueliao,penghuashang,Hmianhuashang,xiankawai,luodipin,gubao,jitan,shuikouduan,aokeng,qita,cuoshang,cuodaohen,abbdashang,assqiexue,qupifengqita,type,liuchengpiaobianhao,chouyangshu,gonghao)");
			strSql.Append(" values (");
			strSql.Append("@time,@gaodiya,@lamo,@nianmo,@kaweichaocha,@liewen,@guilie,@lengliao,@youwufahei,@duanzhen,@qipi,@jushang,@yadianshang,@chongshang,@bengqueliao,@penghuashang,@Hmianhuashang,@xiankawai,@luodipin,@gubao,@jitan,@shuikouduan,@aokeng,@qita,@cuoshang,@cuodaohen,@abbdashang,@assqiexue,@qupifengqita,@type,@liuchengpiaobianhao,@chouyangshu,@gonghao)");
			SqlParameter[] parameters = {
					new SqlParameter("@time", SqlDbType.DateTime),
					new SqlParameter("@gaodiya", SqlDbType.Decimal,17),
					new SqlParameter("@lamo", SqlDbType.Decimal,17),
					new SqlParameter("@nianmo", SqlDbType.Decimal,17),
					new SqlParameter("@kaweichaocha", SqlDbType.Decimal,17),
					new SqlParameter("@liewen", SqlDbType.Decimal,17),
					new SqlParameter("@guilie", SqlDbType.Decimal,17),
					new SqlParameter("@lengliao", SqlDbType.Decimal,17),
					new SqlParameter("@youwufahei", SqlDbType.Decimal,17),
					new SqlParameter("@duanzhen", SqlDbType.Decimal,17),
					new SqlParameter("@qipi", SqlDbType.Decimal,17),
					new SqlParameter("@jushang", SqlDbType.Decimal,17),
					new SqlParameter("@yadianshang", SqlDbType.Decimal,17),
					new SqlParameter("@chongshang", SqlDbType.Decimal,17),
					new SqlParameter("@bengqueliao", SqlDbType.Decimal,17),
					new SqlParameter("@penghuashang", SqlDbType.Decimal,17),
					new SqlParameter("@Hmianhuashang", SqlDbType.Decimal,17),
					new SqlParameter("@xiankawai", SqlDbType.Decimal,17),
					new SqlParameter("@luodipin", SqlDbType.Decimal,17),
					new SqlParameter("@gubao", SqlDbType.Decimal,17),
					new SqlParameter("@jitan", SqlDbType.Decimal,17),
					new SqlParameter("@shuikouduan", SqlDbType.Decimal,17),
					new SqlParameter("@aokeng", SqlDbType.Decimal,17),
					new SqlParameter("@qita", SqlDbType.Decimal,17),
					new SqlParameter("@cuoshang", SqlDbType.Decimal,17),
					new SqlParameter("@cuodaohen", SqlDbType.Decimal,17),
					new SqlParameter("@abbdashang", SqlDbType.Decimal,17),
					new SqlParameter("@assqiexue", SqlDbType.NVarChar,30),
					new SqlParameter("@qupifengqita", SqlDbType.Decimal,17),
					new SqlParameter("@type", SqlDbType.Decimal,17),
					new SqlParameter("@liuchengpiaobianhao", SqlDbType.NVarChar,30),
					new SqlParameter("@chouyangshu", SqlDbType.Decimal,17),
					new SqlParameter("@gonghao", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.time;
			parameters[1].Value = model.gaodiya;
			parameters[2].Value = model.lamo;
			parameters[3].Value = model.nianmo;
			parameters[4].Value = model.kaweichaocha;
			parameters[5].Value = model.liewen;
			parameters[6].Value = model.guilie;
			parameters[7].Value = model.lengliao;
			parameters[8].Value = model.youwufahei;
			parameters[9].Value = model.duanzhen;
			parameters[10].Value = model.qipi;
			parameters[11].Value = model.jushang;
			parameters[12].Value = model.yadianshang;
			parameters[13].Value = model.chongshang;
			parameters[14].Value = model.bengqueliao;
			parameters[15].Value = model.penghuashang;
			parameters[16].Value = model.Hmianhuashang;
			parameters[17].Value = model.xiankawai;
			parameters[18].Value = model.luodipin;
			parameters[19].Value = model.gubao;
			parameters[20].Value = model.jitan;
			parameters[21].Value = model.shuikouduan;
			parameters[22].Value = model.aokeng;
			parameters[23].Value = model.qita;
			parameters[24].Value = model.cuoshang;
			parameters[25].Value = model.cuodaohen;
			parameters[26].Value = model.abbdashang;
			parameters[27].Value = model.assqiexue;
			parameters[28].Value = model.qupifengqita;
			parameters[29].Value = model.type;
			parameters[30].Value = model.liuchengpiaobianhao;
			parameters[31].Value = model.chouyangshu;
			parameters[32].Value = model.gonghao;

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
		public bool Update(WorkShopSystem.Model.YaZhuQueXianDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YaZhuQueXianDetail set ");
			strSql.Append("time=@time,");
			strSql.Append("gaodiya=@gaodiya,");
			strSql.Append("lamo=@lamo,");
			strSql.Append("nianmo=@nianmo,");
			strSql.Append("kaweichaocha=@kaweichaocha,");
			strSql.Append("liewen=@liewen,");
			strSql.Append("guilie=@guilie,");
			strSql.Append("lengliao=@lengliao,");
			strSql.Append("youwufahei=@youwufahei,");
			strSql.Append("duanzhen=@duanzhen,");
			strSql.Append("qipi=@qipi,");
			strSql.Append("jushang=@jushang,");
			strSql.Append("yadianshang=@yadianshang,");
			strSql.Append("chongshang=@chongshang,");
			strSql.Append("bengqueliao=@bengqueliao,");
			strSql.Append("penghuashang=@penghuashang,");
			strSql.Append("Hmianhuashang=@Hmianhuashang,");
			strSql.Append("xiankawai=@xiankawai,");
			strSql.Append("luodipin=@luodipin,");
			strSql.Append("gubao=@gubao,");
			strSql.Append("jitan=@jitan,");
			strSql.Append("shuikouduan=@shuikouduan,");
			strSql.Append("aokeng=@aokeng,");
			strSql.Append("qita=@qita,");
			strSql.Append("cuoshang=@cuoshang,");
			strSql.Append("cuodaohen=@cuodaohen,");
			strSql.Append("abbdashang=@abbdashang,");
			strSql.Append("assqiexue=@assqiexue,");
			strSql.Append("qupifengqita=@qupifengqita,");
			strSql.Append("type=@type,");
			strSql.Append("liuchengpiaobianhao=@liuchengpiaobianhao,");
			strSql.Append("chouyangshu=@chouyangshu,");
			strSql.Append("gonghao=@gonghao");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@time", SqlDbType.DateTime),
					new SqlParameter("@gaodiya", SqlDbType.Decimal,17),
					new SqlParameter("@lamo", SqlDbType.Decimal,17),
					new SqlParameter("@nianmo", SqlDbType.Decimal,17),
					new SqlParameter("@kaweichaocha", SqlDbType.Decimal,17),
					new SqlParameter("@liewen", SqlDbType.Decimal,17),
					new SqlParameter("@guilie", SqlDbType.Decimal,17),
					new SqlParameter("@lengliao", SqlDbType.Decimal,17),
					new SqlParameter("@youwufahei", SqlDbType.Decimal,17),
					new SqlParameter("@duanzhen", SqlDbType.Decimal,17),
					new SqlParameter("@qipi", SqlDbType.Decimal,17),
					new SqlParameter("@jushang", SqlDbType.Decimal,17),
					new SqlParameter("@yadianshang", SqlDbType.Decimal,17),
					new SqlParameter("@chongshang", SqlDbType.Decimal,17),
					new SqlParameter("@bengqueliao", SqlDbType.Decimal,17),
					new SqlParameter("@penghuashang", SqlDbType.Decimal,17),
					new SqlParameter("@Hmianhuashang", SqlDbType.Decimal,17),
					new SqlParameter("@xiankawai", SqlDbType.Decimal,17),
					new SqlParameter("@luodipin", SqlDbType.Decimal,17),
					new SqlParameter("@gubao", SqlDbType.Decimal,17),
					new SqlParameter("@jitan", SqlDbType.Decimal,17),
					new SqlParameter("@shuikouduan", SqlDbType.Decimal,17),
					new SqlParameter("@aokeng", SqlDbType.Decimal,17),
					new SqlParameter("@qita", SqlDbType.Decimal,17),
					new SqlParameter("@cuoshang", SqlDbType.Decimal,17),
					new SqlParameter("@cuodaohen", SqlDbType.Decimal,17),
					new SqlParameter("@abbdashang", SqlDbType.Decimal,17),
					new SqlParameter("@assqiexue", SqlDbType.NVarChar,30),
					new SqlParameter("@qupifengqita", SqlDbType.Decimal,17),
					new SqlParameter("@type", SqlDbType.Decimal,17),
					new SqlParameter("@liuchengpiaobianhao", SqlDbType.NVarChar,30),
					new SqlParameter("@chouyangshu", SqlDbType.Decimal,17),
					new SqlParameter("@gonghao", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.time;
			parameters[1].Value = model.gaodiya;
			parameters[2].Value = model.lamo;
			parameters[3].Value = model.nianmo;
			parameters[4].Value = model.kaweichaocha;
			parameters[5].Value = model.liewen;
			parameters[6].Value = model.guilie;
			parameters[7].Value = model.lengliao;
			parameters[8].Value = model.youwufahei;
			parameters[9].Value = model.duanzhen;
			parameters[10].Value = model.qipi;
			parameters[11].Value = model.jushang;
			parameters[12].Value = model.yadianshang;
			parameters[13].Value = model.chongshang;
			parameters[14].Value = model.bengqueliao;
			parameters[15].Value = model.penghuashang;
			parameters[16].Value = model.Hmianhuashang;
			parameters[17].Value = model.xiankawai;
			parameters[18].Value = model.luodipin;
			parameters[19].Value = model.gubao;
			parameters[20].Value = model.jitan;
			parameters[21].Value = model.shuikouduan;
			parameters[22].Value = model.aokeng;
			parameters[23].Value = model.qita;
			parameters[24].Value = model.cuoshang;
			parameters[25].Value = model.cuodaohen;
			parameters[26].Value = model.abbdashang;
			parameters[27].Value = model.assqiexue;
			parameters[28].Value = model.qupifengqita;
			parameters[29].Value = model.type;
			parameters[30].Value = model.liuchengpiaobianhao;
			parameters[31].Value = model.chouyangshu;
			parameters[32].Value = model.gonghao;

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
			strSql.Append("delete from YaZhuQueXianDetail ");
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
		public WorkShopSystem.Model.YaZhuQueXianDetail GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 time,gaodiya,lamo,nianmo,kaweichaocha,liewen,guilie,lengliao,youwufahei,duanzhen,qipi,jushang,yadianshang,chongshang,bengqueliao,penghuashang,Hmianhuashang,xiankawai,luodipin,gubao,jitan,shuikouduan,aokeng,qita,cuoshang,cuodaohen,abbdashang,assqiexue,qupifengqita,type,liuchengpiaobianhao,chouyangshu,gonghao from YaZhuQueXianDetail ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			WorkShopSystem.Model.YaZhuQueXianDetail model=new WorkShopSystem.Model.YaZhuQueXianDetail();
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
		public WorkShopSystem.Model.YaZhuQueXianDetail DataRowToModel(DataRow row)
		{
			WorkShopSystem.Model.YaZhuQueXianDetail model=new WorkShopSystem.Model.YaZhuQueXianDetail();
			if (row != null)
			{
				if(row["time"]!=null && row["time"].ToString()!="")
				{
					model.time=DateTime.Parse(row["time"].ToString());
				}
				if(row["gaodiya"]!=null && row["gaodiya"].ToString()!="")
				{
					model.gaodiya=decimal.Parse(row["gaodiya"].ToString());
				}
				if(row["lamo"]!=null && row["lamo"].ToString()!="")
				{
					model.lamo=decimal.Parse(row["lamo"].ToString());
				}
				if(row["nianmo"]!=null && row["nianmo"].ToString()!="")
				{
					model.nianmo=decimal.Parse(row["nianmo"].ToString());
				}
				if(row["kaweichaocha"]!=null && row["kaweichaocha"].ToString()!="")
				{
					model.kaweichaocha=decimal.Parse(row["kaweichaocha"].ToString());
				}
				if(row["liewen"]!=null && row["liewen"].ToString()!="")
				{
					model.liewen=decimal.Parse(row["liewen"].ToString());
				}
				if(row["guilie"]!=null && row["guilie"].ToString()!="")
				{
					model.guilie=decimal.Parse(row["guilie"].ToString());
				}
				if(row["lengliao"]!=null && row["lengliao"].ToString()!="")
				{
					model.lengliao=decimal.Parse(row["lengliao"].ToString());
				}
				if(row["youwufahei"]!=null && row["youwufahei"].ToString()!="")
				{
					model.youwufahei=decimal.Parse(row["youwufahei"].ToString());
				}
				if(row["duanzhen"]!=null && row["duanzhen"].ToString()!="")
				{
					model.duanzhen=decimal.Parse(row["duanzhen"].ToString());
				}
				if(row["qipi"]!=null && row["qipi"].ToString()!="")
				{
					model.qipi=decimal.Parse(row["qipi"].ToString());
				}
				if(row["jushang"]!=null && row["jushang"].ToString()!="")
				{
					model.jushang=decimal.Parse(row["jushang"].ToString());
				}
				if(row["yadianshang"]!=null && row["yadianshang"].ToString()!="")
				{
					model.yadianshang=decimal.Parse(row["yadianshang"].ToString());
				}
				if(row["chongshang"]!=null && row["chongshang"].ToString()!="")
				{
					model.chongshang=decimal.Parse(row["chongshang"].ToString());
				}
				if(row["bengqueliao"]!=null && row["bengqueliao"].ToString()!="")
				{
					model.bengqueliao=decimal.Parse(row["bengqueliao"].ToString());
				}
				if(row["penghuashang"]!=null && row["penghuashang"].ToString()!="")
				{
					model.penghuashang=decimal.Parse(row["penghuashang"].ToString());
				}
				if(row["Hmianhuashang"]!=null && row["Hmianhuashang"].ToString()!="")
				{
					model.Hmianhuashang=decimal.Parse(row["Hmianhuashang"].ToString());
				}
				if(row["xiankawai"]!=null && row["xiankawai"].ToString()!="")
				{
					model.xiankawai=decimal.Parse(row["xiankawai"].ToString());
				}
				if(row["luodipin"]!=null && row["luodipin"].ToString()!="")
				{
					model.luodipin=decimal.Parse(row["luodipin"].ToString());
				}
				if(row["gubao"]!=null && row["gubao"].ToString()!="")
				{
					model.gubao=decimal.Parse(row["gubao"].ToString());
				}
				if(row["jitan"]!=null && row["jitan"].ToString()!="")
				{
					model.jitan=decimal.Parse(row["jitan"].ToString());
				}
				if(row["shuikouduan"]!=null && row["shuikouduan"].ToString()!="")
				{
					model.shuikouduan=decimal.Parse(row["shuikouduan"].ToString());
				}
				if(row["aokeng"]!=null && row["aokeng"].ToString()!="")
				{
					model.aokeng=decimal.Parse(row["aokeng"].ToString());
				}
				if(row["qita"]!=null && row["qita"].ToString()!="")
				{
					model.qita=decimal.Parse(row["qita"].ToString());
				}
				if(row["cuoshang"]!=null && row["cuoshang"].ToString()!="")
				{
					model.cuoshang=decimal.Parse(row["cuoshang"].ToString());
				}
				if(row["cuodaohen"]!=null && row["cuodaohen"].ToString()!="")
				{
					model.cuodaohen=decimal.Parse(row["cuodaohen"].ToString());
				}
				if(row["abbdashang"]!=null && row["abbdashang"].ToString()!="")
				{
					model.abbdashang=decimal.Parse(row["abbdashang"].ToString());
				}
				if(row["assqiexue"]!=null)
				{
					model.assqiexue= decimal.Parse(row["assqiexue"].ToString());
                }
				if(row["qupifengqita"]!=null && row["qupifengqita"].ToString()!="")
				{
					model.qupifengqita=decimal.Parse(row["qupifengqita"].ToString());
				}
				if(row["type"]!=null && row["type"].ToString()!="")
				{
					model.type=decimal.Parse(row["type"].ToString());
				}
				if(row["liuchengpiaobianhao"]!=null)
				{
					model.liuchengpiaobianhao=row["liuchengpiaobianhao"].ToString();
				}
				if(row["chouyangshu"]!=null && row["chouyangshu"].ToString()!="")
				{
					model.chouyangshu=decimal.Parse(row["chouyangshu"].ToString());
				}
				if(row["gonghao"]!=null)
				{
					model.gonghao=row["gonghao"].ToString();
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
			strSql.Append("select time,gaodiya,lamo,nianmo,kaweichaocha,liewen,guilie,lengliao,youwufahei,duanzhen,qipi,jushang,yadianshang,chongshang,bengqueliao,penghuashang,Hmianhuashang,xiankawai,luodipin,gubao,jitan,shuikouduan,aokeng,qita,cuoshang,cuodaohen,abbdashang,assqiexue,qupifengqita,type,liuchengpiaobianhao,chouyangshu,gonghao ");
			strSql.Append(" FROM YaZhuQueXianDetail ");
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
			strSql.Append(" time,gaodiya,lamo,nianmo,kaweichaocha,liewen,guilie,lengliao,youwufahei,duanzhen,qipi,jushang,yadianshang,chongshang,bengqueliao,penghuashang,Hmianhuashang,xiankawai,luodipin,gubao,jitan,shuikouduan,aokeng,qita,cuoshang,cuodaohen,abbdashang,assqiexue,qupifengqita,type,liuchengpiaobianhao,chouyangshu,gonghao ");
			strSql.Append(" FROM YaZhuQueXianDetail ");
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
		//	strSql.Append("select count(1) FROM YaZhuQueXianDetail ");
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
			strSql.Append(")AS Row, T.*  from YaZhuQueXianDetail T ");
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
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
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
			parameters[0].Value = "YaZhuQueXianDetail";
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

