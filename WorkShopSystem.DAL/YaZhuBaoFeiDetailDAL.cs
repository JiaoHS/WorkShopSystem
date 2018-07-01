/**  版本信息模板在安装目录下，可自行修改。
* YaZhuBaoFeiDetail.cs
*
* 功 能： N/A
* 类 名： YaZhuBaoFeiDetail
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
	/// 数据访问类:YaZhuBaoFeiDetail
	/// </summary>
	public partial class YaZhuBaoFeiDetailDAL
    {
		public YaZhuBaoFeiDetailDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return SqliteHelper.GetMaxID("id", "YaZhuBaoFeiDetail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from YaZhuBaoFeiDetail");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

			return SqliteHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(WorkShopSystem.Model.YaZhuBaoFeiDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YaZhuBaoFeiDetail(");
			strSql.Append("tiaojipin,feijiagongaokeng,liewen,nainmo,lamo,qipi,youwufahei,cuoshang,shangzhouchengjushang,chongshang,bengliao,penghuashang,hmianhuashang,xiankawai,luodipin,shangzhouchengkongduanlie,jitan,lengliao,qita,chouyangshu,gonghao,liuchengpiaohao)");
			strSql.Append(" values (");
			strSql.Append("@tiaojipin,@feijiagongaokeng,@liewen,@nainmo,@lamo,@qipi,@youwufahei,@cuoshang,@shangzhouchengjushang,@chongshang,@bengliao,@penghuashang,@hmianhuashang,@xiankawai,@luodipin,@shangzhouchengkongduanlie,@jitan,@lengliao,@qita,@chouyangshu,@gonghao,@liuchengpiaohao)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tiaojipin", DbType.Decimal,8),
					new SQLiteParameter("@feijiagongaokeng", DbType.Decimal,8),
					new SQLiteParameter("@liewen", DbType.Decimal,8),
					new SQLiteParameter("@nainmo", DbType.Decimal,8),
					new SQLiteParameter("@lamo", DbType.Decimal,8),
					new SQLiteParameter("@qipi", DbType.Decimal,8),
					new SQLiteParameter("@youwufahei", DbType.Decimal,8),
					new SQLiteParameter("@cuoshang", DbType.Decimal,8),
					new SQLiteParameter("@shangzhouchengjushang", DbType.Decimal,8),
					new SQLiteParameter("@chongshang", DbType.Decimal,8),
					new SQLiteParameter("@bengliao", DbType.Decimal,8),
					new SQLiteParameter("@penghuashang", DbType.Decimal,8),
					new SQLiteParameter("@hmianhuashang", DbType.Decimal,8),
					new SQLiteParameter("@xiankawai", DbType.Decimal,8),
					new SQLiteParameter("@luodipin", DbType.Decimal,8),
					new SQLiteParameter("@shangzhouchengkongduanlie", DbType.Decimal,8),
					new SQLiteParameter("@jitan", DbType.Decimal,8),
					new SQLiteParameter("@lengliao", DbType.Decimal,8),
					new SQLiteParameter("@qita", DbType.Decimal,8),
					new SQLiteParameter("@chouyangshu", DbType.Decimal,8),
					new SQLiteParameter("@gonghao", DbType.String,2147483647),
					new SQLiteParameter("@liuchengpiaohao", DbType.String,2147483647)};
			parameters[0].Value = model.tiaojipin;
			parameters[1].Value = model.feijiagongaokeng;
			parameters[2].Value = model.liewen;
			parameters[3].Value = model.nainmo;
			parameters[4].Value = model.lamo;
			parameters[5].Value = model.qipi;
			parameters[6].Value = model.youwufahei;
			parameters[7].Value = model.cuoshang;
			parameters[8].Value = model.shangzhouchengjushang;
			parameters[9].Value = model.chongshang;
			parameters[10].Value = model.bengliao;
			parameters[11].Value = model.penghuashang;
			parameters[12].Value = model.hmianhuashang;
			parameters[13].Value = model.xiankawai;
			parameters[14].Value = model.luodipin;
			parameters[15].Value = model.shangzhouchengkongduanlie;
			parameters[16].Value = model.jitan;
			parameters[17].Value = model.lengliao;
			parameters[18].Value = model.qita;
			parameters[19].Value = model.chouyangshu;
			parameters[20].Value = model.gonghao;
			parameters[21].Value = model.liuchengpiaohao;

			object obj = SqliteHelper.ExecuteScalar(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(WorkShopSystem.Model.YaZhuBaoFeiDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YaZhuBaoFeiDetail set ");
			strSql.Append("tiaojipin=@tiaojipin,");
			strSql.Append("feijiagongaokeng=@feijiagongaokeng,");
			strSql.Append("liewen=@liewen,");
			strSql.Append("nainmo=@nainmo,");
			strSql.Append("lamo=@lamo,");
			strSql.Append("qipi=@qipi,");
			strSql.Append("youwufahei=@youwufahei,");
			strSql.Append("cuoshang=@cuoshang,");
			strSql.Append("shangzhouchengjushang=@shangzhouchengjushang,");
			strSql.Append("chongshang=@chongshang,");
			strSql.Append("bengliao=@bengliao,");
			strSql.Append("penghuashang=@penghuashang,");
			strSql.Append("hmianhuashang=@hmianhuashang,");
			strSql.Append("xiankawai=@xiankawai,");
			strSql.Append("luodipin=@luodipin,");
			strSql.Append("shangzhouchengkongduanlie=@shangzhouchengkongduanlie,");
			strSql.Append("jitan=@jitan,");
			strSql.Append("lengliao=@lengliao,");
			strSql.Append("qita=@qita,");
			strSql.Append("chouyangshu=@chouyangshu,");
			strSql.Append("gonghao=@gonghao,");
			strSql.Append("liuchengpiaohao=@liuchengpiaohao");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tiaojipin", DbType.Decimal,8),
					new SQLiteParameter("@feijiagongaokeng", DbType.Decimal,8),
					new SQLiteParameter("@liewen", DbType.Decimal,8),
					new SQLiteParameter("@nainmo", DbType.Decimal,8),
					new SQLiteParameter("@lamo", DbType.Decimal,8),
					new SQLiteParameter("@qipi", DbType.Decimal,8),
					new SQLiteParameter("@youwufahei", DbType.Decimal,8),
					new SQLiteParameter("@cuoshang", DbType.Decimal,8),
					new SQLiteParameter("@shangzhouchengjushang", DbType.Decimal,8),
					new SQLiteParameter("@chongshang", DbType.Decimal,8),
					new SQLiteParameter("@bengliao", DbType.Decimal,8),
					new SQLiteParameter("@penghuashang", DbType.Decimal,8),
					new SQLiteParameter("@hmianhuashang", DbType.Decimal,8),
					new SQLiteParameter("@xiankawai", DbType.Decimal,8),
					new SQLiteParameter("@luodipin", DbType.Decimal,8),
					new SQLiteParameter("@shangzhouchengkongduanlie", DbType.Decimal,8),
					new SQLiteParameter("@jitan", DbType.Decimal,8),
					new SQLiteParameter("@lengliao", DbType.Decimal,8),
					new SQLiteParameter("@qita", DbType.Decimal,8),
					new SQLiteParameter("@chouyangshu", DbType.Decimal,8),
					new SQLiteParameter("@gonghao", DbType.String,2147483647),
					new SQLiteParameter("@liuchengpiaohao", DbType.String,2147483647),
					new SQLiteParameter("@id", DbType.Int32,8)};
			parameters[0].Value = model.tiaojipin;
			parameters[1].Value = model.feijiagongaokeng;
			parameters[2].Value = model.liewen;
			parameters[3].Value = model.nainmo;
			parameters[4].Value = model.lamo;
			parameters[5].Value = model.qipi;
			parameters[6].Value = model.youwufahei;
			parameters[7].Value = model.cuoshang;
			parameters[8].Value = model.shangzhouchengjushang;
			parameters[9].Value = model.chongshang;
			parameters[10].Value = model.bengliao;
			parameters[11].Value = model.penghuashang;
			parameters[12].Value = model.hmianhuashang;
			parameters[13].Value = model.xiankawai;
			parameters[14].Value = model.luodipin;
			parameters[15].Value = model.shangzhouchengkongduanlie;
			parameters[16].Value = model.jitan;
			parameters[17].Value = model.lengliao;
			parameters[18].Value = model.qita;
			parameters[19].Value = model.chouyangshu;
			parameters[20].Value = model.gonghao;
			parameters[21].Value = model.liuchengpiaohao;
			parameters[22].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from YaZhuBaoFeiDetail ");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from YaZhuBaoFeiDetail ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=SqliteHelper.ExecuteNonQuery(strSql.ToString());
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
		public WorkShopSystem.Model.YaZhuBaoFeiDetail GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,tiaojipin,feijiagongaokeng,liewen,nainmo,lamo,qipi,youwufahei,cuoshang,shangzhouchengjushang,chongshang,bengliao,penghuashang,hmianhuashang,xiankawai,luodipin,shangzhouchengkongduanlie,jitan,lengliao,qita,chouyangshu,gonghao,liuchengpiaohao from YaZhuBaoFeiDetail ");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

			WorkShopSystem.Model.YaZhuBaoFeiDetail model=new WorkShopSystem.Model.YaZhuBaoFeiDetail();
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
		public WorkShopSystem.Model.YaZhuBaoFeiDetail DataRowToModel(DataRow row)
		{
			WorkShopSystem.Model.YaZhuBaoFeiDetail model=new WorkShopSystem.Model.YaZhuBaoFeiDetail();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["tiaojipin"]!=null && row["tiaojipin"].ToString()!="")
				{
					model.tiaojipin=decimal.Parse(row["tiaojipin"].ToString());
				}
				if(row["feijiagongaokeng"]!=null && row["feijiagongaokeng"].ToString()!="")
				{
					model.feijiagongaokeng=decimal.Parse(row["feijiagongaokeng"].ToString());
				}
				if(row["liewen"]!=null && row["liewen"].ToString()!="")
				{
					model.liewen=decimal.Parse(row["liewen"].ToString());
				}
				if(row["nainmo"]!=null && row["nainmo"].ToString()!="")
				{
					model.nainmo=decimal.Parse(row["nainmo"].ToString());
				}
				if(row["lamo"]!=null && row["lamo"].ToString()!="")
				{
					model.lamo=decimal.Parse(row["lamo"].ToString());
				}
				if(row["qipi"]!=null && row["qipi"].ToString()!="")
				{
					model.qipi=decimal.Parse(row["qipi"].ToString());
				}
				if(row["youwufahei"]!=null && row["youwufahei"].ToString()!="")
				{
					model.youwufahei=decimal.Parse(row["youwufahei"].ToString());
				}
				if(row["cuoshang"]!=null && row["cuoshang"].ToString()!="")
				{
					model.cuoshang=decimal.Parse(row["cuoshang"].ToString());
				}
				if(row["shangzhouchengjushang"]!=null && row["shangzhouchengjushang"].ToString()!="")
				{
					model.shangzhouchengjushang=decimal.Parse(row["shangzhouchengjushang"].ToString());
				}
				if(row["chongshang"]!=null && row["chongshang"].ToString()!="")
				{
					model.chongshang=decimal.Parse(row["chongshang"].ToString());
				}
				if(row["bengliao"]!=null && row["bengliao"].ToString()!="")
				{
					model.bengliao=decimal.Parse(row["bengliao"].ToString());
				}
				if(row["penghuashang"]!=null && row["penghuashang"].ToString()!="")
				{
					model.penghuashang=decimal.Parse(row["penghuashang"].ToString());
				}
				if(row["hmianhuashang"]!=null && row["hmianhuashang"].ToString()!="")
				{
					model.hmianhuashang=decimal.Parse(row["hmianhuashang"].ToString());
				}
				if(row["xiankawai"]!=null && row["xiankawai"].ToString()!="")
				{
					model.xiankawai=decimal.Parse(row["xiankawai"].ToString());
				}
				if(row["luodipin"]!=null && row["luodipin"].ToString()!="")
				{
					model.luodipin=decimal.Parse(row["luodipin"].ToString());
				}
				if(row["shangzhouchengkongduanlie"]!=null && row["shangzhouchengkongduanlie"].ToString()!="")
				{
					model.shangzhouchengkongduanlie=decimal.Parse(row["shangzhouchengkongduanlie"].ToString());
				}
				if(row["jitan"]!=null && row["jitan"].ToString()!="")
				{
					model.jitan=decimal.Parse(row["jitan"].ToString());
				}
				if(row["lengliao"]!=null && row["lengliao"].ToString()!="")
				{
					model.lengliao=decimal.Parse(row["lengliao"].ToString());
				}
				if(row["qita"]!=null && row["qita"].ToString()!="")
				{
					model.qita=decimal.Parse(row["qita"].ToString());
				}
				if(row["chouyangshu"]!=null && row["chouyangshu"].ToString()!="")
				{
					model.chouyangshu=decimal.Parse(row["chouyangshu"].ToString());
				}
				if(row["gonghao"]!=null)
				{
					model.gonghao=row["gonghao"].ToString();
				}
				if(row["liuchengpiaohao"]!=null)
				{
					model.liuchengpiaohao=row["liuchengpiaohao"].ToString();
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
			strSql.Append("select id,tiaojipin,feijiagongaokeng,liewen,nainmo,lamo,qipi,youwufahei,cuoshang,shangzhouchengjushang,chongshang,bengliao,penghuashang,hmianhuashang,xiankawai,luodipin,shangzhouchengkongduanlie,jitan,lengliao,qita,chouyangshu,gonghao,liuchengpiaohao ");
			strSql.Append(" FROM YaZhuBaoFeiDetail ");
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
			strSql.Append("select count(1) FROM YaZhuBaoFeiDetail ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from YaZhuBaoFeiDetail T ");
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
			parameters[0].Value = "YaZhuBaoFeiDetail";
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

