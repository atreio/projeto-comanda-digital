using ComandaDigital.Models.Base;
using System.Collections.Generic;

namespace ComandaDigital.Models
{
    public class Mesa : IEntity
    {
        public Mesa() { }

        public Mesa(string numero, string descricao, int quantidade)
        {
            Numero = numero;
            Descricao = descricao;
            Quantidade = quantidade;
        }

        public string Numero { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public List<Pedido> Pedidos { get; set; }

        public void Editar(string numero, string descricao, int quantidade)
        {
            Numero = numero;
            Descricao = descricao;
            Quantidade = quantidade;
        }
    }
}
