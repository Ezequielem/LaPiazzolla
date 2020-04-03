using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LaPiazzolla.Models;

namespace LaPiazzolla.Data
{
    public class LaPiazzollaContext : DbContext
    {
        public LaPiazzollaContext (DbContextOptions<LaPiazzollaContext> options)
            : base(options)
        {
        }

        public DbSet<Curso> Curso { get; set; }
    }
}
