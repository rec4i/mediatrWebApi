using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    /// <summary>
    /// Her Stokğun nerede olduğunu kullanıcının bilebilmesi için
    /// Depo classını oluştudum ve gerekli özellikleri verdim bu sayede
    /// kullanıcıya istediği zaman hangi depoda ne ürünü var bilgisini
    /// verebileceğiz
    /// </summary>
    public class Depo : BaseEntity
    {
        public string Ad { get; set; }
        public string Adres { get; set; }
        public List<Stok> Stoklar { get; set; }
    }
}
