using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WorkShopSystem.Utility;

namespace WorkShopSystem.DAL
{
    /// <summary>
    /// 数据访问类:JiJiaQueXianDetail
    /// </summary>
    public partial class JiJiaQueXianDetailDAL
    {
        public JiJiaQueXianDetailDAL()
        { }
        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(WorkShopSystem.Model.JiJiaQueXianDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into JiJiaQueXianDetail(");
            strSql.Append("time,cnctiaojipin,falanmianyashang,falanmianhuahenpengshang,hmianyashang,jinqikoukepeng,shangzhouchengkongkepeng,daowen,kongjingchaocha,shuiyin,zangwu,jiagongbuliang,shakong,liewen,bengque,feihua,feipeng,qipi,zazhi,nianmo,maopeifamei,yanghuafahei,luodi,qita,lamo,xiankawai,chouyangshu,gonghao,feijiagongmianaokeng,lvxue,type,liuchengpiaobianhao)");
            strSql.Append(" values (");
            strSql.Append("@time,@cnctiaojipin,@falanmianyashang,@falanmianhuahenpengshang,@hmianyashang,@jinqikoukepeng,@shangzhouchengkongkepeng,@daowen,@kongjingchaocha,@shuiyin,@zangwu,@jiagongbuliang,@shakong,@liewen,@bengque,@feihua,@feipeng,@qipi,@zazhi,@nianmo,@maopeifamei,@yanghuafahei,@luodi,@qita,@lamo,@xiankawai,@chouyangshu,@gonghao,@feijiagongmianaokeng,@lvxue,@type,@liuchengpiaobianhao)");
            SqlParameter[] parameters = {
                    new SqlParameter("@time", SqlDbType.DateTime),
                    new SqlParameter("@cnctiaojipin", SqlDbType.Decimal,17),
                    new SqlParameter("@falanmianyashang", SqlDbType.Decimal,17),
                    new SqlParameter("@falanmianhuahenpengshang", SqlDbType.Decimal,17),
                    new SqlParameter("@hmianyashang", SqlDbType.Decimal,17),
                    new SqlParameter("@jinqikoukepeng", SqlDbType.Decimal,17),
                    new SqlParameter("@shangzhouchengkongkepeng", SqlDbType.Decimal,17),
                    new SqlParameter("@daowen", SqlDbType.Decimal,17),
                    new SqlParameter("@kongjingchaocha", SqlDbType.Decimal,17),
                    new SqlParameter("@shuiyin", SqlDbType.Decimal,17),
                    new SqlParameter("@zangwu", SqlDbType.Decimal,17),
                    new SqlParameter("@jiagongbuliang", SqlDbType.Decimal,17),
                    new SqlParameter("@shakong", SqlDbType.Decimal,17),
                    new SqlParameter("@liewen", SqlDbType.Decimal,17),
                    new SqlParameter("@bengque", SqlDbType.Decimal,17),
                    new SqlParameter("@feihua", SqlDbType.Decimal,17),
                    new SqlParameter("@feipeng", SqlDbType.Decimal,17),
                    new SqlParameter("@qipi", SqlDbType.Decimal,17),
                    new SqlParameter("@zazhi", SqlDbType.Decimal,17),
                    new SqlParameter("@nianmo", SqlDbType.Decimal,17),
                    new SqlParameter("@maopeifamei", SqlDbType.Decimal,17),
                    new SqlParameter("@yanghuafahei", SqlDbType.Decimal,17),
                    new SqlParameter("@luodi", SqlDbType.Decimal,17),
                    new SqlParameter("@qita", SqlDbType.Decimal,17),
                    new SqlParameter("@lamo", SqlDbType.Decimal,17),
                    new SqlParameter("@xiankawai", SqlDbType.Decimal,17),
                    new SqlParameter("@chouyangshu", SqlDbType.Decimal,17),
                    new SqlParameter("@gonghao", SqlDbType.NVarChar,30),
                    new SqlParameter("@feijiagongmianaokeng", SqlDbType.Decimal,17),
                    new SqlParameter("@lvxue", SqlDbType.Decimal,17),
                    new SqlParameter("@type", SqlDbType.Decimal,17),
                    new SqlParameter("@liuchengpiaobianhao", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.time;
            parameters[1].Value = model.cnctiaojipin;
            parameters[2].Value = model.falanmianyashang;
            parameters[3].Value = model.falanmianhuahenpengshang;
            parameters[4].Value = model.hmianyashang;
            parameters[5].Value = model.jinqikoukepeng;
            parameters[6].Value = model.shangzhouchengkongkepeng;
            parameters[7].Value = model.daowen;
            parameters[8].Value = model.kongjingchaocha;
            parameters[9].Value = model.shuiyin;
            parameters[10].Value = model.zangwu;
            parameters[11].Value = model.jiagongbuliang;
            parameters[12].Value = model.shakong;
            parameters[13].Value = model.liewen;
            parameters[14].Value = model.bengque;
            parameters[15].Value = model.feihua;
            parameters[16].Value = model.feipeng;
            parameters[17].Value = model.qipi;
            parameters[18].Value = model.zazhi;
            parameters[19].Value = model.nianmo;
            parameters[20].Value = model.maopeifamei;
            parameters[21].Value = model.yanghuafahei;
            parameters[22].Value = model.luodi;
            parameters[23].Value = model.qita;
            parameters[24].Value = model.lamo;
            parameters[25].Value = model.xiankawai;
            parameters[26].Value = model.chouyangshu;
            parameters[27].Value = model.gonghao;
            parameters[28].Value = model.feijiagongmianaokeng;
            parameters[29].Value = model.lvxue;
            parameters[30].Value = model.type;
            parameters[31].Value = model.liuchengpiaobianhao;

            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
        public bool Update(WorkShopSystem.Model.JiJiaQueXianDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update JiJiaQueXianDetail set ");
            strSql.Append("time=@time,");
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
            SqlParameter[] parameters = {
                    new SqlParameter("@time", SqlDbType.DateTime),
                    new SqlParameter("@cnctiaojipin", SqlDbType.Decimal,17),
                    new SqlParameter("@falanmianyashang", SqlDbType.Decimal,17),
                    new SqlParameter("@falanmianhuahenpengshang", SqlDbType.Decimal,17),
                    new SqlParameter("@hmianyashang", SqlDbType.Decimal,17),
                    new SqlParameter("@jinqikoukepeng", SqlDbType.Decimal,17),
                    new SqlParameter("@shangzhouchengkongkepeng", SqlDbType.Decimal,17),
                    new SqlParameter("@daowen", SqlDbType.Decimal,17),
                    new SqlParameter("@kongjingchaocha", SqlDbType.Decimal,17),
                    new SqlParameter("@shuiyin", SqlDbType.Decimal,17),
                    new SqlParameter("@zangwu", SqlDbType.Decimal,17),
                    new SqlParameter("@jiagongbuliang", SqlDbType.Decimal,17),
                    new SqlParameter("@shakong", SqlDbType.Decimal,17),
                    new SqlParameter("@liewen", SqlDbType.Decimal,17),
                    new SqlParameter("@bengque", SqlDbType.Decimal,17),
                    new SqlParameter("@feihua", SqlDbType.Decimal,17),
                    new SqlParameter("@feipeng", SqlDbType.Decimal,17),
                    new SqlParameter("@qipi", SqlDbType.Decimal,17),
                    new SqlParameter("@zazhi", SqlDbType.Decimal,17),
                    new SqlParameter("@nianmo", SqlDbType.Decimal,17),
                    new SqlParameter("@maopeifamei", SqlDbType.Decimal,17),
                    new SqlParameter("@yanghuafahei", SqlDbType.Decimal,17),
                    new SqlParameter("@luodi", SqlDbType.Decimal,17),
                    new SqlParameter("@qita", SqlDbType.Decimal,17),
                    new SqlParameter("@lamo", SqlDbType.Decimal,17),
                    new SqlParameter("@xiankawai", SqlDbType.Decimal,17),
                    new SqlParameter("@chouyangshu", SqlDbType.Decimal,17),
                    new SqlParameter("@gonghao", SqlDbType.NVarChar,30),
                    new SqlParameter("@feijiagongmianaokeng", SqlDbType.Decimal,17),
                    new SqlParameter("@lvxue", SqlDbType.Decimal,17),
                    new SqlParameter("@type", SqlDbType.Decimal,17),
                    new SqlParameter("@liuchengpiaobianhao", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.time;
            parameters[1].Value = model.cnctiaojipin;
            parameters[2].Value = model.falanmianyashang;
            parameters[3].Value = model.falanmianhuahenpengshang;
            parameters[4].Value = model.hmianyashang;
            parameters[5].Value = model.jinqikoukepeng;
            parameters[6].Value = model.shangzhouchengkongkepeng;
            parameters[7].Value = model.daowen;
            parameters[8].Value = model.kongjingchaocha;
            parameters[9].Value = model.shuiyin;
            parameters[10].Value = model.zangwu;
            parameters[11].Value = model.jiagongbuliang;
            parameters[12].Value = model.shakong;
            parameters[13].Value = model.liewen;
            parameters[14].Value = model.bengque;
            parameters[15].Value = model.feihua;
            parameters[16].Value = model.feipeng;
            parameters[17].Value = model.qipi;
            parameters[18].Value = model.zazhi;
            parameters[19].Value = model.nianmo;
            parameters[20].Value = model.maopeifamei;
            parameters[21].Value = model.yanghuafahei;
            parameters[22].Value = model.luodi;
            parameters[23].Value = model.qita;
            parameters[24].Value = model.lamo;
            parameters[25].Value = model.xiankawai;
            parameters[26].Value = model.chouyangshu;
            parameters[27].Value = model.gonghao;
            parameters[28].Value = model.feijiagongmianaokeng;
            parameters[29].Value = model.lvxue;
            parameters[30].Value = model.type;
            parameters[31].Value = model.liuchengpiaobianhao;

            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
            strSql.Append("delete from JiJiaQueXianDetail ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
            };

            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
        public WorkShopSystem.Model.JiJiaQueXianDetail GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 time,cnctiaojipin,falanmianyashang,falanmianhuahenpengshang,hmianyashang,jinqikoukepeng,shangzhouchengkongkepeng,daowen,kongjingchaocha,shuiyin,zangwu,jiagongbuliang,shakong,liewen,bengque,feihua,feipeng,qipi,zazhi,nianmo,maopeifamei,yanghuafahei,luodi,qita,lamo,xiankawai,chouyangshu,gonghao,feijiagongmianaokeng,lvxue,type,liuchengpiaobianhao from JiJiaQueXianDetail ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
            };

            WorkShopSystem.Model.JiJiaQueXianDetail model = new WorkShopSystem.Model.JiJiaQueXianDetail();
            DataTable ds = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                return DataRowToModel(ds.Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WorkShopSystem.Model.JiJiaQueXianDetail DataRowToModel(DataRow row)
        {
            WorkShopSystem.Model.JiJiaQueXianDetail model = new WorkShopSystem.Model.JiJiaQueXianDetail();
            if (row != null)
            {
                if (row["time"] != null && row["time"].ToString() != "")
                {
                    model.time = DateTime.Parse(row["time"].ToString());
                }
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
                if (row["liuchengpiaobianhao"] != null)
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
            strSql.Append("select time,cnctiaojipin,falanmianyashang,falanmianhuahenpengshang,hmianyashang,jinqikoukepeng,shangzhouchengkongkepeng,daowen,kongjingchaocha,shuiyin,zangwu,jiagongbuliang,shakong,liewen,bengque,feihua,feipeng,qipi,zazhi,nianmo,maopeifamei,yanghuafahei,luodi,qita,lamo,xiankawai,chouyangshu,gonghao,feijiagongmianaokeng,lvxue,type,liuchengpiaobianhao ");
            strSql.Append(" FROM JiJiaQueXianDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.ExecuteDataTable(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" time,cnctiaojipin,falanmianyashang,falanmianhuahenpengshang,hmianyashang,jinqikoukepeng,shangzhouchengkongkepeng,daowen,kongjingchaocha,shuiyin,zangwu,jiagongbuliang,shakong,liewen,bengque,feihua,feipeng,qipi,zazhi,nianmo,maopeifamei,yanghuafahei,luodi,qita,lamo,xiankawai,chouyangshu,gonghao,feijiagongmianaokeng,lvxue,type,liuchengpiaobianhao ");
            strSql.Append(" FROM JiJiaQueXianDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.ExecuteDataTable(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select count(1) FROM JiJiaQueXianDetail ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    object obj = DbHelperSQL.GetSingle(strSql.ToString());
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
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
            strSql.Append(")AS Row, T.*  from JiJiaQueXianDetail T ");
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
			parameters[0].Value = "JiJiaQueXianDetail";
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

