using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeopleApi.Models;

    public class PeopleContext : DbContext
    {
        public PeopleContext (DbContextOptions<PeopleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PeopleApi.Models.Person> Person { get; set; }
    }
