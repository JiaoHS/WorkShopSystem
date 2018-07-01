/**  版本信息模板在安装目录下，可自行修改。
* fanxiuDetail.cs
*
* 功 能： N/A
* 类 名： fanxiuDetail
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
namespace WorkShopSystem.Model
{
	/// <summary>
	/// fanxiuDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class fanxiuDetail
	{
		public fanxiuDetail()
		{}
		#region Model
		private decimal? _bengliao=0M;
		private decimal? _fanpen=0M;
		private decimal? _zhengxing=0M;
		private string _benzhu;
        private string _liuchengpiaohao;
        public string liuchengpiaohao
        {
            set { _liuchengpiaohao = value; }
            get { return _liuchengpiaohao; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? bengliao
		{
			set{ _bengliao=value;}
			get{return _bengliao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fanpen
		{
			set{ _fanpen=value;}
			get{return _fanpen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? zhengxing
		{
			set{ _zhengxing=value;}
			get{return _zhengxing;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string benzhu
		{
			set{ _benzhu=value;}
			get{return _benzhu;}
		}
		#endregion Model

	}
}

