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
namespace WorkShopSystem.Model
{
	/// <summary>
	/// CommonWorkShopRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CommonWorkShopRecord
	{
		public CommonWorkShopRecord()
		{}
		#region Model
		private DateTime? _time;
		private string _yazhujihao;
		private string _maopeihao;
		private string _muhao;
		private string _liuchengpiaobianhao;
		private string _banci;
		private decimal? _jihuashengchanshu=0M;
		private decimal? _shengchanzongshu=0M;
		private decimal? _jishuqishu=0M;
		private decimal? _baofeizongshu=0M;
		private decimal? _baofeilv=0M;
		private decimal? _fanxiuzongshu=0M;
		private decimal? _fanxiulv=0M;
		private string _xianhao;
		private string _gongxu;
		private decimal? _workshoptype;
		private string _gonghao;
		private int? _isdel=0;
		private decimal? _yazhuquexian=0M;
		private decimal? _cuopifengquexian=0M;
		private decimal? _pinjianquexian=0M;
		private decimal? _jijiaquexian=0M;
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
		public string yazhujihao
		{
			set{ _yazhujihao=value;}
			get{return _yazhujihao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maopeihao
		{
			set{ _maopeihao=value;}
			get{return _maopeihao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string muhao
		{
			set{ _muhao=value;}
			get{return _muhao;}
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
		public string banci
		{
			set{ _banci=value;}
			get{return _banci;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? jihuashengchanshu
		{
			set{ _jihuashengchanshu=value;}
			get{return _jihuashengchanshu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? shengchanzongshu
		{
			set{ _shengchanzongshu=value;}
			get{return _shengchanzongshu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? jishuqishu
		{
			set{ _jishuqishu=value;}
			get{return _jishuqishu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? baofeizongshu
		{
			set{ _baofeizongshu=value;}
			get{return _baofeizongshu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? baofeilv
		{
			set{ _baofeilv=value;}
			get{return _baofeilv;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fanxiuzongshu
		{
			set{ _fanxiuzongshu=value;}
			get{return _fanxiuzongshu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fanxiulv
		{
			set{ _fanxiulv=value;}
			get{return _fanxiulv;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xianhao
		{
			set{ _xianhao=value;}
			get{return _xianhao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gongxu
		{
			set{ _gongxu=value;}
			get{return _gongxu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? workshoptype
		{
			set{ _workshoptype=value;}
			get{return _workshoptype;}
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
		public int? isdel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? yazhuquexian
		{
			set{ _yazhuquexian=value;}
			get{return _yazhuquexian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cuopifengquexian
		{
			set{ _cuopifengquexian=value;}
			get{return _cuopifengquexian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? pinjianquexian
		{
			set{ _pinjianquexian=value;}
			get{return _pinjianquexian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? jijiaquexian
		{
			set{ _jijiaquexian=value;}
			get{return _jijiaquexian;}
		}
		#endregion Model

	}
}

