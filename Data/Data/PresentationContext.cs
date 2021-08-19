using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Model.Models;

namespace Data.Data
{
    public class PresentationContext : DbContext
    {
        public PresentationContext (DbContextOptions<PresentationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Domain.Model.Models.ProfessorModel> Professores { get; set; }

        public DbSet<Domain.Model.Models.AlunoModel> Alunos { get; set; }
    }
}
