using ICSharpCode.AvalonEdit.CodeCompletion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGOProDevelop.Service {
    //智能提示服务
    public interface IIntelisenceService {
         IList<ICompletionData> GetCompletionDatas(string language);
    }
}
