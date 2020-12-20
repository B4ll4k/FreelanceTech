using System;
using System.Collections.Generic;
using System.Text;
using FreelanceTech.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FreelanceTech.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Freelancer> Freelancer { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Expertise> Category { get; set; }
        public DbSet<Proposal> Proposal { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Expertise> Expertise { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Wallet> Wallet { get; set; }

    }
}
