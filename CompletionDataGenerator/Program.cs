using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YGOProDevelop.Model;

namespace CompletionDataGenerator {
    class Program {
        static void Main(string[] args) {
            List<CompletionItem> datas = new List<CompletionItem>();
            datas.Add(new CompletionItem() { Description="desc",Text="text",Content = "content", Priority = 0f, Image = "icon" });
            XmlSerializer serializer = new XmlSerializer(datas.GetType());
            StreamWriter sw = new StreamWriter(@".\YGOApi.xml");
            serializer.Serialize(sw, datas);
            sw.Close();
        }
    }
}
