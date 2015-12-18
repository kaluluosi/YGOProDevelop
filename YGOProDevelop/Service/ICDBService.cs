using System;
namespace YGOProDevelop.Service
{
    public interface ICDBService
    {
        void Add(YGOProDevelop.Model.datas card);
        bool IsIDExisted(int id);
        void OnPropertyChanged(string propertyName);
        void Open(string filePath);
        event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        System.Collections.ObjectModel.ObservableCollection<YGOProDevelop.Model.datas> QueryResult { get; set; }
        void Remove(YGOProDevelop.Model.datas card);
        void Replace(YGOProDevelop.Model.datas from, YGOProDevelop.Model.datas to);
        void ResetSearch();
        int Save();
        int Search(int id);
        int Search(string keyword);
    }
}
