using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.AvalonEdit.CodeCompletion;
using System.IO;
using YGOProDevelop.Model;

namespace YGOProDevelop.Service {
    public class DefaultIntelisenceService : IIntelisenceService {
        private IList<ICompletionData> datas;

        public IList<ICompletionData> GetCompletionDatas(string language) {
            if (datas != null) return datas;

            datas = new List<ICompletionData>();
            using(StreamReader sr = new StreamReader(@"data\Intelisence\" + language)) {
                while (sr.EndOfStream==false) {
                    string line = sr.ReadLine();
                    string[] snappets = line.Split('|');
                    MyCompletionData data;
                    if (snappets.Length==2)
                        data = new MyCompletionData(snappets[1],snappets[0]);
                    else
                        data = new MyCompletionData(null, snappets[0]);

                    datas.Add(data);
                }
            }
            return datas;
        }
    }
}
