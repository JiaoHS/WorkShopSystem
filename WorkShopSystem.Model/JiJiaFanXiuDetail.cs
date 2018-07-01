/**  版本信息模板在安装目录下，可自行修改。
* JiJiaFanXiuDetail.cs
*
* 功 能： N/A
* 类 名： JiJiaFanXiuDetail
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
namespace WorkShopSystem.Model
{
	/// <summary>
	/// JiJiaFanXiuDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class JiJiaFanXiuDetail
	{
		public JiJiaFanXiuDetail()
		{}
		#region Model
		private decimal? _jinqikoukepeng=0M;
		private decimal? _falanmianhuashang=0M;
		private decimal? _pensha=0M;
		private decimal? _kefanxipin=0M;
		private decimal? _kefanfamei=0M;
		private decimal? _xiaoshakongkefanxiu=0M;
		private string _beizhu;
		private string _liuchengpiaobianhao;
		private decimal? _louqi=0M;
		/// <summary>
		/// 
		/// </summary>
		public decimal? jinqikoukepeng
		{
			set{ _jinqikoukepeng=value;}
			get{return _jinqikoukepeng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? falanmianhuashang
		{
			set{ _falanmianhuashang=value;}
			get{return _falanmianhuashang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? pensha
		{
			set{ _pensha=value;}
			get{return _pensha;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? kefanxipin
		{
			set{ _kefanxipin=value;}
			get{return _kefanxipin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? kefanfamei
		{
			set{ _kefanfamei=value;}
			get{return _kefanfamei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? xiaoshakongkefanxiu
		{
			set{ _xiaoshakongkefanxiu=value;}
			get{return _xiaoshakongkefanxiu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string beizhu
		{
			set{ _beizhu=value;}
			get{return _beizhu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string liuchengpiaobianhao
		{
			set{ _liuchengpiaobianhao=value;}
			get{return _liuchengpiaobianhao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? louqi
		{
			set{ _louqi=value;}
			get{return _louqi;}
		}
		#endregion Model

	}
}

