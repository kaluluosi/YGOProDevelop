using System;
using System.Collections.Generic;
using YGOProDevelop.CardEditor.Config;

namespace YGOProDevelop.CardEditor.Builder {
	/// <summary>
	/// 系列前缀字段,4个值每个值都单选
	/// </summary>
	public class SetCodeField:Field 
	{	

		/// <summary>
		/// 如果value的值在配置里找不到则返回Null
		/// </summary>
		public static VarItem[] GetSetCodeItems(Int64 value){
			List<VarItem> cfg = ConfigManager.Load("SetCode");
			List<VarItem> result = new List<VarItem>();
			VarItem setCode1 = cfg.Find(item=>item.Value==value);
			value = value >>16;                    
			VarItem setCode2 = cfg.Find(item=>item.Value==value);
			value = value >>16;		               
			VarItem setCode3 = cfg.Find(item=>item.Value==value);
			value = value >>16;		               
			VarItem setCode4 = cfg.Find(item=>item.Value==value);

			//setcode配置表不一定会配置"无"选项,读取到的setccode可能都为null,做个保险.
			if(setCode1==null) setCode1 = VarItem.Default;
			if(setCode2==null) setCode2 = VarItem.Default;
			if(setCode3==null) setCode3 = VarItem.Default;
			if(setCode4==null) setCode4 = VarItem.Default;

			result.Add(setCode1);
			result.Add(setCode2);
			result.Add(setCode3);
			result.Add(setCode4);

			return result.ToArray();
		}

		public SetCodeField(){
			SetCodeItems = new VarItem[4];
			for (Int64 i=0;i<4;i++) 
			{
				SetCodeItems[i] = VarItem.Default;
			}
		}

		public SetCodeField(Int64 value){
			this.SetCodeItems = GetSetCodeItems(value);
		}

		public VarItem[] SetCodeItems { get; set; }

		public override Int64 Value{
			get{

				Int64 val = 0;
				//setcodes默认值为0
				val ^= SetCodeItems[3].Value;
				val = val << 16;
				val ^= SetCodeItems[2].Value;
				val = val << 16;
				val ^= SetCodeItems[1].Value;
				val = val << 16;
				val ^= SetCodeItems[0].Value;
				return val;
			}
		}
	}}

