using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PontoEletronico.Domain;
using PontoEletronico.Domain.Identity;

namespace PontoEletronico.Repository
{
    public class PontoEletronicoContext : DbContext
    {
        public PontoEletronicoContext(DbContextOptions<PontoEletronicoContext> options) : base(options)
        {
        }

        public DbSet<PontoRegistro> PontoRegistros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}