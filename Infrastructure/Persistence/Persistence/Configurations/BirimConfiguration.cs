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
    public class BirimConfiguration : IEntityTypeConfiguration<Birim>
    {
        /// <summary>
        /// Birimler için entityframwork tarafından önceden tanımlanan 
        /// özellikler yeterli ama bazı Birimleri Adet, lt , gr gibi 
        /// bunları tanımlamamız kullanıcıyı daha az yoracaktır ve 
        /// veri tabanını her baştan kurduğumda benim işimide kolaylaştıracaktır
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<Birim> builder)
        {
            List<Birim> birimler = new List<Birim>()
            {
                new Birim{Id = 1 , KısaAdı = "Ad",UzunAdı="Adet",IsDeleted=false,CreatedDate=DateTime.Now},
                new Birim{Id = 2 , KısaAdı = "Lt",UzunAdı="Litre",IsDeleted=false,CreatedDate = DateTime.Now},
                new Birim{Id = 2 , KısaAdı = "Gr",UzunAdı="Gram",IsDeleted=false,CreatedDate = DateTime.Now},
                new Birim{Id = 2 , KısaAdı = "Kg",UzunAdı="Kilogram",IsDeleted=false,CreatedDate = DateTime.Now},
                new Birim{Id = 2 , KısaAdı = "M",UzunAdı="Metre",IsDeleted=false,CreatedDate = DateTime.Now},
            };
            builder.HasData(birimler);
        }
    }
}
