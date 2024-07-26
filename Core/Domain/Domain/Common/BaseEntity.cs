using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{

    /// <summary>
    /// Oluşturdğum diğer her entity için tekrar eder şekilde Id özelliğini eklemek için
    /// Bir base Entity Classı oluşturuyorum
    /// Oluşturulma tarihi ve silimişmi bilgisini tutmak için özellikler yekliyorum
    /// ve default değerlerini veriyorum
    /// </summary>
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

    }
}
