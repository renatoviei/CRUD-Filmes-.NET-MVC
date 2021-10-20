using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Filmes.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {


        }
    }
}
