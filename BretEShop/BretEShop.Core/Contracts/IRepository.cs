using BretEShop.Core.Models;
using System.Linq;

namespace BretEShop.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        IQueryable<T> GetItems();
        void Insert(T t);
        void Update(T t);
    }
}