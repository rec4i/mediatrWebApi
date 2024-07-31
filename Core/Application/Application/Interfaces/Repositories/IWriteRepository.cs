using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;


namespace Application.Interfaces.Repositories
{
    /// <summary>
    /// Burda CRUD işlemlerini yapmak için Write repositorysini oluşturdum
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWriteRepository<T> where T : class, IBaseEntity, new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task<T> UpdateAsync(T entity);
        Task HardDeleteAsync(T entity);
        /// <summary>
        /// Eğer bir datayı gerçekten silmek istiyorsak bu
        /// fonksiyonu kullanmamız gerekiyor
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task HardDeleteRangeAsync(IList<T> entity);
    }
}
