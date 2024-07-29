using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class StokConfiguration : IEntityTypeConfiguration<Stok>
    {
        /// <summary>
        /// Stok Entitiysindeki özellikler zaten entityframwork tarafından 
        /// daha önceden tanımlanmış configurasyonlara sahip
        /// burda pek bir configurasyon yapmamıza gerek yok
        /// </summary>
        /// <param name="builder"></param>

        public void Configure(EntityTypeBuilder<Stok> builder)
        {

        }
    }
}
