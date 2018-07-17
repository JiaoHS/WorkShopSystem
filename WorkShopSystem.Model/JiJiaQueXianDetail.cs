/**  版本信息模板在安装目录下，可自行修改。
* QuanJianDetail.cs
*
* 功 能： N/A
* 类 名： QuanJianDetail
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
	/// QuanJianDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class JiJiaQueXianDetail
	{
		public JiJiaQueXianDetail()
		{}
        #region Model
        private DateTime? _time;
        private decimal? _cnctiaojipin=0M;
		private decimal? _falanmianyashang=0M;
		private decimal? _falanmianhuahenpengshang=0M;
		private decimal? _hmianyashang=0M;
		private decimal? _jinqikoukepeng=0M;
		private decimal? _shangzhouchengkongkepeng=0M;
		private decimal? _daowen=0M;
		private decimal? _kongjingchaocha=0M;
		private decimal? _shuiyin=0M;
		private decimal? _zangwu=0M;
		private decimal? _jiagongbuliang=0M;
		private decimal? _shakong=0M;
		private decimal? _liewen=0M;
		private decimal? _bengque=0M;
		private decimal? _feihua=0M;
		private decimal? _feipeng=0M;
		private decimal? _qipi=0M;
		private decimal? _zazhi=0M;
		private decimal? _nianmo=0M;
		private decimal? _maopeifamei=0M;
		private decimal? _yanghuafahei=0M;
		private decimal? _luodi=0M;
		private decimal? _qita=0M;
		private decimal? _lamo=0M;
		private decimal? _xiankawai=0M;
		private decimal? _chouyangshu=0M;
		private string _gonghao;
		private decimal? _feijiagongmianaokeng=0M;
		private decimal? _lvxue=0M;
		private int? _type=0;
		private string _liuchengpiaobianhao;

        public DateTime? time
        {
            set { _time = value; }
            get { return _time; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal? cnctiaojipin
		{
			set{ _cnctiaojipin=value;}
			get{return _cnctiaojipin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? falanmianyashang
		{
			set{ _falanmianyashang=value;}
			get{return _falanmianyashang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? falanmianhuahenpengshang
		{
			set{ _falanmianhuahenpengshang=value;}
			get{return _falanmianhuahenpengshang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? hmianyashang
		{
			set{ _hmianyashang=value;}
			get{return _hmianyashang;}
		}
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
		public decimal? shangzhouchengkongkepeng
		{
			set{ _shangzhouchengkongkepeng=value;}
			get{return _shangzhouchengkongkepeng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? daowen
		{
			set{ _daowen=value;}
			get{return _daowen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? kongjingchaocha
		{
			set{ _kongjingchaocha=value;}
			get{return _kongjingchaocha;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? shuiyin
		{
			set{ _shuiyin=value;}
			get{return _shuiyin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? zangwu
		{
			set{ _zangwu=value;}
			get{return _zangwu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? jiagongbuliang
		{
			set{ _jiagongbuliang=value;}
			get{return _jiagongbuliang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? shakong
		{
			set{ _shakong=value;}
			get{return _shakong;}
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
		public decimal? bengque
		{
			set{ _bengque=value;}
			get{return _bengque;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? feihua
		{
			set{ _feihua=value;}
			get{return _feihua;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? feipeng
		{
			set{ _feipeng=value;}
			get{return _feipeng;}
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
		public decimal? zazhi
		{
			set{ _zazhi=value;}
			get{return _zazhi;}
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
		public decimal? maopeifamei
		{
			set{ _maopeifamei=value;}
			get{return _maopeifamei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? yanghuafahei
		{
			set{ _yanghuafahei=value;}
			get{return _yanghuafahei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? luodi
		{
			set{ _luodi=value;}
			get{return _luodi;}
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
		public decimal? lamo
		{
			set{ _lamo=value;}
			get{return _lamo;}
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
		public decimal? feijiagongmianaokeng
		{
			set{ _feijiagongmianaokeng=value;}
			get{return _feijiagongmianaokeng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? lvxue
		{
			set{ _lvxue=value;}
			get{return _lvxue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? type
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
		#endregion Model

	}
}

