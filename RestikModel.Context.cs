﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restik
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RestikEntities : DbContext
    {
        public RestikEntities()
            : base("name=RestikEntities")
        {
            Bookings.Load();
            Clients.Load();
            Creators.Load();
            ImageInRestaurants.Load();
            Restaurants.Load();
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Creator> Creators { get; set; }
        public virtual DbSet<ImageInRestaurant> ImageInRestaurants { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
    }
}
