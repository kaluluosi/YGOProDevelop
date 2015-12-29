using System;
using YGOProDevelop.CardEditor.Config;

namespace YGOProDevelop.CardEditor.Builder {
	public abstract class Field 
	{
		/// <summary>
		/// 重写这个属性来获取值
		/// </summary>
		public virtual Int64 Value { get; set;}		
    }
}

