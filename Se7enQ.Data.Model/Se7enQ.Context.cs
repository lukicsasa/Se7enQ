﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Se7enQ.Data.Model
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class Se7enQEntities : DbContext
    {
        public Se7enQEntities()
            : base("name=Se7enQEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Calculation> Calculations { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GeneralKnowledge> GeneralKnowledges { get; set; }
        public virtual DbSet<LogicArray> LogicArrays { get; set; }
        public virtual DbSet<Memory> Memories { get; set; }
        public virtual DbSet<Projection> Projections { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WordDefinition> WordDefinitions { get; set; }
        public virtual DbSet<WordSynonym> WordSynonyms { get; set; }
    }
}
