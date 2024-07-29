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
    public class CariConfiguration : IEntityTypeConfiguration<Cari>
    {
        /// <summary>
        /// Aynı şekilde burdada default olarak tanımlanan özellikler yeterli
        /// eğer üzerine telefon numarası
        /// vergi kimlik numarası gibi özellikler ekleseydik
        /// burda en fazla haç haneli olabilir ve veya diğer filtrereleri uygulayabilirdik
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<Cari> builder)
        {
            
        }
    }
}
