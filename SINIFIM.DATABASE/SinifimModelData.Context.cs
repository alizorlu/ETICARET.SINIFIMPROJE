﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SINIFIM.DATABASE
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SinifimCom_SinifimDB2018DBEntities : DbContext
    {
        public SinifimCom_SinifimDB2018DBEntities()
            : base("name=SinifimCom_SinifimDB2018DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminTB> AdminTB { get; set; }
        public virtual DbSet<AnketCevapTB> AnketCevapTB { get; set; }
        public virtual DbSet<AnketlerTB> AnketlerTB { get; set; }
        public virtual DbSet<ArgorTB> ArgorTB { get; set; }
        public virtual DbSet<Duyuru_GorenlerTB> Duyuru_GorenlerTB { get; set; }
        public virtual DbSet<DuyurularTB> DuyurularTB { get; set; }
        public virtual DbSet<GelenMesajTB> GelenMesajTB { get; set; }
        public virtual DbSet<GonderilenMesajTB> GonderilenMesajTB { get; set; }
        public virtual DbSet<Odev_GorulduTB> Odev_GorulduTB { get; set; }
        public virtual DbSet<Odev_TeslimTB> Odev_TeslimTB { get; set; }
        public virtual DbSet<OdevlerTB> OdevlerTB { get; set; }
        public virtual DbSet<OgrenciTB> OgrenciTB { get; set; }
        public virtual DbSet<SanalSinifTB> SanalSinifTB { get; set; }
        public virtual DbSet<SinifOgrencilerTB> SinifOgrencilerTB { get; set; }
        public virtual DbSet<UniversiteTB> UniversiteTB { get; set; }
    }
}
