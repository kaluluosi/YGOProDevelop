using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using YGOProDevelop.Model;

namespace YGOProDevelop.Service {
    public class CDBService : ICDBService {
        /// <summary>
        /// 相当于cards.cdb本身
        /// </summary>
        public static cardsEntities ce = new cardsEntities();

        public void Open(string filePath) {
            if(File.Exists(filePath) == false)
                throw new FileNotFoundException(filePath +"找不到了！");
            ce.Database.Connection.ConnectionString = "data source=" + filePath;
        }


        public cardsEntities Datas {
            get {
                return ce;
            }
            set {
                
            }
        }

        /// <summary>
        /// 删除卡片对象
        /// </summary>
        public void Remove(datas card) {
            ce.datas.Remove(card);
        }


        /// <summary>
        /// 增加新卡
        /// </summary>
        public void Add(datas card) {
            //如果datas里面有card，那么就抛出异常
            if (ce.datas.FirstOrDefault(c => c.id == card.id) != null)
                throw new Exception("卡密重复");

            ce.datas.Add(card);
        }

        public void Replace(datas from, datas to) {
            Remove(from);
            Add(to);
        }

        /// <summary>
        /// 保存数据库的更改
        /// </summary>
        public int Save() {
            //保存cdb数据
            return  ce.SaveChanges();
        }

        public bool IsIDExisted(long id) {
            datas result = ce.datas.FirstOrDefault(d => d.id == id);
            return result == null ? false : true;
        }

        public void DiscardAllChanged() {
            var entries = ce.ChangeTracker.Entries();
            foreach(var e in entries) {
                e.ReloadAsync();
            }
        }

        public void Reload(datas data) {
            ce.Entry(data).Reload();
        }
    }
}
