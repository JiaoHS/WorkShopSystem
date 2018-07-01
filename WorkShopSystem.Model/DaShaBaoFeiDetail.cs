/**  版本信息模板在安装目录下，可自行修改。
* DaShaBaoFeiDetail.cs
*
* 功 能： N/A
* 类 名： DaShaBaoFeiDetail
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
namespace WorkShopSystem.Model
{
	/// <summary>
	/// DaShaBaoFeiDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DaShaBaoFeiDetail
	{
		public DaShaBaoFeiDetail()
		{}
		#region Model
		private int _id;
		private decimal? _gaodiyatiaoji=0M;
		private decimal? _feijiagongaokeng=0M;
		private decimal? _liewen=0M;
		private decimal? _nianmo=0M;
		private decimal? _qipi=0M;
		private decimal? _youwufahei=0M;
		private decimal? _cuoshang=0M;
		private decimal? _shangzhouchengjushang=0M;
		private decimal? _chongshang=0M;
		private decimal? _bengliao=0M;
		private decimal? _penghuashang=0M;
		private decimal? _hmianhuashang=0M;
		private decimal? _xiankawai=0M;
		private decimal? _luodipin=0M;
		private decimal? _qita=0M;
		private decimal? _chouyangshu=0M;
		private string _gonghao;
		private string _liuchengpiaohao;
		private decimal? _dashatype=0M;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? gaodiyatiaoji
		{
			set{ _gaodiyatiaoji=value;}
			get{return _gaodiyatiaoji;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? feijiagongaokeng
		{
			set{ _feijiagongaokeng=value;}
			get{return _feijiagongaokeng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? liewen
		{
			set{ _liewen=value;}
			get{return _liewen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? nianmo
		{
			set{ _nianmo=value;}
			get{return _nianmo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? qipi
		{
			set{ _qipi=value;}
			get{return _qipi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? youwufahei
		{
			set{ _youwufahei=value;}
			get{return _youwufahei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cuoshang
		{
			set{ _cuoshang=value;}
			get{return _cuoshang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? shangzhouchengjushang
		{
			set{ _shangzhouchengjushang=value;}
			get{return _shangzhouchengjushang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? chongshang
		{
			set{ _chongshang=value;}
			get{return _chongshang;}
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
		public decimal? penghuashang
		{
			set{ _penghuashang=value;}
			get{return _penghuashang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? hmianhuashang
		{
			set{ _hmianhuashang=value;}
			get{return _hmianhuashang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? xiankawai
		{
			set{ _xiankawai=value;}
			get{return _xiankawai;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? luodipin
		{
			set{ _luodipin=value;}
			get{return _luodipin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? qita
		{
			set{ _qita=value;}
			get{return _qita;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? chouyangshu
		{
			set{ _chouyangshu=value;}
			get{return _chouyangshu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gonghao
		{
			set{ _gonghao=value;}
			get{return _gonghao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string liuchengpiaohao
		{
			set{ _liuchengpiaohao=value;}
			get{return _liuchengpiaohao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? dashaType
		{
			set{ _dashatype=value;}
			get{return _dashatype;}
		}
		#endregion Model

	}
}

