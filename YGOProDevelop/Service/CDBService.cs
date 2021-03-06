﻿using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using YGOProDevelop.Model;
using System.Collections.Generic;

namespace YGOProDevelop.Service {
    public class CDBService : ICDBService {
        /// <summary>
        /// 相当于cards.cdb本身
        /// </summary>
        public static cardsEntities ce = new cardsEntities();

        public void Open(string filePath) {
            if (File.Exists(filePath) == false)
                throw new FileNotFoundException(filePath + "找不到了！");
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
            return ce.SaveChanges();
        }

        public bool IsIDExisted(long id) {
            datas result = ce.datas.FirstOrDefault(d => d.id == id);
            return result == null ? false : true;
        }

        /// <summary>
        /// 丢弃所有修改
        /// </summary>
        public void DiscardAllChanged() {
            var entries = ce.ChangeTracker.Entries();
            foreach (var e in entries) {
                e.ReloadAsync();
            }
        }

        /// <summary>
        /// 重新加载某个项
        /// </summary>
        /// <param name="data"></param>
        public void Reload(datas data) {
            ce.Entry(data).Reload();
        }


        public List<datas> Search(string keyword) {
            var result = from c in GetData()
                         join t in Datas.texts on c.id equals t.id
                         where string.Join(t.desc, t.name, t.id).Contains(keyword)
                         select c;
            return result.ToList();
        }


        public List<datas> Search(long id) {
            var result = from c in Datas.datas
                         where c.id == id
                         select c;
            return result.ToList();
        }

        public datas Create(long id) {
            datas d = Datas.datas.Create();
            d.texts = Datas.texts.Create();
            d.id = d.texts.id = id;

            //DataEditor对文本为空的字段没做兼容，会报错，所以要为字符字段初始化为空字符串。
            d.texts.desc = string.Empty;
            d.texts.name = "未命名";
            d.texts.str1 =  string.Empty;
            d.texts.str2 =  string.Empty;
            d.texts.str3 =  string.Empty;
            d.texts.str4 =  string.Empty;
            d.texts.str5 =  string.Empty;
            d.texts.str6 =  string.Empty;
            d.texts.str7 =  string.Empty;
            d.texts.str8 =  string.Empty;
            d.texts.str9 =  string.Empty;
            d.texts.str10 = string.Empty;
            d.texts.str11 = string.Empty;
            d.texts.str12 = string.Empty;
            d.texts.str13 = string.Empty;
            d.texts.str14 = string.Empty;
            d.texts.str15 = string.Empty;
            d.texts.str16 = string.Empty;

            return d;
        }

        public List<datas> GetData() {
            var result = from c in Datas.datas
                         select c;
            return result.ToList();
        }

        public void CreateNewCDB(string fileName) {
            cardsEntities ce1 = new cardsEntities();
            ce1.Database.Connection.ConnectionString = "data source=" + fileName;
            ce1.Database.Connection.Open();
            ce1.Database.Initialize(true);
            ce1.Database.ExecuteSqlCommand(@"CREATE TABLE [datas] (
                                              [id] integer PRIMARY KEY, 
                                              [ot] integer, 
                                              [alias] integer, 
                                              [setcode] integer, 
                                              [type] integer, 
                                              [atk] integer, 
                                              [def] integer, 
                                              [level] integer, 
                                              [race] integer, 
                                              [attribute] integer, 
                                              [category] integer);
                                            
                                            
                                            CREATE TABLE [texts] (
                                              [id] integer PRIMARY KEY CONSTRAINT [datas_id] REFERENCES [datas]([id]) MATCH FULL, 
                                              [name] varchar(128), 
                                              [desc] varchar(1024), 
                                              [str1] varchar(256), 
                                              [str2] varchar(256), 
                                              [str3] varchar(256), 
                                              [str4] varchar(256), 
                                              [str5] varchar(256), 
                                              [str6] varchar(256), 
                                              [str7] varchar(256), 
                                              [str8] varchar(256), 
                                              [str9] varchar(256), 
                                              [str10] varchar(256), 
                                              [str11] varchar(256), 
                                              [str12] varchar(256), 
                                              [str13] varchar(256), 
                                              [str14] varchar(256), 
                                              [str15] varchar(256), 
                                              [str16] varchar(256));");
            ce1.SaveChanges();
        }
    }
}
