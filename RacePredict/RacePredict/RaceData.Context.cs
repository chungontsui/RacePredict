﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RacePredict
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class dbNZGoodies_TestEntities : DbContext
    {
        public dbNZGoodies_TestEntities()
            : base("name=dbNZGoodies_TestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<RaceDataEntities> RaceDataEntities { get; set; }
    
        public virtual ObjectResult<sp_WinningStats_Result> sp_WinningStats()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_WinningStats_Result>("sp_WinningStats");
        }
    }
}