using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WorkShopSystem.Utility;

namespace WorkShopSystem.DAL
{
    /// <summary>
    /// 数据访问类:CommonWorkShopRecord
    /// </summary>
    public partial class CommonWorkShopRecordDAL
    {
        public CommonWorkShopRecordDAL()
        { }
        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(WorkShopSystem.Model.CommonWorkShopRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CommonWorkShopRecord(");
            strSql.Append("time,yazhujihao,maopeihao,muhao,liuchengpiaobianhao,banci,jihuashengchanshu,shengchanzongshu,jishuqishu,baofeizongshu,baofeilv,fanxiuzongshu,fanxiulv,xianhao,gongxu,workshoptype,gonghao,isdel,yazhuquexian,cuopifengquexian,pinjianquexian,jijiaquexian)");
            strSql.Append(" values (");
            strSql.Append("@time,@yazhujihao,@maopeihao,@muhao,@liuchengpiaobianhao,@banci,@jihuashengchanshu,@shengchanzongshu,@jishuqishu,@baofeizongshu,@baofeilv,@fanxiuzongshu,@fanxiulv,@xianhao,@gongxu,@workshoptype,@gonghao,@isdel,@yazhuquexian,@cuopifengquexian,@pinjianquexian,@jijiaquexian)");
            SqlParameter[] parameters = {
                    new SqlParameter("@time", SqlDbType.DateTime),
                    new SqlParameter("@yazhujihao", SqlDbType.NVarChar,50),
                    new SqlParameter("@maopeihao", SqlDbType.NVarChar,50),
                    new SqlParameter("@muhao", SqlDbType.NVarChar,50),
                    new SqlParameter("@liuchengpiaobianhao", SqlDbType.NVarChar,50),
                    new SqlParameter("@banci", SqlDbType.NVarChar,50),
                    new SqlParameter("@jihuashengchanshu", SqlDbType.Decimal,17),
                    new SqlParameter("@shengchanzongshu", SqlDbType.Decimal,17),
                    new SqlParameter("@jishuqishu", SqlDbType.Decimal,17),
                    new SqlParameter("@baofeizongshu", SqlDbType.Decimal,17),
                    new SqlParameter("@baofeilv", SqlDbType.Decimal,17),
                    new SqlParameter("@fanxiuzongshu", SqlDbType.Decimal,17),
                    new SqlParameter("@fanxiulv", SqlDbType.Decimal,17),
                    new SqlParameter("@xianhao", SqlDbType.NVarChar,50),
                    new SqlParameter("@gongxu", SqlDbType.NVarChar,50),
                    new SqlParameter("@workshoptype", SqlDbType.Decimal,17),
                    new SqlParameter("@gonghao", SqlDbType.NVarChar,50),
                    new SqlParameter("@isdel", SqlDbType.Decimal,17),
                    new SqlParameter("@yazhuquexian", SqlDbType.Decimal,17),
                    new SqlParameter("@cuopifengquexian", SqlDbType.Decimal,17),
                    new SqlParameter("@pinjianquexian", SqlDbType.Decimal,17),
                    new SqlParameter("@jijiaquexian", SqlDbType.Decimal,17)};
            parameters[0].Value = model.time;
            parameters[1].Value = model.yazhujihao;
            parameters[2].Value = model.maopeihao;
            parameters[3].Value = model.muhao;
            parameters[4].Value = model.liuchengpiaobianhao;
            parameters[5].Value = model.banci;
            parameters[6].Value = model.jihuashengchanshu;
            parameters[7].Value = model.shengchanzongshu;
            parameters[8].Value = model.jishuqishu;
            parameters[9].Value = model.baofeizongshu;
            parameters[10].Value = model.baofeilv;
            parameters[11].Value = model.fanxiuzongshu;
            parameters[12].Value = model.fanxiulv;
            parameters[13].Value = model.xianhao;
            parameters[14].Value = model.gongxu;
            parameters[15].Value = model.workshoptype;
            parameters[16].Value = model.gonghao;
            parameters[17].Value = model.isdel;
            parameters[18].Value = model.yazhuquexian;
            parameters[19].Value = model.cuopifengquexian;
            parameters[20].Value = model.pinjianquexian;
            parameters[21].Value = model.jijiaquexian;

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
        public bool Update(WorkShopSystem.Model.CommonWorkShopRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CommonWorkShopRecord set ");
            strSql.Append("time=@time,");
            strSql.Append("yazhujihao=@yazhujihao,");
            strSql.Append("maopeihao=@maopeihao,");
            strSql.Append("muhao=@muhao,");
            strSql.Append("liuchengpiaobianhao=@liuchengpiaobianhao,");
            strSql.Append("banci=@banci,");
            strSql.Append("jihuashengchanshu=@jihuashengchanshu,");
            strSql.Append("shengchanzongshu=@shengchanzongshu,");
            strSql.Append("jishuqishu=@jishuqishu,");
            strSql.Append("baofeizongshu=@baofeizongshu,");
            strSql.Append("baofeilv=@baofeilv,");
            strSql.Append("fanxiuzongshu=@fanxiuzongshu,");
            strSql.Append("fanxiulv=@fanxiulv,");
            strSql.Append("xianhao=@xianhao,");
            strSql.Append("gongxu=@gongxu,");
            strSql.Append("workshoptype=@workshoptype,");
            strSql.Append("gonghao=@gonghao,");
            strSql.Append("isdel=@isdel,");
            strSql.Append("yazhuquexian=@yazhuquexian,");
            strSql.Append("cuopifengquexian=@cuopifengquexian,");
            strSql.Append("pinjianquexian=@pinjianquexian,");
            strSql.Append("jijiaquexian=@jijiaquexian");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
                    new SqlParameter("@time", SqlDbType.DateTime),
                    new SqlParameter("@yazhujihao", SqlDbType.NVarChar,50),
                    new SqlParameter("@maopeihao", SqlDbType.NVarChar,50),
                    new SqlParameter("@muhao", SqlDbType.NVarChar,50),
                    new SqlParameter("@liuchengpiaobianhao", SqlDbType.NVarChar,50),
                    new SqlParameter("@banci", SqlDbType.NVarChar,50),
                    new SqlParameter("@jihuashengchanshu", SqlDbType.Decimal,17),
                    new SqlParameter("@shengchanzongshu", SqlDbType.Decimal,17),
                    new SqlParameter("@jishuqishu", SqlDbType.Decimal,17),
                    new SqlParameter("@baofeizongshu", SqlDbType.Decimal,17),
                    new SqlParameter("@baofeilv", SqlDbType.Decimal,17),
                    new SqlParameter("@fanxiuzongshu", SqlDbType.Decimal,17),
                    new SqlParameter("@fanxiulv", SqlDbType.Decimal,17),
                    new SqlParameter("@xianhao", SqlDbType.NVarChar,50),
                    new SqlParameter("@gongxu", SqlDbType.NVarChar,50),
                    new SqlParameter("@workshoptype", SqlDbType.Decimal,17),
                    new SqlParameter("@gonghao", SqlDbType.NVarChar,50),
                    new SqlParameter("@isdel", SqlDbType.Decimal,17),
                    new SqlParameter("@yazhuquexian", SqlDbType.Decimal,17),
                    new SqlParameter("@cuopifengquexian", SqlDbType.Decimal,17),
                    new SqlParameter("@pinjianquexian", SqlDbType.Decimal,17),
                    new SqlParameter("@jijiaquexian", SqlDbType.Decimal,17)};
            parameters[0].Value = model.time;
            parameters[1].Value = model.yazhujihao;
            parameters[2].Value = model.maopeihao;
            parameters[3].Value = model.muhao;
            parameters[4].Value = model.liuchengpiaobianhao;
            parameters[5].Value = model.banci;
            parameters[6].Value = model.jihuashengchanshu;
            parameters[7].Value = model.shengchanzongshu;
            parameters[8].Value = model.jishuqishu;
            parameters[9].Value = model.baofeizongshu;
            parameters[10].Value = model.baofeilv;
            parameters[11].Value = model.fanxiuzongshu;
            parameters[12].Value = model.fanxiulv;
            parameters[13].Value = model.xianhao;
            parameters[14].Value = model.gongxu;
            parameters[15].Value = model.workshoptype;
            parameters[16].Value = model.gonghao;
            parameters[17].Value = model.isdel;
            parameters[18].Value = model.yazhuquexian;
            parameters[19].Value = model.cuopifengquexian;
            parameters[20].Value = model.pinjianquexian;
            parameters[21].Value = model.jijiaquexian;

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
            strSql.Append("delete from CommonWorkShopRecord ");
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
        public WorkShopSystem.Model.CommonWorkShopRecord GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 time,yazhujihao,maopeihao,muhao,liuchengpiaobianhao,banci,jihuashengchanshu,shengchanzongshu,jishuqishu,baofeizongshu,baofeilv,fanxiuzongshu,fanxiulv,xianhao,gongxu,workshoptype,gonghao,isdel,yazhuquexian,cuopifengquexian,pinjianquexian,jijiaquexian from CommonWorkShopRecord ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
            };

            WorkShopSystem.Model.CommonWorkShopRecord model = new WorkShopSystem.Model.CommonWorkShopRecord();
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
        public WorkShopSystem.Model.CommonWorkShopRecord DataRowToModel(DataRow row)
        {
            WorkShopSystem.Model.CommonWorkShopRecord model = new WorkShopSystem.Model.CommonWorkShopRecord();
            if (row != null)
            {
                if (row["time"] != null && row["time"].ToString() != "")
                {
                    model.time = DateTime.Parse(row["time"].ToString());
                }
                if (row["yazhujihao"] != null)
                {
                    model.yazhujihao = row["yazhujihao"].ToString();
                }
                if (row["maopeihao"] != null)
                {
                    model.maopeihao = row["maopeihao"].ToString();
                }
                if (row["muhao"] != null)
                {
                    model.muhao = row["muhao"].ToString();
                }
                if (row["liuchengpiaobianhao"] != null)
                {
                    model.liuchengpiaobianhao = row["liuchengpiaobianhao"].ToString();
                }
                if (row["banci"] != null)
                {
                    model.banci = row["banci"].ToString();
                }
                if (row["jihuashengchanshu"] != null && row["jihuashengchanshu"].ToString() != "")
                {
                    model.jihuashengchanshu = decimal.Parse(row["jihuashengchanshu"].ToString());
                }
                if (row["shengchanzongshu"] != null && row["shengchanzongshu"].ToString() != "")
                {
                    model.shengchanzongshu = decimal.Parse(row["shengchanzongshu"].ToString());
                }
                if (row["jishuqishu"] != null && row["jishuqishu"].ToString() != "")
                {
                    model.jishuqishu = decimal.Parse(row["jishuqishu"].ToString());
                }
                if (row["baofeizongshu"] != null && row["baofeizongshu"].ToString() != "")
                {
                    model.baofeizongshu = decimal.Parse(row["baofeizongshu"].ToString());
                }
                if (row["baofeilv"] != null && row["baofeilv"].ToString() != "")
                {
                    model.baofeilv = decimal.Parse(row["baofeilv"].ToString());
                }
                if (row["fanxiuzongshu"] != null && row["fanxiuzongshu"].ToString() != "")
                {
                    model.fanxiuzongshu = decimal.Parse(row["fanxiuzongshu"].ToString());
                }
                if (row["fanxiulv"] != null && row["fanxiulv"].ToString() != "")
                {
                    model.fanxiulv = decimal.Parse(row["fanxiulv"].ToString());
                }
                if (row["xianhao"] != null)
                {
                    model.xianhao = row["xianhao"].ToString();
                }
                if (row["gongxu"] != null)
                {
                    model.gongxu = row["gongxu"].ToString();
                }
                if (row["workshoptype"] != null && row["workshoptype"].ToString() != "")
                {
                    model.workshoptype = decimal.Parse(row["workshoptype"].ToString());
                }
                if (row["gonghao"] != null)
                {
                    model.gonghao = row["gonghao"].ToString();
                }
                if (row["isdel"] != null && row["isdel"].ToString() != "")
                {
                    model.isdel = int.Parse(row["isdel"].ToString());
                }
                if (row["yazhuquexian"] != null && row["yazhuquexian"].ToString() != "")
                {
                    model.yazhuquexian = decimal.Parse(row["yazhuquexian"].ToString());
                }
                if (row["cuopifengquexian"] != null && row["cuopifengquexian"].ToString() != "")
                {
                    model.cuopifengquexian = decimal.Parse(row["cuopifengquexian"].ToString());
                }
                if (row["pinjianquexian"] != null && row["pinjianquexian"].ToString() != "")
                {
                    model.pinjianquexian = decimal.Parse(row["pinjianquexian"].ToString());
                }
                if (row["jijiaquexian"] != null && row["jijiaquexian"].ToString() != "")
                {
                    model.jijiaquexian = decimal.Parse(row["jijiaquexian"].ToString());
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
            strSql.Append("select time,yazhujihao,maopeihao,muhao,liuchengpiaobianhao,banci,jihuashengchanshu,shengchanzongshu,jishuqishu,baofeizongshu,baofeilv,fanxiuzongshu,fanxiulv,xianhao,gongxu,workshoptype,gonghao,isdel,yazhuquexian,cuopifengquexian,pinjianquexian,jijiaquexian ");
            strSql.Append(" FROM CommonWorkShopRecord ");
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
            strSql.Append(" time,yazhujihao,maopeihao,muhao,liuchengpiaobianhao,banci,jihuashengchanshu,shengchanzongshu,jishuqishu,baofeizongshu,baofeilv,fanxiuzongshu,fanxiulv,xianhao,gongxu,workshoptype,gonghao,isdel,yazhuquexian,cuopifengquexian,pinjianquexian,jijiaquexian ");
            strSql.Append(" FROM CommonWorkShopRecord ");
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
        //	StringBuilder strSql=new StringBuilder();
        //	strSql.Append("select count(1) FROM CommonWorkShopRecord ");
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
            strSql.Append(")AS Row, T.*  from CommonWorkShopRecord T ");
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
			parameters[0].Value = "CommonWorkShopRecord";
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
        #region  ExtensionMethod
        public DataTable GetMuHaoList(string workType)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            switch (workType)
            {
                case "a":
                    strSql.Append("select count(*) c,muhao from CommonWorkShopRecord where workshoptype in(0,1,2,3,4) group by muhao order by c desc");
                    break;
                case "b":
                    strSql.Append("select count(*) c,muhao from CommonWorkShopRecord where workshoptype in(5,6,7,8) group by muhao order by c desc");
                    break;
                default:
                    break;
            }
            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetMaoPiList(string workType)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            switch (workType)
            {
                case "a":
                    strSql.Append("select count(*) c,maopeihao from CommonWorkShopRecord where workshoptype in(0,1,2,3,4) group by maopeihao order by c desc");
                    break;
                case "b":
                    strSql.Append("select count(*) c,maopeihao from CommonWorkShopRecord where workshoptype in(5,6,7,8) group by maopeihao order by c desc");
                    break;
                default:
                    break;
            }

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetLiuChengPiaoList(string timeStart, string timeEnd, string workType)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            switch (workType)
            {
                case "a":
                    strSql.Append(string.Format("select count(*) c,liuchengpiaobianhao from CommonWorkShopRecord where workshoptype in(0,1,2,3,4) and time<='{0}' and time >='{1}' group by liuchengpiaobianhao order by c desc", timeEnd, timeStart));
                    break;
                case "b":
                    strSql.Append(string.Format("select count(*) c,liuchengpiaobianhao from CommonWorkShopRecord where workshoptype in(5,6,7,8) and time<='{0}' and time >='{1}' group by liuchengpiaobianhao order by c desc", timeEnd, timeStart));
                    break;
                default:
                    break;
            }

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }

        public DataTable GetNumByTime(string workType, string timeStart)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            switch (workType)
            {
                case "a":
                    strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanshu,sum(jishuqishu) as jishuqishu,sum(fanxiuzongshu) as fanxiuzongshu,sum(yazhuquexian) as yazhuquexian,sum(cuopifengquexian) as cuopifengquexian,sum(pinjianquexian) as pinjianquexian from CommonWorkShopRecord where workshoptype =0 and convert(char(7) ,time , 120)>'2017-01' and convert(char(7) ,time , 120)='{0}'", timeStart));
                    break;
                case "b":
                    strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanshu,sum(jishuqishu) as jishuqishu,sum(fanxiuzongshu) as fanxiuzongshu,sum(yazhuquexian) as yazhuquexian,sum(pinjianquexian) as pinjianquexian,sum(jijiaquexian) as jijiaquexian from CommonWorkShopRecord where workshoptype =5 and convert(char(7) ,time , 120)>'2017-01' and convert(char(7) ,time , 120)='{0}'", timeStart));
                    break;
                case "c":
                    strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanshu from CommonWorkShopRecord where workshoptype =4 and convert(char(7) ,time , 120)>'2017-01' and convert(char(7) ,time , 120)='{0}'", timeStart));
                    break;
            }

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }

        public DataTable GetNumByTimeWorkshoptype(string workType, string timeStart)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(yazhuquexian) as yazhuquexian,sum(jijiaquexian) as jijiaquexian from CommonWorkShopRecord where workshoptype ={0} and convert(char(7) ,time , 120)='{1}'", workType, timeStart));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }

        public DataTable GetAllGroupByTime()
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT convert(char(7) ,time , 120) as time from CommonWorkShopRecord where convert(char(7) ,time , 120)>'2017-01' GROUP BY convert(char(7) ,time , 120)");

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetDetailBaoFeiList(string time, string type,int quexiantype)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            string sqlTemp = string.Empty;
            if (type == "0" || type == "1" || type == "2" || type == "3" || type == "4")
            {
                if(quexiantype==0)
                {
                    sqlTemp = string.Format(@"select sum(gaodiya) as gaodiya,sum(lamo) as lamo,sum(nianmo) as nianmo,sum(kaweichaocha) as kaweichaocha,sum(liewen) as liewen,sum(guilie) as guilie,sum(lengliao) as lengliao,sum(youwufahei) as youwufahei,sum(duanzhen) as duanzhen,sum(qipi) as qipi,sum(jushang) as jushang,sum(yadianshang) as yadianshang,sum(chongshang) as chongshang,sum(bengqueliao) as bengqueliao,sum(penghuashang) as penghuashang,sum(Hmianhuashang) as Hmianhuashang,sum(xiankawai) as xiankawai,sum(luodipin) as luodipin,sum(gubao) as gubao,sum(jitan) as jitan,sum(shuikouduan) as shuikouduan,sum(aokeng) as aokeng,sum(qita) as qita from YaZhuQueXianDetail where type={1} and liuchengpiaobianhao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype={2} and convert(char(7) ,time , 120)='{0}')", time, type, type);
                }
                if (quexiantype == 1)
                {
                    sqlTemp = string.Format(@"select sum(cuoshang) as cuoshang,sum(cuodaohen) as cuodaohen,sum(abbdashang) as abbdashang,sum(assqiexue) as assqiexue,sum(qupifengqita) as qupifengqita from YaZhuQueXianDetail where type={1} and liuchengpiaobianhao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype={2} and convert(char(7) ,time , 120)='{0}')", time, type, type);
                }
                strSql.Append(sqlTemp);
            }
            else
            {
                strSql.Append(string.Format(@"select sum(cnctiaojipin) as type1,sum(falanmianyashang) as type2,sum(falanmianhuahenpengshang) as type3,sum(hmianyashang) as type4,sum(jinqikoukepeng) as type5,sum(shangzhouchengkongkepeng) as type6,sum(daowen) as type7,sum(kongjingchaocha) as type8,sum(shuiyin) as type9,sum(zangwu) as type10,sum(jiagongbuliang) as type11,sum(shakong) as type12,sum(liewen) as type13,sum(bengque) as type14,sum(feihua) as type15,sum(feipeng) as type16,sum(qipi) as type17,sum(zazhi) as type18,sum(nianmo) as type19,sum(maopeifamei) as type20,sum(yanghuafahei) as type21,sum(luodi) as type22,sum(qita) as type23,sum(lamo) as type24,sum(xiankawai) as type25 from JiJiaQueXianDetail where type={1} and liuchengpiaobianhao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=8 and convert(char(7) ,time , 120)='{0}')", time,type));

                #region 机加缺陷
                //switch (type)
                //{

                //    #region 压铸明细
                //    //                case "0"://压铸
                //    //                    strSql.Append(string.Format(@"select sum(tiaojipin) as tiaojipin,sum(feijiagongaokeng) as feijiagongaokeng,sum(liewen) as liewen,sum(nainmo) as nainmo,sum(lamo) as lamo,sum(qipi) as qipi,sum(youwufahei) as youwufahei,sum(cuoshang) as cuoshang,sum(shangzhouchengjushang) as shangzhouchengjushang,sum(chongshang) as chongshang,sum(bengliao) as bengliao,sum(penghuashang) as penghuashang,sum(hmianhuashang) as hmianhuashang,sum(xiankawai) as xiankawai,sum(luodipin) as luodipin,sum(shangzhouchengkongduanlie) as shangzhouchengkongduanlie,sum(jitan) as jitan,sum(lengliao) as lengliao,sum(qita) as qita from YaZhuQueXianDetail where type=0 and liuchengpiaohao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=0 and convert(char(7) ,time , 120)='{0}')", time));
                //    //                    break;
                //    //                case "1"://打砂1
                //    //                    strSql.Append(string.Format(@"select sum(gaodiyatiaoji) as gaodiyatiaoji,sum(feijiagongaokeng) as feijiagongaokeng,sum(liewen) as liewen,sum(nianmo) as nianmo,sum(qipi) as qipi,sum(youwufahei) as youwufahei,sum(cuoshang) as cuoshang,sum(shangzhouchengjushang) as shangzhouchengjushang,sum(chongshang) as chongshang,sum(bengliao) as bengliao,sum(penghuashang) as penghuashang,sum(hmianhuashang) as hmianhuashang,sum(xiankawai) as xiankawai,sum(luodipin) as luodipin,sum(qita) as qita from YaZhuQueXianDetail where type=1 and liuchengpiaohao in(select liuchengpiaobianhao from CommonWorkShopRecord  where workshoptype=1 and convert(char(7) ,time , 120)='{0}')", time));
                //    //                    break;
                //    //                case "2"://打砂2
                //    //                    strSql.Append(string.Format(@"select sum(gaodiyatiaoji) as gaodiyatiaoji,sum(feijiagongaokeng) as feijiagongaokeng,sum(liewen) as liewen,sum(nianmo) as nianmo,sum(qipi) as qipi,sum(youwufahei) as youwufahei,sum(cuoshang) as cuoshang,sum(shangzhouchengjushang) as shangzhouchengjushang,sum(chongshang) as chongshang,sum(bengliao) as bengliao,sum(penghuashang) as penghuashang,sum(hmianhuashang) as hmianhuashang,sum(xiankawai) as xiankawai,sum(luodipin) as luodipin,sum(qita) as qita from YaZhuQueXianDetail where type=2 and liuchengpiaohao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=2 and convert(char(7) ,time , 120)='{0}')", time));
                //    //                    break;
                //    //                case "3"://披锋组
                //    //                    strSql.Append(string.Format(@"select
                //    //sum(feijiagongaokeng) as feijiagongaokeng,sum(liewen) as liewen,sum(nianmo) as nianmo,sum(lamo) as lamo,sum(qipi) as qipi,sum(youwufahei) as youwufahei,sum(lengliao) as lengliao,sum(cuoshang) as cuoshang,sum(shangzhouchengjushang) as shangzhouchengjushang,sum(chongshang) as chongshang,sum(bengliao) as bengliao,sum(penghuashang) as penghuashang,sum(hmianhuashang) as hmianhuashang,sum(hmianbianxing) as hmianbianxing,sum(yashang) as yashang,sum(xiankawai) as xiankawai,sum(luodipin) as luodipin,sum(abbdashang) as abbdashang,sum(qita) as qita from YaZhuQueXianDetail where type=3 and liuchengpiaohao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=3 and convert(char(7) ,time , 120)='{0}')", time));
                //    //                    break;
                //    //                case "4"://披锋组H
                //    //                    strSql.Append(string.Format(@"select sum(shayan) as shayan,sum(feijiagongmianaokeng) as feijiagongmianaokeng,sum(liewen) as liewen,sum(nianmo) as nianmo,sum(lamo) as lamo,sum(qipi) as qipi,sum(youwufahei) as youwufahei,sum(lengliao) as lengliao,sum(cuoshang) as cuoshang,sum(shangzhouchengjushang) as shangzhouchengjushang,sum(chongshang) as chongshang,sum(bengliao) as bengliao,sum(penghuashang) as penghuashang,sum(hmianhuashang) as hmianhuashang,sum(rjiaobianxing) as rjiaobianxing,sum(hmianbianxing) as hmianbianxing,sum(yashang) as yashang,sum(xiankawai) as xiankawai,sum(luodipin) as luodipin,sum(assdashang) as assdashang,sum(gubao) as gubao,sum(aokeng) as aokeng,sum(cuzaodugao) as cuzaodugao,sum(qita) as qita from YaZhuQueXianDetail where type=4 and liuchengpiaohao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=4 and convert(char(7) ,time , 120)='{0}')", time));
                //    //                    break; 
                //    #endregion
                //    case "5"://拉线统计
                //        strSql.Append(string.Format(@"select sum(cnctiaojipin) as type1,sum(falanmianyashang) as type2,sum(falanmianhuahenpengshang) as type3,sum(hmianyashang) as type4,sum(jinqikoukepeng) as type5,sum(shangzhouchengkongkepeng) as type6,sum(daowen) as type7,sum(kongjingchaocha) as type8,sum(shuiyin) as type9,sum(zangwu) as type10,sum(jiagongbuliang) as type11,sum(shakong) as type12,sum(liewen) as type13,sum(bengque) as type14,sum(feihua) as type15,sum(feipeng) as type16,sum(qipi) as type17,sum(zazhi) as type18,sum(nianmo) as type19,sum(maopeifamei) as type20,sum(yanghuafahei) as type21,sum(luodi) as type22,sum(qita) as type23,sum(lamo) as type24,sum(xiankawai) as type25 from JiJiaQueXianDetail where type=8 and liuchengpiaobianhao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=8 and convert(char(7) ,time , 120)='{0}')", time));
                //        break;
                //    case "6"://清洗统计
                //        strSql.Append(string.Format(@"select sum(luodi) as type1,sum(qita) as type2,sum(chouyangshu) as type3 from JiJiaQueXianDetail where type=6 and liuchengpiaobianhao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=6 and convert(char(7) ,time , 120)='{0}')", time));
                //        break;
                //    case "7"://CNC统计
                //        strSql.Append(string.Format(@"select sum(cnctiaojipin) as type1,sum(falanmianyashang) as type2,sum(hmianyashang) as type3,sum(jinqikoukepeng) as type4,sum(shangzhouchengkongkepeng) as type5,sum(daowen) as type6,sum(kongjingchaocha) as type7,sum(shuiyin) as type8,sum(zangwu) as type9,sum(jiagongbuliang) as type10,sum(shakong) as type11,sum(liewen) as type12,sum(bengque) as type13,sum(feijiagongmianaokeng) as type14,sum(qipi) as type15,sum(zazhi) as type16,sum(nianmo) as type17,sum(maopeifamei) as type18,sum(yanghuafahei) as type19,sum(luodi) as type20,sum(qita) as type21,sum(lvxue) as type22,sum(chouyangshu) as type23 from JiJiaQueXianDetail where type=5 and liuchengpiaobianhao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=5 and convert(char(7) ,time , 120)='{0}')", time));
                //        break;
                //    case "8"://测漏统计
                //        strSql.Append(string.Format(@"select sum(falanmianhuahenpengshang) as type1,sum(shangzhouchengkongkepeng) as type2,sum(jiagongbuliang) as type3,sum(luodi) as type4,sum(qipi) as type5,sum(lvxue) as type6,sum(qita) as type7 from JiJiaQueXianDetail where type=7 and liuchengpiaobianhao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=7 and convert(char(7) ,time , 120)='{0}')", time));
                //        break;
                //    default:
                //        break;
                //} 
                #endregion
            }



            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }

        public DataTable GetInfoByOne(string strWhere)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT time,yazhujihao,maopeihao,muhao,liuchengpiaobianhao,banci,jihuashengchanshu,shengchanzongshu,jishuqishu,baofeizongshu,baofeilv,fanxiuzongshu,fanxiulv,xianhao,gongxu,(case workshoptype when 0 then '压铸' when 1 then '打砂1' when 2 then '打砂2' when 3 then '披锋' when 4 then 'H面全检' when 5 then 'CNC' when 6 then '清洗' when 7 then '测漏' when 8 then '拉线全检' else '空的' end) workshoptype ,gonghao,yazhuquexian,cuopifengquexian,pinjianquexian,jijiaquexian from CommonWorkShopRecord ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        //获取压铸车间数据的天数的第一个和最后一个
        public DataTable GetTimeDayList(string time)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT convert(char(10) ,time , 120) as time from CommonWorkShopRecord where convert(char(7) ,time , 120)='{0}' GROUP BY convert(char(10) ,time , 120) order by time", time));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetMonthList(int type)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            string typeList = type == 0 ? "0,1,2,3,4" : "5,6,7,8";
            strSql.Append(string.Format("SELECT convert(char(7) ,time , 120) as time from CommonWorkShopRecord where workshoptype in ({0}) and convert(char(7) ,time , 120)>'2017-01' GROUP BY convert(char(7) ,time , 120) order by time", typeList));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetNum(string shebeibianhao, string lingjianbianhao, string time, string daynight)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu from CommonWorkShopRecord where workshoptype=0 and convert(char(10) ,time , 120)='{0}' and (yazhujihao='{1}' or yazhujihao='{4}') and maopeihao='{2}' and banci='{3}'", time, shebeibianhao, lingjianbianhao, daynight, shebeibianhao.TrimEnd('#')));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }

        public DataTable GetNumJiJia(string xianhao, string lingjianbianhao, string time, string banci)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu from CommonWorkShopRecord where workshoptype=5 and convert(char(10) ,time , 120)='{0}' and xianhao in ({1}) and maopeihao in ({2}) and banci='{3}'", time, xianhao, lingjianbianhao, banci));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }

        public DataTable GetNumByDay(string time, string shenchanbianhaolist, string lingjianbianhaolist)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu,sum(yazhuquexian) as yazhuquexian,sum(cuopifengquexian) as cuopifengquexian,sum(pinjianquexian) as pinjianquexian,sum(jishuqishu) as jishuqishu from CommonWorkShopRecord where workshoptype=0 and convert(char(10) ,time , 120)='{0}' and yazhujihao in ({1}) and maopeihao in ({2}) ", time, shenchanbianhaolist, lingjianbianhaolist));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }

        public DataTable GetJiJIaNumByDay(string time, string shenchanbianhaolist, string lingjianbianhaolist)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu,sum(yazhuquexian) as yazhuquexian,sum(jijiaquexian) as jijiaquexian,sum(pinjianquexian) as pinjianquexian,sum(fanxiuzongshu) as fanxiuzongshu from CommonWorkShopRecord where workshoptype=5 and convert(char(10) ,time , 120)='{0}' and xianhao in ({1}) and maopeihao in ({2}) ", time, shenchanbianhaolist, lingjianbianhaolist));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }

        public DataTable GetDaShaNum(string dashaindex, string time)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu,sum(yazhuquexian) as yazhuquexian,sum(cuopifengquexian) as cuopifengquexian,sum(pinjianquexian) as pinjianquexian from CommonWorkShopRecord where workshoptype in ({0}) and convert(char(10) ,time , 120)='{1}'", dashaindex, time));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetQingXiNum(string maopihao, string time)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu,sum(yazhuquexian) as yazhuquexian,sum(jijiaquexian) as jijiaquexian,sum(pinjianquexian) as pinjianquexian,sum(fanxiuzongshu) as fanxiuzongshu from CommonWorkShopRecord where workshoptype=6 and maopeihao in({0}) and convert(char(10) ,time , 120)='{1}'", maopihao, time));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetDaShaDayCount(int dashaindex, string time, string banci)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu from CommonWorkShopRecord where workshoptype = {0} and convert(char(10) ,time , 120)='{1}' and banci ='{2}'", dashaindex, time, banci));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetQingXiDayCount(string lingjianbianhao, string time)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu from CommonWorkShopRecord where workshoptype = 6 and maopeihao='{0}' and convert(char(10) ,time , 120)='{1}'", lingjianbianhao, time));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetCuoPiFengDayCount(int xianhao, string lingjianbianhao, string time, string banci)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu from CommonWorkShopRecord where workshoptype = 3 and xianhao='{0}' and convert(char(10) ,time , 120)='{1}' and banci ='{2}' and maopeihao='{3}'", xianhao.ToString() + "#", time, banci, lingjianbianhao));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetCeLouDayCount(string gongyiliucheng, string lingjianbianhao, string time, string banci)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu from CommonWorkShopRecord where workshoptype = 7 and yazhujihao='{0}' and convert(char(10) ,time , 120)='{1}' and banci ='{2}' and maopeihao='{3}'", gongyiliucheng, time, banci, lingjianbianhao));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetCuoPiFengNum(string xianhao, string time, string lingjianbianhao)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu,sum(yazhuquexian) as yazhuquexian,sum(cuopifengquexian) as cuopifengquexian,sum(pinjianquexian) as pinjianquexian from CommonWorkShopRecord where workshoptype = 3 and convert(char(10) ,time , 120)='{0}' and xianhao in ({1}) and maopeihao in ({2})", time, xianhao, lingjianbianhao));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetCeLouNum(string xianhao, string time, string lingjianbianhao)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu,sum(yazhuquexian) as yazhuquexian,sum(jijiaquexian) as jijiaquexian,sum(pinjianquexian) as pinjianquexian,sum(fanxiuzongshu) as fanxiuzongshu from CommonWorkShopRecord where workshoptype = 7 and convert(char(10) ,time , 120)='{0}' and yazhujihao in ({1}) and maopeihao in ({2})", time, xianhao, lingjianbianhao));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetShouDongCuoPiFengDayCount(string xianhao, string time, string banci)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu from CommonWorkShopRecord where workshoptype = 3 and convert(char(10) ,time , 120)='{0}' and banci ='{1}' and gonghao='{2}'", time, banci, xianhao));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetQuanJianDayCount(string xianhao, string time, string maopeihao)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu from CommonWorkShopRecord where workshoptype = 8 and convert(char(10) ,time , 120)='{0}' and maopeihao ='{1}' and maopeihao='{2}'", time, maopeihao, xianhao));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetShouDongCuoPiFengDayCount(string bianhao, string time)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu,sum(yazhuquexian) as yazhuquexian,sum(cuopifengquexian) as cuopifengquexian,sum(pinjianquexian) as pinjianquexian from CommonWorkShopRecord where workshoptype = 3 and convert(char(10) ,time , 120)='{0}' and gonghao in ({1})", time, bianhao));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetJiJiaQuanJianDayCount(string yazhujihao, string time, string lingjianbianhao)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu,sum(yazhuquexian) as yazhuquexian,sum(jijiaquexian) as jijiaquexian,sum(pinjianquexian) as pinjianquexian,sum(fanxiuzongshu) as fanxiuzongshu from CommonWorkShopRecord where workshoptype = 8 and convert(char(10) ,time , 120)='{0}' and yazhujihao in ({1}) and maopeihao in({2})", time, yazhujihao, lingjianbianhao));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetQuanJianDayCounts(int xianhao, string time, string banci)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu from CommonWorkShopRecord where workshoptype = 4 and convert(char(10) ,time , 120)='{0}' and banci ='{1}' and xianhao='{2}'", time, banci, xianhao.ToString() + "#"));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetQuanJianNum(string xianhao, string time)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu,sum(yazhuquexian) as yazhuquexian,sum(cuopifengquexian) as cuopifengquexian,sum(pinjianquexian) as pinjianquexian from CommonWorkShopRecord where workshoptype = 4 and convert(char(10) ,time , 120)='{0}' and xianhao in ({1})", time, xianhao));

            dt = SqlHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetListSum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(jihuashengchanshu) jihuashengchanshu,sum(shengchanzongshu) shengchanzongshu,sum(jishuqishu) jishuqishu,sum(baofeizongshu) baofeizongshu,sum(fanxiuzongshu) fanxiuzongsh,sum(yazhuquexian) yazhuquexian,sum(cuopifengquexian) cuopifengquexian,sum(pinjianquexian) pinjianquexian,sum(jijiaquexian) jijiaquexian");
            strSql.Append(" FROM CommonWorkShopRecord ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.ExecuteDataTable(strSql.ToString());
        }
        #endregion  ExtensionMethod
        #endregion  ExtensionMethod
    }
}

