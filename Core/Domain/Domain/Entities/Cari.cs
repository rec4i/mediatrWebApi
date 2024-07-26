using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    /// <summary>
    /// Cari Bilgilerini tutmak için için bir class oluşturdum ve baseentityden kalıttım
    /// Ve Hareket Adında diğer oluşturduğum entity ile bağlantısını sağlamak için 
    /// Haraket classından oluşan bir liste ekledim bu sayede entityframework ile 
    /// bu classı veri tabanından çağırdığımda eğer include edersem bu özellik dolu olarak
    /// gelecek
    /// </summary>
    public class Cari : BaseEntity
    {
        public string Ad { get; set; }
        public string Adres { get; set; }

        //1 Müşteri
        //2 Tedarikçi
        public int Tür { get; set; }

        public List<Hareket> Hareketler { get; set; }
    }
}
