/**  版本信息模板在安装目录下，可自行修改。
* CommonWorkShopRecord.cs
*
* 功 能： N/A
* 类 名： CommonWorkShopRecord
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/6/21 9:59:51   N/A    初版
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
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@time", DbType.DateTime),
                    new SQLiteParameter("@yazhujihao", DbType.String,2147483647),
                    new SQLiteParameter("@maopeihao", DbType.String,2147483647),
                    new SQLiteParameter("@muhao", DbType.String,2147483647),
                    new SQLiteParameter("@liuchengpiaobianhao", DbType.String,2147483647),
                    new SQLiteParameter("@banci", DbType.String,2147483647),
                    new SQLiteParameter("@jihuashengchanshu", DbType.Decimal,8),
                    new SQLiteParameter("@shengchanzongshu", DbType.Decimal,8),
                    new SQLiteParameter("@jishuqishu", DbType.Decimal,8),
                    new SQLiteParameter("@baofeizongshu", DbType.Decimal,8),
                    new SQLiteParameter("@baofeilv", DbType.Decimal,8),
                    new SQLiteParameter("@fanxiuzongshu", DbType.Decimal,8),
                    new SQLiteParameter("@fanxiulv", DbType.Decimal,8),
                    new SQLiteParameter("@xianhao", DbType.String,2147483647),
                    new SQLiteParameter("@gongxu", DbType.String,2147483647),
                    new SQLiteParameter("@workshoptype", DbType.Decimal,8),
                    new SQLiteParameter("@gonghao", DbType.String,2147483647),
                    new SQLiteParameter("@isdel", DbType.Int32,8),
                    new SQLiteParameter("@yazhuquexian", DbType.Decimal,8),
                    new SQLiteParameter("@cuopifengquexian", DbType.Decimal,8),
                    new SQLiteParameter("@pinjianquexian", DbType.Decimal,8),
                    new SQLiteParameter("@jijiaquexian", DbType.Decimal,8)};
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
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@time", DbType.DateTime),
                    new SQLiteParameter("@yazhujihao", DbType.String,2147483647),
                    new SQLiteParameter("@maopeihao", DbType.String,2147483647),
                    new SQLiteParameter("@muhao", DbType.String,2147483647),
                    new SQLiteParameter("@liuchengpiaobianhao", DbType.String,2147483647),
                    new SQLiteParameter("@banci", DbType.String,2147483647),
                    new SQLiteParameter("@jihuashengchanshu", DbType.Decimal,8),
                    new SQLiteParameter("@shengchanzongshu", DbType.Decimal,8),
                    new SQLiteParameter("@jishuqishu", DbType.Decimal,8),
                    new SQLiteParameter("@baofeizongshu", DbType.Decimal,8),
                    new SQLiteParameter("@baofeilv", DbType.Decimal,8),
                    new SQLiteParameter("@fanxiuzongshu", DbType.Decimal,8),
                    new SQLiteParameter("@fanxiulv", DbType.Decimal,8),
                    new SQLiteParameter("@xianhao", DbType.String,2147483647),
                    new SQLiteParameter("@gongxu", DbType.String,2147483647),
                    new SQLiteParameter("@workshoptype", DbType.Decimal,8),
                    new SQLiteParameter("@gonghao", DbType.String,2147483647),
                    new SQLiteParameter("@isdel", DbType.Int32,8),
                    new SQLiteParameter("@yazhuquexian", DbType.Decimal,8),
                    new SQLiteParameter("@cuopifengquexian", DbType.Decimal,8),
                    new SQLiteParameter("@pinjianquexian", DbType.Decimal,8),
                    new SQLiteParameter("@jijiaquexian", DbType.Decimal,8)};
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
            strSql.Append("delete from CommonWorkShopRecord ");
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
        public WorkShopSystem.Model.CommonWorkShopRecord GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select time,yazhujihao,maopeihao,muhao,liuchengpiaobianhao,banci,jihuashengchanshu,shengchanzongshu,jishuqishu,baofeizongshu,baofeilv,fanxiuzongshu,fanxiulv,xianhao,gongxu,workshoptype,gonghao,isdel,yazhuquexian,cuopifengquexian,pinjianquexian,jijiaquexian from CommonWorkShopRecord ");
            strSql.Append(" where ");
            SQLiteParameter[] parameters = {
            };

            WorkShopSystem.Model.CommonWorkShopRecord model = new WorkShopSystem.Model.CommonWorkShopRecord();
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
            return SqliteHelper.ExecuteDataTable(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetListSum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select time,yazhujihao,maopeihao,muhao,liuchengpiaobianhao,banci,sum(jihuashengchanshu) jihuashengchanshu,sum(shengchanzongshu) shengchanzongshu,sum(jishuqishu) jishuqishu,sum(baofeizongshu) baofeizongshu,baofeilv,sum(fanxiuzongshu) fanxiuzongshu,fanxiulv,xianhao,gongxu,workshoptype,gonghao,isdel,sum(yazhuquexian) yazhuquexian,sum(cuopifengquexian) cuopifengquexian,sum(pinjianquexian) pinjianquexian,sum(jijiaquexian) jijiaquexian");
            strSql.Append(" FROM CommonWorkShopRecord ");
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
            strSql.Append("select count(1) FROM CommonWorkShopRecord ");
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
                strSql.Append("order by T. desc");
            }
            strSql.Append(")AS Row, T.*  from CommonWorkShopRecord T ");
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
			parameters[0].Value = "CommonWorkShopRecord";
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
            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
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

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
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

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }

        public DataTable GetNumByTime(string workType, string timeStart)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            switch (workType)
            {
                case "a":
                    strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanshu,sum(jishuqishu) as jishuqishu,sum(fanxiuzongshu) as fanxiuzongshu,sum(yazhuquexian) as yazhuquexian,sum(cuopifengquexian) as cuopifengquexian,sum(pinjianquexian) as pinjianquexian from CommonWorkShopRecord where workshoptype =0 and strftime('%Y-%m',  time)='{0}'", timeStart));
                    break;
                case "b":
                    strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanshu,sum(jishuqishu) as jishuqishu,sum(fanxiuzongshu) as fanxiuzongshu,sum(yazhuquexian) as yazhuquexian,sum(pinjianquexian) as pinjianquexian,sum(jijiaquexian) as jijiaquexian from CommonWorkShopRecord where workshoptype =7 and strftime('%Y-%m',  time)='{0}'", timeStart));
                    break;
                default:
                    break;
            }

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }

        public DataTable GetNumByTimeWorkshoptype(string workType, string timeStart)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(yazhuquexian) as yazhuquexian,sum(jijiaquexian) as jijiaquexian from CommonWorkShopRecord where workshoptype ={0} and strftime('%Y-%m',  time)='{1}'", workType, timeStart));

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }

        public DataTable GetAllGroupByTime()
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT strftime('%Y-%m',  time) as time from CommonWorkShopRecord GROUP BY strftime('%Y-%m',time)");

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetDetailBaoFeiList(string time, string type)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            switch (type)
            {
                case "0"://压铸
                    strSql.Append(string.Format(@"select sum(tiaojipin) as tiaojipin,sum(feijiagongaokeng) as feijiagongaokeng,sum(liewen) as liewen,sum(nainmo) as nainmo,sum(lamo) as lamo,sum(qipi) as qipi,sum(youwufahei) as youwufahei,sum(cuoshang) as cuoshang,sum(shangzhouchengjushang) as shangzhouchengjushang,sum(chongshang) as chongshang,sum(bengliao) as bengliao,sum(penghuashang) as penghuashang,sum(hmianhuashang) as hmianhuashang,sum(xiankawai) as xiankawai,sum(luodipin) as luodipin,sum(shangzhouchengkongduanlie) as shangzhouchengkongduanlie,sum(jitan) as jitan,sum(lengliao) as lengliao,sum(qita) as qita from YaZhuBaoFeiDetail where liuchengpiaohao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=0 and strftime('%Y-%m',  time)='{0}')", time));
                    break;
                case "1"://打砂1
                    strSql.Append(string.Format(@"select sum(gaodiyatiaoji) as gaodiyatiaoji,sum(feijiagongaokeng) as feijiagongaokeng,sum(liewen) as liewen,sum(nianmo) as nianmo,sum(qipi) as qipi,sum(youwufahei) as youwufahei,sum(cuoshang) as cuoshang,sum(shangzhouchengjushang) as shangzhouchengjushang,sum(chongshang) as chongshang,sum(bengliao) as bengliao,sum(penghuashang) as penghuashang,sum(hmianhuashang) as hmianhuashang,sum(xiankawai) as xiankawai,sum(luodipin) as luodipin,sum(qita) as qita from DaShaBaoFeiDetail where dashatype=1 and liuchengpiaohao in(select liuchengpiaobianhao from CommonWorkShopRecord  where workshoptype=1 and strftime('%Y-%m',  time)='{0}')", time));
                    break;
                case "2"://打砂2
                    strSql.Append(string.Format(@"select sum(gaodiyatiaoji) as gaodiyatiaoji,sum(feijiagongaokeng) as feijiagongaokeng,sum(liewen) as liewen,sum(nianmo) as nianmo,sum(qipi) as qipi,sum(youwufahei) as youwufahei,sum(cuoshang) as cuoshang,sum(shangzhouchengjushang) as shangzhouchengjushang,sum(chongshang) as chongshang,sum(bengliao) as bengliao,sum(penghuashang) as penghuashang,sum(hmianhuashang) as hmianhuashang,sum(xiankawai) as xiankawai,sum(luodipin) as luodipin,sum(qita) as qita from DaShaBaoFeiDetail where dashatype=2 and liuchengpiaohao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=2 and strftime('%Y-%m',  time)='{0}')", time));
                    break;
                case "3"://披锋组
                    strSql.Append(string.Format(@"select
sum(feijiagongaokeng) as feijiagongaokeng,sum(liewen) as liewen,sum(nianmo) as nianmo,sum(lamo) as lamo,sum(qipi) as qipi,sum(youwufahei) as youwufahei,sum(lengliao) as lengliao,sum(cuoshang) as cuoshang,sum(shangzhouchengjushang) as shangzhouchengjushang,sum(chongshang) as chongshang,sum(bengliao) as bengliao,sum(penghuashang) as penghuashang,sum(hmianhuashang) as hmianhuashang,sum(hmianbianxing) as hmianbianxing,sum(yashang) as yashang,sum(xiankawai) as xiankawai,sum(luodipin) as luodipin,sum(abbdashang) as abbdashang,sum(qita) as qita from piFengBaoFeiDetail where liuchengpiaohao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=3 and strftime('%Y-%m',  time)='{0}')", time));
                    break;
                case "4"://披锋组H
                    strSql.Append(string.Format(@"select sum(shayan) as shayan,sum(feijiagongmianaokeng) as feijiagongmianaokeng,sum(liewen) as liewen,sum(nianmo) as nianmo,sum(lamo) as lamo,sum(qipi) as qipi,sum(youwufahei) as youwufahei,sum(lengliao) as lengliao,sum(cuoshang) as cuoshang,sum(shangzhouchengjushang) as shangzhouchengjushang,sum(chongshang) as chongshang,sum(bengliao) as bengliao,sum(penghuashang) as penghuashang,sum(hmianhuashang) as hmianhuashang,sum(rjiaobianxing) as rjiaobianxing,sum(hmianbianxing) as hmianbianxing,sum(yashang) as yashang,sum(xiankawai) as xiankawai,sum(luodipin) as luodipin,sum(assdashang) as assdashang,sum(gubao) as gubao,sum(aokeng) as aokeng,sum(cuzaodugao) as cuzaodugao,sum(qita) as qita from PiFengHBaiFeiDetail where liuchengpiaohao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=4 and strftime('%Y-%m',  time)='{0}')", time));
                    break;
                case "5"://拉线统计
                    strSql.Append(string.Format(@"select sum(cnctiaojipin) as type1,sum(falanmianyashang) as type2,sum(hmianyashang) as type3,sum(jinqikoukepeng) as type4,sum(shangzhouchengkongkepeng) as type5,sum(daowen) as type6,sum(kongjingchaocha) as type7,sum(shuiyin) as type8,sum(zangwu) as type9,sum(jiagongbuliang) as type10,sum(shakong) as type11,sum(liewen) as type12,sum(bengque) as type13,sum(feihua) as type14,sum(feipeng) as type15,sum(qipi) as type16,sum(zazhi) as type17,sum(nianmo) as type18,sum(maopeifamei) as type19,sum(yanghuafahei) as type20,sum(luodi) as type21,sum(qita) as type22,sum(lamo) as type23,sum(xiankawai) as type24,sum(chouyangshu) as type25 from QuanJianDetail where type=1 and liuchengpiaobianhao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=5 and strftime('%Y-%m',  time)='{0}')", time));
                    break;
                case "6"://清洗统计
                    strSql.Append(string.Format(@"select sum(luodi) as type1,sum(qita) as type2,sum(chouyangshu) as type3 from QuanJianDetail where type=2 and liuchengpiaobianhao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=6 and strftime('%Y-%m',  time)='{0}')", time));
                    break;
                case "7"://CNC统计
                    strSql.Append(string.Format(@"select sum(cnctiaojipin) as type1,sum(falanmianyashang) as type2,sum(hmianyashang) as type3,sum(jinqikoukepeng) as type4,sum(shangzhouchengkongkepeng) as type5,sum(daowen) as type6,sum(kongjingchaocha) as type7,sum(shuiyin) as type8,sum(zangwu) as type9,sum(jiagongbuliang) as type10,sum(shakong) as type11,sum(liewen) as type12,sum(bengque) as type13,sum(feijiagongmianaokeng) as type14,sum(qipi) as type15,sum(zazhi) as type16,sum(nianmo) as type17,sum(maopeifamei) as type18,sum(yanghuafahei) as type19,sum(luodi) as type20,sum(qita) as type21,sum(lvxue) as type22,sum(chouyangshu) as type23 from QuanJianDetail where type=3 and liuchengpiaobianhao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=7 and strftime('%Y-%m',  time)='{0}')", time));
                    break;
                case "8"://测漏统计
                    strSql.Append(string.Format(@"select sum(falanmianhuahenpengshang) as type1,sum(shangzhouchengkongkepeng) as type2,sum(jiagongbuliang) as type3,sum(luodi) as type4,sum(qipi) as type5,sum(lvxue) as type6,sum(qita) as type7 from QuanJianDetail where type=4 and liuchengpiaobianhao in(select liuchengpiaobianhao from CommonWorkShopRecord where workshoptype=8 and strftime('%Y-%m',  time)='{0}')", time));
                    break;
                default:
                    break;
            }

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }

        public DataTable GetInfoByOne(string strWhere)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT time,yazhujihao,maopeihao,muhao,liuchengpiaobianhao,banci,jihuashengchanshu,shengchanzongshu,jishuqishu,baofeizongshu,baofeilv,fanxiuzongshu,fanxiulv,xianhao,gongxu,workshoptype,gonghao,yazhuquexian,cuopifengquexian,pinjianquexian from CommonWorkShopRecord ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        //获取压铸车间数据的天数的第一个和最后一个
        public DataTable GetTimeDayList(string time)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT strftime('%Y-%m-%d',  time) as time from CommonWorkShopRecord where workshoptype=0 and strftime('%Y-%m',time)='{0}' GROUP BY strftime('%Y-%m-%d',time) order by time", time));

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetMonthList()
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT strftime('%Y-%m',  time) as time from CommonWorkShopRecord where workshoptype=0 GROUP BY strftime('%Y-%m',time) order by time");

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetNum(string shebeibianhao, string lingjianbianhao, string time, string daynight)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu from CommonWorkShopRecord where workshoptype=0 and strftime('%Y-%m-%d',time)='{0}' and (yazhujihao='{1}' or yazhujihao='{4}') and maopeihao='{2}' and banci='{3}'", time, shebeibianhao, lingjianbianhao, daynight, shebeibianhao.TrimEnd('#')));

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }

        public DataTable GetNumByDay(string time, string shenchanbianhaolist, string lingjianbianhaolist)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu,sum(yazhuquexian) as yazhuquexian,sum(cuopifengquexian) as cuopifengquexian,sum(pinjianquexian) as pinjianquexian,sum(jishuqishu) as jishuqishu from CommonWorkShopRecord where workshoptype=0 and strftime('%Y-%m-%d',time)='{0}' and yazhujihao in ({1}) and maopeihao in ({2}) ", time, shenchanbianhaolist, lingjianbianhaolist));

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetDaShaNum(string dashaindex, string time)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu,sum(yazhuquexian) as yazhuquexian,sum(cuopifengquexian) as cuopifengquexian,sum(pinjianquexian) as pinjianquexian from CommonWorkShopRecord where workshoptype in ({0}) and strftime('%Y-%m-%d',time)='{1}'", dashaindex, time));

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetDaShaDayCount(int dashaindex, string time, string banci)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu from CommonWorkShopRecord where workshoptype = {0} and strftime('%Y-%m-%d',time)='{1}' and banci ='{2}'", dashaindex, time, banci));

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetCuoPiFengDayCount(int xianhao, string lingjianbianhao, string time, string banci)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu from CommonWorkShopRecord where workshoptype = 3 and strftime('%Y-%m-%d',time)='{1}' and banci ='{2}' and maopeihao='{3}'", xianhao.ToString() + "#", time, banci, lingjianbianhao));

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetCuoPiFengNum(string xianhao, string time, string lingjianbianhao)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu,sum(yazhuquexian) as yazhuquexian,sum(cuopifengquexian) as cuopifengquexian,sum(pinjianquexian) as pinjianquexian from CommonWorkShopRecord where workshoptype = 3 and strftime('%Y-%m-%d',time)='{0}' and xianhao in ({1}) and maopeihao in ({2})", time, xianhao, lingjianbianhao));

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetShouDongCuoPiFengDayCount(string xianhao, string time, string banci)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu from CommonWorkShopRecord where workshoptype = 3 and strftime('%Y-%m-%d',time)='{0}' and banci ='{1}' and gonghao={2}", time, banci, xianhao));

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetShouDongCuoPiFengDayCount(string bianhao, string time)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu,sum(yazhuquexian) as yazhuquexian,sum(cuopifengquexian) as cuopifengquexian,sum(pinjianquexian) as pinjianquexian from CommonWorkShopRecord where workshoptype = 3 and strftime('%Y-%m-%d',time)='{0}' and gonghao in ({1})", time, bianhao));

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetQuanJianDayCounts(int xianhao, string time, string banci)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu from CommonWorkShopRecord where workshoptype = 4 and strftime('%Y-%m-%d',time)='{0}' and banci ='{1}' and xianhao={2}", time, banci, xianhao.ToString() + "#"));

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        public DataTable GetQuanJianNum(string xianhao, string time)
        {
            DataTable dt = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("SELECT sum(shengchanzongshu) as shengchanzongshu,sum(yazhuquexian) as yazhuquexian,sum(cuopifengquexian) as cuopifengquexian,sum(pinjianquexian) as pinjianquexian from CommonWorkShopRecord where workshoptype = 4 and strftime('%Y-%m-%d',time)='{0}' and xianhao in ({1})", time, xianhao));

            dt = SqliteHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }
        #endregion  ExtensionMethod
    }
}

