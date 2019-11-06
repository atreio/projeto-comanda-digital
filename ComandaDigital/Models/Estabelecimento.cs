using ComandaDigital.Models.Base;
using System.Collections.Generic;

namespace ComandaDigital.Models
{
    public class Estabelecimento : IEntity
    {
        public Estabelecimento() { }

        public Estabelecimento(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
        public List<Mesa> Mesas { get; set; }
        public List<Produto> Produtos { get; set; }

        public void EditarEstabelecimento(string nome)
        {
            Nome = nome;
        }
    }
}
