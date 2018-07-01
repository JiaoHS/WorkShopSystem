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
namespace WorkShopSystem.Model
{
	/// <summary>
	/// YaZhuBaoFeiDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class YaZhuBaoFeiDetail
	{
		public YaZhuBaoFeiDetail()
		{}
		#region Model
		private int _id;
		private decimal? _tiaojipin=0M;
		private decimal? _feijiagongaokeng=0M;
		private decimal? _liewen=0M;
		private decimal? _nainmo=0M;
		private decimal? _lamo=0M;
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
		private decimal? _shangzhouchengkongduanlie=0M;
		private decimal? _jitan=0M;
		private decimal? _lengliao=0M;
		private decimal? _qita=0M;
		private decimal? _chouyangshu=0M;
		private string _gonghao;
		private string _liuchengpiaohao;
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
		public decimal? tiaojipin
		{
			set{ _tiaojipin=value;}
			get{return _tiaojipin;}
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
		public decimal? nainmo
		{
			set{ _nainmo=value;}
			get{return _nainmo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? lamo
		{
			set{ _lamo=value;}
			get{return _lamo;}
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
		public decimal? shangzhouchengkongduanlie
		{
			set{ _shangzhouchengkongduanlie=value;}
			get{return _shangzhouchengkongduanlie;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? jitan
		{
			set{ _jitan=value;}
			get{return _jitan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? lengliao
		{
			set{ _lengliao=value;}
			get{return _lengliao;}
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
		#endregion Model

	}
}

