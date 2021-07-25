using CasaDoCodigo.Models;
using System.Collections.Generic;

namespace CasaDoCodigo.ViewModels
{
    public class BuscaProdutosViewModel
    {
        public IList<Produto> Produtos { get; set; }
        public string Pesquisa { get; set; }
    }
}
