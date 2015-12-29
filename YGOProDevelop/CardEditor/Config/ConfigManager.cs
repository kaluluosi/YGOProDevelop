using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YGOProDevelop.CardEditor.Config {
    /// <summary>
    /// 专门用来读取和管理配置缓存的类
    /// </summary>
    public class ConfigManager {

        /// <summary>
        /// 数据缓存
        /// </summary>
        public static Dictionary<string, List<VarItem>> dataCache = new Dictionary<string, List<VarItem>>();

        /// <summary>
        /// 通过文件名获取配置
        /// </summary>
        /// <param name="fileName">配置文件名不带后缀的</param>
        /// <returns></returns>
        public static List<VarItem> Load(string fileName) {

            //如果缓存里面有这个配置就直接返还
            if (dataCache.ContainsKey(fileName)&& dataCache[fileName] != null)
                return dataCache[fileName];

            //如果缓存里没这个配置就第一次读取
            string path = GetDefaultConfigPath(fileName);

            //校验是路径是否有效
            if (File.Exists(path) == false)
                throw new FileNotFoundException("文件没找到", path);

            //读取
            List<VarItem> items = new List<VarItem>();
            XmlSerializer xmlSerializer = new XmlSerializer(items.GetType());
            FileStream fs = new FileStream(path, FileMode.Open);
            using (fs) {
                try {
                    items = xmlSerializer.Deserialize(fs) as List<VarItem>;
                }
                catch (InvalidOperationException ex) {
                    throw ;
                }
            }

            //如果配置没有内容可能会读到空的items，不过这是允许的。
            dataCache.Add(fileName, items);

            return items;
        }

        public static void Save(string fileName,IEnumerable<VarItem> collection) {
            string path = GetDefaultConfigPath(fileName);

            if (collection == null)
                throw new ArgumentNullException("要保存的集合为空");

            List<VarItem> items = new List<VarItem>(collection);
            XmlSerializer xmlSerializer = new XmlSerializer(items.GetType());
            FileStream fs = new FileStream(path,FileMode.Create);
            using (fs) {
                try {
                    xmlSerializer.Serialize(fs, items);
                }
                catch (InvalidOperationException ex) {
                    throw;
                }
            }
        }

        /// <summary>
        /// 获取默认的配置文件夹路径
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultConfigFolderPath() {
//             string currentDirectory = Directory.GetCurrentDirectory();
//             string defCfgPath = currentDirectory + @"\Data\";
            string defCfgPath = Path.GetFullPath(@".\Data");
            return defCfgPath;
        }

        /// <summary>
        /// 通过fileName获取默认的配置文件fullName,fileName不能带后缀
        /// </summary>
        /// <param name="fileName">不带后缀的文件名</param>
        /// <returns></returns>
        public static string GetDefaultConfigPath(string fileName) {
            return GetDefaultConfigFolderPath()+@"\" + fileName+".xml";
        }

    }
}
