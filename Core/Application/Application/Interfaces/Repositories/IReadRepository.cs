using Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    /// <summary>
    /// Bu intarface daha önceden class, daha önceden 
    /// oluşturduğum IBaseEntity ve new lenebilir olmalı
    /// bu yüzden "T : class, IBaseEntity, new()" ekleyerek bunu sağlamış olduk
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReadRepository<T> where T : class, IBaseEntity, new()
    {
        /// <summary>
        /// Burda asyc olarak GetAll methonu yaptım bu sayede filtre kullanarak
        /// sorgu yapabileceğim 
        /// </summary>
        /// <param name="predicate">Burdaki expression sayesinde (o=> o.x==y)
        /// şeklinde parametre kullarak filtre uygulayabileceğim
        /// </param>
        /// <param name="include">
        /// bu parametre sayesinde istedğim özellikleri include edebileceğim
        /// include etmek sql de "JOIN" işleminin karşılığıdır
        /// </param>
        /// <param name="orderBy">
        /// Bu Parametre Sayesinde sıralama yapabileceğim
        /// </param>
        /// <param name="enableTracking">
        /// Bu parametre ef core tracking özelliğini gerektiğinde devre dışı bırakmak için
        /// tracking özelliği nesnein değişip değişmediğini kontrol eder ve efcore ile işlerken
        /// modified özelliğini kullanarak update edebilirz
        /// </param>
        /// <returns></returns>
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false);

        /// <summary>
        /// Veritabanından sayfalama (paging) yaparak kayıtları getirir.
        /// Kullanıcı, sorgu üzerinde filtre, sıralama, ilişki dahil etme gibi işlemler yapabilir.
        /// </summary>
        /// <param name="currentPage">
        /// Getirilecek verinin hangi sayfada olduğunu belirten parametre. Sayfalama için başlangıç sayfasını belirtir.
        /// Varsayılan olarak 1. sayfa döner.
        /// </param>
        /// <param name="pageSize">
        /// Her sayfada kaç kayıt olacağını belirten parametre. Sayfalama sırasında bir sayfada gösterilecek kayıt sayısını tanımlar.
        /// Varsayılan değer 10'dur.
        /// </param>
        /// <returns>
        /// Sayfalama uygulanmış, belirtilen kriterlere göre filtrelenmiş, sıralanmış ve ilişkili verileri
        /// dahil edilmiş kayıtların bir listesini asenkron olarak döndürür.
        /// </returns>

        Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false, int currentPage = 1, int pageSize = 10);

        /// <summary>
        /// Eğer tek bir entity istiyorsak bu metodu kullanabiliriz
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <param name="enableTracking"></param>
        /// <returns></returns>
        Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false);

        /// <summary>
        /// Eğer async bir şekilde istemiyorsam burdaki find metodunu kullanarak da 
        /// datayı filtreleye bilrim veya bir Task.Run() çalıştırarak içerisinde kullanabilirm
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="enableTracking"></param>
        /// <returns></returns>
        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);

        /// <summary>
        /// Belirli bir datayı saydırmam gerektiğinde bunu kullanabilirim
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);


    }
}
