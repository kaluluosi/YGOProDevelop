using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YGOProDevelop.CDBEditor.Cfg;

namespace YGOProDevelop.CDBEditor.Cfg {
    /// <summary>
    /// 设置配置类，相当于CardEditor各选项配置信息的配置文件对象。
    /// 配置类，用来作为资源给xaml绑定用
    /// </summary>
    public class SettingConfig {

        public static List<VarItem> Ots {
            get {
                return ConfigManager.Load("Ot");
            }
        }

        public static List<VarItem> Races {
            get {
                return ConfigManager.Load("Race");
            }
        }

        public static List<VarItem> Attributes {
            get {
                return ConfigManager.Load("Attribute");
            }
        }

        public static List<VarItem> Categorys {
            get {
                return ConfigManager.Load("Category");
            }
        }

        public static List<VarItem> SetCodes {
            get {
                return ConfigManager.Load("SetCode");
            }
        }

        public static List<VarItem> Types {
            get {
                return ConfigManager.Load("Type");
            }
        }

        public static List<VarItem> StarLevel {
            get {
                return ConfigManager.Load("StarLevel");
            }
        }
    }
}
