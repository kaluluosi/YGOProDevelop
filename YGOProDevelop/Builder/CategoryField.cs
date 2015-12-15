using System;
using System.Collections.Generic;
using YGOProDevelop.CDBEditor.Cfg;

namespace YGOProDevelop.Builder {
	/// <summary>
	/// 效果分类字段,多选
	/// </summary>
	public class CategoryField:Field 
	{	
		/// <summary>
		/// 如果value的值在配置里找不到则返回Null
		/// </summary>
		public static List<VarItem> GetCategoryItems(Int64 value) 
		{
			List<VarItem> cfg = ConfigManager.Load("Category");
			List<VarItem> results = cfg.FindAll(item=>item.BeContainedIn(value));
			return results;
		}

		public CategoryField(){
			CategoryItems = new List<VarItem>();
		}

		public CategoryField(Int64 value){
			this.CategoryItems = GetCategoryItems(value);
		}

		public List<VarItem> CategoryItems { get; set; }

		public override Int64 Value{
			get{
				Int64 value=0;
				//如郭Category为Null则会掉过这个循环直接返回value=0的值
				foreach (VarItem category in CategoryItems) 
				{
					value ^= category.Value;
				}
				return value;
			}
		}
	}
}

