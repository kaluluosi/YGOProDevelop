﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace YGOProDevelop.CardEditor.Config {
    public class VarItem {

		public static readonly VarItem Default= new VarItem(){Description="无",Value=0,MultiSelect=false};

        /// <summary>
        /// 用于显示的中文描述
        /// </summary>
		[XmlAttribute()]
        public string Description {
            get;
            set;
        }

        /// <summary>
        /// 用于计算并保存到数据库的值
        /// </summary>
		[XmlAttribute()]
		public Int64 Value {
            get;
            set;
        }

        /// <summary>
        /// 这个设置的小贴士
        /// </summary>
		[XmlAttribute()]
        public string Tips {
            get;
            set;
        }

        public List<VarItem> SubItems {
            get;
            set;
        }

        /// <summary>
        /// 是否是多选
        /// </summary>
		[XmlAttribute()]
        public bool MultiSelect {
            get;
            set;
        }

		public bool BeContainedIn(Int64 value){
            return (this.Value & value)!=0;
        }
        
        public override string ToString() {
            return Description;
        }

        public static long MergeValue(IEnumerable<VarItem> items) {
            long value = 0;
            foreach(var item in items) {
                value ^= item.Value;
            }
            return value;
        }
    }
}
