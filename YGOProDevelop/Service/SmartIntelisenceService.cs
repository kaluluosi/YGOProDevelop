using ICSharpCode.AvalonEdit.CodeCompletion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ICSharpCode.AvalonEdit.Highlighting;
using YGOProDevelop.Model;
using System.Windows.Media.Imaging;

namespace YGOProDevelop.Service {
    public class SmartIntelisenceService:IIntelisenceService {
        private Dictionary<IHighlightingDefinition, IList<ICompletionData>> dataDict = new Dictionary<IHighlightingDefinition, IList<ICompletionData>>();

        public IList<ICompletionData> GetCompletionDatas(IHighlightingDefinition language) {
            if (language == null) return null;
            if (dataDict.ContainsKey(language)) return dataDict[language];
            dataDict.Add(language, new List<ICompletionData>());
            var datas = dataDict[language];
            //以后ecp格式改用自己定义的xml格式
            string path = @"data\Intelisence\"+language.Name;

            if (Directory.Exists(path) == false) return datas;

            foreach(string file in Directory.GetFiles(path)) {
                using (StreamReader sr = new StreamReader(file)) {
                    //这里改用xmlSerialize
                    //To Do
                    try {
                        LoadData(datas, sr);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                }
            }
            return datas;
        }

        private void LoadData(IList<ICompletionData> datas, StreamReader sr) {
            XmlSerializer loader = new XmlSerializer(typeof(List<CompletionItem>));
            var items = loader.Deserialize(sr) as List<CompletionItem>;
            var completionDatas = from item in items
                                  select new DefaultCompletionData() {
                                      Text = item.Text,
                                      Content = item.Content,
                                      Description = item.Description,
                                      //                                               Image = new BitmapImage(new Uri(item.Image, UriKind.RelativeOrAbsolute)),
                                      Priority = item.Priority
                                  };
            foreach (ICompletionData cd in completionDatas) {
                datas.Add(cd);
            }
        }
    }
}
