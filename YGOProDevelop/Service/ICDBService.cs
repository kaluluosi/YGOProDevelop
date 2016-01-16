using System;
using YGOProDevelop.Model;

namespace YGOProDevelop.Service
{
    public interface ICDBService
    {
        void Add(YGOProDevelop.Model.datas card);
        bool IsIDExisted(long id);
        void Open(string filePath);
        void Remove(YGOProDevelop.Model.datas card);
        void Replace(YGOProDevelop.Model.datas from, YGOProDevelop.Model.datas to);
        int Save();
        void DiscardAllChanged();
        void Reload(datas data);
        cardsEntities Datas { get; set; }
    }
}
