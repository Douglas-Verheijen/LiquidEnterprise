﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Liquid.Library.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LibraryEntities : DbContext
    {
        public LibraryEntities()
            : base("name=LibraryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Music> Musics { get; set; }
    }
}
