﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Test_WebApi.Data;
using Test_WebApi.Models;

namespace Test_WebApi.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        
  
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }

        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestDataModel> RequestData { get; set; }

        public DbSet<CreateRequest> CreateRequest { get; set; }


    }
}
