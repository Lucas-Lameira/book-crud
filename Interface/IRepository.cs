using System.Collections.Generic;

namespace Project.Books.Interface
{
    public interface IRepository<T>
    {
        List<T> List();
        T ReturnById(int id);
        void create(T entity);
        void delete(int id);
        void update(int id, T entity);
        int NextId();
    }
}