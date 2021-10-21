using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Filmes.Models
{
    public class Filme
    {
      
        public int FilmeId { get; set; }
        public string Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }

    }
}
