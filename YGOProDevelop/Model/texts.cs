//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YGOProDevelop.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class texts
    {
        public long id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string str1 { get; set; }
        public string str2 { get; set; }
        public string str3 { get; set; }
        public string str4 { get; set; }
        public string str5 { get; set; }
        public string str6 { get; set; }
        public string str7 { get; set; }
        public string str8 { get; set; }
        public string str9 { get; set; }
        public string str10 { get; set; }
        public string str11 { get; set; }
        public string str12 { get; set; }
        public string str13 { get; set; }
        public string str14 { get; set; }
        public string str15 { get; set; }
        public string str16 { get; set; }
    
        public virtual datas datas { get; set; }

//         private List<string> strs;
//         public List<string> Strs {
//             get {
//                 if(strs == null) {
//                     strs = new List<string>() {str1,str2,str3,str4,str5,str6,str7,str8,str9,str10,str11,str12,str13,str14,str15,str16};
//                 }
//                 return strs;
//             }
//         }

        public texts Copy() {
            return MemberwiseClone() as texts;
        }
    }
}
