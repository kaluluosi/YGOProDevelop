using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Class1
    {

        public List<Document> Documents { get; set; }

        public Class1() {
            Documents = new List<Document>();
            Documents.Add(new Document() { Title = "ko" });
            Documents.Add(new Document() { Title = "ko22" });

        }
    }
}
