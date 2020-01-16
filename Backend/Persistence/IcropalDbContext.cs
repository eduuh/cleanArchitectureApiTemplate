using Domain;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class IcropalDbContext : IdentityDbContext<User>
    {
        public IcropalDbContext(DbContextOptions options) : base(options)
        {

        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //     //one to many relatioships : Using fluent apis

        //     // User
        //     // one user can have man ExpertAppointements
        //     modelBuilder.Entity<User>()
        //     .HasMany(c => c.ExpertAppointments)
        //     .WithOne(c => c.User).IsRequired()
        //     .OnDelete(DeleteBehavior.Restrict);
        //     // One user can have many Orders
        //     modelBuilder.Entity<User>()
        //   .HasMany(c => c.Orders)
        //   .WithOne(c => c.User).IsRequired()
        //   .OnDelete(DeleteBehavior.Restrict);

        //     //One user can have many ServiceProviders
        //     modelBuilder.Entity<User>()
        // .HasMany(c => c.ServiceProviders)
        // .WithOne(c => c.User).IsRequired()
        // .OnDelete(DeleteBehavior.Restrict);

        //     // One user can have many DiagnosisResults
        

        //     // One user can have many Posts
        //     modelBuilder.Entity<User>()
        //  .HasMany(c => c.Posts)
        //  .WithOne(c => c.User).IsRequired()
        //  .OnDelete(DeleteBehavior.Restrict);

        //     //One user can have many Ratings
        //     modelBuilder.Entity<User>()
        //   .HasMany(c => c.Ratings)
        //   .WithOne(c => c.User).IsRequired()
        //   .OnDelete(DeleteBehavior.Restrict);

        //     // Subscriptions

        //     //can have many user
        //     modelBuilder.Entity<Subscription>()
        //          .HasMany(s => s.Users)
        //          .WithOne(u => u.Subscription)
        //          .OnDelete(DeleteBehavior.Restrict);


        //     // Transactions
        //     // can have many ExpertAppointments
        //     modelBuilder.Entity<Transaction>()
        //         .HasMany(t => t.ExpertAppointments)
        //         .WithOne(ea => ea.Transaction)
        //         .OnDelete(DeleteBehavior.Restrict);

        //     // can have many orders
        //     modelBuilder.Entity<Transaction>()
        //         .HasMany(t => t.Orders)
        //         .WithOne(o => o.Transaction)
        //         .OnDelete(DeleteBehavior.Restrict);

        //     // can have many subscriptions
        //     modelBuilder.Entity<Transaction>()
        //         .HasMany(t => t.Subscriptions)
        //         .WithOne(s => s.Transaction)
        //         .OnDelete(DeleteBehavior.Restrict);



        //     // order
        //     //can have one product
        //     modelBuilder.Entity<Order>()
        //         .HasOne(p => p.Product)
        //         .WithMany(o => o.Orders)
        //         .OnDelete(DeleteBehavior.Restrict);

        //     //Product
        //     //many products could belong to a servicprovider
        //     modelBuilder.Entity<Product>()
        //         .HasOne(sp => sp.ServiceProvider)
        //         .WithMany(p => p.Products)
        //         .OnDelete(DeleteBehavior.Restrict);

        //     //ServiceProvider

        //     modelBuilder.Entity<ServiceProvider>()
        //         .HasMany(e => e.Experts)
        //         .WithOne(sp => sp.ServiceProvider)
        //         .OnDelete(DeleteBehavior.Restrict);

        //     modelBuilder.Entity<ServiceProvider>()
        //        .HasMany(r => r.Ratings)
        //        .WithOne(sp => sp.ServiceProvider)
        //        .OnDelete(DeleteBehavior.Restrict);



        //     // ServiceCategory
        //     modelBuilder.Entity<ServiceCategory>()
        //         .HasMany(sp => sp.ServiceProviders)
        //         .WithOne(sc => sc.ServiceCategory)
        //         .OnDelete(DeleteBehavior.Restrict);

        //     // Locations
        //     modelBuilder.Entity<Location>()
        //         .HasOne(u => u.User)
        //         .WithOne(l => l.Location).IsRequired()
        //         .HasForeignKey<Location>(l => l.Userref)
        //         .OnDelete(DeleteBehavior.Restrict);

        //     modelBuilder.Entity<Location>()
        //         .HasMany(dr => dr.DiagnosisResults)
        //         .WithOne(l => l.Location).IsRequired()
        //         .OnDelete(DeleteBehavior.Restrict);


        //     modelBuilder.Entity<Location>()
        //         .HasMany(sp => sp.ServiceProviders)
        //         .WithOne(l => l.Location)
        //         .OnDelete(DeleteBehavior.Restrict);

        //     //Experts

        //     modelBuilder.Entity<Expert>()
        //        .HasMany(ea => ea.ExpertAppointments)
        //        .WithOne(e => e.Expert)
        //        .OnDelete(DeleteBehavior.Restrict);

        //     // Order
        //     modelBuilder.Entity<Order>()
        //         .HasOne(t => t.Transaction)
        //         .WithMany(o => o.Orders)
        //         .OnDelete(DeleteBehavior.Restrict);

        //     modelBuilder.Entity<Order>()
        //         .HasOne(p => p.Product)
        //         .WithMany(o => o.Orders)
        //         .OnDelete(DeleteBehavior.Restrict);
        //     // Disease Info

        //     modelBuilder.Entity<DiseaseInfo>()
        //         .HasMany(dr => dr.DiagnosisResults)
        //         .WithOne(di => di.DiseaseInfo)
        //         .OnDelete(DeleteBehavior.Restrict);
        //     modelBuilder.Entity<DiseaseInfo>()
        //         .HasMany(pd => pd.ProductDiseaseInfos)
        //         .WithOne(di => di.DiseaseInfo)
        //         .OnDelete(DeleteBehavior.Restrict);

        //     modelBuilder.Entity<DiagnosisResult>()
        //     .HasOne(u =>u.User)
        //     .WithMany(d => d.DiagnosisResults)
        //     .OnDelete(DeleteBehavior.Restrict);

        //     // Many to Many Relatioships With Product and Disease

        //     modelBuilder.Entity<ProductDisease>().HasKey(pd => new { pd.ProductId, pd.DiseaseInfoId });
        //     // Relationship from the product side of view
        //     modelBuilder.Entity<ProductDisease>()
        //         .HasOne(p => p.Product)
        //         .WithMany(pd => pd.ProductDiseaseInfos)
        //         .HasForeignKey(d => d.DiseaseInfoId);

        //     //Relationship from the disease side of view
        //     modelBuilder.Entity<ProductDisease>()
        //         .HasOne(d => d.DiseaseInfo)
        //         .WithMany(pd => pd.ProductDiseaseInfos)
        //         .HasForeignKey(p => p.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
