using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        /// <summary>
        /// Core Katmanında Oluşturduğum entityleri burada 
        /// DbContext nesnemin içerisine özellik olarak tanımlıyorum
        /// Bu sayede migration oluşturduğumda burdaki özellikler
        /// birer tablo olarak veri tabanına eklenecektir
        /// </summary>
        public DbSet<Birim> Birimler { get; set; }
        public DbSet<Cari> Cariler { get; set; }
        public DbSet<Depo> Depolar { get; set; }
        public DbSet<Hareket> Hareketler { get; set; }
        public DbSet<Stok> Stoklar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ////Aşşaıdaki kod oluşturduğumuz configuration nesnelirini oluşturduğumuz modele
            ///Tanımlanmasını sağlıyor "ApplyConfigurationsFromAssembly" bu metot 
            ///aynı dll içerisindeki tüm conguration dosyalarını modele dahil ediyor
            /// "GetExecutingAssembly" bu metot dll execute edildiğinde dll içerisindeki
            /// namespace altındaki nesneleri geri dönüyor gibi düşüne biliriz
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
