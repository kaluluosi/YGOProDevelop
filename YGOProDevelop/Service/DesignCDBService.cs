using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using YGOProDevelop.Model;

namespace YGOProDevelop.Service {
    public class DesignCDBService : ICDBService {
        public ObservableCollection<datas> QueryResult {
            get {
                datas d1 = new datas();
                d1.texts = new texts();
                d1.texts.name = "限制苏生";
                d1.texts.desc = "测试用";
                return new ObservableCollection<datas> { d1 };
            }

            set {
                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Add(datas card) {
            throw new NotImplementedException();
        }

        public bool IsIDExisted(int id) {
            throw new NotImplementedException();
        }

        public void OnPropertyChanged(string propertyName) {
            throw new NotImplementedException();
        }

        public void Open(string filePath) {
            throw new NotImplementedException();
        }

        public void Remove(datas card) {
            throw new NotImplementedException();
        }

        public void Replace(datas from, datas to) {
            throw new NotImplementedException();
        }

        public void ResetSearch() {
            
        }

        public int Save() {
            throw new NotImplementedException();
        }

        public int Search(string keyword) {
            throw new NotImplementedException();
        }

        public int Search(int id) {
            throw new NotImplementedException();
        }
    }
}
