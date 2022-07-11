using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //Get bir liste oluşturmaz. Sadece tek bir veri getirebilir. Bundan dolayı fiyat aralığına göre filtreleme gibi işlemler için GetAll metodu kullanılmalıdır.
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
} 
