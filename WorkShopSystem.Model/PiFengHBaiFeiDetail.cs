/**  版本信息模板在安装目录下，可自行修改。
* PiFengHBaiFeiDetail.cs
*
* 功 能： N/A
* 类 名： PiFengHBaiFeiDetail
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
	/// PiFengHBaiFeiDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PiFengHBaiFeiDetail
	{
		public PiFengHBaiFeiDetail()
		{}
		#region Model
		private int _id;
		private decimal? _shayan=0M;
		private decimal? _feijiagongmianaokeng=0M;
		private decimal? _liewen=0M;
		private decimal? _nianmo=0M;
		private decimal? _lamo=0M;
		private decimal? _qipi=0M;
		private decimal? _youwufahei=0M;
		private decimal? _lengliao=0M;
		private decimal? _cuoshang=0M;
		private decimal? _shangzhouchengjushang=0M;
		private decimal? _chongshang=0M;
		private decimal? _bengliao=0M;
		private decimal? _penghuashang=0M;
		private decimal? _hmianhuashang=0M;
		private decimal? _hmianbianxing=0M;
		private decimal? _rjiaobianxing=0M;
		private decimal? _yashang=0M;
		private decimal? _xiankawai=0M;
		private decimal? _luodipin=0M;
		private decimal? _assdashang=0M;
		private decimal? _gubao=0M;
		private decimal? _aokeng=0M;
		private decimal? _cuzaodugao=0M;
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
		public decimal? shayan
		{
			set{ _shayan=value;}
			get{return _shayan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? feijiagongmianaokeng
		{
			set{ _feijiagongmianaokeng=value;}
			get{return _feijiagongmianaokeng;}
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
		public decimal? lengliao
		{
			set{ _lengliao=value;}
			get{return _lengliao;}
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
		public decimal? hmianbianxing
		{
			set{ _hmianbianxing=value;}
			get{return _hmianbianxing;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? rjiaobianxing
		{
			set{ _rjiaobianxing=value;}
			get{return _rjiaobianxing;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? yashang
		{
			set{ _yashang=value;}
			get{return _yashang;}
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
		public decimal? assdashang
		{
			set{ _assdashang=value;}
			get{return _assdashang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? gubao
		{
			set{ _gubao=value;}
			get{return _gubao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aokeng
		{
			set{ _aokeng=value;}
			get{return _aokeng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cuzaodugao
		{
			set{ _cuzaodugao=value;}
			get{return _cuzaodugao;}
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

