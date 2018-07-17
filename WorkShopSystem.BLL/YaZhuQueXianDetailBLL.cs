/**  版本信息模板在安装目录下，可自行修改。
* YaZhuQueXianDetail.cs
*
* 功 能： N/A
* 类 名： YaZhuQueXianDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/17 10:46:40   N/A    初版
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
	/// YaZhuQueXianDetail
	/// </summary>
	public partial class YaZhuQueXianDetailBLL
	{
		private readonly WorkShopSystem.DAL.YaZhuQueXianDetailDAL dal=new WorkShopSystem.DAL.YaZhuQueXianDetailDAL();
		public YaZhuQueXianDetailBLL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WorkShopSystem.Model.YaZhuQueXianDetail model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WorkShopSystem.Model.YaZhuQueXianDetail model)
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
		public WorkShopSystem.Model.YaZhuQueXianDetail GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WorkShopSystem.Model.YaZhuQueXianDetail GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "YaZhuQueXianDetailModel-" ;
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
				catch{}
			}
			return (WorkShopSystem.Model.YaZhuQueXianDetail)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataTable GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WorkShopSystem.Model.YaZhuQueXianDetail> GetModelList(string strWhere)
		{
			DataTable ds = dal.GetList(strWhere);
			return DataTableToList(ds);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WorkShopSystem.Model.YaZhuQueXianDetail> DataTableToList(DataTable dt)
		{
			List<WorkShopSystem.Model.YaZhuQueXianDetail> modelList = new List<WorkShopSystem.Model.YaZhuQueXianDetail>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WorkShopSystem.Model.YaZhuQueXianDetail model;
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
		//public int GetRecordCount(string strWhere)
		//{
		//	return dal.GetRecordCount(strWhere);
		//}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataTable GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

