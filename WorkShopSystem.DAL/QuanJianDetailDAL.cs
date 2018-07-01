/**  版本信息模板在安装目录下，可自行修改。
* QuanJianDetail.cs
*
* 功 能： N/A
* 类 名： QuanJianDetail
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
    /// 数据访问类:QuanJianDetail
    /// </summary>
    public partial class QuanJianDetailDAL
    {
        public QuanJianDetailDAL()
        { }
        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(WorkShopSystem.Model.QuanJianDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into QuanJianDetail(");
            strSql.Append("cnctiaojipin,falanmianyashang,falanmianhuahenpengshang,hmianyashang,jinqikoukepeng,shangzhouchengkongkepeng,daowen,kongjingchaocha,shuiyin,zangwu,jiagongbuliang,shakong,liewen,bengque,feihua,feipeng,qipi,zazhi,nianmo,maopeifamei,yanghuafahei,luodi,qita,lamo,xiankawai,chouyangshu,gonghao,feijiagongmianaokeng,lvxue,type,liuchengpiaobianhao)");
            strSql.Append(" values (");
            strSql.Append("@cnctiaojipin,@falanmianyashang,@falanmianhuahenpengshang,@hmianyashang,@jinqikoukepeng,@shangzhouchengkongkepeng,@daowen,@kongjingchaocha,@shuiyin,@zangwu,@jiagongbuliang,@shakong,@liewen,@bengque,@feihua,@feipeng,@qipi,@zazhi,@nianmo,@maopeifamei,@yanghuafahei,@luodi,@qita,@lamo,@xiankawai,@chouyangshu,@gonghao,@feijiagongmianaokeng,@lvxue,@type,@liuchengpiaobianhao)");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@cnctiaojipin", DbType.Decimal,8),
                    new SQLiteParameter("@falanmianyashang", DbType.Decimal,8),
                    new SQLiteParameter("@falanmianhuahenpengshang", DbType.Decimal,8),
                    new SQLiteParameter("@hmianyashang", DbType.Decimal,8),
                    new SQLiteParameter("@jinqikoukepeng", DbType.Decimal,8),
                    new SQLiteParameter("@shangzhouchengkongkepeng", DbType.Decimal,8),
                    new SQLiteParameter("@daowen", DbType.Decimal,8),
                    new SQLiteParameter("@kongjingchaocha", DbType.Decimal,8),
                    new SQLiteParameter("@shuiyin", DbType.Decimal,8),
                    new SQLiteParameter("@zangwu", DbType.Decimal,8),
                    new SQLiteParameter("@jiagongbuliang", DbType.Decimal,8),
                    new SQLiteParameter("@shakong", DbType.Decimal,8),
                    new SQLiteParameter("@liewen", DbType.Decimal,8),
                    new SQLiteParameter("@bengque", DbType.Decimal,8),
                    new SQLiteParameter("@feihua", DbType.Decimal,8),
                    new SQLiteParameter("@feipeng", DbType.Decimal,8),
                    new SQLiteParameter("@qipi", DbType.Decimal,8),
                    new SQLiteParameter("@zazhi", DbType.Decimal,8),
                    new SQLiteParameter("@nianmo", DbType.Decimal,8),
                    new SQLiteParameter("@maopeifamei", DbType.Decimal,8),
                    new SQLiteParameter("@yanghuafahei", DbType.Decimal,8),
                    new SQLiteParameter("@luodi", DbType.Decimal,8),
                    new SQLiteParameter("@qita", DbType.Decimal,8),
                    new SQLiteParameter("@lamo", DbType.Decimal,8),
                    new SQLiteParameter("@xiankawai", DbType.Decimal,8),
                    new SQLiteParameter("@chouyangshu", DbType.Decimal,8),
                    new SQLiteParameter("@gonghao", DbType.String,2147483647),
                    new SQLiteParameter("@feijiagongmianaokeng", DbType.Decimal,8),
                    new SQLiteParameter("@lvxue", DbType.Decimal,8),
                    new SQLiteParameter("@type", DbType.Int32,4),
                    new SQLiteParameter("@liuchengpiaobianhao",DbType.String,2147483647)};
            parameters[0].Value = model.cnctiaojipin;
            parameters[1].Value = model.falanmianyashang;
            parameters[2].Value = model.falanmianhuahenpengshang;
            parameters[3].Value = model.hmianyashang;
            parameters[4].Value = model.jinqikoukepeng;
            parameters[5].Value = model.shangzhouchengkongkepeng;
            parameters[6].Value = model.daowen;
            parameters[7].Value = model.kongjingchaocha;
            parameters[8].Value = model.shuiyin;
            parameters[9].Value = model.zangwu;
            parameters[10].Value = model.jiagongbuliang;
            parameters[11].Value = model.shakong;
            parameters[12].Value = model.liewen;
            parameters[13].Value = model.bengque;
            parameters[14].Value = model.feihua;
            parameters[15].Value = model.feipeng;
            parameters[16].Value = model.qipi;
            parameters[17].Value = model.zazhi;
            parameters[18].Value = model.nianmo;
            parameters[19].Value = model.maopeifamei;
            parameters[20].Value = model.yanghuafahei;
            parameters[21].Value = model.luodi;
            parameters[22].Value = model.qita;
            parameters[23].Value = model.lamo;
            parameters[24].Value = model.xiankawai;
            parameters[25].Value = model.chouyangshu;
            parameters[26].Value = model.gonghao;
            parameters[27].Value = model.feijiagongmianaokeng;
            parameters[28].Value = model.lvxue;
            parameters[29].Value = model.type;
            parameters[30].Value = model.liuchengpiaobianhao;

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
        public bool Update(WorkShopSystem.Model.QuanJianDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update QuanJianDetail set ");
            strSql.Append("cnctiaojipin=@cnctiaojipin,");
            strSql.Append("falanmianyashang=@falanmianyashang,");
            strSql.Append("falanmianhuahenpengshang=@falanmianhuahenpengshang,");
            strSql.Append("hmianyashang=@hmianyashang,");
            strSql.Append("jinqikoukepeng=@jinqikoukepeng,");
            strSql.Append("shangzhouchengkongkepeng=@shangzhouchengkongkepeng,");
            strSql.Append("daowen=@daowen,");
            strSql.Append("kongjingchaocha=@kongjingchaocha,");
            strSql.Append("shuiyin=@shuiyin,");
            strSql.Append("zangwu=@zangwu,");
            strSql.Append("jiagongbuliang=@jiagongbuliang,");
            strSql.Append("shakong=@shakong,");
            strSql.Append("liewen=@liewen,");
            strSql.Append("bengque=@bengque,");
            strSql.Append("feihua=@feihua,");
            strSql.Append("feipeng=@feipeng,");
            strSql.Append("qipi=@qipi,");
            strSql.Append("zazhi=@zazhi,");
            strSql.Append("nianmo=@nianmo,");
            strSql.Append("maopeifamei=@maopeifamei,");
            strSql.Append("yanghuafahei=@yanghuafahei,");
            strSql.Append("luodi=@luodi,");
            strSql.Append("qita=@qita,");
            strSql.Append("lamo=@lamo,");
            strSql.Append("xiankawai=@xiankawai,");
            strSql.Append("chouyangshu=@chouyangshu,");
            strSql.Append("gonghao=@gonghao,");
            strSql.Append("feijiagongmianaokeng=@feijiagongmianaokeng,");
            strSql.Append("lvxue=@lvxue,");
            strSql.Append("type=@type,");
            strSql.Append("liuchengpiaobianhao=@liuchengpiaobianhao");
            strSql.Append(" where ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@cnctiaojipin", DbType.Decimal,8),
                    new SQLiteParameter("@falanmianyashang", DbType.Decimal,8),
                    new SQLiteParameter("@falanmianhuahenpengshang", DbType.Decimal,8),
                    new SQLiteParameter("@hmianyashang", DbType.Decimal,8),
                    new SQLiteParameter("@jinqikoukepeng", DbType.Decimal,8),
                    new SQLiteParameter("@shangzhouchengkongkepeng", DbType.Decimal,8),
                    new SQLiteParameter("@daowen", DbType.Decimal,8),
                    new SQLiteParameter("@kongjingchaocha", DbType.Decimal,8),
                    new SQLiteParameter("@shuiyin", DbType.Decimal,8),
                    new SQLiteParameter("@zangwu", DbType.Decimal,8),
                    new SQLiteParameter("@jiagongbuliang", DbType.Decimal,8),
                    new SQLiteParameter("@shakong", DbType.Decimal,8),
                    new SQLiteParameter("@liewen", DbType.Decimal,8),
                    new SQLiteParameter("@bengque", DbType.Decimal,8),
                    new SQLiteParameter("@feihua", DbType.Decimal,8),
                    new SQLiteParameter("@feipeng", DbType.Decimal,8),
                    new SQLiteParameter("@qipi", DbType.Decimal,8),
                    new SQLiteParameter("@zazhi", DbType.Decimal,8),
                    new SQLiteParameter("@nianmo", DbType.Decimal,8),
                    new SQLiteParameter("@maopeifamei", DbType.Decimal,8),
                    new SQLiteParameter("@yanghuafahei", DbType.Decimal,8),
                    new SQLiteParameter("@luodi", DbType.Decimal,8),
                    new SQLiteParameter("@qita", DbType.Decimal,8),
                    new SQLiteParameter("@lamo", DbType.Decimal,8),
                    new SQLiteParameter("@xiankawai", DbType.Decimal,8),
                    new SQLiteParameter("@chouyangshu", DbType.Decimal,8),
                    new SQLiteParameter("@gonghao", DbType.String,2147483647),
                    new SQLiteParameter("@feijiagongmianaokeng", DbType.Decimal,8),
                    new SQLiteParameter("@lvxue", DbType.Decimal,8),
                    new SQLiteParameter("@type", DbType.Int32,4),
                    new SQLiteParameter("@liuchengpiaobianhao", DbType.String,2147483647)};
            parameters[0].Value = model.cnctiaojipin;
            parameters[1].Value = model.falanmianyashang;
            parameters[2].Value = model.falanmianhuahenpengshang;
            parameters[3].Value = model.hmianyashang;
            parameters[4].Value = model.jinqikoukepeng;
            parameters[5].Value = model.shangzhouchengkongkepeng;
            parameters[6].Value = model.daowen;
            parameters[7].Value = model.kongjingchaocha;
            parameters[8].Value = model.shuiyin;
            parameters[9].Value = model.zangwu;
            parameters[10].Value = model.jiagongbuliang;
            parameters[11].Value = model.shakong;
            parameters[12].Value = model.liewen;
            parameters[13].Value = model.bengque;
            parameters[14].Value = model.feihua;
            parameters[15].Value = model.feipeng;
            parameters[16].Value = model.qipi;
            parameters[17].Value = model.zazhi;
            parameters[18].Value = model.nianmo;
            parameters[19].Value = model.maopeifamei;
            parameters[20].Value = model.yanghuafahei;
            parameters[21].Value = model.luodi;
            parameters[22].Value = model.qita;
            parameters[23].Value = model.lamo;
            parameters[24].Value = model.xiankawai;
            parameters[25].Value = model.chouyangshu;
            parameters[26].Value = model.gonghao;
            parameters[27].Value = model.feijiagongmianaokeng;
            parameters[28].Value = model.lvxue;
            parameters[29].Value = model.type;
            parameters[30].Value = model.liuchengpiaobianhao;

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
            strSql.Append("delete from QuanJianDetail ");
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
        public WorkShopSystem.Model.QuanJianDetail GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select cnctiaojipin,falanmianyashang,falanmianhuahenpengshang,hmianyashang,jinqikoukepeng,shangzhouchengkongkepeng,daowen,kongjingchaocha,shuiyin,zangwu,jiagongbuliang,shakong,liewen,bengque,feihua,feipeng,qipi,zazhi,nianmo,maopeifamei,yanghuafahei,luodi,qita,lamo,xiankawai,chouyangshu,gonghao,feijiagongmianaokeng,lvxue,type,liuchengpiaobianhao from QuanJianDetail ");
            strSql.Append(" where ");
            SQLiteParameter[] parameters = {
            };

            WorkShopSystem.Model.QuanJianDetail model = new WorkShopSystem.Model.QuanJianDetail();
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
        public WorkShopSystem.Model.QuanJianDetail DataRowToModel(DataRow row)
        {
            WorkShopSystem.Model.QuanJianDetail model = new WorkShopSystem.Model.QuanJianDetail();
            if (row != null)
            {
                if (row["cnctiaojipin"] != null && row["cnctiaojipin"].ToString() != "")
                {
                    model.cnctiaojipin = decimal.Parse(row["cnctiaojipin"].ToString());
                }
                if (row["falanmianyashang"] != null && row["falanmianyashang"].ToString() != "")
                {
                    model.falanmianyashang = decimal.Parse(row["falanmianyashang"].ToString());
                }
                if (row["falanmianhuahenpengshang"] != null && row["falanmianhuahenpengshang"].ToString() != "")
                {
                    model.falanmianhuahenpengshang = decimal.Parse(row["falanmianhuahenpengshang"].ToString());
                }
                if (row["hmianyashang"] != null && row["hmianyashang"].ToString() != "")
                {
                    model.hmianyashang = decimal.Parse(row["hmianyashang"].ToString());
                }
                if (row["jinqikoukepeng"] != null && row["jinqikoukepeng"].ToString() != "")
                {
                    model.jinqikoukepeng = decimal.Parse(row["jinqikoukepeng"].ToString());
                }
                if (row["shangzhouchengkongkepeng"] != null && row["shangzhouchengkongkepeng"].ToString() != "")
                {
                    model.shangzhouchengkongkepeng = decimal.Parse(row["shangzhouchengkongkepeng"].ToString());
                }
                if (row["daowen"] != null && row["daowen"].ToString() != "")
                {
                    model.daowen = decimal.Parse(row["daowen"].ToString());
                }
                if (row["kongjingchaocha"] != null && row["kongjingchaocha"].ToString() != "")
                {
                    model.kongjingchaocha = decimal.Parse(row["kongjingchaocha"].ToString());
                }
                if (row["shuiyin"] != null && row["shuiyin"].ToString() != "")
                {
                    model.shuiyin = decimal.Parse(row["shuiyin"].ToString());
                }
                if (row["zangwu"] != null && row["zangwu"].ToString() != "")
                {
                    model.zangwu = decimal.Parse(row["zangwu"].ToString());
                }
                if (row["jiagongbuliang"] != null && row["jiagongbuliang"].ToString() != "")
                {
                    model.jiagongbuliang = decimal.Parse(row["jiagongbuliang"].ToString());
                }
                if (row["shakong"] != null && row["shakong"].ToString() != "")
                {
                    model.shakong = decimal.Parse(row["shakong"].ToString());
                }
                if (row["liewen"] != null && row["liewen"].ToString() != "")
                {
                    model.liewen = decimal.Parse(row["liewen"].ToString());
                }
                if (row["bengque"] != null && row["bengque"].ToString() != "")
                {
                    model.bengque = decimal.Parse(row["bengque"].ToString());
                }
                if (row["feihua"] != null && row["feihua"].ToString() != "")
                {
                    model.feihua = decimal.Parse(row["feihua"].ToString());
                }
                if (row["feipeng"] != null && row["feipeng"].ToString() != "")
                {
                    model.feipeng = decimal.Parse(row["feipeng"].ToString());
                }
                if (row["qipi"] != null && row["qipi"].ToString() != "")
                {
                    model.qipi = decimal.Parse(row["qipi"].ToString());
                }
                if (row["zazhi"] != null && row["zazhi"].ToString() != "")
                {
                    model.zazhi = decimal.Parse(row["zazhi"].ToString());
                }
                if (row["nianmo"] != null && row["nianmo"].ToString() != "")
                {
                    model.nianmo = decimal.Parse(row["nianmo"].ToString());
                }
                if (row["maopeifamei"] != null && row["maopeifamei"].ToString() != "")
                {
                    model.maopeifamei = decimal.Parse(row["maopeifamei"].ToString());
                }
                if (row["yanghuafahei"] != null && row["yanghuafahei"].ToString() != "")
                {
                    model.yanghuafahei = decimal.Parse(row["yanghuafahei"].ToString());
                }
                if (row["luodi"] != null && row["luodi"].ToString() != "")
                {
                    model.luodi = decimal.Parse(row["luodi"].ToString());
                }
                if (row["qita"] != null && row["qita"].ToString() != "")
                {
                    model.qita = decimal.Parse(row["qita"].ToString());
                }
                if (row["lamo"] != null && row["lamo"].ToString() != "")
                {
                    model.lamo = decimal.Parse(row["lamo"].ToString());
                }
                if (row["xiankawai"] != null && row["xiankawai"].ToString() != "")
                {
                    model.xiankawai = decimal.Parse(row["xiankawai"].ToString());
                }
                if (row["chouyangshu"] != null && row["chouyangshu"].ToString() != "")
                {
                    model.chouyangshu = decimal.Parse(row["chouyangshu"].ToString());
                }
                if (row["gonghao"] != null)
                {
                    model.gonghao = row["gonghao"].ToString();
                }
                if (row["feijiagongmianaokeng"] != null && row["feijiagongmianaokeng"].ToString() != "")
                {
                    model.feijiagongmianaokeng = decimal.Parse(row["feijiagongmianaokeng"].ToString());
                }
                if (row["lvxue"] != null && row["lvxue"].ToString() != "")
                {
                    model.lvxue = decimal.Parse(row["lvxue"].ToString());
                }
                if (row["type"] != null && row["type"].ToString() != "")
                {
                    model.type = int.Parse(row["type"].ToString());
                }
                if (row["liuchengpiaobianhao"] != null && row["liuchengpiaobianhao"].ToString() != "")
                {
                    model.liuchengpiaobianhao = row["liuchengpiaobianhao"].ToString();
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
            strSql.Append("select cnctiaojipin,falanmianyashang,falanmianhuahenpengshang,hmianyashang,jinqikoukepeng,shangzhouchengkongkepeng,daowen,kongjingchaocha,shuiyin,zangwu,jiagongbuliang,shakong,liewen,bengque,feihua,feipeng,qipi,zazhi,nianmo,maopeifamei,yanghuafahei,luodi,qita,lamo,xiankawai,chouyangshu,gonghao,feijiagongmianaokeng,lvxue,type,liuchengpiaobianhao ");
            strSql.Append(" FROM QuanJianDetail ");
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
            strSql.Append("select count(1) FROM QuanJianDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T. desc");
            }
            strSql.Append(")AS Row, T.*  from QuanJianDetail T ");
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
			parameters[0].Value = "QuanJianDetail";
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

