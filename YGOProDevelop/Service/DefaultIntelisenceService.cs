using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.AvalonEdit.CodeCompletion;
using System.IO;
using YGOProDevelop.Model;
using ICSharpCode.AvalonEdit.Highlighting;

namespace YGOProDevelop.Service {
    public class DefaultIntelisenceService : IIntelisenceService {

        public DefaultIntelisenceService(string cfgPath) {
            _cfgPath = cfgPath;
        }

        private IList<ICompletionData> datas;
        private  string _cfgPath;

        public IList<ICompletionData> GetCompletionDatas(IHighlightingDefinition language) {
            if (language == null) return null;
            if (datas!=null) return datas;

            datas = new List<ICompletionData>();
            //以后ecp格式改用自己定义的xml格式
            string path = _cfgPath;
            using (StreamReader sr = new StreamReader(string.Format(path, language.Name, language.Name))) {
                while (sr.EndOfStream == false) {
                    string line = sr.ReadLine();
                    string[] snappets = line.Split('|');
                    DefaultCompletionData data;
                    if (snappets.Length == 2)
                        data = new DefaultCompletionData() { Text=snappets[0],Description=snappets[1],Content=snappets[0]};
                    else
                        data = new DefaultCompletionData() { Text = snappets[0], Content = snappets[0] };

                    datas.Add(data);
                }
            }
            return datas;
        }
    }
}
