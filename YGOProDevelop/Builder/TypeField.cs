using System;
using System.Collections.Generic;
using YGOProDevelop.CDBEditor.Cfg;

namespace YGOProDevelop.Builder {
	/// <summary>
	/// 类型字段,父类型为单选,子类型可能为单选可能为多选
	/// </summary>
	public class TypeField:Field 
	{	
		public static VarItem GetTypeItem(Int64 value){
			List<VarItem> cfg = ConfigManager.Load("Type");
			VarItem result = cfg.Find(item=>item.BeContainedIn(value));
			return result;
		}

		public static List<VarItem> GetSubTypeItems(VarItem parentType,Int64 value){
			if (parentType == null)
				return null;
			List<VarItem> items = parentType.SubItems.FindAll(item=>item.BeContainedIn(value));
            if (parentType.MultiSelect == false && items.Count == 0)
                items.Add(parentType.SubItems[0]);
            return items;
        }

        public static List<VarItem> GetSubTypeItems(Int64 value) {
            return GetSubTypeItems(GetTypeItem(value), value);
        }

		public TypeField(){
			SubTypeItems = new List<VarItem>();
		}

		public TypeField(Int64 value){
			//获取父类型
			this.TypeItem = GetTypeItem(value);
			//获取子类型
			this.SubTypeItems = GetSubTypeItems(this.TypeItem,value);
		}

		public VarItem TypeItem { get; set; } 	
		public List<VarItem> SubTypeItems { get; set; }

		public override Int64 Value{
			get{
				//Type SubType可能为null
				if(TypeItem==null||SubTypeItems==null) return 0;

				Int64 value =0;
				value ^= TypeItem.Value;
				foreach (VarItem subType in SubTypeItems) 
				{
					value ^= subType.Value;
				}

				return value;
			}
		}

	}
}

