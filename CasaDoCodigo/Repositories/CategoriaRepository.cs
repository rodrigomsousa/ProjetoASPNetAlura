using CasaDoCodigo.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task AddCategoria(string nome);
        Categoria GetCategoria(string nome);
    }

    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task AddCategoria(string nome)
        {
            var categoria = contexto.Set<Categoria>()
                .Where(c => c.Nome == nome)
                .SingleOrDefault();

            if (categoria == null)
            {
                categoria = new Categoria
                {
                    Nome = nome
                };

                contexto.Set<Categoria>().Add(categoria);
                await contexto.SaveChangesAsync();
            }
            
        }

        public Categoria GetCategoria(string nome)
        {
            var categoria = contexto.Set<Categoria>()
                .Where(c => c.Nome == nome)
                .SingleOrDefault();

            if (categoria == null)
            {
                throw new ArgumentException("Categoria inválida");
            }

            return categoria;
        }
    }
}
