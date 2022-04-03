using System;
using System.Collections.Generic;
using aspnet_server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace aspnet_server {
    public class AspNetServerContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Name> Names { get; set; }
        public AspNetServerContext() {
        }

        public AspNetServerContext(DbContextOptions<AspNetServerContext> options) : base(options) {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseMySql("server=localhost;user=root;password=root123;database=aspnet_server", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
        }
    }
}
