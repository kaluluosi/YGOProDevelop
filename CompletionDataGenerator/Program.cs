using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YGOProDevelop.Model;

namespace CompletionDataGenerator {
    class Program {
        static void Main(string[] args) {

            var items = MakeCompletionItem();
            Save(items, @".\YGOProApi.xml");
            int level = 117899274;
//             Int64 level = 10;
            //level=10 l=7 r=7

            byte[] bytes = BitConverter.GetBytes(level);
            int lv = BitConverter.ToInt16(bytes,0);
            int l = bytes[2];
            int r = bytes[3];
            r = 10;
            Console.WriteLine("LV:{0} L:{1} R:{2}",lv,l,r);

//             List<int> setcodes = new List<int> { 1, 2, 3, 4 };
//             long var = 0;
//             for(int i = 0; i < 4; i++) {
//                 var ^= setcodes[i] << (i * 8);
//             }
//             var setcode = var;
//             byte[] bs = BitConverter.GetBytes(setcode);
//             Console.Read();
        }

        public static int Get(int index,int value) {
            int mask16 = 0xff;
            int left = 8;

            value = value >> left * index;
            return value & mask16;
        }

        static List<CompletionItem> MakeCompletionItem() {
            List<CompletionItem> tempData = new List<CompletionItem>();
            using (StreamReader sr = new StreamReader(@".\_functions.txt_sort.txt")) {
                Regex reg = new Regex(@"[\w.]*(?=\()");
                string line;
                string funcName="";
                StringBuilder descript = new StringBuilder();
                while (sr.EndOfStream == false) {
                    line = sr.ReadLine();
                    //如果该行以●开头则是函数
                    if (line.StartsWith("●")) {
                        //如果这时候funcname和description不是空的，那么意味着上一个函数已经读完，处理掉
                        if (string.IsNullOrEmpty(funcName) == false) {
                            CompletionItem item = new CompletionItem();
                            item.Content = funcName.Remove(0,1);
                            item.Description = descript.ToString() ;
                            item.Image= null;
                            item.Priority = 0f;
                            item.Text = reg.Match(item.Content).Value;
                            tempData.Add(item);
                            funcName =string.Empty;
                            descript.Clear();
                        }
                        funcName = line;
                        descript.AppendLine(line);
                    }
                    else {
                        descript.AppendLine(line);
                    }
                }
            }
            return tempData;
        }

        static void Save(List<CompletionItem> items,string fileName) {
            List<CompletionItem> datas = items;
            datas.Add(new CompletionItem() { Description="desc",Text="text",Content = "content", Priority = 0f, Image = "icon" });
            XmlSerializer serializer = new XmlSerializer(datas.GetType());
            StreamWriter sw = new StreamWriter(fileName);
            serializer.Serialize(sw, datas);
            sw.Close();
        }
    }
}
