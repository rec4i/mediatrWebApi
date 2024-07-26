using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Stok : BaseEntity
    {
        public string Ad { get; set; }
        public string Açıklama { get; set; }

        public int DepoId { get; set; }
        public Depo Depo { get; set; }

        public int BirimId { get; set; }
        public Birim Birim { get; set; }
    }
}
