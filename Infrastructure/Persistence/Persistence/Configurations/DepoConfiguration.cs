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
    public class DepoConfiguration : IEntityTypeConfiguration<Depo>
    {
        /// <summary>
        /// Depo İçin bir "Ana Depo" ekleyebiliriz ve bu sayede 
        /// veritabanı ilk oluşturulduğunda depo bilgileri istendiğinde
        /// karşılığını dönebiliriz
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Depo> builder)
        {
            Depo depo = new Depo()
            {
                Id = 1,
                Ad = "Ana Depo",
                Adres = "Merkez",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            builder.HasData(depo);
        }
    }
}
