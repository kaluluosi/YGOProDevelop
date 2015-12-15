using System;
using System.Collections.Generic;
using YGOProDevelop.CDBEditor.Cfg;

namespace YGOProDevelop.Builder {
	/// <summary>
	/// 种族字段,单选
	/// </summary>
	public class RaceField:Field 
	{
		/// <summary>
		/// 如果value的值在配置里找不到则返回Null
		/// </summary>
		public static VarItem GetRaceItem(Int64 value){
			List<VarItem> cfg = ConfigManager.Load("Race");
			VarItem result = cfg.Find(item=>item.Value==value);
			return result==null?VarItem.Default:result;
		}

		public RaceField(){

		}

		public RaceField(Int64 value){
			RaceItem = GetRaceItem(value);
		}

		public VarItem RaceItem { get; set; }
		public override Int64 Value{
			get{
				return RaceItem.Value;
			}
		}
	}}

