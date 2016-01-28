using System;
using System.Collections.Generic;
using YGOProDevelop.Model;

namespace YGOProDevelop.Service
{
    public interface ICDBService
    {
        List<datas> GetData();
        datas Create(long id);
        void Add(YGOProDevelop.Model.datas card);
        bool IsIDExisted(long id);
        void Open(string filePath);
        void Remove(YGOProDevelop.Model.datas card);
        void Replace(YGOProDevelop.Model.datas from, YGOProDevelop.Model.datas to);
        int Save();
        void DiscardAllChanged();
        void Reload(datas data);

        List<datas> Search(string keyword);
        List<datas> Search(long id);
        cardsEntities Datas { get; set; }
    }
}
