﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CM.InfraAccesoDatos.Repositorio
{
    using CM.Dominio.Modelo.Entidades;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBCitasMedicasEntities : DbContext
    {
        public DBCitasMedicasEntities()
            : base("name=DBCitasMedicasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Consultorios> Consultorios { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<EspecialidadMedicos> EspecialidadMedicos { get; set; }
        public virtual DbSet<HorarioMedicos> HorarioMedicos { get; set; }
        public virtual DbSet<Horarios> Horarios { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
