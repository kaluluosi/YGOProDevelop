using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using YGOProDevelop.Builder;
using System.Threading;
using System.IO;

namespace YGOProDevelop.CDBEditor.CDB {
    public class CDBManager : INotifyPropertyChanged {
        /// <summary>
        /// 相当于cards.cdb本身
        /// </summary>
        public static cardsEntities ce = new cardsEntities();

        /// <summary>
        /// 采用单例模式
        /// </summary>
        private static CDBManager cdbMgr;
        public static CDBManager Instance {
            get {
                if (cdbMgr == null) {
                    CDBManager.ce.Database.Connection.ConnectionString = @"data source=.\cards.cdb";
                    cdbMgr = new CDBManager();
                    cdbMgr.ResetSearch();
                }
                return cdbMgr;
            }
        }

        public CDBManager Load(string filePath) {
            string connectionStr = ce.Database.Connection.ConnectionString;
            string connectionStrTemplate = @"data source={0}";
            
            ce.Database.Connection.ConnectionString=string.Format(connectionStrTemplate,Path.GetFullPath(filePath));
            ResetSearch();
            return this;
        }

        private ObservableCollection<datas> queryResult;

        /// <summary>
        /// 查询结果，由于使用了observerableCollection所以增删查都会自动通知控件刷新
        /// </summary>
        public ObservableCollection<datas> QueryResult {
            get {
                return queryResult;
            }
            set {
                queryResult = value;
                OnPropertyChanged("QueryResult");
            }
        }

        /// <summary>
        /// 删除卡片对象
        /// </summary>
        public void Remove(datas card) {
            queryResult.Remove(card);
            ce.datas.Remove(card);
        }


        /// <summary>
        /// 增加新卡
        /// </summary>
        public void Add(datas card) {
            //如果datas里面有card，那么就抛出异常
            if (ce.datas.FirstOrDefault(c => c.id == card.id) != null)
                throw new Exception("卡密重复");

            queryResult.Add(card);
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

        /// <summary>
        /// 重置搜索，相当于将所有的卡片查找出来
        /// </summary>
        public void ResetSearch() {
            var result = from c in ce.datas
                         select c;
            foreach(var c in result) {
                Console.WriteLine(c.texts.name);
            }
            QueryResult = new ObservableCollection<datas>(result);
        }

        /// <summary>
        /// 根据id来查找
        /// </summary>
        /// <returns>返回查找到的数量</returns>
        public int Search(int id) {
            //不通知界面刷新的resetsearch
            queryResult = new ObservableCollection<datas>(ce.datas);
            var result = from c in queryResult
                         where c.id == id
                         select c;
            //必须为QueryResult赋值才会通知界面
            QueryResult = new ObservableCollection<datas>(result);
            return QueryResult.Count;
        }

        /// <summary>
        /// 通过卡片名称和描述来查找，这是默认的查找方式
        /// </summary>
        public int Search(string keyword) {
            //不通知界面刷新的resetsearch
            queryResult = new ObservableCollection<datas>(ce.datas);
            var result = from c in queryResult
                         where c.texts.desc.Contains(keyword) || c.texts.name.Contains(keyword) 
                         select c;
            QueryResult = new ObservableCollection<datas>();
            foreach(var c in result) {
                queryResult.Add(c);
            }
            return queryResult.Count;
        }


        public bool IsIDExisted(int id) {
            datas result = ce.datas.FirstOrDefault(d => d.id == id);
            return result == null ? false : true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
