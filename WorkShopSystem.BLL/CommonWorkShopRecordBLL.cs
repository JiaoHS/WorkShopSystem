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
using System.Collections.Generic;
using Maticsoft.Common;
using WorkShopSystem.Model;
namespace WorkShopSystem.BLL
{
    /// <summary>
    /// CommonWorkShopRecord
    /// </summary>
    public partial class CommonWorkShopRecordBLL
    {
        private readonly WorkShopSystem.DAL.CommonWorkShopRecordDAL dal = new WorkShopSystem.DAL.CommonWorkShopRecordDAL();
        public CommonWorkShopRecordBLL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(WorkShopSystem.Model.CommonWorkShopRecord model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WorkShopSystem.Model.CommonWorkShopRecord model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.Delete();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WorkShopSystem.Model.CommonWorkShopRecord GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.GetModel();
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public WorkShopSystem.Model.CommonWorkShopRecord GetModelByCache()
        {
            //该表无主键信息，请自定义主键/条件字段
            string CacheKey = "CommonWorkShopRecordModel-";
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel();
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (WorkShopSystem.Model.CommonWorkShopRecord)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetListSum(string strWhere)
        {
            return dal.GetListSum(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WorkShopSystem.Model.CommonWorkShopRecord> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WorkShopSystem.Model.CommonWorkShopRecord> DataTableToList(DataTable dt)
        {
            List<WorkShopSystem.Model.CommonWorkShopRecord> modelList = new List<WorkShopSystem.Model.CommonWorkShopRecord>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                WorkShopSystem.Model.CommonWorkShopRecord model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataTable GetMuHaoList(string workType)
        {
            return dal.GetMuHaoList(workType);
        }
        public DataTable GetMaoPiList(string workType)
        {
            return dal.GetMaoPiList(workType);
        }
        public DataTable GetLiuChengPiaoList(string timeStart, string timeEnd, string workType)
        {
            return dal.GetLiuChengPiaoList(timeStart, timeEnd, workType);
        }
        public DataTable GetNumByTime(string workType, string timeStart)
        {
            return dal.GetNumByTime(workType, timeStart);
        }
        public DataTable GetDetailBaoFeiList(string time, string type)
        {
            return dal.GetDetailBaoFeiList(time, type);
        }
        public DataTable GetInfoByOne(string strSql)
        {
            return dal.GetInfoByOne(strSql);
        }
        public DataTable GetAllGroupByTime()
        {
            return dal.GetAllGroupByTime();
        }
        public DataTable GetNumByTimeWorkshoptype(string workType, string timeStart)
        {
            return dal.GetNumByTimeWorkshoptype(workType, timeStart);
        }
        public DataTable GetTimeDayList(string time)
        {
            return dal.GetTimeDayList(time);
        }
        public DataTable GetMonthList()
        {
            return dal.GetMonthList();
        }
        public DataTable GetNum(string shebeibianhao, string lingjianbianhao, string time, string daynight)
        {
            return dal.GetNum(shebeibianhao, lingjianbianhao, time, daynight);
        }

        public DataTable GetNumByDay(string time,string shenchanbianhaolist,string lingjianbianhaolist)
        {
            return dal.GetNumByDay(time, shenchanbianhaolist, lingjianbianhaolist);
        }

        public DataTable GetDaShaNum(string dashaindex,string time)
        {
            return dal.GetDaShaNum(dashaindex, time);
        }

        public DataTable GetDaShaDayCount(int dashaindex, string time,string banci)
        {
            return dal.GetDaShaDayCount(dashaindex, time, banci);
        }

        public DataTable GetCuoPiFengDayCount(int xianhao, string lingjianbianhao, string time, string banci)
        {
            return dal.GetCuoPiFengDayCount(xianhao, lingjianbianhao, time, banci);
        }

        public DataTable GetCuoPiFengNum(string shenchanbianhaolist, string time,string lingjianbianhao)
        {
            return dal.GetCuoPiFengNum(shenchanbianhaolist, time, lingjianbianhao);
        }

        public DataTable GetShouDongCuoPiFengDayCount(string bianhao, string time, string banci)
        {
            return dal.GetShouDongCuoPiFengDayCount(bianhao, time, banci);
        }

        public DataTable GetShouDongCuoPiFengNum(string bianhao, string time)
        {
            return dal.GetShouDongCuoPiFengDayCount(bianhao, time);
        }

        public DataTable GetQuanJianDayCount(int xianhao, string time, string banci)
        {
            return dal.GetQuanJianDayCounts(xianhao, time, banci);
        }

        public DataTable GetQuanJianNum(string xianhao, string time)
        {
            return dal.GetQuanJianNum(xianhao, time);
        }
        #endregion  ExtensionMethod
    }
}

