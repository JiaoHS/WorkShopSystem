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
namespace WorkShopSystem.Model
{
	/// <summary>
	/// YaZhuQueXianDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class YaZhuQueXianDetail
	{
		public YaZhuQueXianDetail()
		{}
		#region Model
		private DateTime? _time;
		private decimal? _gaodiya;
		private decimal? _lamo;
		private decimal? _nianmo;
		private decimal? _kaweichaocha;
		private decimal? _liewen;
		private decimal? _guilie;
		private decimal? _lengliao;
		private decimal? _youwufahei;
		private decimal? _duanzhen;
		private decimal? _qipi;
		private decimal? _jushang;
		private decimal? _yadianshang;
		private decimal? _chongshang;
		private decimal? _bengqueliao;
		private decimal? _penghuashang;
		private decimal? _hmianhuashang;
		private decimal? _xiankawai;
		private decimal? _luodipin;
		private decimal? _gubao;
		private decimal? _jitan;
		private decimal? _shuikouduan;
		private decimal? _aokeng;
		private decimal? _qita;
		private decimal? _cuoshang;
		private decimal? _cuodaohen;
		private decimal? _abbdashang;
		private decimal _assqiexue;
		private decimal? _qupifengqita;
		private decimal? _type;
		private string _liuchengpiaobianhao;
		private decimal? _chouyangshu;
		private string _gonghao;
		/// <summary>
		/// 
		/// </summary>
		public DateTime? time
		{
			set{ _time=value;}
			get{return _time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? gaodiya
		{
			set{ _gaodiya=value;}
			get{return _gaodiya;}
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
		public decimal? nianmo
		{
			set{ _nianmo=value;}
			get{return _nianmo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? kaweichaocha
		{
			set{ _kaweichaocha=value;}
			get{return _kaweichaocha;}
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
		public decimal? guilie
		{
			set{ _guilie=value;}
			get{return _guilie;}
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
		public decimal? youwufahei
		{
			set{ _youwufahei=value;}
			get{return _youwufahei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? duanzhen
		{
			set{ _duanzhen=value;}
			get{return _duanzhen;}
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
		public decimal? jushang
		{
			set{ _jushang=value;}
			get{return _jushang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? yadianshang
		{
			set{ _yadianshang=value;}
			get{return _yadianshang;}
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
		public decimal? bengqueliao
		{
			set{ _bengqueliao=value;}
			get{return _bengqueliao;}
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
		public decimal? Hmianhuashang
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
		public decimal? gubao
		{
			set{ _gubao=value;}
			get{return _gubao;}
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
		public decimal? shuikouduan
		{
			set{ _shuikouduan=value;}
			get{return _shuikouduan;}
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
		public decimal? qita
		{
			set{ _qita=value;}
			get{return _qita;}
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
		public decimal? cuodaohen
		{
			set{ _cuodaohen=value;}
			get{return _cuodaohen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? abbdashang
		{
			set{ _abbdashang=value;}
			get{return _abbdashang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal assqiexue
		{
			set{ _assqiexue=value;}
			get{return _assqiexue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? qupifengqita
		{
			set{ _qupifengqita=value;}
			get{return _qupifengqita;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? type
		{
			set{ _type=value;}
			get{return _type;}
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
		#endregion Model

	}
}

