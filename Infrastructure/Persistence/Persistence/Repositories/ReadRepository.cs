using Application.Interfaces.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    /// <summary>
    /// Burda somut olarak ReadRepository sini oluşturdum yani soyut olan fonksiyonlarımızı
    /// somut hale bu classta tanımlayacağım
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReadRepository<T> : IReadRepository<T> where T : class, IBaseEntity, new()
    {

        /// <summary>
        /// Constracture oluşturarak DbContext nesnesini inject ettim
        /// ve bir DbContext nesnesine atarak her fonksiyonun içerisinde 
        /// oluşturmaktan kurtuldum
        /// </summary>
        private readonly DbContext dbContext;
        public ReadRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /// <summary>
        /// Bu özellik ise hangi entity yi kallıttıysak o entitin tablosunu
        /// işaret edecek
        /// </summary>
        private DbSet<T> Table { get => dbContext.Set<T>(); }

        /// <summary>
        /// Burada daha önceden oluşturduğumuz soyut fonksiyonu gerçek haline getirdim
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <param name="orderBy"></param>
        /// <param name="enableTracking"></param>
        /// <returns></returns>
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {

            //Tüm filtrelerimiz bu nesne üzerine adım adım ekleyeceğiz
            IQueryable<T> queryable = Table;
            ///Burda yaptığım kontrol daha öncedende bahsettiğim Tracking özelliğinin
            ///kontrol edip ona göre işlem yaptığımız yer 
            if (!enableTracking) queryable = queryable.AsNoTracking();
            /// Include işlemlerini burada sorgumuza ekliyoruz
            if (include is not null) queryable = include(queryable);
            /// ve en son olarak filtremizi uyguluyoruz bu işlemin en son olmasının sebebi
            /// işlemimizi hızlandırmak çünkü ilk önce include yapıp sonradan eğer filtrelersek
            /// anlamsız bir iş olur
            if (predicate is not null) queryable = queryable.Where(predicate);
            /// ve en son olarak sıralamamızı ekliyoruz
            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync();
            /// ve geri dönüyoruz
            return await queryable.ToListAsync();
        }

        /// <summary>
        /// Bu fonksiyon ise paging yaptığımız fonksiyon
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <param name="orderBy"></param>
        /// <param name="enableTracking"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null)
                ////Burada paging işlemini gerçekleştiriyoruz default olarak ilk 10 nesneyi dönecek
                ///page değiştikçe diğer özellikler gelexek
                return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

            return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<T> GetAsync(
            Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
            IIncludableQueryable<T, object>>? include = null, 
            bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);

            //queryable.Where(predicate);

            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if (predicate is not null) Table.Where(predicate);

            return await Table.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
        {
            if (!enableTracking) Table.AsNoTracking();
            return Table.Where(predicate);
        }
    }
}
