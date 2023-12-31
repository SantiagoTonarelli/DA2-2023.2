﻿using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Context:DbContext
    {
        public DbSet<User> Users { get; set; }

        public Context(DbContextOptions options):base(options) { }
    }
}
