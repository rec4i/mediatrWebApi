using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    /// <summary>
    /// Cari ve depo hareketlerini tutmak için bir class oluşturdum ve BaseEntityden kalıttım
    /// bu sayede carinin ve depo hareketlerini takip edebileceğiz
    /// 
    /// </summary>
    public class Hareket : BaseEntity
    {
        // NOTE:  Hareket Tipleri Yerine Enum Tanımlanabilir
        //1 Depo Stok Girişi
        //2 Depo Stok Çıkışı
        //3 Cari Satış
        //4 Ürün Satın Alma 
        public int HareketTipi { get; set; }

        public int? CariId { get; set; }
        public Cari? Cari { get; set; }


        public int? DepoId { get; set; }
        public Depo? Depo { get; set; }



        public int StokId { get; set; }
        public Stok Stok { get; set; }


    }
}
