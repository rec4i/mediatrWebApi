using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Birim : BaseEntity
    {
        public string UzunAdı { get; set; }
        public string KısaAdı { get; set; }
        public List<Stok> Stoklar { get; set; }
    }
}
